using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Blazor.Extensions
{
    public abstract class RenderingContext : IDisposable
    {
        private const string NamespacePrefix = "BlazorExtensions";
        private const string GetPropertyAction = "getProperty";
        private const string CallMethodAction = "call";
        private const string CallBatchAction = "callBatch";
        private const string AddAction = "add";
        private const string RemoveAction = "remove";
        private readonly List<object[]> batchedCallObjects = new List<object[]>();
        private readonly string contextName;
        private readonly IJSRuntime jsRuntime;
        private readonly object parameters;
        private readonly SemaphoreSlim semaphoreSlim = new SemaphoreSlim(1, 1);

        private bool awaitingBatchedCall;
        private bool batching;
        private bool initialized;

        public ElementReference Canvas { get; }

        internal RenderingContext(BECanvasComponent reference, string contextName, object parameters = null)
        {
            this.Canvas = reference.CanvasReference;
            this.contextName = contextName;
            this.jsRuntime = reference.JsRuntime;
            this.parameters = parameters;
        }

        protected virtual Task ExtendedInitializeAsync() => Task.CompletedTask;

        internal async Task<RenderingContext> InitializeAsync()
        {
            await this.semaphoreSlim.WaitAsync();
            if (!this.initialized)
            {
                await this.jsRuntime.InvokeAsync<object>($"{NamespacePrefix}.{this.contextName}.{AddAction}", this.Canvas, this.parameters);
                await this.ExtendedInitializeAsync();
                this.initialized = true;
            }
            this.semaphoreSlim.Release();
            return this;
        }

        #region Protected Methods

        public async Task BeginBatchAsync()
        {
            await this.semaphoreSlim.WaitAsync();
            this.batching = true;
            this.semaphoreSlim.Release();
        }

        public async Task EndBatchAsync()
        {
            await this.semaphoreSlim.WaitAsync();

            await this.BatchCallInnerAsync();
        }

        protected async Task BatchCallAsync(string name, bool isMethodCall, params object[] value)
        {
            await this.semaphoreSlim.WaitAsync();

            var callObject = new object[value.Length + 2];
            callObject[0] = name;
            callObject[1] = isMethodCall;
            Array.Copy(value, 0, callObject, 2, value.Length);
            this.batchedCallObjects.Add(callObject);

            if (this.batching || this.awaitingBatchedCall)
            {
                this.semaphoreSlim.Release();
            }
            else
            {
                await this.BatchCallInnerAsync();
            }
        }

        protected async Task<T> GetPropertyAsync<T>(string property)
        {
            return await this.jsRuntime.InvokeAsync<T>($"{NamespacePrefix}.{this.contextName}.{GetPropertyAction}", this.Canvas, property);
        }

        protected T CallMethod<T>(string method)
        {
            return this.CallMethodAsync<T>(method).GetAwaiter().GetResult();
        }

        protected async Task<T> CallMethodAsync<T>(string method)
        {
            return await this.jsRuntime.InvokeAsync<T>($"{NamespacePrefix}.{this.contextName}.{CallMethodAction}", this.Canvas, method);
        }

        protected T CallMethod<T>(string method, params object[] value)
        {
            return this.CallMethodAsync<T>(method, value).GetAwaiter().GetResult();
        }

        protected async Task<T> CallMethodAsync<T>(string method, params object[] value)
        {
            return await this.jsRuntime.InvokeAsync<T>($"{NamespacePrefix}.{this.contextName}.{CallMethodAction}", this.Canvas, method, value);
        }

        private async Task BatchCallInnerAsync()
        {
            this.awaitingBatchedCall = true;
            var currentBatch = this.batchedCallObjects.ToArray();
            this.batchedCallObjects.Clear();
            this.semaphoreSlim.Release();

            _ = await this.jsRuntime.InvokeAsync<object>($"{NamespacePrefix}.{this.contextName}.{CallBatchAction}", this.Canvas, currentBatch);

            await this.semaphoreSlim.WaitAsync();
            this.awaitingBatchedCall = false;
            this.batching = false;
            this.semaphoreSlim.Release();
        }

        public void Dispose()
        {
            Task.Run(async () => await this.jsRuntime.InvokeAsync<object>($"{NamespacePrefix}.{this.contextName}.{RemoveAction}", this.Canvas));
        }

        #endregion
    }
}
