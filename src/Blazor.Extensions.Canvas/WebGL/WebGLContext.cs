using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Blazor.Extensions.WebGL;

public class WebGlContext : RenderingContext
{
    public int DrawingBufferWidth { get; private set; }
    public int DrawingBufferHeight { get; private set; }

    public WebGlContext(BECanvasComponent reference, WebGlContextAttributes attributes = null) : base(reference, "WebGL", attributes)
    {
    }

    protected override async ValueTask ExtendedInitializeAsync()
    {
        this.DrawingBufferWidth = await this.GetDrawingBufferWidthAsync().ConfigureAwait(false);
        this.DrawingBufferHeight = await this.GetDrawingBufferHeightAsync().ConfigureAwait(false);
    }

    #region Methods
    public ValueTask ClearColorAsync(float red, float green, float blue, float alpha) => this.BatchCallAsync("clearColor", isMethodCall: true, red, green, blue, alpha);

    public ValueTask ClearAsync(BufferBits mask) => this.BatchCallAsync("clear", isMethodCall: true, mask);

    public ValueTask<WebGlContextAttributes> GetContextAttributesAsync() => this.CallMethodAsync<WebGlContextAttributes>("getContextAttributes");

    public ValueTask<bool> IsContextLostAsync() => this.CallMethodAsync<bool>("isContextLost");

    public ValueTask ScissorAsync(int x, int y, int width, int height) => this.BatchCallAsync("scissor", isMethodCall: true, x, y, width, height);

    public ValueTask ViewportAsync(int x, int y, int width, int height) => this.BatchCallAsync("viewport", isMethodCall: true, x, y, width, height);

    public ValueTask ActiveTextureAsync(Texture texture) => this.BatchCallAsync("activeTexture", isMethodCall: true, texture);

    public ValueTask BlendColorAsync(float red, float green, float blue, float alpha) => this.BatchCallAsync("blendColor", isMethodCall: true, red, green, blue, alpha);

    public ValueTask BlendEquationAsync(BlendingEquation equation) => this.BatchCallAsync("blendEquation", isMethodCall: true, equation);

    public ValueTask BlendEquationSeparateAsync(BlendingEquation modeRgb, BlendingEquation modeAlpha) => this.BatchCallAsync("blendEquationSeparate", isMethodCall: true, modeRgb, modeAlpha);

    public ValueTask BlendFuncAsync(BlendingMode sfactor, BlendingMode dfactor) => this.BatchCallAsync("blendFunc", isMethodCall: true, sfactor, dfactor);

    public ValueTask BlendFuncSeparateAsync(BlendingMode srcRgb, BlendingMode dstRgb, BlendingMode srcAlpha, BlendingMode dstAlpha) => this.BatchCallAsync("blendFuncSeparate", isMethodCall: true, srcRgb, dstRgb, srcAlpha, dstAlpha);

    public ValueTask ClearDepthAsync(float depth) => this.BatchCallAsync("clearDepth", isMethodCall: true, depth);

    public ValueTask ClearStencilAsync(int stencil) => this.BatchCallAsync("clearStencil", isMethodCall: true, stencil);

    public ValueTask ColorMaskAsync(bool red, bool green, bool blue, bool alpha) => this.BatchCallAsync("colorMask", isMethodCall: true, red, green, blue, alpha);

    public ValueTask CullFaceAsync(Face mode) => this.BatchCallAsync("cullFace", isMethodCall: true, mode);

    public ValueTask DepthFuncAsync(CompareFunction func) => this.BatchCallAsync("depthFunc", isMethodCall: true, func);

    public ValueTask DepthMaskAsync(bool flag) => this.BatchCallAsync("depthMask", isMethodCall: true, flag);

    public ValueTask DepthRangeAsync(float zNear, float zFar) => this.BatchCallAsync("depthRange", isMethodCall: true, zNear, zFar);

    public ValueTask DisableAsync(EnableCap cap) => this.BatchCallAsync("disable", isMethodCall: true, cap);

    public ValueTask EnableAsync(EnableCap cap) => this.BatchCallAsync("enable", isMethodCall: true, cap);

    public ValueTask FrontFaceAsync(FrontFaceDirection mode) => this.BatchCallAsync("frontFace", isMethodCall: true, mode);

    public ValueTask<T> GetParameterAsync<T>(Parameter parameter) => this.CallMethodAsync<T>("getParameter", parameter);

    public ValueTask<Error> GetErrorAsync() => this.CallMethodAsync<Error>("getError");

