namespace Blazor.Extensions.WebGL;

public enum BufferBits
{
    ColorBufferBit = 0x4000,
    DepthBufferBit = 0x100,
    StencilBufferBit = 0x400
}

public enum Primitive
{
    Points = 0,
    Lines = 1,
    LineLoop = 2,
    LineStrip = 3,
    Triangles = 4,
    TriangleStrip = 5,
    TriangleFan = 6
}

public enum BlendingMode
{
    Zero = 0,
    One = 1,
    SrcColor = 0x300,
    OneMinusSrcColor = 0x301,
    SrcAlpha = 0x302,
    OneMinusSrcAlpha = 0x303,
    DstAlpha = 0x304,
    OneMinusDstAlpha = 0x305,
    DstColor = 0x306,
    OneMinusDstColor = 0x307,
    SrcAlphaSaturate = 0x308,
    ConstantColor = 0x8001,
    OneMinusConstantColor = 0x8002,
    ConstantAlpha = 0x8003,
    OneMinusConstantAlpha = 0x8004
}

public enum BlendingEquation
{
    FuncAdd = 0x8006,
    FuncSubtract = 0x800A,
    FuncReverseSubtract = 0x800B
}

public enum Parameter
{
    BlendEquation = 0x8009,
    BlendEquationRgb = 0x8009,
    BlendEquationAlpha = 0x883D,
    BlendDstRgb = 0x80C8,
    BlendSrcRbg = 0x80C9,
    BlendDstAlpha = 0x80CA,
    BlendSrcAlpha = 0x80CB,
    BlendColor = 0x8005,
    ArrayBufferBinding = 0x8894,
    ElementArrayBufferBinding = 0x8895,
    LineWidth = 0x0B21,
    AliasedPointSizeRange = 0x846D,
    AliasedLineWidthRange = 0x846E,
    CullFaceMode = 0x0B45,
    FrontFace = 0x0B46,
    DepthRange = 0x0B70,
    DepthWritemask = 0x0B72,
    DepthClearValue = 0x0B73,
    DepthFunc = 0x0B74,
    StencilClearValue = 0x0B91,
    StencilFunc = 0x0B92,
    StencilFail = 0x0B94,
    StencilPassDepthFail = 0x0B95,
    StencilPassDepthPass = 0x0B96,
    StencilRef = 0x0B97,
    StencilValueMask = 0x0B93,
    StencilWritemask = 0x0B98,
    StencilBackFunc = 0x8800,
    StencilBackFail = 0x8801,
    StencilBackPassDepthFail = 0x8802,
    StencilBackPassDepthPass = 0x8803,
    StencilBackRef = 0x8CA3,
    StencilBackValueMask = 0x8CA4,
    StencilBackWritemask = 0x8CA5,
    Viewport = 0x0BA2,
    ScissorBox = 0x0C10,
    ColorClearValue = 0x0C22,
    ColorWritemask = 0x0C23,
    UnpackAlignment = 0x0CF5,
    PackAlignment = 0x0D05,
    MaxTextureSize = 0x0D33,
    MaxViewportDims = 0x0D3A,
    SubpixelBits = 0x0D50,
    RedBits = 0x0D52,
    GreenBits = 0x0D53,
    BlueBits = 0x0D54,
    AlphaBits = 0x0D55,
    DepthBits = 0x0D56,
    StencilBits = 0x0D57,
    PolygonOffsetUnits = 0x2A00,
    PolygonOffsetFactor = 0x8038,
    TextureBinding2D = 0x8069,
    SampleBuffers = 0x80A8,
    Samples = 0x80A9,
    SampleCoverageValue = 0x80AA,
    SampleCoverageInvert = 0x80AB,
    CompressedTextureFormats = 0x86A3,
    Vendor = 0x1F00,
    Renderer = 0x1F01,
    Version = 0x1F02,
    ImplementationColorReadType = 0x8B9A,
    ImplementationColorReadFormat = 0x8B9B,
    BrowserDefaultWebgl = 0x9244,
    MaxVertexAttribs = 0x8869,
    MaxVertexUniformVectors = 0x8DFB,
    MaxVaryingVectors = 0x8DFC,
    MaxCombinedTextureImageUnits = 0x8B4D,
    MaxVertexTextureImageUnits = 0x8B4C,
    MaxTextureImageUnits = 0x8872,
    MaxFragmentUniformVectors = 0x8DFD,
    ShadingLanguageVersion = 0x8B8C,
    CurrentProgram = 0x8B8D,
    MaxRenderbufferSize = 0x84E8,
    FramebufferBinding = 0x8CA6,
    RenderbufferBinding = 0x8CA7,
    ActiveTexture = 0x84E0
}

