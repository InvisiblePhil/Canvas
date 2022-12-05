using System;
using System.Threading.Tasks;
using Blazor.Extensions.Model;
using Microsoft.AspNetCore.Components;

namespace Blazor.Extensions.Canvas2D
{
    public class Canvas2DContext : RenderingContext
    {
        #region Constants
        private const string ContextName = "Canvas2d";
        private const string FillStyleProperty = "fillStyle";
        private const string StrokeStyleProperty = "strokeStyle";
        private const string FillRectMethod = "fillRect";
        private const string ClearRectMethod = "clearRect";
        private const string StrokeRectMethod = "strokeRect";
        private const string FillTextMethod = "fillText";
        private const string StrokeTextMethod = "strokeText";
        private const string MeasureTextMethod = "measureText";
        private const string LineWidthProperty = "lineWidth";
        private const string LineCapProperty = "lineCap";
        private const string LineJoinProperty = "lineJoin";
        private const string MiterLimitProperty = "miterLimit";
        private const string GetLineDashMethod = "getLineDash";
        private const string SetLineDashMethod = "setLineDash";
        private const string LineDashOffsetProperty = "lineDashOffset";
        private const string ShadowBlurProperty = "shadowBlur";
        private const string ShadowColorProperty = "shadowColor";
        private const string ShadowOffsetXProperty = "shadowOffsetX";
        private const string ShadowOffsetYProperty = "shadowOffsetY";
        private const string BeginPathMethod = "beginPath";
        private const string ClosePathMethod = "closePath";
        private const string MoveToMethod = "moveTo";
        private const string LineToMethod = "lineTo";
        private const string BezierCurveToMethod = "bezierCurveTo";
        private const string QuadraticCurveToMethod = "quadraticCurveTo";
        private const string ArcMethod = "arc";
        private const string ArcToMethod = "arcTo";
        private const string RectMethod = "rect";
        private const string EllipseMethod = "ellipse";
        private const string FillMethod = "fill";
        private const string StrokeMethod = "stroke";
        private const string DrawFocusIfNeededMethod = "drawFocusIfNeeded";
        private const string ScrollPathIntoViewMethod = "scrollPathIntoView";
        private const string ClipMethod = "clip";
        private const string IsPointInPathMethod = "isPointInPath";
        private const string IsPointInStrokeMethod = "isPointInStroke";
        private const string RotateMethod = "rotate";
        private const string ScaleMethod = "scale";
        private const string TranslateMethod = "translate";
        private const string TransformMethod = "transform";
        private const string SetTransformMethod = "setTransform";
        private const string GlobalAlphaProperty = "globalAlpha";
        private const string SaveMethod = "save";
        private const string RestoreMethod = "restore";
        private const string DrawImageMethod = "drawImage";
        private const string CreatePatternMethod = "createPattern";
        private const string GlobalCompositeOperationProperty = "globalCompositeOperation";

        private readonly string[] repeatNames = new[]
        {
            "repeat", "repeat-x", "repeat-y", "no-repeat"
        };

        #endregion

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

        public Canvas2DContext(BECanvasComponent reference) : base(reference, ContextName)
        {
        }

        #region Property Setters

        public async Task SetFillStyleAsync(object value)
        {
            this.FillStyle = value;
            await this.BatchCallAsync(FillStyleProperty, false, value);
        }

        public async Task SetStrokeStyleAsync(string value)
        {
            this.StrokeStyle = value;
            await this.BatchCallAsync(StrokeStyleProperty, isMethodCall: false, value);
        }

        public async Task SetFontAsync(string value)
        {
            this.Font = value;
            await this.BatchCallAsync("font", isMethodCall: false, value);
        }

        public async Task SetTextAlignAsync(TextAlign value)
        {
            this.TextAlign = value;
            await this.BatchCallAsync("textAlign", isMethodCall: false, value.ToString().ToLowerInvariant());
        }

        public async Task SetDirectionAsync(TextDirection value)
        {
            this.Direction = value;
            await this.BatchCallAsync("direction", isMethodCall: false, value.ToString().ToLowerInvariant());
        }

        public async Task SetTextBaselineAsync(TextBaseline value)
        {
            this.TextBaseline = value;
            await this.BatchCallAsync("textBaseline", isMethodCall: false, value.ToString().ToLowerInvariant());
        }

