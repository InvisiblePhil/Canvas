namespace Blazor.Extensions.WebGL
{
    public class WebGlContextAttributes
    {
        public bool Alpha { get; set; } = true;
        public bool Antialias { get; set; } = true;
        public bool Depth { get; set; } = true;
        public bool PremultipliedAlpha { get; set; } = true;
        public bool PreserveDrawingBuffer { get; set; } = false;
        public bool Stencil { get; set; } = false;
        public string PowerPreference { get; set; } = PowerPreferenceDefault;
        public bool FailIfMajorPerformanceCaveat { get; set; } = false;

        public const string PowerPreferenceDefault = "default";
        public const string PowerPreferenceHighPerformance = "high-performance";
        public const string PowerPreferenceLowPower = "low-power";
    }

    public class WebGlShaderPrecisionFormat
    {
        public int RangeMin { get; set; }
        public int RangeMax { get; set; }
        public int Precision { get; set; }
    }

    public class WebGlActiveInfo
    {
        public string Name { get; set; } //todo: make readonly
        public int Size { get; set; }
        public UniformType Type { get; set; }
    }

    public class WebGlObject
    {
        public string WebGlType { get; set; }
        public int Id { get; set; }
    }

    public class WebGlBuffer : WebGlObject
    { }

    public class WebGlFramebuffer : WebGlObject
    { }

    public class WebGlRenderbuffer : WebGlObject
    { }

    public class WebGlTexture : WebGlObject
    { }

    public class WebGlProgram : WebGlObject
    { }

    public class WebGlShader : WebGlObject
    { }

    public class WebGlUniformLocation : WebGlObject
    { }
}