    public ValueTask HintAsync(HintTarget target, HintMode mode) => this.BatchCallAsync("hint", isMethodCall: true, target, mode);

    public ValueTask<bool> IsEnabledAsync(EnableCap cap) => this.CallMethodAsync<bool>("isEnabled", cap);

    public ValueTask LineWidthAsync(float width) => this.CallMethodAsyncVoid("lineWidth", width);

    public ValueTask<bool> PixelStoreIAsync(PixelStorageMode pname, int param) => this.CallMethodAsync<bool>("pixelStorei", pname, param);

    public ValueTask PolygonOffsetAsync(float factor, float units) => this.BatchCallAsync("polygonOffset", isMethodCall: true, factor, units);

    public ValueTask SampleCoverageAsync(float value, bool invert) => this.BatchCallAsync("sampleCoverage", isMethodCall: true, value, invert);

    public ValueTask StencilFuncAsync(CompareFunction func, int reference, uint mask) => this.BatchCallAsync("stencilFunc", isMethodCall: true, func, reference, mask);

    public ValueTask StencilFuncSeparateAsync(Face face, CompareFunction func, int reference, uint mask) => this.BatchCallAsync("stencilFuncSeparate", isMethodCall: true, face, func, reference, mask);

    public ValueTask StencilMaskAsync(uint mask) => this.BatchCallAsync("stencilMask", isMethodCall: true, mask);

    public ValueTask StencilMaskSeparateAsync(Face face, uint mask) => this.BatchCallAsync("stencilMaskSeparate", isMethodCall: true, face, mask);

    public ValueTask StencilOpAsync(StencilFunction fail, StencilFunction zfail, StencilFunction zpass) => this.BatchCallAsync("stencilOp", isMethodCall: true, fail, zfail, zpass);

    public ValueTask StencilOpSeparateAsync(Face face, StencilFunction fail, StencilFunction zfail, StencilFunction zpass) => this.BatchCallAsync("stencilOpSeparate", isMethodCall: true, face, fail, zfail, zpass);

    public ValueTask BindBufferAsync(BufferType target, WebGlBuffer buffer) => this.BatchCallAsync("bindBuffer", isMethodCall: true, target, buffer);

    public ValueTask BufferDataAsync(BufferType target, int size, BufferUsageHint usage) => this.BatchCallAsync("bufferData", isMethodCall: true, target, size, usage);

    public ValueTask BufferDataAsync<T>(BufferType target, T[] data, BufferUsageHint usage) => this.BatchCallAsync("bufferData", isMethodCall: true, target, ConvertToByteArray(data), usage);

    public ValueTask BufferSubDataAsync<T>(BufferType target, uint offset, T[] data) => this.BatchCallAsync("bufferSubData", isMethodCall: true, target, offset, ConvertToByteArray(data));

    public ValueTask<WebGlBuffer> CreateBufferAsync() => this.CallMethodAsync<WebGlBuffer>("createBuffer");

    public ValueTask DeleteBufferAsync(WebGlBuffer buffer) => this.BatchCallAsync("deleteBuffer", isMethodCall: true, buffer);

    public ValueTask<T> GetBufferParameterAsync<T>(BufferType target, BufferParameter pname) => this.CallMethodAsync<T>("getBufferParameter", target, pname);

    public ValueTask<bool> IsBufferAsync(WebGlBuffer buffer) => this.CallMethodAsync<bool>("isBuffer", buffer);

    public ValueTask BindFramebufferAsync(FramebufferType target, WebGlFramebuffer framebuffer) => this.BatchCallAsync("bindFramebuffer", isMethodCall: true, target, framebuffer);

    public ValueTask<FramebufferStatus> CheckFramebufferStatusAsync(FramebufferType target) => this.CallMethodAsync<FramebufferStatus>("checkFramebufferStatus", target);

    public ValueTask<WebGlFramebuffer> CreateFramebufferAsync() => this.CallMethodAsync<WebGlFramebuffer>("createFramebuffer");

    public ValueTask DeleteFramebufferAsync(WebGlFramebuffer buffer) => this.BatchCallAsync("deleteFramebuffer", isMethodCall: true, buffer);

    public ValueTask FramebufferRenderbufferAsync(FramebufferType target, FramebufferAttachment attachment, RenderbufferType renderbuffertarget, WebGlRenderbuffer renderbuffer) => this.BatchCallAsync("framebufferRenderbuffer", isMethodCall: true, target, attachment, renderbuffertarget, renderbuffer);

