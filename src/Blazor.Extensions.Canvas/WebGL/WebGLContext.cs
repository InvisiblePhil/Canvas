using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Blazor.Extensions.WebGL
{
    public class WebGlContext : RenderingContext
    {
        private class Constants
        {
            public const string ContextName = "WebGL";
            public const string ClearColor = "clearColor";
            public const string Clear = "clear";
            public const string DrawingBufferWidth = "drawingBufferWidth";
            public const string DrawingBufferHeight = "drawingBufferHeight";
            public const string GetContextAttributes = "getContextAttributes";
            public const string IsContextLost = "isContextLost";
            public const string Scissor = "scissor";
            public const string Viewport = "viewport";
            public const string ActiveTexture = "activeTexture";
            public const string BlendColor = "blendColor";
            public const string BlendEquation = "blendEquation";
            public const string BlendEquationSeparate = "blendEquationSeparate";
            public const string BlendFunc = "blendFunc";
            public const string BlendFuncSeparate = "blendFuncSeparate";
            public const string ClearDepth = "clearDepth";
            public const string ClearStencil = "clearStencil";
            public const string ColorMask = "colorMask";
            public const string CullFace = "cullFace";
            public const string DepthFunc = "depthFunc";
            public const string DepthMask = "depthMask";
            public const string DepthRange = "depthRange";
            public const string Disable = "disable";
            public const string Enable = "enable";
            public const string FrontFace = "frontFace";
            public const string GetParameter = "getParameter";
            public const string GetError = "getError";
            public const string Hint = "hint";
            public const string IsEnabled = "isEnabled";
            public const string LineWidth = "lineWidth";
            public const string PixelStoreI = "pixelStorei";
            public const string PolygonOffset = "polygonOffset";
            public const string SampleCoverage = "sampleCoverage";
            public const string StencilFunc = "stencilFunc";
            public const string StencilFuncSeparate = "stencilFuncSeparate";
            public const string StencilMask = "stencilMask";
            public const string StencilMaskSeparate = "stencilMaskSeparate";
            public const string StencilOp = "stencilOp";
            public const string StencilOpSeparate = "stencilOpSeparate";
            public const string BindBuffer = "bindBuffer";
            public const string BufferData = "bufferData";
            public const string BufferSubData = "bufferSubData";
            public const string CreateBuffer = "createBuffer";
            public const string DeleteBuffer = "deleteBuffer";
            public const string GetBufferParameter = "getBufferParameter";
            public const string IsBuffer = "isBuffer";
            public const string BindFramebuffer = "bindFramebuffer";
            public const string CheckFramebufferStatus = "checkFramebufferStatus";
            public const string CreateFramebuffer = "createFramebuffer";
            public const string DeleteFramebuffer = "deleteFramebuffer";
            public const string FramebufferRenderbuffer = "framebufferRenderbuffer";
            public const string FramebufferTexture2D = "framebufferTexture2D";
            public const string GetFramebufferAttachmentParameter = "getFramebufferAttachmentParameter";
            public const string IsFramebuffer = "isFramebuffer";
            public const string ReadPixels = "readPixels";
            public const string BindRenderbuffer = "bindRenderbuffer";
            public const string CreateRenderbuffer = "createRenderbuffer";
            public const string DeleteRenderbuffer = "deleteRenderbuffer";
            public const string GetRenderbufferParameter = "getRenderbufferParameter";
            public const string IsRenderbuffer = "isRenderbuffer";
            public const string RenderbufferStorage = "renderbufferStorage";
            public const string BindTexture = "bindTexture";
            public const string CopyTexImage2D = "copyTexImage2D";
            public const string CopyTexSubImage2D = "copyTexSubImage2D";
            public const string CreateTexture = "createTexture";
            public const string DeleteTexture = "deleteTexture";
            public const string GenerateMipmap = "generateMipmap";
            public const string GetTexParameter = "getTexParameter";
            public const string IsTexture = "isTexture";
            public const string TexImage2D = "texImage2D";
            public const string TexSubImage2D = "texSubImage2D";
            public const string TexParameterF = "texParameterf";
            public const string TexParameterI = "texParameteri";
            public const string AttachShader = "attachShader";
            public const string BindAttribLocation = "bindAttribLocation";
            public const string CompileShader = "compileShader";
            public const string CreateProgram = "createProgram";
            public const string CreateShader = "createShader";
            public const string DeleteProgram = "deleteProgram";
            public const string DeleteShader = "deleteShader";
            public const string DetachShader = "detachShader";
            public const string GetAttachedShaders = "getAttachedShaders";
            public const string GetProgramParameter = "getProgramParameter";
            public const string GetProgramInfoLog = "getProgramInfoLog";
            public const string GetShaderParameter = "getShaderParameter";
            public const string GetShaderPrecisionFormat = "getShaderPrecisionFormat";
            public const string GetShaderInfoLog = "getShaderInfoLog";
            public const string GetShaderSource = "getShaderSource";
            public const string IsProgram = "isProgram";
            public const string IsShader = "isShader";
            public const string LinkProgram = "linkProgram";
            public const string ShaderSource = "shaderSource";
            public const string UseProgram = "useProgram";
            public const string ValidateProgram = "validateProgram";
            public const string DisableVertexAttribArray = "disableVertexAttribArray";
            public const string EnableVertexAttribArray = "enableVertexAttribArray";
            public const string GetActiveAttrib = "getActiveAttrib";
            public const string GetActiveUniform = "getActiveUniform";
            public const string GetAttribLocation = "getAttribLocation";
            public const string GetUniform = "getUniform";
            public const string GetUniformLocation = "getUniformLocation";
            public const string GetVertexAttrib = "getVertexAttrib";
            public const string GetVertexAttribOffset = "getVertexAttribOffset";
            public const string Uniform = "uniform";
            public const string UniformMatrix = "uniformMatrix";
            public const string VertexAttrib = "vertexAttrib";
            public const string VertexAttribPointer = "vertexAttribPointer";
            public const string DrawArrays = "drawArrays";
            public const string DrawElements = "drawElements";
            public const string Finish = "finish";
            public const string Flush = "flush";
        }

        #region Properties
        public int DrawingBufferWidth { get; private set; }
        public int DrawingBufferHeight { get; private set; }
        #endregion

        public WebGlContext(BECanvasComponent reference, WebGlContextAttributes attributes = null) : base(reference, Constants.ContextName, attributes)
        {
        }

        protected override async Task ExtendedInitializeAsync()
        {
            this.DrawingBufferWidth = await this.GetDrawingBufferWidthAsync();
            this.DrawingBufferHeight = await this.GetDrawingBufferHeightAsync();
        }

        #region Methods
        [Obsolete("Use the async version instead, which is already called internally.")]
        public void ClearColor(float red, float green, float blue, float alpha) => this.CallMethod<object>(Constants.ClearColor, red, green, blue, alpha);
        public async Task ClearColorAsync(float red, float green, float blue, float alpha) => await this.BatchCallAsync(Constants.ClearColor, isMethodCall: true, red, green, blue, alpha);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public void Clear(BufferBits mask) => this.CallMethod<object>(Constants.Clear, mask);
        public async Task ClearAsync(BufferBits mask) => await this.BatchCallAsync(Constants.Clear, isMethodCall: true, mask);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public WebGlContextAttributes GetContextAttributes() => this.CallMethod<WebGlContextAttributes>(Constants.GetContextAttributes);
        public async Task<WebGlContextAttributes> GetContextAttributesAsync() => await this.CallMethodAsync<WebGlContextAttributes>(Constants.GetContextAttributes);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public bool IsContextLost() => this.CallMethod<bool>(Constants.IsContextLost);
        public async Task<bool> IsContextLostAsync() => await this.CallMethodAsync<bool>(Constants.IsContextLost);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public void Scissor(int x, int y, int width, int height) => this.CallMethod<object>(Constants.Scissor, x, y, width, height);
        public async Task ScissorAsync(int x, int y, int width, int height) => await this.BatchCallAsync(Constants.Scissor, isMethodCall: true, x, y, width, height);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public void Viewport(int x, int y, int width, int height) => this.CallMethod<object>(Constants.Viewport, x, y, width, height);
        public async Task ViewportAsync(int x, int y, int width, int height) => await this.BatchCallAsync(Constants.Viewport, isMethodCall: true, x, y, width, height);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public void ActiveTexture(Texture texture) => this.CallMethod<object>(Constants.ActiveTexture, texture);
        public async Task ActiveTextureAsync(Texture texture) => await this.BatchCallAsync(Constants.ActiveTexture, isMethodCall: true, texture);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public void BlendColor(float red, float green, float blue, float alpha) => this.CallMethod<object>(Constants.BlendColor, red, green, blue, alpha);
        public async Task BlendColorAsync(float red, float green, float blue, float alpha) => await this.BatchCallAsync(Constants.BlendColor, isMethodCall: true, red, green, blue, alpha);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public void BlendEquation(BlendingEquation equation) => this.CallMethod<object>(Constants.BlendEquation, equation);
        public async Task BlendEquationAsync(BlendingEquation equation) => await this.BatchCallAsync(Constants.BlendEquation, isMethodCall: true, equation);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public void BlendEquationSeparate(BlendingEquation modeRgb, BlendingEquation modeAlpha) => this.CallMethod<object>(Constants.BlendEquationSeparate, modeRgb, modeAlpha);
        public async Task BlendEquationSeparateAsync(BlendingEquation modeRgb, BlendingEquation modeAlpha) => await this.BatchCallAsync(Constants.BlendEquationSeparate, isMethodCall: true, modeRgb, modeAlpha);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public void BlendFunc(BlendingMode sfactor, BlendingMode dfactor) => this.CallMethod<object>(Constants.BlendFunc, sfactor, dfactor);
        public async Task BlendFuncAsync(BlendingMode sfactor, BlendingMode dfactor) => await this.BatchCallAsync(Constants.BlendFunc, isMethodCall: true, sfactor, dfactor);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public void BlendFuncSeparate(BlendingMode srcRgb, BlendingMode dstRgb, BlendingMode srcAlpha, BlendingMode dstAlpha) => this.CallMethod<object>(Constants.BlendFuncSeparate, srcRgb, dstRgb, srcAlpha, dstAlpha);
        public async Task BlendFuncSeparateAsync(BlendingMode srcRgb, BlendingMode dstRgb, BlendingMode srcAlpha, BlendingMode dstAlpha) => await this.BatchCallAsync(Constants.BlendFuncSeparate, isMethodCall: true, srcRgb, dstRgb, srcAlpha, dstAlpha);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public void ClearDepth(float depth) => this.CallMethod<object>(Constants.ClearDepth, depth);
        public async Task ClearDepthAsync(float depth) => await this.BatchCallAsync(Constants.ClearDepth, isMethodCall: true, depth);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public void ClearStencil(int stencil) => this.CallMethod<object>(Constants.ClearStencil, stencil);
        public async Task ClearStencilAsync(int stencil) => await this.BatchCallAsync(Constants.ClearStencil, isMethodCall: true, stencil);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public void ColorMask(bool red, bool green, bool blue, bool alpha) => this.CallMethod<object>(Constants.ColorMask, red, green, blue, alpha);
        public async Task ColorMaskAsync(bool red, bool green, bool blue, bool alpha) => await this.BatchCallAsync(Constants.ColorMask, isMethodCall: true, red, green, blue, alpha);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public void CullFace(Face mode) => this.CallMethod<object>(Constants.CullFace, mode);
        public async Task CullFaceAsync(Face mode) => await this.BatchCallAsync(Constants.CullFace, isMethodCall: true, mode);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public void DepthFunc(CompareFunction func) => this.CallMethod<object>(Constants.DepthFunc, func);
        public async Task DepthFuncAsync(CompareFunction func) => await this.BatchCallAsync(Constants.DepthFunc, isMethodCall: true, func);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public void DepthMask(bool flag) => this.CallMethod<object>(Constants.DepthMask, flag);
        public async Task DepthMaskAsync(bool flag) => await this.BatchCallAsync(Constants.DepthMask, isMethodCall: true, flag);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public void DepthRange(float zNear, float zFar) => this.CallMethod<object>(Constants.DepthRange, zNear, zFar);
        public async Task DepthRangeAsync(float zNear, float zFar) => await this.BatchCallAsync(Constants.DepthRange, isMethodCall: true, zNear, zFar);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public void Disable(EnableCap cap) => this.CallMethod<object>(Constants.Disable, cap);
        public async Task DisableAsync(EnableCap cap) => await this.BatchCallAsync(Constants.Disable, isMethodCall: true, cap);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public void Enable(EnableCap cap) => this.CallMethod<object>(Constants.Enable, cap);
        public async Task EnableAsync(EnableCap cap) => await this.BatchCallAsync(Constants.Enable, isMethodCall: true, cap);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public void FrontFace(FrontFaceDirection mode) => this.CallMethod<object>(Constants.FrontFace, mode);
        public async Task FrontFaceAsync(FrontFaceDirection mode) => await this.BatchCallAsync(Constants.FrontFace, isMethodCall: true, mode);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public T GetParameter<T>(Parameter parameter) => this.CallMethod<T>(Constants.GetParameter, parameter);
        public async Task<T> GetParameterAsync<T>(Parameter parameter) => await this.CallMethodAsync<T>(Constants.GetParameter, parameter);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public Error GetError() => this.CallMethod<Error>(Constants.GetError);
        public async Task<Error> GetErrorAsync() => await this.CallMethodAsync<Error>(Constants.GetError);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public void Hint(HintTarget target, HintMode mode) => this.CallMethod<object>(Constants.Hint, target, mode);
        public async Task HintAsync(HintTarget target, HintMode mode) => await this.BatchCallAsync(Constants.Hint, isMethodCall: true, target, mode);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public bool IsEnabled(EnableCap cap) => this.CallMethod<bool>(Constants.IsEnabled, cap);
        public async Task<bool> IsEnabledAsync(EnableCap cap) => await this.CallMethodAsync<bool>(Constants.IsEnabled, cap);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public void LineWidth(float width) => this.CallMethod<object>(Constants.LineWidth, width);
        public async Task LineWidthAsync(float width) => await this.CallMethodAsync<object>(Constants.LineWidth, width);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public bool PixelStoreI(PixelStorageMode pname, int param) => this.CallMethod<bool>(Constants.PixelStoreI, pname, param);
        public async Task<bool> PixelStoreIAsync(PixelStorageMode pname, int param) => await this.CallMethodAsync<bool>(Constants.PixelStoreI, pname, param);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public void PolygonOffset(float factor, float units) => this.CallMethod<object>(Constants.PolygonOffset, factor, units);
        public async Task PolygonOffsetAsync(float factor, float units) => await this.BatchCallAsync(Constants.PolygonOffset, isMethodCall: true, factor, units);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public void SampleCoverage(float value, bool invert) => this.CallMethod<object>(Constants.SampleCoverage, value, invert);
        public async Task SampleCoverageAsync(float value, bool invert) => await this.BatchCallAsync(Constants.SampleCoverage, isMethodCall: true, value, invert);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public void StencilFunc(CompareFunction func, int reference, uint mask) => this.CallMethod<object>(Constants.StencilFunc, func, reference, mask);
        public async Task StencilFuncAsync(CompareFunction func, int reference, uint mask) => await this.BatchCallAsync(Constants.StencilFunc, isMethodCall: true, func, reference, mask);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public void StencilFuncSeparate(Face face, CompareFunction func, int reference, uint mask) => this.CallMethod<object>(Constants.StencilFuncSeparate, face, func, reference, mask);
        public async Task StencilFuncSeparateAsync(Face face, CompareFunction func, int reference, uint mask) => await this.BatchCallAsync(Constants.StencilFuncSeparate, isMethodCall: true, face, func, reference, mask);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public void StencilMask(uint mask) => this.CallMethod<object>(Constants.StencilMask, mask);
        public async Task StencilMaskAsync(uint mask) => await this.BatchCallAsync(Constants.StencilMask, isMethodCall: true, mask);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public void StencilMaskSeparate(Face face, uint mask) => this.CallMethod<object>(Constants.StencilMaskSeparate, face, mask);
        public async Task StencilMaskSeparateAsync(Face face, uint mask) => await this.BatchCallAsync(Constants.StencilMaskSeparate, isMethodCall: true, face, mask);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public void StencilOp(StencilFunction fail, StencilFunction zfail, StencilFunction zpass) => this.CallMethod<object>(Constants.StencilOp, fail, zfail, zpass);
        public async Task StencilOpAsync(StencilFunction fail, StencilFunction zfail, StencilFunction zpass) => await this.BatchCallAsync(Constants.StencilOp, isMethodCall: true, fail, zfail, zpass);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public void StencilOpSeparate(Face face, StencilFunction fail, StencilFunction zfail, StencilFunction zpass) => this.CallMethod<object>(Constants.StencilOpSeparate, face, fail, zfail, zpass);
        public async Task StencilOpSeparateAsync(Face face, StencilFunction fail, StencilFunction zfail, StencilFunction zpass) => await this.BatchCallAsync(Constants.StencilOpSeparate, isMethodCall: true, face, fail, zfail, zpass);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public void BindBuffer(BufferType target, WebGlBuffer buffer) => this.CallMethod<object>(Constants.BindBuffer, target, buffer);
        public async Task BindBufferAsync(BufferType target, WebGlBuffer buffer) => await this.BatchCallAsync(Constants.BindBuffer, isMethodCall: true, target, buffer);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public void BufferData(BufferType target, int size, BufferUsageHint usage) => this.CallMethod<object>(Constants.BufferData, target, size, usage);
        public async Task BufferDataAsync(BufferType target, int size, BufferUsageHint usage) => await this.BatchCallAsync(Constants.BufferData, isMethodCall: true, target, size, usage);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public void BufferData<T>(BufferType target, T[] data, BufferUsageHint usage) => this.CallMethod<object>(Constants.BufferData, target, this.ConvertToByteArray(data), usage);
        public async Task BufferDataAsync<T>(BufferType target, T[] data, BufferUsageHint usage) => await this.BatchCallAsync(Constants.BufferData, isMethodCall: true, target, this.ConvertToByteArray(data), usage);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public void BufferSubData<T>(BufferType target, uint offset, T[] data) => this.CallMethod<object>(Constants.BufferSubData, target, offset, this.ConvertToByteArray(data));
        public async Task BufferSubDataAsync<T>(BufferType target, uint offset, T[] data) => await this.BatchCallAsync(Constants.BufferSubData, isMethodCall: true, target, offset, this.ConvertToByteArray(data));

        [Obsolete("Use the async version instead, which is already called internally.")]
        public WebGlBuffer CreateBuffer() => this.CallMethod<WebGlBuffer>(Constants.CreateBuffer);
        public async Task<WebGlBuffer> CreateBufferAsync() => await this.CallMethodAsync<WebGlBuffer>(Constants.CreateBuffer);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public void DeleteBuffer(WebGlBuffer buffer) => this.CallMethod<WebGlBuffer>(Constants.DeleteBuffer, buffer);
        public async Task DeleteBufferAsync(WebGlBuffer buffer) => await this.BatchCallAsync(Constants.DeleteBuffer, isMethodCall: true, buffer);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public T GetBufferParameter<T>(BufferType target, BufferParameter pname) => this.CallMethod<T>(Constants.GetBufferParameter, target, pname);
        public async Task<T> GetBufferParameterAsync<T>(BufferType target, BufferParameter pname) => await this.CallMethodAsync<T>(Constants.GetBufferParameter, target, pname);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public bool IsBuffer(WebGlBuffer buffer) => this.CallMethod<bool>(Constants.IsBuffer, buffer);
        public async Task<bool> IsBufferAsync(WebGlBuffer buffer) => await this.CallMethodAsync<bool>(Constants.IsBuffer, buffer);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public void BindFramebuffer(FramebufferType target, WebGlFramebuffer framebuffer) => this.CallMethod<object>(Constants.BindFramebuffer, target, framebuffer);
        public async Task BindFramebufferAsync(FramebufferType target, WebGlFramebuffer framebuffer) => await this.BatchCallAsync(Constants.BindFramebuffer, isMethodCall: true, target, framebuffer);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public FramebufferStatus CheckFramebufferStatus(FramebufferType target) => this.CallMethod<FramebufferStatus>(Constants.CheckFramebufferStatus, target);
        public async Task<FramebufferStatus> CheckFramebufferStatusAsync(FramebufferType target) => await this.CallMethodAsync<FramebufferStatus>(Constants.CheckFramebufferStatus, target);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public WebGlFramebuffer CreateFramebuffer() => this.CallMethod<WebGlFramebuffer>(Constants.CreateFramebuffer);
        public async Task<WebGlFramebuffer> CreateFramebufferAsync() => await this.CallMethodAsync<WebGlFramebuffer>(Constants.CreateFramebuffer);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public void DeleteFramebuffer(WebGlFramebuffer buffer) => this.CallMethod<object>(Constants.DeleteFramebuffer, buffer);
        public async Task DeleteFramebufferAsync(WebGlFramebuffer buffer) => await this.BatchCallAsync(Constants.DeleteFramebuffer, isMethodCall: true, buffer);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public void FramebufferRenderbuffer(FramebufferType target, FramebufferAttachment attachment, RenderbufferType renderbuffertarget, WebGlRenderbuffer renderbuffer) => this.CallMethod<object>(Constants.FramebufferRenderbuffer, target, attachment, renderbuffertarget, renderbuffer);
        public async Task FramebufferRenderbufferAsync(FramebufferType target, FramebufferAttachment attachment, RenderbufferType renderbuffertarget, WebGlRenderbuffer renderbuffer) => await this.BatchCallAsync(Constants.FramebufferRenderbuffer, isMethodCall: true, target, attachment, renderbuffertarget, renderbuffer);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public void FramebufferTexture2D(FramebufferType target, FramebufferAttachment attachment, Texture2DType textarget, WebGlTexture texture, int level) => this.CallMethod<object>(Constants.FramebufferTexture2D, target, attachment, textarget, texture, level);
        public async Task FramebufferTexture2DAsync(FramebufferType target, FramebufferAttachment attachment, Texture2DType textarget, WebGlTexture texture, int level) => await this.BatchCallAsync(Constants.FramebufferTexture2D, isMethodCall: true, target, attachment, textarget, texture, level);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public T GetFramebufferAttachmentParameter<T>(FramebufferType target, FramebufferAttachment attachment, FramebufferAttachmentParameter pname) => this.CallMethod<T>(Constants.GetFramebufferAttachmentParameter, target, attachment, pname);
        public async Task<T> GetFramebufferAttachmentParameterAsync<T>(FramebufferType target, FramebufferAttachment attachment, FramebufferAttachmentParameter pname) => await this.CallMethodAsync<T>(Constants.GetFramebufferAttachmentParameter, target, attachment, pname);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public bool IsFramebuffer(WebGlFramebuffer framebuffer) => this.CallMethod<bool>(Constants.IsFramebuffer, framebuffer);
        public async Task<bool> IsFramebufferAsync(WebGlFramebuffer framebuffer) => await this.CallMethodAsync<bool>(Constants.IsFramebuffer, framebuffer);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public void ReadPixels(int x, int y, int width, int height, PixelFormat format, PixelType type, byte[] pixels) => this.CallMethod<object>(Constants.ReadPixels, x, y, width, height, format, type, pixels); //pixels should be an ArrayBufferView which the data gets read into
        public async Task ReadPixelsAsync(int x, int y, int width, int height, PixelFormat format, PixelType type, byte[] pixels) => await this.BatchCallAsync(Constants.ReadPixels, isMethodCall: true, x, y, width, height, format, type, pixels); //pixels should be an ArrayBufferView which the data gets read into

        [Obsolete("Use the async version instead, which is already called internally.")]
        public void BindRenderbuffer(RenderbufferType target, WebGlRenderbuffer renderbuffer) => this.CallMethod<object>(Constants.BindRenderbuffer, target, renderbuffer);
        public async Task BindRenderbufferAsync(RenderbufferType target, WebGlRenderbuffer renderbuffer) => await this.BatchCallAsync(Constants.BindRenderbuffer, isMethodCall: true, target, renderbuffer);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public WebGlRenderbuffer CreateRenderbuffer() => this.CallMethod<WebGlRenderbuffer>(Constants.CreateRenderbuffer);
        public async Task<WebGlRenderbuffer> CreateRenderbufferAsync() => await this.CallMethodAsync<WebGlRenderbuffer>(Constants.CreateRenderbuffer);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public void DeleteRenderbuffer(WebGlRenderbuffer buffer) => this.CallMethod<object>(Constants.DeleteRenderbuffer, buffer);
        public async Task DeleteRenderbufferAsync(WebGlRenderbuffer buffer) => await this.BatchCallAsync(Constants.DeleteRenderbuffer, isMethodCall: true, buffer);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public T GetRenderbufferParameter<T>(RenderbufferType target, RenderbufferParameter pname) => this.CallMethod<T>(Constants.GetRenderbufferParameter, target, pname);
        public async Task<T> GetRenderbufferParameterAsync<T>(RenderbufferType target, RenderbufferParameter pname) => await this.CallMethodAsync<T>(Constants.GetRenderbufferParameter, target, pname);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public bool IsRenderbuffer(WebGlRenderbuffer renderbuffer) => this.CallMethod<bool>(Constants.IsRenderbuffer, renderbuffer);
        public async Task<bool> IsRenderbufferAsync(WebGlRenderbuffer renderbuffer) => await this.CallMethodAsync<bool>(Constants.IsRenderbuffer, renderbuffer);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public void RenderbufferStorage(RenderbufferType type, RenderbufferFormat internalFormat, int width, int height) => this.CallMethod<object>(Constants.RenderbufferStorage, type, internalFormat, width, height);
        public async Task RenderbufferStorageAsync(RenderbufferType type, RenderbufferFormat internalFormat, int width, int height) => await this.BatchCallAsync(Constants.RenderbufferStorage, isMethodCall: true, type, internalFormat, width, height);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public void BindTexture(TextureType type, WebGlTexture texture) => this.CallMethod<object>(Constants.BindTexture, type, texture);
        public async Task BindTextureAsync(TextureType type, WebGlTexture texture) => await this.BatchCallAsync(Constants.BindTexture, isMethodCall: true, type, texture);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public void CopyTexImage2D(Texture2DType target, int level, PixelFormat format, int x, int y, int width, int height, int border) => this.CallMethod<object>(Constants.CopyTexImage2D, target, level, format, x, y, width, height, border);
        public async Task CopyTexImage2DAsync(Texture2DType target, int level, PixelFormat format, int x, int y, int width, int height, int border) => await this.BatchCallAsync(Constants.CopyTexImage2D, isMethodCall: true, target, level, format, x, y, width, height, border);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public void CopyTexSubImage2D(Texture2DType target, int level, int xoffset, int yoffset, int x, int y, int width, int height) => this.CallMethod<object>(Constants.CopyTexSubImage2D, target, level, xoffset, yoffset, x, y, width, height);
        public async Task CopyTexSubImage2DAsync(Texture2DType target, int level, int xoffset, int yoffset, int x, int y, int width, int height) => await this.BatchCallAsync(Constants.CopyTexSubImage2D, isMethodCall: true, target, level, xoffset, yoffset, x, y, width, height);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public WebGlTexture CreateTexture() => this.CallMethod<WebGlTexture>(Constants.CreateTexture);
        public async Task<WebGlTexture> CreateTextureAsync() => await this.CallMethodAsync<WebGlTexture>(Constants.CreateTexture);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public void DeleteTexture(WebGlTexture texture) => this.CallMethod<object>(Constants.DeleteTexture, texture);
        public async Task DeleteTextureAsync(WebGlTexture texture) => await this.BatchCallAsync(Constants.DeleteTexture, isMethodCall: true, texture);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public void GenerateMipmap(TextureType target) => this.CallMethod<object>(Constants.GenerateMipmap, target);
        public async Task GenerateMipmapAsync(TextureType target) => await this.BatchCallAsync(Constants.GenerateMipmap, isMethodCall: true, target);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public T GetTexParameter<T>(TextureType target, TextureParameter pname) => this.CallMethod<T>(Constants.GetTexParameter, target, pname);
        public async Task<T> GetTexParameterAsync<T>(TextureType target, TextureParameter pname) => await this.CallMethodAsync<T>(Constants.GetTexParameter, target, pname);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public bool IsTexture(WebGlTexture texture) => this.CallMethod<bool>(Constants.IsTexture, texture);
        public async Task<bool> IsTextureAsync(WebGlTexture texture) => await this.CallMethodAsync<bool>(Constants.IsTexture, texture);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public void TexImage2D<T>(Texture2DType target, int level, PixelFormat internalFormat, int width, int height, PixelFormat format, PixelType type, T[] pixels)
            where T : struct
            => this.CallMethod<object>(Constants.TexImage2D, target, level, internalFormat, width, height, format, type, pixels);
        public async Task TexImage2DAsync<T>(Texture2DType target, int level, PixelFormat internalFormat, int width, int height, PixelFormat format, PixelType type, T[] pixels)
            where T : struct
            => await this.BatchCallAsync(Constants.TexImage2D, isMethodCall: true, target, level, internalFormat, width, height, format, type, pixels);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public void TexSubImage2D<T>(Texture2DType target, int level, int xoffset, int yoffset, int width, int height, PixelFormat format, PixelType type, T[] pixels)
            where T : struct
            => this.CallMethod<object>(Constants.TexSubImage2D, target, level, xoffset, yoffset, width, height, format, type, pixels);
        public async Task TexSubImage2DAsync<T>(Texture2DType target, int level, int xoffset, int yoffset, int width, int height, PixelFormat format, PixelType type, T[] pixels)
            where T : struct
            => await this.BatchCallAsync(Constants.TexSubImage2D, isMethodCall: true, target, level, xoffset, yoffset, width, height, format, type, pixels);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public void TexParameter(TextureType target, TextureParameter pname, float param) => this.CallMethod<object>(Constants.TexParameterF, target, pname, param);
        public async Task TexParameterAsync(TextureType target, TextureParameter pname, float param) => await this.BatchCallAsync(Constants.TexParameterF, isMethodCall: true, target, pname, param);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public void TexParameter(TextureType target, TextureParameter pname, int param) => this.CallMethod<object>(Constants.TexParameterI, target, pname, param);
        public async Task TexParameterAsync(TextureType target, TextureParameter pname, int param) => await this.BatchCallAsync(Constants.TexParameterI, isMethodCall: true, target, pname, param);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public void AttachShader(WebGlProgram program, WebGlShader shader) => this.CallMethod<object>(Constants.AttachShader, program, shader);
        public async Task AttachShaderAsync(WebGlProgram program, WebGlShader shader) => await this.BatchCallAsync(Constants.AttachShader, isMethodCall: true, program, shader);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public void BindAttribLocation(WebGlProgram program, uint index, string name) => this.CallMethod<object>(Constants.BindAttribLocation, program, index, name);
        public async Task BindAttribLocationAsync(WebGlProgram program, uint index, string name) => await this.BatchCallAsync(Constants.BindAttribLocation, isMethodCall: true, program, index, name);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public void CompileShader(WebGlShader shader) => this.CallMethod<object>(Constants.CompileShader, shader);
        public async Task CompileShaderAsync(WebGlShader shader) => await this.BatchCallAsync(Constants.CompileShader, isMethodCall: true, shader);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public WebGlProgram CreateProgram() => this.CallMethod<WebGlProgram>(Constants.CreateProgram);
        public async Task<WebGlProgram> CreateProgramAsync() => await this.CallMethodAsync<WebGlProgram>(Constants.CreateProgram);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public WebGlShader CreateShader(ShaderType type) => this.CallMethod<WebGlShader>(Constants.CreateShader, type);
        public async Task<WebGlShader> CreateShaderAsync(ShaderType type) => await this.CallMethodAsync<WebGlShader>(Constants.CreateShader, type);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public void DeleteProgram(WebGlProgram program) => this.CallMethod<object>(Constants.DeleteProgram, program);
        public async Task DeleteProgramAsync(WebGlProgram program) => await this.BatchCallAsync(Constants.DeleteProgram, isMethodCall: true, program);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public void DeleteShader(WebGlShader shader) => this.CallMethod<object>(Constants.DeleteShader, shader);
        public async Task DeleteShaderAsync(WebGlShader shader) => await this.BatchCallAsync(Constants.DeleteShader, isMethodCall: true, shader);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public void DetachShader(WebGlProgram program, WebGlShader shader) => this.CallMethod<object>(Constants.DetachShader, program, shader);
        public async Task DetachShaderAsync(WebGlProgram program, WebGlShader shader) => await this.BatchCallAsync(Constants.DetachShader, isMethodCall: true, program, shader);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public WebGlShader[] GetAttachedShaders(WebGlProgram program) => this.CallMethod<WebGlShader[]>(Constants.GetAttachedShaders, program);
        public async Task<WebGlShader[]> GetAttachedShadersAsync(WebGlProgram program) => await this.CallMethodAsync<WebGlShader[]>(Constants.GetAttachedShaders, program);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public T GetProgramParameter<T>(WebGlProgram program, ProgramParameter pname) => this.CallMethod<T>(Constants.GetProgramParameter, program, pname);
        public async Task<T> GetProgramParameterAsync<T>(WebGlProgram program, ProgramParameter pname) => await this.CallMethodAsync<T>(Constants.GetProgramParameter, program, pname);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public string GetProgramInfoLog(WebGlProgram program) => this.CallMethod<string>(Constants.GetProgramInfoLog, program);
        public async Task<string> GetProgramInfoLogAsync(WebGlProgram program) => await this.CallMethodAsync<string>(Constants.GetProgramInfoLog, program);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public T GetShaderParameter<T>(WebGlShader shader, ShaderParameter pname) => this.CallMethod<T>(Constants.GetShaderParameter, shader, pname);
        public async Task<T> GetShaderParameterAsync<T>(WebGlShader shader, ShaderParameter pname) => await this.CallMethodAsync<T>(Constants.GetShaderParameter, shader, pname);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public WebGlShaderPrecisionFormat GetShaderPrecisionFormat(ShaderType shaderType, ShaderPrecision precisionType) => this.CallMethod<WebGlShaderPrecisionFormat>(Constants.GetShaderPrecisionFormat, shaderType, precisionType);
        public async Task<WebGlShaderPrecisionFormat> GetShaderPrecisionFormatAsync(ShaderType shaderType, ShaderPrecision precisionType) => await this.CallMethodAsync<WebGlShaderPrecisionFormat>(Constants.GetShaderPrecisionFormat, shaderType, precisionType);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public string GetShaderInfoLog(WebGlShader shader) => this.CallMethod<string>(Constants.GetShaderInfoLog, shader);
        public async Task<string> GetShaderInfoLogAsync(WebGlShader shader) => await this.CallMethodAsync<string>(Constants.GetShaderInfoLog, shader);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public string GetShaderSource(WebGlShader shader) => this.CallMethod<string>(Constants.GetShaderSource, shader);
        public async Task<string> GetShaderSourceAsync(WebGlShader shader) => await this.CallMethodAsync<string>(Constants.GetShaderSource, shader);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public bool IsProgram(WebGlProgram program) => this.CallMethod<bool>(Constants.IsProgram, program);
        public async Task<bool> IsProgramAsync(WebGlProgram program) => await this.CallMethodAsync<bool>(Constants.IsProgram, program);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public bool IsShader(WebGlShader shader) => this.CallMethod<bool>(Constants.IsShader, shader);
        public async Task<bool> IsShaderAsync(WebGlShader shader) => await this.CallMethodAsync<bool>(Constants.IsShader, shader);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public void LinkProgram(WebGlProgram program) => this.CallMethod<object>(Constants.LinkProgram, program);
        public async Task LinkProgramAsync(WebGlProgram program) => await this.BatchCallAsync(Constants.LinkProgram, isMethodCall: true, program);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public void ShaderSource(WebGlShader shader, string source) => this.CallMethod<object>(Constants.ShaderSource, shader, source);
        public async Task ShaderSourceAsync(WebGlShader shader, string source) => await this.BatchCallAsync(Constants.ShaderSource, isMethodCall: true, shader, source);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public void UseProgram(WebGlProgram program) => this.CallMethod<object>(Constants.UseProgram, program);
        public async Task UseProgramAsync(WebGlProgram program) => await this.BatchCallAsync(Constants.UseProgram, isMethodCall: true, program);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public void ValidateProgram(WebGlProgram program) => this.CallMethod<object>(Constants.ValidateProgram, program);
        public async Task ValidateProgramAsync(WebGlProgram program) => await this.BatchCallAsync(Constants.ValidateProgram, isMethodCall: true, program);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public void DisableVertexAttribArray(uint index) => this.CallMethod<object>(Constants.DisableVertexAttribArray, index);
        public async Task DisableVertexAttribArrayAsync(uint index) => await this.BatchCallAsync(Constants.DisableVertexAttribArray, isMethodCall: true, index);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public void EnableVertexAttribArray(uint index) => this.CallMethod<object>(Constants.EnableVertexAttribArray, index);
        public async Task EnableVertexAttribArrayAsync(uint index) => await this.BatchCallAsync(Constants.EnableVertexAttribArray, isMethodCall: true, index);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public WebGlActiveInfo GetActiveAttrib(WebGlProgram program, uint index) => this.CallMethod<WebGlActiveInfo>(Constants.GetActiveAttrib, program, index);
        public async Task<WebGlActiveInfo> GetActiveAttribAsync(WebGlProgram program, uint index) => await this.CallMethodAsync<WebGlActiveInfo>(Constants.GetActiveAttrib, program, index);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public WebGlActiveInfo GetActiveUniform(WebGlProgram program, uint index) => this.CallMethod<WebGlActiveInfo>(Constants.GetActiveUniform, program, index);
        public async Task<WebGlActiveInfo> GetActiveUniformAsync(WebGlProgram program, uint index) => await this.CallMethodAsync<WebGlActiveInfo>(Constants.GetActiveUniform, program, index);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public int GetAttribLocation(WebGlProgram program, string name) => this.CallMethod<int>(Constants.GetAttribLocation, program, name);
        public async Task<int> GetAttribLocationAsync(WebGlProgram program, string name) => await this.CallMethodAsync<int>(Constants.GetAttribLocation, program, name);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public T GetUniform<T>(WebGlProgram program, WebGlUniformLocation location) => this.CallMethod<T>(Constants.GetUniform, program, location);
        public async Task<T> GetUniformAsync<T>(WebGlProgram program, WebGlUniformLocation location) => await this.CallMethodAsync<T>(Constants.GetUniform, program, location);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public WebGlUniformLocation GetUniformLocation(WebGlProgram program, string name) => this.CallMethod<WebGlUniformLocation>(Constants.GetUniformLocation, program, name);
        public async Task<WebGlUniformLocation> GetUniformLocationAsync(WebGlProgram program, string name) => await this.CallMethodAsync<WebGlUniformLocation>(Constants.GetUniformLocation, program, name);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public T GetVertexAttrib<T>(uint index, VertexAttribute pname) => this.CallMethod<T>(Constants.GetVertexAttrib, index, pname);
        public async Task<T> GetVertexAttribAsync<T>(uint index, VertexAttribute pname) => await this.CallMethodAsync<T>(Constants.GetVertexAttrib, index, pname);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public long GetVertexAttribOffset(uint index, VertexAttributePointer pname) => this.CallMethod<long>(Constants.GetVertexAttribOffset, index, pname);
        public async Task<long> GetVertexAttribOffsetAsync(uint index, VertexAttributePointer pname) => await this.CallMethodAsync<long>(Constants.GetVertexAttribOffset, index, pname);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public void VertexAttribPointer(uint index, int size, DataType type, bool normalized, int stride, long offset) => this.CallMethod<object>(Constants.VertexAttribPointer, index, size, type, normalized, stride, offset);
        public async Task VertexAttribPointerAsync(uint index, int size, DataType type, bool normalized, int stride, long offset) => await this.BatchCallAsync(Constants.VertexAttribPointer, isMethodCall: true, index, size, type, normalized, stride, offset);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public void Uniform(WebGlUniformLocation location, params float[] value)
        {
            switch (value.Length)
            {
                case 1:
                    this.CallMethod<object>(Constants.Uniform + "1fv", location, value);
                    break;
                case 2:
                    this.CallMethod<object>(Constants.Uniform + "2fv", location, value);
                    break;
                case 3:
                    this.CallMethod<object>(Constants.Uniform + "3fv", location, value);
                    break;
                case 4:
                    this.CallMethod<object>(Constants.Uniform + "4fv", location, value);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(value), value.Length, "Value array is empty or too long");
            }
        }
        public async Task UniformAsync(WebGlUniformLocation location, params float[] value)
        {
            switch (value.Length)
            {
                case 1:
                    await this.BatchCallAsync(Constants.Uniform + "1fv", isMethodCall: true, location, value);
                    break;
                case 2:
                    await this.BatchCallAsync(Constants.Uniform + "2fv", isMethodCall: true, location, value);
                    break;
                case 3:
                    await this.BatchCallAsync(Constants.Uniform + "3fv", isMethodCall: true, location, value);
                    break;
                case 4:
                    await this.BatchCallAsync(Constants.Uniform + "4fv", isMethodCall: true, location, value);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(value), value.Length, "Value array is empty or too long");
            }
        }

        [Obsolete("Use the async version instead, which is already called internally.")]
        public void Uniform(WebGlUniformLocation location, params int[] value)
        {
            switch (value.Length)
            {
                case 1:
                    this.CallMethod<object>(Constants.Uniform + "1iv", location, value);
                    break;
                case 2:
                    this.CallMethod<object>(Constants.Uniform + "2iv", location, value);
                    break;
                case 3:
                    this.CallMethod<object>(Constants.Uniform + "3iv", location, value);
                    break;
                case 4:
                    this.CallMethod<object>(Constants.Uniform + "4iv", location, value);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(value), value.Length, "Value array is empty or too long");
            }
        }
        public async Task UniformAsync(WebGlUniformLocation location, params int[] value)
        {
            switch (value.Length)
            {
                case 1:
                    await this.BatchCallAsync(Constants.Uniform + "1iv", isMethodCall: true, location, value);
                    break;
                case 2:
                    await this.BatchCallAsync(Constants.Uniform + "2iv", isMethodCall: true, location, value);
                    break;
                case 3:
                    await this.BatchCallAsync(Constants.Uniform + "3iv", isMethodCall: true, location, value);
                    break;
                case 4:
                    await this.BatchCallAsync(Constants.Uniform + "4iv", isMethodCall: true, location, value);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(value), value.Length, "Value array is empty or too long");
            }
        }

        [Obsolete("Use the async version instead, which is already called internally.")]
        public void UniformMatrix(WebGlUniformLocation location, bool transpose, float[] value)
        {
            switch (value.Length)
            {
                case 2 * 2:
                    this.CallMethod<object>(Constants.UniformMatrix + "2fv", location, transpose, value);
                    break;
                case 3 * 3:
                    this.CallMethod<object>(Constants.UniformMatrix + "3fv", location, transpose, value);
                    break;
                case 4 * 4:
                    this.CallMethod<object>(Constants.UniformMatrix + "4fv", location, transpose, value);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(value), value.Length, "Value array has incorrect size");
            }
        }
        public async Task UniformMatrixAsync(WebGlUniformLocation location, bool transpose, float[] value)
        {
            switch (value.Length)
            {
                case 2 * 2:
                    await this.BatchCallAsync(Constants.UniformMatrix + "2fv", isMethodCall: true, location, transpose, value);
                    break;
                case 3 * 3:
                    await this.BatchCallAsync(Constants.UniformMatrix + "3fv", isMethodCall: true, location, transpose, value);
                    break;
                case 4 * 4:
                    await this.BatchCallAsync(Constants.UniformMatrix + "4fv", isMethodCall: true, location, transpose, value);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(value), value.Length, "Value array has incorrect size");
            }
        }

        [Obsolete("Use the async version instead, which is already called internally.")]
        public void VertexAttrib(uint index, params float[] value)
        {
            switch (value.Length)
            {
                case 1:
                    this.CallMethod<object>(Constants.VertexAttrib + "1fv", index, value);
                    break;
                case 2:
                    this.CallMethod<object>(Constants.VertexAttrib + "2fv", index, value);
                    break;
                case 3:
                    this.CallMethod<object>(Constants.VertexAttrib + "3fv", index, value);
                    break;
                case 4:
                    this.CallMethod<object>(Constants.VertexAttrib + "4fv", index, value);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(value), value.Length, "Value array is empty or too long");
            }
        }
        public async Task VertexAttribAsync(uint index, params float[] value)
        {
            switch (value.Length)
            {
                case 1:
                    await this.BatchCallAsync(Constants.VertexAttrib + "1fv", isMethodCall: true, index, value);
                    break;
                case 2:
                    await this.BatchCallAsync(Constants.VertexAttrib + "2fv", isMethodCall: true, index, value);
                    break;
                case 3:
                    await this.BatchCallAsync(Constants.VertexAttrib + "3fv", isMethodCall: true, index, value);
                    break;
                case 4:
                    await this.BatchCallAsync(Constants.VertexAttrib + "4fv", isMethodCall: true, index, value);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(value), value.Length, "Value array is empty or too long");
            }
        }

        [Obsolete("Use the async version instead, which is already called internally.")]
        public void DrawArrays(Primitive mode, int first, int count) => this.CallMethod<object>(Constants.DrawArrays, mode, first, count);
        public async Task DrawArraysAsync(Primitive mode, int first, int count) => await this.BatchCallAsync(Constants.DrawArrays, isMethodCall: true, mode, first, count);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public void DrawElements(Primitive mode, int count, DataType type, long offset) => this.CallMethod<object>(Constants.DrawElements, mode, count, type, offset);
        public async Task DrawElementsAsync(Primitive mode, int count, DataType type, long offset) => await this.BatchCallAsync(Constants.DrawElements, isMethodCall: true, mode, count, type, offset);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public void Finish() => this.CallMethod<object>(Constants.Finish);
        public async Task FinishAsync() => await this.BatchCallAsync(Constants.Finish, isMethodCall: true);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public void Flush() => this.CallMethod<object>(Constants.Flush);
        public async Task FlushAsync() => await this.BatchCallAsync(Constants.Flush, isMethodCall: true);

        private byte[] ConvertToByteArray<T>(T[] arr)
        {
            byte[] byteArr = new byte[arr.Length * Marshal.SizeOf<T>()];
            Buffer.BlockCopy(arr, 0, byteArr, 0, byteArr.Length);
            return byteArr;
        }
        private async Task<int> GetDrawingBufferWidthAsync() => await this.GetPropertyAsync<int>(Constants.DrawingBufferWidth);
        private async Task<int> GetDrawingBufferHeightAsync() => await this.GetPropertyAsync<int>(Constants.DrawingBufferHeight);
        #endregion
    }
}