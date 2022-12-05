using System.Threading.Tasks;
using Blazor.Extensions.Model;
using Microsoft.AspNetCore.Components;

namespace Blazor.Extensions.Canvas2D;

public class Canvas2DContext : RenderingContext
{
    #region Properties

    public object FillStyle { get; private set; } = "#000";

    public string StrokeStyle { get; private set; } = "#000";

    public string Font { get; private set; } = "10px sans-serif";

    public TextAlign TextAlign { get; private set; }

    public TextDirection Direction { get; private set; }

    public TextBaseline TextBaseline { get; private set; }

    public float LineWidth { get; private set; } = 1.0f;

    public LineCap LineCap { get; private set; }

    public LineJoin LineJoin { get; private set; }

    public float MiterLimit { get; private set; } = 10;

    public float LineDashOffset { get; private set; }

    public float ShadowBlur { get; private set; }

    public string ShadowColor { get; private set; } = "black";

    public float ShadowOffsetX { get; private set; }

    public float ShadowOffsetY { get; private set; }

    public float GlobalAlpha { get; private set; } = 1.0f;

    public string GlobalCompositeOperation { get; private set; } = "source-over";

    #endregion Properties

    public Canvas2DContext(BECanvasComponent reference) : base(reference, "Canvas2d")
    {
    }

    #region Property Setters

    public ValueTask SetFillStyleAsync(object value)
    {
        this.FillStyle = value;
        return this.BatchCallAsync("fillStyle", false, value);
    }

    public ValueTask SetStrokeStyleAsync(string value)
    {
        this.StrokeStyle = value;
        return this.BatchCallAsync("strokeStyle", isMethodCall: false, value);
    }

    public ValueTask SetFontAsync(string value)
    {
        this.Font = value;
        return this.BatchCallAsync("font", isMethodCall: false, value);
    }

    public ValueTask SetTextAlignAsync(TextAlign value)
    {
        this.TextAlign = value;
        return this.BatchCallAsync("textAlign", isMethodCall: false, value.ToString().ToLowerInvariant());
    }

    public ValueTask SetDirectionAsync(TextDirection value)
    {
        this.Direction = value;
        return this.BatchCallAsync("direction", isMethodCall: false, value.ToString().ToLowerInvariant());
    }

    public ValueTask SetTextBaselineAsync(TextBaseline value)
    {
        this.TextBaseline = value;
        return this.BatchCallAsync("textBaseline", isMethodCall: false, value.ToString().ToLowerInvariant());
    }

    public ValueTask SetLineWidthAsync(float value)
    {
        this.LineWidth = value;
        return this.BatchCallAsync("lineWidth", isMethodCall: false, value);
    }

    public ValueTask SetLineCapAsync(LineCap value)
    {
        this.LineCap = value;
        return this.BatchCallAsync("lineCap", isMethodCall: false, value.ToString().ToLowerInvariant());
    }

    public ValueTask SetLineJoinAsync(LineJoin value)
    {
        this.LineJoin = value;
        return this.BatchCallAsync("lineJoin", isMethodCall: false, value.ToString().ToLowerInvariant());
    }

    public ValueTask SetMiterLimitAsync(float value)
    {
        this.MiterLimit = value;
        return this.BatchCallAsync("miterLimit", isMethodCall: false, value.ToString().ToLowerInvariant());
    }

    public ValueTask SetLineDashOffsetAsync(float value)
    {
        this.LineDashOffset = value;
        return this.BatchCallAsync("lineDashOffset", isMethodCall: false, value);
    }

    public ValueTask SetShadowBlurAsync(float value)
    {
        this.ShadowBlur = value;
        return this.BatchCallAsync("shadowBlur", isMethodCall: false, value);
    }

    public ValueTask SetShadowColorAsync(string value)
    {
        this.ShadowColor = value;
        return this.BatchCallAsync("shadowColor", isMethodCall: false, value);
    }

    public ValueTask SetShadowOffsetXAsync(float value)
    {
        this.ShadowOffsetX = value;
        return this.BatchCallAsync("shadowOffsetX", isMethodCall: false, value);
    }

    public ValueTask SetShadowOffsetYAsync(float value)
    {
        this.ShadowOffsetY = value;
        return this.BatchCallAsync("shadowOffsetY", isMethodCall: false, value);
    }

    public ValueTask SetGlobalAlphaAsync(float value)
    {
        this.GlobalAlpha = value;
        return this.BatchCallAsync("globalAlpha", isMethodCall: false, value);
    }

    public ValueTask SetGlobalCompositeOperationAsync(string value)
    {
        this.GlobalCompositeOperation = value;
        return this.BatchCallAsync("globalCompositeOperation", isMethodCall: false, value);
    }

    #endregion Property Setters

    #region Methods

    public ValueTask FillRectAsync(double x, double y, double width, double height) => this.BatchCallAsync("fillRect", isMethodCall: true, x, y, width, height);

    public ValueTask ClearRectAsync(double x, double y, double width, double height) => this.BatchCallAsync("clearRect", isMethodCall: true, x, y, width, height);

    public ValueTask StrokeRectAsync(double x, double y, double width, double height) => this.BatchCallAsync("strokeRect", isMethodCall: true, x, y, width, height);

    public ValueTask FillTextAsync(string text, double x, double y, double? maxWidth = null) => this.BatchCallAsync("fillText", isMethodCall: true, maxWidth.HasValue ? new object[] { text, x, y, maxWidth.Value } : new object[] { text, x, y });

