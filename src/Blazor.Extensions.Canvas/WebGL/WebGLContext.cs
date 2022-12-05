using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Blazor.Extensions.WebGL;

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
        this.DrawingBufferWidth = await this.GetDrawingBufferWidthAsync().ConfigureAwait(false);
        this.DrawingBufferHeight = await this.GetDrawingBufferHeightAsync().ConfigureAwait(false);
    }

    #region Methods
    public ValueTask ClearColorAsync(float red, float green, float blue, float alpha) => this.BatchCallAsync(Constants.ClearColor, isMethodCall: true, red, green, blue, alpha);

    public ValueTask ClearAsync(BufferBits mask) => this.BatchCallAsync(Constants.Clear, isMethodCall: true, mask);

    public ValueTask<WebGlContextAttributes> GetContextAttributesAsync() => this.CallMethodAsync<WebGlContextAttributes>(Constants.GetContextAttributes);

    public ValueTask<bool> IsContextLostAsync() => this.CallMethodAsync<bool>(Constants.IsContextLost);

    public ValueTask ScissorAsync(int x, int y, int width, int height) => this.BatchCallAsync(Constants.Scissor, isMethodCall: true, x, y, width, height);

    public ValueTask ViewportAsync(int x, int y, int width, int height) => this.BatchCallAsync(Constants.Viewport, isMethodCall: true, x, y, width, height);

    public ValueTask ActiveTextureAsync(Texture texture) => this.BatchCallAsync(Constants.ActiveTexture, isMethodCall: true, texture);

    public ValueTask BlendColorAsync(float red, float green, float blue, float alpha) => this.BatchCallAsync(Constants.BlendColor, isMethodCall: true, red, green, blue, alpha);

    public ValueTask BlendEquationAsync(BlendingEquation equation) => this.BatchCallAsync(Constants.BlendEquation, isMethodCall: true, equation);

    public ValueTask BlendEquationSeparateAsync(BlendingEquation modeRgb, BlendingEquation modeAlpha) => this.BatchCallAsync(Constants.BlendEquationSeparate, isMethodCall: true, modeRgb, modeAlpha);

    public ValueTask BlendFuncAsync(BlendingMode sfactor, BlendingMode dfactor) => this.BatchCallAsync(Constants.BlendFunc, isMethodCall: true, sfactor, dfactor);

    public ValueTask BlendFuncSeparateAsync(BlendingMode srcRgb, BlendingMode dstRgb, BlendingMode srcAlpha, BlendingMode dstAlpha) => this.BatchCallAsync(Constants.BlendFuncSeparate, isMethodCall: true, srcRgb, dstRgb, srcAlpha, dstAlpha);

    public ValueTask ClearDepthAsync(float depth) => this.BatchCallAsync(Constants.ClearDepth, isMethodCall: true, depth);

    public ValueTask ClearStencilAsync(int stencil) => this.BatchCallAsync(Constants.ClearStencil, isMethodCall: true, stencil);

    public ValueTask ColorMaskAsync(bool red, bool green, bool blue, bool alpha) => this.BatchCallAsync(Constants.ColorMask, isMethodCall: true, red, green, blue, alpha);

    public ValueTask CullFaceAsync(Face mode) => this.BatchCallAsync(Constants.CullFace, isMethodCall: true, mode);

    public ValueTask DepthFuncAsync(CompareFunction func) => this.BatchCallAsync(Constants.DepthFunc, isMethodCall: true, func);

    public ValueTask DepthMaskAsync(bool flag) => this.BatchCallAsync(Constants.DepthMask, isMethodCall: true, flag);

    public ValueTask DepthRangeAsync(float zNear, float zFar) => this.BatchCallAsync(Constants.DepthRange, isMethodCall: true, zNear, zFar);

    public ValueTask DisableAsync(EnableCap cap) => this.BatchCallAsync(Constants.Disable, isMethodCall: true, cap);

    public ValueTask EnableAsync(EnableCap cap) => this.BatchCallAsync(Constants.Enable, isMethodCall: true, cap);

    public ValueTask FrontFaceAsync(FrontFaceDirection mode) => this.BatchCallAsync(Constants.FrontFace, isMethodCall: true, mode);

    public ValueTask<T> GetParameterAsync<T>(Parameter parameter) => this.CallMethodAsync<T>(Constants.GetParameter, parameter);

    public ValueTask<Error> GetErrorAsync() => this.CallMethodAsync<Error>(Constants.GetError);

    public ValueTask HintAsync(HintTarget target, HintMode mode) => this.BatchCallAsync(Constants.Hint, isMethodCall: true, target, mode);

    public ValueTask<bool> IsEnabledAsync(EnableCap cap) => this.CallMethodAsync<bool>(Constants.IsEnabled, cap);

    public ValueTask LineWidthAsync(float width) => this.CallMethodAsyncVoid(Constants.LineWidth, width);

    public ValueTask<bool> PixelStoreIAsync(PixelStorageMode pname, int param) => this.CallMethodAsync<bool>(Constants.PixelStoreI, pname, param);

    public ValueTask PolygonOffsetAsync(float factor, float units) => this.BatchCallAsync(Constants.PolygonOffset, isMethodCall: true, factor, units);

    public ValueTask SampleCoverageAsync(float value, bool invert) => this.BatchCallAsync(Constants.SampleCoverage, isMethodCall: true, value, invert);

    public ValueTask StencilFuncAsync(CompareFunction func, int reference, uint mask) => this.BatchCallAsync(Constants.StencilFunc, isMethodCall: true, func, reference, mask);

    public ValueTask StencilFuncSeparateAsync(Face face, CompareFunction func, int reference, uint mask) => this.BatchCallAsync(Constants.StencilFuncSeparate, isMethodCall: true, face, func, reference, mask);

    public ValueTask StencilMaskAsync(uint mask) => this.BatchCallAsync(Constants.StencilMask, isMethodCall: true, mask);

    public ValueTask StencilMaskSeparateAsync(Face face, uint mask) => this.BatchCallAsync(Constants.StencilMaskSeparate, isMethodCall: true, face, mask);

    public ValueTask StencilOpAsync(StencilFunction fail, StencilFunction zfail, StencilFunction zpass) => this.BatchCallAsync(Constants.StencilOp, isMethodCall: true, fail, zfail, zpass);

    public ValueTask StencilOpSeparateAsync(Face face, StencilFunction fail, StencilFunction zfail, StencilFunction zpass) => this.BatchCallAsync(Constants.StencilOpSeparate, isMethodCall: true, face, fail, zfail, zpass);

    public ValueTask BindBufferAsync(BufferType target, WebGlBuffer buffer) => this.BatchCallAsync(Constants.BindBuffer, isMethodCall: true, target, buffer);

    public ValueTask BufferDataAsync(BufferType target, int size, BufferUsageHint usage) => this.BatchCallAsync(Constants.BufferData, isMethodCall: true, target, size, usage);

    public ValueTask BufferDataAsync<T>(BufferType target, T[] data, BufferUsageHint usage) => this.BatchCallAsync(Constants.BufferData, isMethodCall: true, target, ConvertToByteArray(data), usage);

    public ValueTask BufferSubDataAsync<T>(BufferType target, uint offset, T[] data) => this.BatchCallAsync(Constants.BufferSubData, isMethodCall: true, target, offset, ConvertToByteArray(data));

    public ValueTask<WebGlBuffer> CreateBufferAsync() => this.CallMethodAsync<WebGlBuffer>(Constants.CreateBuffer);

    public ValueTask DeleteBufferAsync(WebGlBuffer buffer) => this.BatchCallAsync(Constants.DeleteBuffer, isMethodCall: true, buffer);

    public ValueTask<T> GetBufferParameterAsync<T>(BufferType target, BufferParameter pname) => this.CallMethodAsync<T>(Constants.GetBufferParameter, target, pname);

    public ValueTask<bool> IsBufferAsync(WebGlBuffer buffer) => this.CallMethodAsync<bool>(Constants.IsBuffer, buffer);

    public ValueTask BindFramebufferAsync(FramebufferType target, WebGlFramebuffer framebuffer) => this.BatchCallAsync(Constants.BindFramebuffer, isMethodCall: true, target, framebuffer);

    public ValueTask<FramebufferStatus> CheckFramebufferStatusAsync(FramebufferType target) => this.CallMethodAsync<FramebufferStatus>(Constants.CheckFramebufferStatus, target);

    public ValueTask<WebGlFramebuffer> CreateFramebufferAsync() => this.CallMethodAsync<WebGlFramebuffer>(Constants.CreateFramebuffer);

    public ValueTask DeleteFramebufferAsync(WebGlFramebuffer buffer) => this.BatchCallAsync(Constants.DeleteFramebuffer, isMethodCall: true, buffer);

    public ValueTask FramebufferRenderbufferAsync(FramebufferType target, FramebufferAttachment attachment, RenderbufferType renderbuffertarget, WebGlRenderbuffer renderbuffer) => this.BatchCallAsync(Constants.FramebufferRenderbuffer, isMethodCall: true, target, attachment, renderbuffertarget, renderbuffer);

    public ValueTask FramebufferTexture2DAsync(FramebufferType target, FramebufferAttachment attachment, Texture2DType textarget, WebGlTexture texture, int level) => this.BatchCallAsync(Constants.FramebufferTexture2D, isMethodCall: true, target, attachment, textarget, texture, level);

    public ValueTask<T> GetFramebufferAttachmentParameterAsync<T>(FramebufferType target, FramebufferAttachment attachment, FramebufferAttachmentParameter pname) => this.CallMethodAsync<T>(Constants.GetFramebufferAttachmentParameter, target, attachment, pname);

    public ValueTask<bool> IsFramebufferAsync(WebGlFramebuffer framebuffer) => this.CallMethodAsync<bool>(Constants.IsFramebuffer, framebuffer);

    public ValueTask ReadPixelsAsync(int x, int y, int width, int height, PixelFormat format, PixelType type, byte[] pixels) => this.BatchCallAsync(Constants.ReadPixels, isMethodCall: true, x, y, width, height, format, type, pixels); //pixels should be an ArrayBufferView which the data gets read into

    public ValueTask BindRenderbufferAsync(RenderbufferType target, WebGlRenderbuffer renderbuffer) => this.BatchCallAsync(Constants.BindRenderbuffer, isMethodCall: true, target, renderbuffer);

    public ValueTask<WebGlRenderbuffer> CreateRenderbufferAsync() => this.CallMethodAsync<WebGlRenderbuffer>(Constants.CreateRenderbuffer);

    public ValueTask DeleteRenderbufferAsync(WebGlRenderbuffer buffer) => this.BatchCallAsync(Constants.DeleteRenderbuffer, isMethodCall: true, buffer);

    public ValueTask<T> GetRenderbufferParameterAsync<T>(RenderbufferType target, RenderbufferParameter pname) => this.CallMethodAsync<T>(Constants.GetRenderbufferParameter, target, pname);

    public ValueTask<bool> IsRenderbufferAsync(WebGlRenderbuffer renderbuffer) => this.CallMethodAsync<bool>(Constants.IsRenderbuffer, renderbuffer);

    public ValueTask RenderbufferStorageAsync(RenderbufferType type, RenderbufferFormat internalFormat, int width, int height) => this.BatchCallAsync(Constants.RenderbufferStorage, isMethodCall: true, type, internalFormat, width, height);

    public ValueTask BindTextureAsync(TextureType type, WebGlTexture texture) => this.BatchCallAsync(Constants.BindTexture, isMethodCall: true, type, texture);

    public ValueTask CopyTexImage2DAsync(Texture2DType target, int level, PixelFormat format, int x, int y, int width, int height, int border) => this.BatchCallAsync(Constants.CopyTexImage2D, isMethodCall: true, target, level, format, x, y, width, height, border);

    public ValueTask CopyTexSubImage2DAsync(Texture2DType target, int level, int xoffset, int yoffset, int x, int y, int width, int height) => this.BatchCallAsync(Constants.CopyTexSubImage2D, isMethodCall: true, target, level, xoffset, yoffset, x, y, width, height);

    public ValueTask<WebGlTexture> CreateTextureAsync() => this.CallMethodAsync<WebGlTexture>(Constants.CreateTexture);

    public ValueTask DeleteTextureAsync(WebGlTexture texture) => this.BatchCallAsync(Constants.DeleteTexture, isMethodCall: true, texture);

    public ValueTask GenerateMipmapAsync(TextureType target) => this.BatchCallAsync(Constants.GenerateMipmap, isMethodCall: true, target);

    public ValueTask<T> GetTexParameterAsync<T>(TextureType target, TextureParameter pname) => this.CallMethodAsync<T>(Constants.GetTexParameter, target, pname);

    public ValueTask<bool> IsTextureAsync(WebGlTexture texture) => this.CallMethodAsync<bool>(Constants.IsTexture, texture);

    public ValueTask TexImage2DAsync<T>(Texture2DType target, int level, PixelFormat internalFormat, int width, int height, PixelFormat format, PixelType type, T[] pixels)
        where T : struct
        => this.BatchCallAsync(Constants.TexImage2D, isMethodCall: true, target, level, internalFormat, width, height, format, type, pixels);

    public ValueTask TexSubImage2DAsync<T>(Texture2DType target, int level, int xoffset, int yoffset, int width, int height, PixelFormat format, PixelType type, T[] pixels)
        where T : struct
        => this.BatchCallAsync(Constants.TexSubImage2D, isMethodCall: true, target, level, xoffset, yoffset, width, height, format, type, pixels);

    public ValueTask TexParameterAsync(TextureType target, TextureParameter pname, float param) => this.BatchCallAsync(Constants.TexParameterF, isMethodCall: true, target, pname, param);

    public ValueTask TexParameterAsync(TextureType target, TextureParameter pname, int param) => this.BatchCallAsync(Constants.TexParameterI, isMethodCall: true, target, pname, param);

    public ValueTask AttachShaderAsync(WebGlProgram program, WebGlShader shader) => this.BatchCallAsync(Constants.AttachShader, isMethodCall: true, program, shader);

    public ValueTask BindAttribLocationAsync(WebGlProgram program, uint index, string name) => this.BatchCallAsync(Constants.BindAttribLocation, isMethodCall: true, program, index, name);

    public ValueTask CompileShaderAsync(WebGlShader shader) => this.BatchCallAsync(Constants.CompileShader, isMethodCall: true, shader);

    public ValueTask<WebGlProgram> CreateProgramAsync() => this.CallMethodAsync<WebGlProgram>(Constants.CreateProgram);

    public ValueTask<WebGlShader> CreateShaderAsync(ShaderType type) => this.CallMethodAsync<WebGlShader>(Constants.CreateShader, type);

    public ValueTask DeleteProgramAsync(WebGlProgram program) => this.BatchCallAsync(Constants.DeleteProgram, isMethodCall: true, program);

    public ValueTask DeleteShaderAsync(WebGlShader shader) => this.BatchCallAsync(Constants.DeleteShader, isMethodCall: true, shader);

    public ValueTask DetachShaderAsync(WebGlProgram program, WebGlShader shader) => this.BatchCallAsync(Constants.DetachShader, isMethodCall: true, program, shader);

    public ValueTask<WebGlShader[]> GetAttachedShadersAsync(WebGlProgram program) => this.CallMethodAsync<WebGlShader[]>(Constants.GetAttachedShaders, program);

    public ValueTask<T> GetProgramParameterAsync<T>(WebGlProgram program, ProgramParameter pname) => this.CallMethodAsync<T>(Constants.GetProgramParameter, program, pname);

    public ValueTask<string> GetProgramInfoLogAsync(WebGlProgram program) => this.CallMethodAsync<string>(Constants.GetProgramInfoLog, program);

    public ValueTask<T> GetShaderParameterAsync<T>(WebGlShader shader, ShaderParameter pname) => this.CallMethodAsync<T>(Constants.GetShaderParameter, shader, pname);

    public ValueTask<WebGlShaderPrecisionFormat> GetShaderPrecisionFormatAsync(ShaderType shaderType, ShaderPrecision precisionType) => this.CallMethodAsync<WebGlShaderPrecisionFormat>(Constants.GetShaderPrecisionFormat, shaderType, precisionType);

    public ValueTask<string> GetShaderInfoLogAsync(WebGlShader shader) => this.CallMethodAsync<string>(Constants.GetShaderInfoLog, shader);

    public ValueTask<string> GetShaderSourceAsync(WebGlShader shader) => this.CallMethodAsync<string>(Constants.GetShaderSource, shader);

    public ValueTask<bool> IsProgramAsync(WebGlProgram program) => this.CallMethodAsync<bool>(Constants.IsProgram, program);

    public ValueTask<bool> IsShaderAsync(WebGlShader shader) => this.CallMethodAsync<bool>(Constants.IsShader, shader);

    public ValueTask LinkProgramAsync(WebGlProgram program) => this.BatchCallAsync(Constants.LinkProgram, isMethodCall: true, program);

    public ValueTask ShaderSourceAsync(WebGlShader shader, string source) => this.BatchCallAsync(Constants.ShaderSource, isMethodCall: true, shader, source);

    public ValueTask UseProgramAsync(WebGlProgram program) => this.BatchCallAsync(Constants.UseProgram, isMethodCall: true, program);

    public ValueTask ValidateProgramAsync(WebGlProgram program) => this.BatchCallAsync(Constants.ValidateProgram, isMethodCall: true, program);

    public ValueTask DisableVertexAttribArrayAsync(uint index) => this.BatchCallAsync(Constants.DisableVertexAttribArray, isMethodCall: true, index);

    public ValueTask EnableVertexAttribArrayAsync(uint index) => this.BatchCallAsync(Constants.EnableVertexAttribArray, isMethodCall: true, index);

    public ValueTask<WebGlActiveInfo> GetActiveAttribAsync(WebGlProgram program, uint index) => this.CallMethodAsync<WebGlActiveInfo>(Constants.GetActiveAttrib, program, index);

    public ValueTask<WebGlActiveInfo> GetActiveUniformAsync(WebGlProgram program, uint index) => this.CallMethodAsync<WebGlActiveInfo>(Constants.GetActiveUniform, program, index);

    public ValueTask<int> GetAttribLocationAsync(WebGlProgram program, string name) => this.CallMethodAsync<int>(Constants.GetAttribLocation, program, name);

    public ValueTask<T> GetUniformAsync<T>(WebGlProgram program, WebGlUniformLocation location) => this.CallMethodAsync<T>(Constants.GetUniform, program, location);

    public ValueTask<WebGlUniformLocation> GetUniformLocationAsync(WebGlProgram program, string name) => this.CallMethodAsync<WebGlUniformLocation>(Constants.GetUniformLocation, program, name);

    public ValueTask<T> GetVertexAttribAsync<T>(uint index, VertexAttribute pname) => this.CallMethodAsync<T>(Constants.GetVertexAttrib, index, pname);

    public ValueTask<long> GetVertexAttribOffsetAsync(uint index, VertexAttributePointer pname) => this.CallMethodAsync<long>(Constants.GetVertexAttribOffset, index, pname);

    public ValueTask VertexAttribPointerAsync(uint index, int size, DataType type, bool normalized, int stride, long offset) => this.BatchCallAsync(Constants.VertexAttribPointer, isMethodCall: true, index, size, type, normalized, stride, offset);

    public ValueTask UniformAsync(WebGlUniformLocation location, params float[] value)
    {
        return value.Length switch
        {
            1 => this.BatchCallAsync(Constants.Uniform + "1fv", isMethodCall: true, location, value),
            2 => this.BatchCallAsync(Constants.Uniform + "2fv", isMethodCall: true, location, value),
            3 => this.BatchCallAsync(Constants.Uniform + "3fv", isMethodCall: true, location, value),
            4 => this.BatchCallAsync(Constants.Uniform + "4fv", isMethodCall: true, location, value),
            _ => throw new ArgumentOutOfRangeException(nameof(value), value.Length,
                "Value array is empty or too long")
        };
    }

    public ValueTask UniformAsync(WebGlUniformLocation location, params int[] value)
    {
        return value.Length switch
        {
            1 => this.BatchCallAsync(Constants.Uniform + "1iv", isMethodCall: true, location, value),
            2 => this.BatchCallAsync(Constants.Uniform + "2iv", isMethodCall: true, location, value),
            3 => this.BatchCallAsync(Constants.Uniform + "3iv", isMethodCall: true, location, value),
            4 => this.BatchCallAsync(Constants.Uniform + "4iv", isMethodCall: true, location, value),
            _ => throw new ArgumentOutOfRangeException(nameof(value), value.Length,
                "Value array is empty or too long")
        };
    }

    public ValueTask UniformMatrixAsync(WebGlUniformLocation location, bool transpose, float[] value)
    {
        return value.Length switch
        {
            2 * 2 => this.BatchCallAsync(Constants.UniformMatrix + "2fv", isMethodCall: true, location, transpose,
                value),
            3 * 3 => this.BatchCallAsync(Constants.UniformMatrix + "3fv", isMethodCall: true, location, transpose,
                value),
            4 * 4 => this.BatchCallAsync(Constants.UniformMatrix + "4fv", isMethodCall: true, location, transpose,
                value),
            _ => throw new ArgumentOutOfRangeException(nameof(value), value.Length,
                "Value array has incorrect size")
        };
    }

    public ValueTask VertexAttribAsync(uint index, params float[] value)
    {
        return value.Length switch
        {
            1 => this.BatchCallAsync(Constants.VertexAttrib + "1fv", isMethodCall: true, index, value),
            2 => this.BatchCallAsync(Constants.VertexAttrib + "2fv", isMethodCall: true, index, value),
            3 => this.BatchCallAsync(Constants.VertexAttrib + "3fv", isMethodCall: true, index, value),
            4 => this.BatchCallAsync(Constants.VertexAttrib + "4fv", isMethodCall: true, index, value),
            _ => throw new ArgumentOutOfRangeException(nameof(value), value.Length,
                "Value array is empty or too long")
        };
    }

    public ValueTask DrawArraysAsync(Primitive mode, int first, int count) => this.BatchCallAsync(Constants.DrawArrays, isMethodCall: true, mode, first, count);

    public ValueTask DrawElementsAsync(Primitive mode, int count, DataType type, long offset) => this.BatchCallAsync(Constants.DrawElements, isMethodCall: true, mode, count, type, offset);

    public ValueTask FinishAsync() => this.BatchCallAsync(Constants.Finish, isMethodCall: true);

    public ValueTask FlushAsync() => this.BatchCallAsync(Constants.Flush, isMethodCall: true);

    private static byte[] ConvertToByteArray<T>(T[] arr)
    {
        var byteArr = new byte[arr.Length * Marshal.SizeOf<T>()];
        Buffer.BlockCopy(arr, 0, byteArr, 0, byteArr.Length);
        return byteArr;
    }
    private ValueTask<int> GetDrawingBufferWidthAsync() => this.GetPropertyAsync<int>(Constants.DrawingBufferWidth);
    private ValueTask<int> GetDrawingBufferHeightAsync() => this.GetPropertyAsync<int>(Constants.DrawingBufferHeight);
    #endregion
}