    public ValueTask FramebufferTexture2DAsync(FramebufferType target, FramebufferAttachment attachment, Texture2DType textarget, WebGlTexture texture, int level) => this.BatchCallAsync("framebufferTexture2D", isMethodCall: true, target, attachment, textarget, texture, level);

    public ValueTask<T> GetFramebufferAttachmentParameterAsync<T>(FramebufferType target, FramebufferAttachment attachment, FramebufferAttachmentParameter pname) => this.CallMethodAsync<T>("getFramebufferAttachmentParameter", target, attachment, pname);

    public ValueTask<bool> IsFramebufferAsync(WebGlFramebuffer framebuffer) => this.CallMethodAsync<bool>("isFramebuffer", framebuffer);

    public ValueTask ReadPixelsAsync(int x, int y, int width, int height, PixelFormat format, PixelType type, byte[] pixels) => this.BatchCallAsync("readPixels", isMethodCall: true, x, y, width, height, format, type, pixels); //pixels should be an ArrayBufferView which the data gets read into

    public ValueTask BindRenderbufferAsync(RenderbufferType target, WebGlRenderbuffer renderbuffer) => this.BatchCallAsync("bindRenderbuffer", isMethodCall: true, target, renderbuffer);

    public ValueTask<WebGlRenderbuffer> CreateRenderbufferAsync() => this.CallMethodAsync<WebGlRenderbuffer>("createRenderbuffer");

    public ValueTask DeleteRenderbufferAsync(WebGlRenderbuffer buffer) => this.BatchCallAsync("deleteRenderbuffer", isMethodCall: true, buffer);

    public ValueTask<T> GetRenderbufferParameterAsync<T>(RenderbufferType target, RenderbufferParameter pname) => this.CallMethodAsync<T>("getRenderbufferParameter", target, pname);

    public ValueTask<bool> IsRenderbufferAsync(WebGlRenderbuffer renderbuffer) => this.CallMethodAsync<bool>("isRenderbuffer", renderbuffer);

    public ValueTask RenderbufferStorageAsync(RenderbufferType type, RenderbufferFormat internalFormat, int width, int height) => this.BatchCallAsync("renderbufferStorage", isMethodCall: true, type, internalFormat, width, height);

    public ValueTask BindTextureAsync(TextureType type, WebGlTexture texture) => this.BatchCallAsync("bindTexture", isMethodCall: true, type, texture);

    public ValueTask CopyTexImage2DAsync(Texture2DType target, int level, PixelFormat format, int x, int y, int width, int height, int border) => this.BatchCallAsync("copyTexImage2D", isMethodCall: true, target, level, format, x, y, width, height, border);

    public ValueTask CopyTexSubImage2DAsync(Texture2DType target, int level, int xoffset, int yoffset, int x, int y, int width, int height) => this.BatchCallAsync("copyTexSubImage2D", isMethodCall: true, target, level, xoffset, yoffset, x, y, width, height);

    public ValueTask<WebGlTexture> CreateTextureAsync() => this.CallMethodAsync<WebGlTexture>("createTexture");

    public ValueTask DeleteTextureAsync(WebGlTexture texture) => this.BatchCallAsync("deleteTexture", isMethodCall: true, texture);

    public ValueTask GenerateMipmapAsync(TextureType target) => this.BatchCallAsync("generateMipmap", isMethodCall: true, target);

    public ValueTask<T> GetTexParameterAsync<T>(TextureType target, TextureParameter pname) => this.CallMethodAsync<T>("getTexParameter", target, pname);

    public ValueTask<bool> IsTextureAsync(WebGlTexture texture) => this.CallMethodAsync<bool>("isTexture", texture);

    public ValueTask TexImage2DAsync<T>(Texture2DType target, int level, PixelFormat internalFormat, int width, int height, PixelFormat format, PixelType type, T[] pixels)
        where T : struct
        => this.BatchCallAsync("texImage2D", isMethodCall: true, target, level, internalFormat, width, height, format, type, pixels);

    public ValueTask TexSubImage2DAsync<T>(Texture2DType target, int level, int xoffset, int yoffset, int width, int height, PixelFormat format, PixelType type, T[] pixels)
        where T : struct
        => this.BatchCallAsync("texSubImage2D", isMethodCall: true, target, level, xoffset, yoffset, width, height, format, type, pixels);

    public ValueTask TexParameterAsync(TextureType target, TextureParameter pname, float param) => this.BatchCallAsync("texParameterf", isMethodCall: true, target, pname, param);

    public ValueTask TexParameterAsync(TextureType target, TextureParameter pname, int param) => this.BatchCallAsync("texParameteri", isMethodCall: true, target, pname, param);

