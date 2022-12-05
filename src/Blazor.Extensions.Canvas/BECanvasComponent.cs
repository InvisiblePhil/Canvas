using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;

namespace Blazor.Extensions
{
    public class BECanvasComponent : ComponentBase
    {
        [Parameter]
        public long Height { get; set; }

        [Parameter]
        public long Width { get; set; }

        [Parameter(CaptureUnmatchedValues = true)]
        public Dictionary<string, object> InputAttributes { get; set; } = new Dictionary<string, object>();

        [Parameter]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        protected ElementReference canvasRef;

        public ElementReference CanvasReference => this.canvasRef;

        [Inject]
        internal IJSRuntime JsRuntime { get; set; }
    }
}