        public async Task SetLineWidthAsync(float value)
        {
            this.LineWidth = value;
            await this.BatchCallAsync(LineWidthProperty, isMethodCall: false, value);
        }

        public async Task SetLineCapAsync(LineCap value)
        {
            this.LineCap = value;
            await this.BatchCallAsync(LineCapProperty, isMethodCall: false, value.ToString().ToLowerInvariant());
        }

        public async Task SetLineJoinAsync(LineJoin value)
        {
            this.LineJoin = value;
            await this.BatchCallAsync(LineJoinProperty, isMethodCall: false, value.ToString().ToLowerInvariant());
        }

        public async Task SetMiterLimitAsync(float value)
        {
            this.MiterLimit = value;
            await this.BatchCallAsync(MiterLimitProperty, isMethodCall: false, value.ToString().ToLowerInvariant());
        }

        public async Task SetLineDashOffsetAsync(float value)
        {
            this.LineDashOffset = value;
            await this.BatchCallAsync(LineDashOffsetProperty, isMethodCall: false, value);
        }

        public async Task SetShadowBlurAsync(float value)
        {
            this.ShadowBlur = value;
            await this.BatchCallAsync(ShadowBlurProperty, isMethodCall: false, value);
        }

        public async Task SetShadowColorAsync(string value)
        {
            this.ShadowColor = value;
            await this.BatchCallAsync(ShadowColorProperty, isMethodCall: false, value);
        }

        public async Task SetShadowOffsetXAsync(float value)
        {
            this.ShadowOffsetX = value;
            await this.BatchCallAsync(ShadowOffsetXProperty, isMethodCall: false, value);
        }

        public async Task SetShadowOffsetYAsync(float value)
        {
            this.ShadowOffsetY = value;
            await this.BatchCallAsync(ShadowOffsetYProperty, isMethodCall: false, value);
        }

        public async Task SetGlobalAlphaAsync(float value)
        {
            this.GlobalAlpha = value;
            await this.BatchCallAsync(GlobalAlphaProperty, isMethodCall: false, value);
        }

        public async Task SetGlobalCompositeOperationAsync(string value)
        {
            this.GlobalCompositeOperation = value;
            await this.BatchCallAsync(GlobalCompositeOperationProperty, isMethodCall: false, value);
        }

        #endregion Property Setters

        #region Methods

        [Obsolete("Use the async version instead, which is already called internally.")]
        public void FillRect(double x, double y, double width, double height) => this.CallMethod<object>(FillRectMethod, x, y, width, height);
        public async Task FillRectAsync(double x, double y, double width, double height) => await this.BatchCallAsync(FillRectMethod, isMethodCall: true, x, y, width, height);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public void ClearRect(double x, double y, double width, double height) => this.CallMethod<object>(ClearRectMethod, x, y, width, height);
        public async Task ClearRectAsync(double x, double y, double width, double height) => await this.BatchCallAsync(ClearRectMethod, isMethodCall: true, x, y, width, height);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public void StrokeRect(double x, double y, double width, double height) => this.CallMethod<object>(StrokeRectMethod, x, y, width, height);
        public async Task StrokeRectAsync(double x, double y, double width, double height) => await this.BatchCallAsync(StrokeRectMethod, isMethodCall: true, x, y, width, height);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public void FillText(string text, double x, double y, double? maxWidth = null) => this.CallMethod<object>(FillTextMethod, maxWidth.HasValue ? new object[] { text, x, y, maxWidth.Value } : new object[] { text, x, y });
        public async Task FillTextAsync(string text, double x, double y, double? maxWidth = null) => await this.BatchCallAsync(FillTextMethod, isMethodCall: true, maxWidth.HasValue ? new object[] { text, x, y, maxWidth.Value } : new object[] { text, x, y });

        [Obsolete("Use the async version instead, which is already called internally.")]
        public void StrokeText(string text, double x, double y, double? maxWidth = null) => this.CallMethod<object>(StrokeTextMethod, maxWidth.HasValue ? new object[] { text, x, y, maxWidth.Value } : new object[] { text, x, y });
        public async Task StrokeTextAsync(string text, double x, double y, double? maxWidth = null) => await this.BatchCallAsync(StrokeTextMethod, isMethodCall: true, maxWidth.HasValue ? new object[] { text, x, y, maxWidth.Value } : new object[] { text, x, y });