    public ValueTask AttachShaderAsync(WebGlProgram program, WebGlShader shader) => this.BatchCallAsync("attachShader", isMethodCall: true, program, shader);

    public ValueTask BindAttribLocationAsync(WebGlProgram program, uint index, string name) => this.BatchCallAsync("bindAttribLocation", isMethodCall: true, program, index, name);

    public ValueTask CompileShaderAsync(WebGlShader shader) => this.BatchCallAsync("compileShader", isMethodCall: true, shader);

    public ValueTask<WebGlProgram> CreateProgramAsync() => this.CallMethodAsync<WebGlProgram>("createProgram");

    public ValueTask<WebGlShader> CreateShaderAsync(ShaderType type) => this.CallMethodAsync<WebGlShader>("createShader", type);

    public ValueTask DeleteProgramAsync(WebGlProgram program) => this.BatchCallAsync("deleteProgram", isMethodCall: true, program);

    public ValueTask DeleteShaderAsync(WebGlShader shader) => this.BatchCallAsync("deleteShader", isMethodCall: true, shader);

    public ValueTask DetachShaderAsync(WebGlProgram program, WebGlShader shader) => this.BatchCallAsync("detachShader", isMethodCall: true, program, shader);

    public ValueTask<WebGlShader[]> GetAttachedShadersAsync(WebGlProgram program) => this.CallMethodAsync<WebGlShader[]>("getAttachedShaders", program);

    public ValueTask<T> GetProgramParameterAsync<T>(WebGlProgram program, ProgramParameter pname) => this.CallMethodAsync<T>("getProgramParameter", program, pname);

    public ValueTask<string> GetProgramInfoLogAsync(WebGlProgram program) => this.CallMethodAsync<string>("getProgramInfoLog", program);

    public ValueTask<T> GetShaderParameterAsync<T>(WebGlShader shader, ShaderParameter pname) => this.CallMethodAsync<T>("getShaderParameter", shader, pname);

    public ValueTask<WebGlShaderPrecisionFormat> GetShaderPrecisionFormatAsync(ShaderType shaderType, ShaderPrecision precisionType) => this.CallMethodAsync<WebGlShaderPrecisionFormat>("getShaderPrecisionFormat", shaderType, precisionType);

    public ValueTask<string> GetShaderInfoLogAsync(WebGlShader shader) => this.CallMethodAsync<string>("getShaderInfoLog", shader);

    public ValueTask<string> GetShaderSourceAsync(WebGlShader shader) => this.CallMethodAsync<string>("getShaderSource", shader);

    public ValueTask<bool> IsProgramAsync(WebGlProgram program) => this.CallMethodAsync<bool>("isProgram", program);

    public ValueTask<bool> IsShaderAsync(WebGlShader shader) => this.CallMethodAsync<bool>("isShader", shader);

    public ValueTask LinkProgramAsync(WebGlProgram program) => this.BatchCallAsync("linkProgram", isMethodCall: true, program);

    public ValueTask ShaderSourceAsync(WebGlShader shader, string source) => this.BatchCallAsync("shaderSource", isMethodCall: true, shader, source);

    public ValueTask UseProgramAsync(WebGlProgram program) => this.BatchCallAsync("useProgram", isMethodCall: true, program);

    public ValueTask ValidateProgramAsync(WebGlProgram program) => this.BatchCallAsync("validateProgram", isMethodCall: true, program);

    public ValueTask DisableVertexAttribArrayAsync(uint index) => this.BatchCallAsync("disableVertexAttribArray", isMethodCall: true, index);

    public ValueTask EnableVertexAttribArrayAsync(uint index) => this.BatchCallAsync("enableVertexAttribArray", isMethodCall: true, index);

    public ValueTask<WebGlActiveInfo> GetActiveAttribAsync(WebGlProgram program, uint index) => this.CallMethodAsync<WebGlActiveInfo>("getActiveAttrib", program, index);

    public ValueTask<WebGlActiveInfo> GetActiveUniformAsync(WebGlProgram program, uint index) => this.CallMethodAsync<WebGlActiveInfo>("getActiveUniform", program, index);

    public ValueTask<int> GetAttribLocationAsync(WebGlProgram program, string name) => this.CallMethodAsync<int>("getAttribLocation", program, name);

    public ValueTask<T> GetUniformAsync<T>(WebGlProgram program, WebGlUniformLocation location) => this.CallMethodAsync<T>("getUniform", program, location);

