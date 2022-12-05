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

        public int DrawingBufferWidth { get; private set; }
        public int DrawingBufferHeight { get; private set; }

        public WebGlContext(BECanvasComponent reference, WebGlContextAttributes attributes = null) : base(reference, Constants.ContextName, attributes)
        {
        }

        protected override async ValueTask ExtendedInitializeAsync()
        {
            this.DrawingBufferWidth = await this.GetDrawingBufferWidthAsync();
            this.DrawingBufferHeight = await this.GetDrawingBufferHeightAsync();
        }

        #region Methods
        public async ValueTask ClearColorAsync(float red, float green, float blue, float alpha) => await this.BatchCallAsync(Constants.ClearColor, isMethodCall: true, red, green, blue, alpha);

        public async ValueTask ClearAsync(BufferBits mask) => await this.BatchCallAsync(Constants.Clear, isMethodCall: true, mask);

        public async ValueTask<WebGlContextAttributes> GetContextAttributesAsync() => await this.CallMethodAsync<WebGlContextAttributes>(Constants.GetContextAttributes);

        public async ValueTask<bool> IsContextLostAsync() => await this.CallMethodAsync<bool>(Constants.IsContextLost);

        public async ValueTask ScissorAsync(int x, int y, int width, int height) => await this.BatchCallAsync(Constants.Scissor, isMethodCall: true, x, y, width, height);

        public async ValueTask ViewportAsync(int x, int y, int width, int height) => await this.BatchCallAsync(Constants.Viewport, isMethodCall: true, x, y, width, height);

        public async ValueTask ActiveTextureAsync(Texture texture) => await this.BatchCallAsync(Constants.ActiveTexture, isMethodCall: true, texture);

        public async ValueTask BlendColorAsync(float red, float green, float blue, float alpha) => await this.BatchCallAsync(Constants.BlendColor, isMethodCall: true, red, green, blue, alpha);

        public async ValueTask BlendEquationAsync(BlendingEquation equation) => await this.BatchCallAsync(Constants.BlendEquation, isMethodCall: true, equation);

        public async ValueTask BlendEquationSeparateAsync(BlendingEquation modeRgb, BlendingEquation modeAlpha) => await this.BatchCallAsync(Constants.BlendEquationSeparate, isMethodCall: true, modeRgb, modeAlpha);

        public async ValueTask BlendFuncAsync(BlendingMode sfactor, BlendingMode dfactor) => await this.BatchCallAsync(Constants.BlendFunc, isMethodCall: true, sfactor, dfactor);

        public async ValueTask BlendFuncSeparateAsync(BlendingMode srcRgb, BlendingMode dstRgb, BlendingMode srcAlpha, BlendingMode dstAlpha) => await this.BatchCallAsync(Constants.BlendFuncSeparate, isMethodCall: true, srcRgb, dstRgb, srcAlpha, dstAlpha);

        public async ValueTask ClearDepthAsync(float depth) => await this.BatchCallAsync(Constants.ClearDepth, isMethodCall: true, depth);

        public async ValueTask ClearStencilAsync(int stencil) => await this.BatchCallAsync(Constants.ClearStencil, isMethodCall: true, stencil);

        public async ValueTask ColorMaskAsync(bool red, bool green, bool blue, bool alpha) => await this.BatchCallAsync(Constants.ColorMask, isMethodCall: true, red, green, blue, alpha);

        public async ValueTask CullFaceAsync(Face mode) => await this.BatchCallAsync(Constants.CullFace, isMethodCall: true, mode);

        public async ValueTask DepthFuncAsync(CompareFunction func) => await this.BatchCallAsync(Constants.DepthFunc, isMethodCall: true, func);

        public async ValueTask DepthMaskAsync(bool flag) => await this.BatchCallAsync(Constants.DepthMask, isMethodCall: true, flag);

        public async ValueTask DepthRangeAsync(float zNear, float zFar) => await this.BatchCallAsync(Constants.DepthRange, isMethodCall: true, zNear, zFar);

        public async ValueTask DisableAsync(EnableCap cap) => await this.BatchCallAsync(Constants.Disable, isMethodCall: true, cap);

        public async ValueTask EnableAsync(EnableCap cap) => await this.BatchCallAsync(Constants.Enable, isMethodCall: true, cap);

        public async ValueTask FrontFaceAsync(FrontFaceDirection mode) => await this.BatchCallAsync(Constants.FrontFace, isMethodCall: true, mode);

        public async ValueTask<T> GetParameterAsync<T>(Parameter parameter) => await this.CallMethodAsync<T>(Constants.GetParameter, parameter);

        public async ValueTask<Error> GetErrorAsync() => await this.CallMethodAsync<Error>(Constants.GetError);

        public async ValueTask HintAsync(HintTarget target, HintMode mode) => await this.BatchCallAsync(Constants.Hint, isMethodCall: true, target, mode);

        public async ValueTask<bool> IsEnabledAsync(EnableCap cap) => await this.CallMethodAsync<bool>(Constants.IsEnabled, cap);

        public async ValueTask LineWidthAsync(float width) => await this.CallMethodAsync<object>(Constants.LineWidth, width);

        public async ValueTask<bool> PixelStoreIAsync(PixelStorageMode pname, int param) => await this.CallMethodAsync<bool>(Constants.PixelStoreI, pname, param);

        public async ValueTask PolygonOffsetAsync(float factor, float units) => await this.BatchCallAsync(Constants.PolygonOffset, isMethodCall: true, factor, units);

        public async ValueTask SampleCoverageAsync(float value, bool invert) => await this.BatchCallAsync(Constants.SampleCoverage, isMethodCall: true, value, invert);

        public async ValueTask StencilFuncAsync(CompareFunction func, int reference, uint mask) => await this.BatchCallAsync(Constants.StencilFunc, isMethodCall: true, func, reference, mask);

        public async ValueTask StencilFuncSeparateAsync(Face face, CompareFunction func, int reference, uint mask) => await this.BatchCallAsync(Constants.StencilFuncSeparate, isMethodCall: true, face, func, reference, mask);

        public async ValueTask StencilMaskAsync(uint mask) => await this.BatchCallAsync(Constants.StencilMask, isMethodCall: true, mask);

        public async ValueTask StencilMaskSeparateAsync(Face face, uint mask) => await this.BatchCallAsync(Constants.StencilMaskSeparate, isMethodCall: true, face, mask);

        public async ValueTask StencilOpAsync(StencilFunction fail, StencilFunction zfail, StencilFunction zpass) => await this.BatchCallAsync(Constants.StencilOp, isMethodCall: true, fail, zfail, zpass);

        public async ValueTask StencilOpSeparateAsync(Face face, StencilFunction fail, StencilFunction zfail, StencilFunction zpass) => await this.BatchCallAsync(Constants.StencilOpSeparate, isMethodCall: true, face, fail, zfail, zpass);

        public async ValueTask BindBufferAsync(BufferType target, WebGlBuffer buffer) => await this.BatchCallAsync(Constants.BindBuffer, isMethodCall: true, target, buffer);

        public async ValueTask BufferDataAsync(BufferType target, int size, BufferUsageHint usage) => await this.BatchCallAsync(Constants.BufferData, isMethodCall: true, target, size, usage);

        public async ValueTask BufferDataAsync<T>(BufferType target, T[] data, BufferUsageHint usage) => await this.BatchCallAsync(Constants.BufferData, isMethodCall: true, target, this.ConvertToByteArray(data), usage);

        public async ValueTask BufferSubDataAsync<T>(BufferType target, uint offset, T[] data) => await this.BatchCallAsync(Constants.BufferSubData, isMethodCall: true, target, offset, this.ConvertToByteArray(data));

        public async ValueTask<WebGlBuffer> CreateBufferAsync() => await this.CallMethodAsync<WebGlBuffer>(Constants.CreateBuffer);

        public async ValueTask DeleteBufferAsync(WebGlBuffer buffer) => await this.BatchCallAsync(Constants.DeleteBuffer, isMethodCall: true, buffer);

        public async ValueTask<T> GetBufferParameterAsync<T>(BufferType target, BufferParameter pname) => await this.CallMethodAsync<T>(Constants.GetBufferParameter, target, pname);

        public async ValueTask<bool> IsBufferAsync(WebGlBuffer buffer) => await this.CallMethodAsync<bool>(Constants.IsBuffer, buffer);

        public async ValueTask BindFramebufferAsync(FramebufferType target, WebGlFramebuffer framebuffer) => await this.BatchCallAsync(Constants.BindFramebuffer, isMethodCall: true, target, framebuffer);

        public async ValueTask<FramebufferStatus> CheckFramebufferStatusAsync(FramebufferType target) => await this.CallMethodAsync<FramebufferStatus>(Constants.CheckFramebufferStatus, target);

        public async ValueTask<WebGlFramebuffer> CreateFramebufferAsync() => await this.CallMethodAsync<WebGlFramebuffer>(Constants.CreateFramebuffer);

        public async ValueTask DeleteFramebufferAsync(WebGlFramebuffer buffer) => await this.BatchCallAsync(Constants.DeleteFramebuffer, isMethodCall: true, buffer);

        public async ValueTask FramebufferRenderbufferAsync(FramebufferType target, FramebufferAttachment attachment, RenderbufferType renderbuffertarget, WebGlRenderbuffer renderbuffer) => await this.BatchCallAsync(Constants.FramebufferRenderbuffer, isMethodCall: true, target, attachment, renderbuffertarget, renderbuffer);

        public async ValueTask FramebufferTexture2DAsync(FramebufferType target, FramebufferAttachment attachment, Texture2DType textarget, WebGlTexture texture, int level) => await this.BatchCallAsync(Constants.FramebufferTexture2D, isMethodCall: true, target, attachment, textarget, texture, level);

        public async ValueTask<T> GetFramebufferAttachmentParameterAsync<T>(FramebufferType target, FramebufferAttachment attachment, FramebufferAttachmentParameter pname) => await this.CallMethodAsync<T>(Constants.GetFramebufferAttachmentParameter, target, attachment, pname);

        public async ValueTask<bool> IsFramebufferAsync(WebGlFramebuffer framebuffer) => await this.CallMethodAsync<bool>(Constants.IsFramebuffer, framebuffer);

        public async ValueTask ReadPixelsAsync(int x, int y, int width, int height, PixelFormat format, PixelType type, byte[] pixels) => await this.BatchCallAsync(Constants.ReadPixels, isMethodCall: true, x, y, width, height, format, type, pixels); //pixels should be an ArrayBufferView which the data gets read into

        public async ValueTask BindRenderbufferAsync(RenderbufferType target, WebGlRenderbuffer renderbuffer) => await this.BatchCallAsync(Constants.BindRenderbuffer, isMethodCall: true, target, renderbuffer);

        public async ValueTask<WebGlRenderbuffer> CreateRenderbufferAsync() => await this.CallMethodAsync<WebGlRenderbuffer>(Constants.CreateRenderbuffer);

        public async ValueTask DeleteRenderbufferAsync(WebGlRenderbuffer buffer) => await this.BatchCallAsync(Constants.DeleteRenderbuffer, isMethodCall: true, buffer);

        public async ValueTask<T> GetRenderbufferParameterAsync<T>(RenderbufferType target, RenderbufferParameter pname) => await this.CallMethodAsync<T>(Constants.GetRenderbufferParameter, target, pname);

        public async ValueTask<bool> IsRenderbufferAsync(WebGlRenderbuffer renderbuffer) => await this.CallMethodAsync<bool>(Constants.IsRenderbuffer, renderbuffer);

        public async ValueTask RenderbufferStorageAsync(RenderbufferType type, RenderbufferFormat internalFormat, int width, int height) => await this.BatchCallAsync(Constants.RenderbufferStorage, isMethodCall: true, type, internalFormat, width, height);

        public async ValueTask BindTextureAsync(TextureType type, WebGlTexture texture) => await this.BatchCallAsync(Constants.BindTexture, isMethodCall: true, type, texture);

        public async ValueTask CopyTexImage2DAsync(Texture2DType target, int level, PixelFormat format, int x, int y, int width, int height, int border) => await this.BatchCallAsync(Constants.CopyTexImage2D, isMethodCall: true, target, level, format, x, y, width, height, border);

        public async ValueTask CopyTexSubImage2DAsync(Texture2DType target, int level, int xoffset, int yoffset, int x, int y, int width, int height) => await this.BatchCallAsync(Constants.CopyTexSubImage2D, isMethodCall: true, target, level, xoffset, yoffset, x, y, width, height);

        public async ValueTask<WebGlTexture> CreateTextureAsync() => await this.CallMethodAsync<WebGlTexture>(Constants.CreateTexture);

        public async ValueTask DeleteTextureAsync(WebGlTexture texture) => await this.BatchCallAsync(Constants.DeleteTexture, isMethodCall: true, texture);

        public async ValueTask GenerateMipmapAsync(TextureType target) => await this.BatchCallAsync(Constants.GenerateMipmap, isMethodCall: true, target);

        public async ValueTask<T> GetTexParameterAsync<T>(TextureType target, TextureParameter pname) => await this.CallMethodAsync<T>(Constants.GetTexParameter, target, pname);

        public async ValueTask<bool> IsTextureAsync(WebGlTexture texture) => await this.CallMethodAsync<bool>(Constants.IsTexture, texture);

        public async ValueTask TexImage2DAsync<T>(Texture2DType target, int level, PixelFormat internalFormat, int width, int height, PixelFormat format, PixelType type, T[] pixels)
            where T : struct
            => await this.BatchCallAsync(Constants.TexImage2D, isMethodCall: true, target, level, internalFormat, width, height, format, type, pixels);

        public async ValueTask TexSubImage2DAsync<T>(Texture2DType target, int level, int xoffset, int yoffset, int width, int height, PixelFormat format, PixelType type, T[] pixels)
            where T : struct
            => await this.BatchCallAsync(Constants.TexSubImage2D, isMethodCall: true, target, level, xoffset, yoffset, width, height, format, type, pixels);

        public async ValueTask TexParameterAsync(TextureType target, TextureParameter pname, float param) => await this.BatchCallAsync(Constants.TexParameterF, isMethodCall: true, target, pname, param);

        public async ValueTask TexParameterAsync(TextureType target, TextureParameter pname, int param) => await this.BatchCallAsync(Constants.TexParameterI, isMethodCall: true, target, pname, param);

        public async ValueTask AttachShaderAsync(WebGlProgram program, WebGlShader shader) => await this.BatchCallAsync(Constants.AttachShader, isMethodCall: true, program, shader);

        public async ValueTask BindAttribLocationAsync(WebGlProgram program, uint index, string name) => await this.BatchCallAsync(Constants.BindAttribLocation, isMethodCall: true, program, index, name);

        public async ValueTask CompileShaderAsync(WebGlShader shader) => await this.BatchCallAsync(Constants.CompileShader, isMethodCall: true, shader);

        public async ValueTask<WebGlProgram> CreateProgramAsync() => await this.CallMethodAsync<WebGlProgram>(Constants.CreateProgram);

        public async ValueTask<WebGlShader> CreateShaderAsync(ShaderType type) => await this.CallMethodAsync<WebGlShader>(Constants.CreateShader, type);

        public async ValueTask DeleteProgramAsync(WebGlProgram program) => await this.BatchCallAsync(Constants.DeleteProgram, isMethodCall: true, program);

        public async ValueTask DeleteShaderAsync(WebGlShader shader) => await this.BatchCallAsync(Constants.DeleteShader, isMethodCall: true, shader);

        public async ValueTask DetachShaderAsync(WebGlProgram program, WebGlShader shader) => await this.BatchCallAsync(Constants.DetachShader, isMethodCall: true, program, shader);

        public async ValueTask<WebGlShader[]> GetAttachedShadersAsync(WebGlProgram program) => await this.CallMethodAsync<WebGlShader[]>(Constants.GetAttachedShaders, program);

        public async ValueTask<T> GetProgramParameterAsync<T>(WebGlProgram program, ProgramParameter pname) => await this.CallMethodAsync<T>(Constants.GetProgramParameter, program, pname);

        public async ValueTask<string> GetProgramInfoLogAsync(WebGlProgram program) => await this.CallMethodAsync<string>(Constants.GetProgramInfoLog, program);

        public async ValueTask<T> GetShaderParameterAsync<T>(WebGlShader shader, ShaderParameter pname) => await this.CallMethodAsync<T>(Constants.GetShaderParameter, shader, pname);

        public async ValueTask<WebGlShaderPrecisionFormat> GetShaderPrecisionFormatAsync(ShaderType shaderType, ShaderPrecision precisionType) => await this.CallMethodAsync<WebGlShaderPrecisionFormat>(Constants.GetShaderPrecisionFormat, shaderType, precisionType);

        public async ValueTask<string> GetShaderInfoLogAsync(WebGlShader shader) => await this.CallMethodAsync<string>(Constants.GetShaderInfoLog, shader);

        public async ValueTask<string> GetShaderSourceAsync(WebGlShader shader) => await this.CallMethodAsync<string>(Constants.GetShaderSource, shader);

        public async ValueTask<bool> IsProgramAsync(WebGlProgram program) => await this.CallMethodAsync<bool>(Constants.IsProgram, program);

        public async ValueTask<bool> IsShaderAsync(WebGlShader shader) => await this.CallMethodAsync<bool>(Constants.IsShader, shader);

        public async ValueTask LinkProgramAsync(WebGlProgram program) => await this.BatchCallAsync(Constants.LinkProgram, isMethodCall: true, program);

        public async ValueTask ShaderSourceAsync(WebGlShader shader, string source) => await this.BatchCallAsync(Constants.ShaderSource, isMethodCall: true, shader, source);

        public async ValueTask UseProgramAsync(WebGlProgram program) => await this.BatchCallAsync(Constants.UseProgram, isMethodCall: true, program);

        public async ValueTask ValidateProgramAsync(WebGlProgram program) => await this.BatchCallAsync(Constants.ValidateProgram, isMethodCall: true, program);

        public async ValueTask DisableVertexAttribArrayAsync(uint index) => await this.BatchCallAsync(Constants.DisableVertexAttribArray, isMethodCall: true, index);

        public async ValueTask EnableVertexAttribArrayAsync(uint index) => await this.BatchCallAsync(Constants.EnableVertexAttribArray, isMethodCall: true, index);

        public async ValueTask<WebGlActiveInfo> GetActiveAttribAsync(WebGlProgram program, uint index) => await this.CallMethodAsync<WebGlActiveInfo>(Constants.GetActiveAttrib, program, index);

        public async ValueTask<WebGlActiveInfo> GetActiveUniformAsync(WebGlProgram program, uint index) => await this.CallMethodAsync<WebGlActiveInfo>(Constants.GetActiveUniform, program, index);

        public async ValueTask<int> GetAttribLocationAsync(WebGlProgram program, string name) => await this.CallMethodAsync<int>(Constants.GetAttribLocation, program, name);

        public async ValueTask<T> GetUniformAsync<T>(WebGlProgram program, WebGlUniformLocation location) => await this.CallMethodAsync<T>(Constants.GetUniform, program, location);

        public async ValueTask<WebGlUniformLocation> GetUniformLocationAsync(WebGlProgram program, string name) => await this.CallMethodAsync<WebGlUniformLocation>(Constants.GetUniformLocation, program, name);

        public async ValueTask<T> GetVertexAttribAsync<T>(uint index, VertexAttribute pname) => await this.CallMethodAsync<T>(Constants.GetVertexAttrib, index, pname);

        public async ValueTask<long> GetVertexAttribOffsetAsync(uint index, VertexAttributePointer pname) => await this.CallMethodAsync<long>(Constants.GetVertexAttribOffset, index, pname);

        public async ValueTask VertexAttribPointerAsync(uint index, int size, DataType type, bool normalized, int stride, long offset) => await this.BatchCallAsync(Constants.VertexAttribPointer, isMethodCall: true, index, size, type, normalized, stride, offset);

        public async ValueTask UniformAsync(WebGlUniformLocation location, params float[] value)
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

        public async ValueTask UniformAsync(WebGlUniformLocation location, params int[] value)
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

        public async ValueTask UniformMatrixAsync(WebGlUniformLocation location, bool transpose, float[] value)
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

        public async ValueTask VertexAttribAsync(uint index, params float[] value)
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

        public async ValueTask DrawArraysAsync(Primitive mode, int first, int count) => await this.BatchCallAsync(Constants.DrawArrays, isMethodCall: true, mode, first, count);

        public async ValueTask DrawElementsAsync(Primitive mode, int count, DataType type, long offset) => await this.BatchCallAsync(Constants.DrawElements, isMethodCall: true, mode, count, type, offset);

        public async ValueTask FinishAsync() => await this.BatchCallAsync(Constants.Finish, isMethodCall: true);

        public async ValueTask FlushAsync() => await this.BatchCallAsync(Constants.Flush, isMethodCall: true);

        private byte[] ConvertToByteArray<T>(T[] arr)
        {
            byte[] byteArr = new byte[arr.Length * Marshal.SizeOf<T>()];
            Buffer.BlockCopy(arr, 0, byteArr, 0, byteArr.Length);
            return byteArr;
        }
        private async ValueTask<int> GetDrawingBufferWidthAsync() => await this.GetPropertyAsync<int>(Constants.DrawingBufferWidth);
        private async ValueTask<int> GetDrawingBufferHeightAsync() => await this.GetPropertyAsync<int>(Constants.DrawingBufferHeight);
        #endregion
    }
}