        [Obsolete("Use the async version instead, which is already called internally.")]
        public TextMetrics MeasureText(string text) => this.CallMethod<TextMetrics>(MeasureTextMethod, text);
        public async Task<TextMetrics> MeasureTextAsync(string text) => await this.CallMethodAsync<TextMetrics>(MeasureTextMethod, text);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public float[] GetLineDash() => this.CallMethod<float[]>(GetLineDashMethod);
        public async Task<float[]> GetLineDashAsync() => await this.CallMethodAsync<float[]>(GetLineDashMethod);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public void SetLineDash(float[] segments) => this.CallMethod<object>(SetLineDashMethod, segments);
        public async Task SetLineDashAsync(float[] segments) => await this.BatchCallAsync(SetLineDashMethod, isMethodCall: true, segments);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public void BeginPath() => this.CallMethod<object>(BeginPathMethod);
        public async Task BeginPathAsync() => await this.BatchCallAsync(BeginPathMethod, isMethodCall: true);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public void ClosePath() => this.CallMethod<object>(ClosePathMethod);
        public async Task ClosePathAsync() => await this.BatchCallAsync(ClosePathMethod, isMethodCall: true);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public void MoveTo(double x, double y) => this.CallMethod<object>(MoveToMethod, x, y);
        public async Task MoveToAsync(double x, double y) => await this.BatchCallAsync(MoveToMethod, isMethodCall: true, x, y);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public void LineTo(double x, double y) => this.CallMethod<object>(LineToMethod, x, y);
        public async Task LineToAsync(double x, double y) => await this.BatchCallAsync(LineToMethod, isMethodCall: true, x, y);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public void BezierCurveTo(double cp1X, double cp1Y, double cp2X, double cp2Y, double x, double y) => this.CallMethod<object>(BezierCurveToMethod, cp1X, cp1Y, cp2X, cp2Y, x, y);
        public async Task BezierCurveToAsync(double cp1X, double cp1Y, double cp2X, double cp2Y, double x, double y) => await this.BatchCallAsync(BezierCurveToMethod, isMethodCall: true, cp1X, cp1Y, cp2X, cp2Y, x, y);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public void QuadraticCurveTo(double cpx, double cpy, double x, double y) => this.CallMethod<object>(QuadraticCurveToMethod, cpx, cpy, x, y);
        public async Task QuadraticCurveToAsync(double cpx, double cpy, double x, double y) => await this.BatchCallAsync(QuadraticCurveToMethod, isMethodCall: true, cpx, cpy, x, y);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public void Arc(double x, double y, double radius, double startAngle, double endAngle, bool? anticlockwise = null) => this.CallMethod<object>(ArcMethod, anticlockwise.HasValue ? new object[] { x, y, radius, startAngle, endAngle, anticlockwise.Value } : new object[] { x, y, radius, startAngle, endAngle });
        public async Task ArcAsync(double x, double y, double radius, double startAngle, double endAngle, bool? anticlockwise = null) => await this.BatchCallAsync(ArcMethod, isMethodCall: true, anticlockwise.HasValue ? new object[] { x, y, radius, startAngle, endAngle, anticlockwise.Value } : new object[] { x, y, radius, startAngle, endAngle });

        [Obsolete("Use the async version instead, which is already called internally.")]
        public void ArcTo(double x1, double y1, double x2, double y2, double radius) => this.CallMethod<object>(ArcToMethod, x1, y1, x2, y2, radius);
        public async Task ArcToAsync(double x1, double y1, double x2, double y2, double radius) => await this.BatchCallAsync(ArcToMethod, isMethodCall: true, x1, y1, x2, y2, radius);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public void Rect(double x, double y, double width, double height) => this.CallMethod<object>(RectMethod, x, y, width, height);
        public async Task RectAsync(double x, double y, double width, double height) => await this.BatchCallAsync(RectMethod, isMethodCall: true, x, y, width, height);

