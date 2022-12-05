using System.Threading.Tasks;
using Blazor.Extensions.Canvas2D;
using Blazor.Extensions.WebGL;

namespace Blazor.Extensions;

public static class CanvasContextExtensions
{
    public static async ValueTask<Canvas2DContext> CreateCanvas2DAsync(this BECanvasComponent canvas)
    {
        return await new Canvas2DContext(canvas).InitializeAsync().ConfigureAwait(false) as Canvas2DContext;
    }

    public static async ValueTask<WebGlContext> CreateWebGlAsync(this BECanvasComponent canvas)
    {
        return await new WebGlContext(canvas).InitializeAsync().ConfigureAwait(false) as WebGlContext;
    }

    public static async ValueTask<WebGlContext> CreateWebGlAsync(this BECanvasComponent canvas, WebGlContextAttributes attributes)
    {
        return await new WebGlContext(canvas, attributes).InitializeAsync().ConfigureAwait(false) as WebGlContext;
    }
}