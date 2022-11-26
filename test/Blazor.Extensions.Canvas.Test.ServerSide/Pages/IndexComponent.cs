using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using Blazor.Extensions.Canvas2D;

namespace Blazor.Extensions.Canvas.Test.ServerSide.Pages
{
    public class IndexComponent : ComponentBase
    {
        private Canvas2DContext context;

        protected BECanvasComponent canvasReference;

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            this.context = await this.canvasReference.CreateCanvas2DAsync();
            await this.context.SetFillStyleAsync("green");

            await this.context.FillRectAsync(10, 100, 100, 100);

            await this.context.SetFontAsync("48px serif");
            await this.context.StrokeTextAsync("Hello Blazor!!!", 10, 100);
        }
    }
}
