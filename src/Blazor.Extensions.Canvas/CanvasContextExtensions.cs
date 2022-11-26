using System.Threading.Tasks;
using Blazor.Extensions.Canvas2D;
using Blazor.Extensions.WebGL;

namespace Blazor.Extensions
{
    public static class CanvasContextExtensions
    {
        public static Canvas2DContext CreateCanvas2D(this BECanvasComponent canvas)
        {
            return new Canvas2DContext(canvas).InitializeAsync().GetAwaiter().GetResult() as Canvas2DContext;
        }

        public static async Task<Canvas2DContext> CreateCanvas2DAsync(this BECanvasComponent canvas)
        {
            return await new Canvas2DContext(canvas).InitializeAsync().ConfigureAwait(false) as Canvas2DContext;
        }

        public static WebGlContext CreateWebGl(this BECanvasComponent canvas)
        {
            return new WebGlContext(canvas).InitializeAsync().GetAwaiter().GetResult() as WebGlContext;
        }

        public static async Task<WebGlContext> CreateWebGlAsync(this BECanvasComponent canvas)
        {
            return await new WebGlContext(canvas).InitializeAsync().ConfigureAwait(false) as WebGlContext;
        }

        public static WebGlContext CreateWebGl(this BECanvasComponent canvas, WebGlContextAttributes attributes)
        {
            return new WebGlContext(canvas, attributes).InitializeAsync().GetAwaiter().GetResult() as WebGlContext;
        }

        public static async Task<WebGlContext> CreateWebGlAsync(this BECanvasComponent canvas, WebGlContextAttributes attributes)
        {
            return await new WebGlContext(canvas, attributes).InitializeAsync().ConfigureAwait(false) as WebGlContext;
        }
    }
}