    public ValueTask StrokeTextAsync(string text, double x, double y, double? maxWidth = null) => this.BatchCallAsync("strokeText", isMethodCall: true, maxWidth.HasValue ? new object[] { text, x, y, maxWidth.Value } : new object[] { text, x, y });

    public ValueTask<TextMetrics> MeasureTextAsync(string text) => this.CallMethodAsync<TextMetrics>("measureText", text);

    public ValueTask<float[]> GetLineDashAsync() => this.CallMethodAsync<float[]>("getLineDash");

    public ValueTask SetLineDashAsync(float[] segments) => this.BatchCallAsync("setLineDash", isMethodCall: true, segments);

    public ValueTask BeginPathAsync() => this.BatchCallAsync("beginPath", isMethodCall: true);

    public ValueTask ClosePathAsync() => this.BatchCallAsync("closePath", isMethodCall: true);

    public ValueTask MoveToAsync(double x, double y) => this.BatchCallAsync("moveTo", isMethodCall: true, x, y);

    public ValueTask LineToAsync(double x, double y) => this.BatchCallAsync("lineTo", isMethodCall: true, x, y);

    public ValueTask BezierCurveToAsync(double cp1X, double cp1Y, double cp2X, double cp2Y, double x, double y) => this.BatchCallAsync("bezierCurveTo", isMethodCall: true, cp1X, cp1Y, cp2X, cp2Y, x, y);

    public ValueTask QuadraticCurveToAsync(double cpx, double cpy, double x, double y) => this.BatchCallAsync("quadraticCurveTo", isMethodCall: true, cpx, cpy, x, y);

    public ValueTask ArcAsync(double x, double y, double radius, double startAngle, double endAngle, bool? anticlockwise = null) => this.BatchCallAsync("arc", isMethodCall: true, anticlockwise.HasValue ? new object[] { x, y, radius, startAngle, endAngle, anticlockwise.Value } : new object[] { x, y, radius, startAngle, endAngle });

    public ValueTask ArcToAsync(double x1, double y1, double x2, double y2, double radius) => this.BatchCallAsync("arcTo", isMethodCall: true, x1, y1, x2, y2, radius);

    public ValueTask RectAsync(double x, double y, double width, double height) => this.BatchCallAsync("rect", isMethodCall: true, x, y, width, height);

    public ValueTask EllipseAsync(double x, double y, double radiusX, double radiusY, double startAngle, double endAngle, bool counterClockwise = false) => this.BatchCallAsync("ellipse", isMethodCall: true, x, y, radiusX, radiusY, startAngle, endAngle, counterClockwise);

    public ValueTask FillAsync() => this.BatchCallAsync("fill", isMethodCall: true);

    public ValueTask StrokeAsync() => this.BatchCallAsync("stroke", isMethodCall: true);

    public ValueTask DrawFocusIfNeededAsync(ElementReference elementReference) => this.BatchCallAsync("drawFocusIfNeeded", isMethodCall: true, elementReference);

    public ValueTask ScrollPathIntoViewAsync() => this.BatchCallAsync("scrollPathIntoView", isMethodCall: true);

    public ValueTask ClipAsync() => this.BatchCallAsync("clip", isMethodCall: true);

    public ValueTask<bool> IsPointInPathAsync(double x, double y) => this.CallMethodAsync<bool>("isPointInPath", x, y);

    public ValueTask<bool> IsPointInStrokeAsync(double x, double y) => this.CallMethodAsync<bool>("isPointInStroke", x, y);

    public ValueTask RotateAsync(float angle) => this.BatchCallAsync("rotate", isMethodCall: true, angle);

    public ValueTask ScaleAsync(double x, double y) => this.BatchCallAsync("scale", isMethodCall: true, x, y);

    public ValueTask TranslateAsync(double x, double y) => this.BatchCallAsync("translate", isMethodCall: true, x, y);

    public ValueTask TransformAsync(double m11, double m12, double m21, double m22, double dx, double dy) => this.BatchCallAsync("transform", isMethodCall: true, m11, m12, m21, m22, dx, dy);

    public ValueTask SetTransformAsync(double m11, double m12, double m21, double m22, double dx, double dy) => this.BatchCallAsync("setTransform", isMethodCall: true, m11, m12, m21, m22, dx, dy);

    public ValueTask SaveAsync() => this.BatchCallAsync("save", isMethodCall: true);

    public ValueTask RestoreAsync() => this.BatchCallAsync("restore", isMethodCall: true);

    public ValueTask DrawImageAsync(ElementReference elementReference, double dx, double dy) => this.BatchCallAsync("drawImage", isMethodCall: true, elementReference, dx, dy);
    public ValueTask DrawImageAsync(ElementReference elementReference, double dx, double dy, double dWidth, double dHeight) => this.BatchCallAsync("drawImage", isMethodCall: true, elementReference, dx, dy, dWidth, dHeight);
    public ValueTask DrawImageAsync(ElementReference elementReference, double sx, double sy, double sWidth, double sHeight, double dx, double dy, double dWidth, double dHeight) => this.BatchCallAsync("drawImage", isMethodCall: true, elementReference, sx, sy, sWidth, sHeight, dx, dy, dWidth, dHeight);

    private readonly string[] repeatNames = {
        "repeat", "repeat-x", "repeat-y", "no-repeat"
    };
    public ValueTask<object> CreatePatternAsync(ElementReference image, RepeatPattern repeat) => this.CallMethodAsync<object>("createPattern", image, this.repeatNames[(int)repeat]);

    #endregion Methods
}