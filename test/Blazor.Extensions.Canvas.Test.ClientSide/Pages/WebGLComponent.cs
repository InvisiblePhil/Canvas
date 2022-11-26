using System;
using System.Threading.Tasks;
using Blazor.Extensions.WebGL;
using Microsoft.AspNetCore.Components;

namespace Blazor.Extensions.Canvas.Test.ClientSide.Pages
{
    public class WebGlComponent : ComponentBase
    {
        private WebGlContext context;

        protected BECanvasComponent canvasReference;

        private const string VsSource = "attribute vec3 aPos;" +
                                         "attribute vec3 aColor;" +
                                         "varying vec3 vColor;" +

                                         "void main() {" +
                                            "gl_Position = vec4(aPos, 1.0);" +
                                            "vColor = aColor;" +
                                         "}";

        private const string FsSource = "precision mediump float;" +
                                         "varying vec3 vColor;" +

                                         "void main() {" +
                                            "gl_FragColor = vec4(vColor, 1.0);" +
                                         "}";

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            this.context = await this.canvasReference.CreateWebGlAsync(new WebGlContextAttributes
            {
                PowerPreference = WebGlContextAttributes.PowerPreferenceHighPerformance
            });

            await this.context.ClearColorAsync(0, 0, 0, 1);
            await this.context.ClearAsync(BufferBits.ColorBufferBit);

            var program = await this.InitProgramAsync(this.context, VsSource, FsSource);

            var vertexBuffer = await this.context.CreateBufferAsync();
            await this.context.BindBufferAsync(BufferType.ArrayBuffer, vertexBuffer);

            var vertices = new[]
            {
                -0.5f, -0.5f, 0.0f, 1.0f, 0.0f, 0.0f,
                0.5f, -0.5f, 0.0f, 0.0f, 1.0f, 0.0f,
                0.0f,  0.5f, 0.0f, 0.0f, 0.0f, 1.0f
            };
            await this.context.BufferDataAsync(BufferType.ArrayBuffer, vertices, BufferUsageHint.StaticDraw);

            await this.context.VertexAttribPointerAsync(0, 3, DataType.Float, false, 6 * sizeof(float), 0);
            await this.context.VertexAttribPointerAsync(1, 3, DataType.Float, false, 6 * sizeof(float), 3 * sizeof(float));
            await this.context.EnableVertexAttribArrayAsync(0);
            await this.context.EnableVertexAttribArrayAsync(1);

            await this.context.UseProgramAsync(program);

            await this.context.DrawArraysAsync(Primitive.Triangles, 0, 3);
        }

        private async Task<WebGlProgram> InitProgramAsync(WebGlContext gl, string vsSource, string fsSource)
        {
            var vertexShader = await this.LoadShaderAsync(gl, ShaderType.VertexShader, vsSource);
            var fragmentShader = await this.LoadShaderAsync(gl, ShaderType.FragmentShader, fsSource);

            var program = await gl.CreateProgramAsync();
            await gl.AttachShaderAsync(program, vertexShader);
            await gl.AttachShaderAsync(program, fragmentShader);
            await gl.LinkProgramAsync(program);

            await gl.DeleteShaderAsync(vertexShader);
            await gl.DeleteShaderAsync(fragmentShader);

            if (!await gl.GetProgramParameterAsync<bool>(program, ProgramParameter.LinkStatus))
            {
                string info = await gl.GetProgramInfoLogAsync(program);
                throw new Exception("An error occured while linking the program: " + info);
            }

            return program;
        }

        private async Task<WebGlShader> LoadShaderAsync(WebGlContext gl, ShaderType type, string source)
        {
            var shader = await gl.CreateShaderAsync(type);

            await gl.ShaderSourceAsync(shader, source);
            await gl.CompileShaderAsync(shader);

            if (!await gl.GetShaderParameterAsync<bool>(shader, ShaderParameter.CompileStatus))
            {
                string info = await gl.GetShaderInfoLogAsync(shader);
                await gl.DeleteShaderAsync(shader);
                throw new Exception("An error occured while compiling the shader: " + info);
            }

            return shader;
        }
    }
}