public enum BufferUsageHint
{
    StaticDraw = 0x88E4,
    StreamDraw = 0x88E0,
    DynamicDraw = 0x88E8
}

public enum BufferType
{
    ArrayBuffer = 0x8892,
    ElementArrayBuffer = 0x8893
}

public enum BufferParameter
{
    BufferSize = 0x8764,
    BufferUsage = 0x8765
}

public enum VertexAttribute
{
    CurrentVertexAttrib = 0x8626,
    VertexAttribArrayEnabled = 0x8622,
    VertexAttribArraySize = 0x8623,
    VertexAttribArrayStride = 0x8624,
    VertexAttribArrayType = 0x8625,
    VertexAttribArrayNormalized = 0x886A,
    VertexAttribArrayBufferBinding = 0x889F
}

public enum VertexAttributePointer
{
    VertexAttribArrayPointer = 0x8645
}

public enum Face
{
    Front = 0x0404,
    Back = 0x0405,
    FrontAndBack = 0x0408
}

public enum EnableCap
{
    CullFace = 0x0B44,
    Blend = 0x0BE2,
    DepthTest = 0x0B71,
    Dither = 0x0BD0,
    PolygonOffsetFill = 0x8037,
    SampleAlphaToCoverage = 0x809E,
    SampleCoverage = 0x80A0,
    ScissorTest = 0x0C11,
    StencilTest = 0x0B90
}

public enum Error
{
    NoError = 0,
    InvalidEnum = 0x0500,
    InvalidValue = 0x0501,
    InvalidOperation = 0x0502,
    OutOfMemory = 0x0505,
    ContextLostWebgl = 0x9242
}

public enum FrontFaceDirection
{
    Cw = 0x0900,
    Ccw = 0x0901
}

public enum HintMode
{
    DontCare = 0x1100,
    Fastest = 0x1101,
    Nicest = 0x1102
}

public enum HintTarget
{
    GenerateMipmapHint = 0x8192
}

public enum PixelFormat
{
    Alpha = 0x1906,
    Rgb = 0x1907,
    Rgba = 0x1908,
    Luminance = 0x1909,
    LuminanceAlpha = 0x190A
}

public enum PixelType
{
    UnsignedByte = 0x1401,
    UnsignedShort4444 = 0x8033,
    UnsignedShort5551 = 0x8034,
    UnsignedShort565 = 0x8363,
    Float = 0x1406
}

public enum ShaderType
{
    FragmentShader = 0x8B30,
    VertexShader = 0x8B31
}

public enum ShaderParameter
{
    CompileStatus = 0x8B81,
    DeleteStatus = 0x8B80,
    ShaderType = 0x8B4F
}

public enum ProgramParameter
{
    DeleteStatus = 0x8B80,
    LinkStatus = 0x8B82,
    ValidateStatus = 0x8B83,
    AttachedShaders = 0x8B85,
    ActiveAttributes = 0x8B89,
    ActiveUniforms = 0x8B86
}

public enum CompareFunction
{
    Never = 0x0200,
    Always = 0x0207,
    Less = 0x0201,
    Equal = 0x0202,
    Lequal = 0x0203,
    Greater = 0x0204,
    Gequal = 0x0206,
    Notequal = 0x0205
}

public enum StencilFunction
{
    Keep = 0x1E00,
    Replace = 0x1E01,
    Incr = 0x1E02,
    Decr = 0x1E03,
    Invert = 0x150A,
    IncrWrap = 0x8507,
    DecrWrap = 0x8508
}

public enum TextureType
{
    Texture2D = 0x0DE1,
    TextureCubeMap = 0x8513,
}

public enum Texture2DType
{
    Texture2D = 0x0DE1,
    TextureCubeMapPositiveX = 0x8515,
    TextureCubeMapNegativeX = 0x8516,
    TextureCubeMapPositiveY = 0x8517,
    TextureCubeMapNegativeY = 0x8518,
    TextureCubeMapPositiveZ = 0x8519,
    TextureCubeMapNegativeZ = 0x851A
}