    public ValueTask<WebGlUniformLocation> GetUniformLocationAsync(WebGlProgram program, string name) => this.CallMethodAsync<WebGlUniformLocation>("getUniformLocation", program, name);

    public ValueTask<T> GetVertexAttribAsync<T>(uint index, VertexAttribute pname) => this.CallMethodAsync<T>("getVertexAttrib", index, pname);

    public ValueTask<long> GetVertexAttribOffsetAsync(uint index, VertexAttributePointer pname) => this.CallMethodAsync<long>("getVertexAttribOffset", index, pname);

    public ValueTask VertexAttribPointerAsync(uint index, int size, DataType type, bool normalized, int stride, long offset) => this.BatchCallAsync("vertexAttribPointer", isMethodCall: true, index, size, type, normalized, stride, offset);

    public ValueTask UniformAsync(WebGlUniformLocation location, params float[] value)
    {
        return value.Length switch
        {
            1 => this.BatchCallAsync("uniform" + "1fv", isMethodCall: true, location, value),
            2 => this.BatchCallAsync("uniform" + "2fv", isMethodCall: true, location, value),
            3 => this.BatchCallAsync("uniform" + "3fv", isMethodCall: true, location, value),
            4 => this.BatchCallAsync("uniform" + "4fv", isMethodCall: true, location, value),
            _ => throw new ArgumentOutOfRangeException(nameof(value), value.Length,
                "Value array is empty or too long")
        };
    }

    public ValueTask UniformAsync(WebGlUniformLocation location, params int[] value)
    {
        return value.Length switch
        {
            1 => this.BatchCallAsync("uniform" + "1iv", isMethodCall: true, location, value),
            2 => this.BatchCallAsync("uniform" + "2iv", isMethodCall: true, location, value),
            3 => this.BatchCallAsync("uniform" + "3iv", isMethodCall: true, location, value),
            4 => this.BatchCallAsync("uniform" + "4iv", isMethodCall: true, location, value),
            _ => throw new ArgumentOutOfRangeException(nameof(value), value.Length,
                "Value array is empty or too long")
        };
    }

    public ValueTask UniformMatrixAsync(WebGlUniformLocation location, bool transpose, float[] value)
    {
        return value.Length switch
        {
            2 * 2 => this.BatchCallAsync("uniformMatrix" + "2fv", isMethodCall: true, location, transpose,
                value),
            3 * 3 => this.BatchCallAsync("uniformMatrix" + "3fv", isMethodCall: true, location, transpose,
                value),
            4 * 4 => this.BatchCallAsync("uniformMatrix" + "4fv", isMethodCall: true, location, transpose,
                value),
            _ => throw new ArgumentOutOfRangeException(nameof(value), value.Length,
                "Value array has incorrect size")
        };
    }

    public ValueTask VertexAttribAsync(uint index, params float[] value)
    {
        return value.Length switch
        {
            1 => this.BatchCallAsync("vertexAttrib" + "1fv", isMethodCall: true, index, value),
            2 => this.BatchCallAsync("vertexAttrib" + "2fv", isMethodCall: true, index, value),
            3 => this.BatchCallAsync("vertexAttrib" + "3fv", isMethodCall: true, index, value),
            4 => this.BatchCallAsync("vertexAttrib" + "4fv", isMethodCall: true, index, value),
            _ => throw new ArgumentOutOfRangeException(nameof(value), value.Length,
                "Value array is empty or too long")
        };
    }

    public ValueTask DrawArraysAsync(Primitive mode, int first, int count) => this.BatchCallAsync("drawArrays", isMethodCall: true, mode, first, count);

    public ValueTask DrawElementsAsync(Primitive mode, int count, DataType type, long offset) => this.BatchCallAsync("drawElements", isMethodCall: true, mode, count, type, offset);

    public ValueTask FinishAsync() => this.BatchCallAsync("finish", isMethodCall: true);

    public ValueTask FlushAsync() => this.BatchCallAsync("flush", isMethodCall: true);

    private static byte[] ConvertToByteArray<T>(T[] arr)
    {
        var byteArr = new byte[arr.Length * Marshal.SizeOf<T>()];
        Buffer.BlockCopy(arr, 0, byteArr, 0, byteArr.Length);
        return byteArr;
    }
    private ValueTask<int> GetDrawingBufferWidthAsync() => this.GetPropertyAsync<int>("drawingBufferWidth");
    private ValueTask<int> GetDrawingBufferHeightAsync() => this.GetPropertyAsync<int>("drawingBufferHeight");
    #endregion
}