        public async Task EllipseAsync(double x, double y, double radiusX, double radiusY, double startAngle, double endAngle, bool counterClockwise = false) => await this.BatchCallAsync(EllipseMethod, isMethodCall: true, x, y, radiusX, radiusY, startAngle, endAngle, counterClockwise);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public void Fill() => this.CallMethod<object>(FillMethod);
        public async Task FillAsync() => await this.BatchCallAsync(FillMethod, isMethodCall: true);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public void Stroke() => this.CallMethod<object>(StrokeMethod);
        public async Task StrokeAsync() => await this.BatchCallAsync(StrokeMethod, isMethodCall: true);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public void DrawFocusIfNeeded(ElementReference elementReference) => this.CallMethod<object>(DrawFocusIfNeededMethod, elementReference);
        public async Task DrawFocusIfNeededAsync(ElementReference elementReference) => await this.BatchCallAsync(DrawFocusIfNeededMethod, isMethodCall: true, elementReference);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public void ScrollPathIntoView() => this.CallMethod<object>(ScrollPathIntoViewMethod);
        public async Task ScrollPathIntoViewAsync() => await this.BatchCallAsync(ScrollPathIntoViewMethod, isMethodCall: true);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public void Clip() => this.CallMethod<object>(ClipMethod);
        public async Task ClipAsync() => await this.BatchCallAsync(ClipMethod, isMethodCall: true);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public bool IsPointInPath(double x, double y) => this.CallMethod<bool>(IsPointInPathMethod, x, y);
        public async Task<bool> IsPointInPathAsync(double x, double y) => await this.CallMethodAsync<bool>(IsPointInPathMethod, x, y);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public bool IsPointInStroke(double x, double y) => this.CallMethod<bool>(IsPointInStrokeMethod, x, y);
        public async Task<bool> IsPointInStrokeAsync(double x, double y) => await this.CallMethodAsync<bool>(IsPointInStrokeMethod, x, y);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public void Rotate(float angle) => this.CallMethod<object>(RotateMethod, angle);
        public async Task RotateAsync(float angle) => await this.BatchCallAsync(RotateMethod, isMethodCall: true, angle);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public void Scale(double x, double y) => this.CallMethod<object>(ScaleMethod, x, y);
        public async Task ScaleAsync(double x, double y) => await this.BatchCallAsync(ScaleMethod, isMethodCall: true, x, y);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public void Translate(double x, double y) => this.CallMethod<object>(TranslateMethod, x, y);
        public async Task TranslateAsync(double x, double y) => await this.BatchCallAsync(TranslateMethod, isMethodCall: true, x, y);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public void Transform(double m11, double m12, double m21, double m22, double dx, double dy) => this.CallMethod<object>(TransformMethod, m11, m12, m21, m22, dx, dy);
        public async Task TransformAsync(double m11, double m12, double m21, double m22, double dx, double dy) => await this.BatchCallAsync(TransformMethod, isMethodCall: true, m11, m12, m21, m22, dx, dy);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public void SetTransform(double m11, double m12, double m21, double m22, double dx, double dy) => this.CallMethod<object>(SetTransformMethod, m11, m12, m21, m22, dx, dy);
        public async Task SetTransformAsync(double m11, double m12, double m21, double m22, double dx, double dy) => await this.BatchCallAsync(SetTransformMethod, isMethodCall: true, m11, m12, m21, m22, dx, dy);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public void Save() => this.CallMethod<object>(SaveMethod);
        public async Task SaveAsync() => await this.BatchCallAsync(SaveMethod, isMethodCall: true);

        [Obsolete("Use the async version instead, which is already called internally.")]
        public void Restore() => this.CallMethod<object>(RestoreMethod);
        public async Task RestoreAsync() => await this.BatchCallAsync(RestoreMethod, isMethodCall: true);

        public async Task DrawImageAsync(ElementReference elementReference, double dx, double dy) => await this.BatchCallAsync(DrawImageMethod, isMethodCall: true, elementReference, dx, dy);
        public async Task DrawImageAsync(ElementReference elementReference, double dx, double dy, double dWidth, double dHeight) => await this.BatchCallAsync(DrawImageMethod, isMethodCall: true, elementReference, dx, dy, dWidth, dHeight);
        public async Task DrawImageAsync(ElementReference elementReference, double sx, double sy, double sWidth, double sHeight, double dx, double dy, double dWidth, double dHeight) => await this.BatchCallAsync(DrawImageMethod, isMethodCall: true, elementReference, sx, sy, sWidth, sHeight, dx, dy, dWidth, dHeight);

        public async Task<object> CreatePatternAsync(ElementReference image, RepeatPattern repeat) => await this.CallMethodAsync<object>(CreatePatternMethod, image, this.repeatNames[(int)repeat]);

        #endregion Methods
    }
}