public enum TextureParameter
{
    TextureMagFilter = 0x2800,
    TextureMinFilter = 0x2801,
    TextureWrapS = 0x2802,
    TextureWrapT = 0x2803
}

public enum TextureParameterValue
{
    Nearest = 0x2600,
    Linear = 0x2601,
    NearestMipmapNearest = 0x2700,
    LinearMipmapNearest = 0x2701,
    NearestMipmapLinear = 0x2702,
    LinearMipmapLinear = 0x2703,
    Repeat = 0x2901,
    ClampToEdge = 0x812F,
    MirroredRepeat = 0x8370
}

public enum UniformType
{
    FloatVec2 = 0x8B50,
    FloatVec3 = 0x8B51,
    FloatVec4 = 0x8B52,
    IntVec2 = 0x8B53,
    IntVec3 = 0x8B54,
    IntVec4 = 0x8B55,
    Bool = 0x8B56,
    BoolVec2 = 0x8B57,
    BoolVec3 = 0x8B58,
    BoolVec4 = 0x8B59,
    FloatMat2 = 0x8B5A,
    FloatMat3 = 0x8B5B,
    FloatMat4 = 0x8B5C,
    Sampler2D = 0x8B5E,
    SamplerCube = 0x8B60
}

public enum ShaderPrecision
{
    LowFloat = 0x8DF0,
    MediumFloat = 0x8DF1,
    HighFloat = 0x8DF2,
    LowInt = 0x8DF3,
    MediumInt = 0x8DF4,
    HighInt = 0x8DF5
}

public enum RenderbufferType
{
    Renderbuffer = 0x8D41
}

public enum FramebufferType
{
    Framebuffer = 0x8D40
}

public enum RenderbufferParameter
{
    RenderbufferWidth = 0x8D42,
    RenderbufferHeight = 0x8D43,
    RenderbufferInternalFormat = 0x8D44,
    RenderbufferRedSize = 0x8D50,
    RenderbufferGreenSize = 0x8D51,
    RenderbufferBlueSize = 0x8D52,
    RenderbufferAlphaSize = 0x8D53,
    RenderbufferDepthSize = 0x8D54,
    RenderbufferStencilSize = 0x8D55
}

public enum FramebufferAttachment
{
    ColorAttachment0 = 0x8CE0,
    DepthAttachment = 0x8D00,
    StencilAttachment = 0x8D20,
    DepthStencilAttachment = 0x821A
}

public enum FramebufferAttachmentParameter
{
    FramebufferAttachmentObjectType = 0x8CD0,
    FramebufferAttachmentObjectName = 0x8CD1,
    FramebufferAttachmentTextureLevel = 0x8CD2,
    FramebufferAttachmentTextureCubeMapFace = 0x8CD3
}

public enum FramebufferStatus
{
    None = 0,
    FramebufferComplete = 0x8CD5,
    FramebufferIncompleteAttachment = 0x8CD6,
    FramebufferIncompleteMissingAttachment = 0x8CD7,
    FramebufferIncompleteDimensions = 0x8CD9,
    FramebufferUnsupported = 0x8CDD
}

public enum PixelStorageMode
{
    UnpackFlipYWebgl = 0x9240,
    UnpackPremultiplyAlphaWebgl = 0x9241,
    UnpackColorspaceConversionWebgl = 0x9243
}

public enum RenderbufferFormat
{
    Rgba4 = 0x8056,
    Rgb5A1 = 0x8057,
    Rgb565 = 0x8D62,
    DepthComponent16 = 0x81A5,
    StencilIndex8 = 0x8D48,
    DepthStencil = 0x84F9
}

public enum DataType
{
    Byte = 0x1400,
    UnsignedByte = 0x1401,
    Short = 0x1402,
    UnsignedShort = 0x1403,
    Int = 0x1404,
    UnsignedInt = 0x1405,
    Float = 0x1406
}

public enum Texture
{
    Texture0 = 0x84C0,
    Texture1,
    Texture2,
    Texture3,
    Texture4,
    Texture5,
    Texture6,
    Texture7,
    Texture8,
    Texture9,
    Texture10,
    Texture11,
    Texture12,
    Texture13,
    Texture14,
    Texture15,
    Texture16,
    Texture17,
    Texture18,
    Texture19,
    Texture20,
    Texture21,
    Texture22,
    Texture23,
    Texture24,
    Texture25,
    Texture26,
    Texture27,
    Texture28,
    Texture29,
    Texture30,
    Texture31
}