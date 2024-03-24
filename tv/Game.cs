using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL;
using OpenTK;
using OpenTK.Graphics;
using System.Drawing;

namespace tv
{
    namespace television
    {
        public class Game : GameWindow
        {
            int vertexBufferObject;
            public Game(int width = 1280, int height = 768, string title = "TV") : base(width, height, GraphicsMode.Default, title)
            {
                Title = title;
                Size = new Size(width, height);
            }

            protected override void OnResize(EventArgs e)
            {
                GL.Viewport(0, 0, Width, Height);
                base.OnResize(e);
            }

            protected override void OnLoad(EventArgs e)
            {
                GL.ClearColor(Color4.SteelBlue);
                this.vertexBufferObject = GL.GenBuffer();
                GL.BindBuffer(BufferTarget.ArrayBuffer, this.vertexBufferObject);              
                base.OnLoad(e);
            }

            protected override void OnUnload(EventArgs e)
            {
                GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
                GL.DeleteBuffer(this.vertexBufferObject);
                base.OnUnload(e);
            }

            protected override void OnUpdateFrame(FrameEventArgs args)
            {
                base.OnUpdateFrame(args);
            }

            protected override void OnRenderFrame(FrameEventArgs args)
            {
                GL.Clear(ClearBufferMask.ColorBufferBit);
                GL.BindBuffer(BufferTarget.ArrayBuffer, this.vertexBufferObject);
                GL.VertexAttribPointer(0, 2, VertexAttribPointerType.Float, false, 0, 0);

                // Definir una matriz de proyección perspectiva
                Matrix4 perspective = Matrix4.CreatePerspectiveFieldOfView(MathHelper.PiOver4, (float)Width / Height, 0.1f, 100f);
                GL.MatrixMode(MatrixMode.Projection);
                GL.LoadMatrix(ref perspective);

                // Definir una matriz de vista para simular una cámara que observa la TV desde una posición y orientación específicas
                Matrix4 view = Matrix4.LookAt(new Vector3(0, 0, 3), Vector3.Zero, Vector3.UnitY);
                GL.MatrixMode(MatrixMode.Modelview);
                GL.LoadMatrix(ref view);


                // Dibujar la TV
                DrawTV();

                this.Context.SwapBuffers();
                base.OnRenderFrame(args);
            }

            private void DrawTV()
            {
                // Dibujar el marco de la televisión (rectángulo exterior)
                GL.Color4(Color4.Gray);
                GL.Begin(PrimitiveType.Quads);
                GL.Vertex3(-0.6f, -0.4f, 0);
                GL.Vertex3(0.6f, -0.4f, 0);
                GL.Vertex3(0.6f, 0.4f, 0);
                GL.Vertex3(-0.6f, 0.4f, 0);
                GL.End();

                // Dibujar la pantalla de la televisión (rectángulo interior)
                GL.Color4(Color4.Black);
                GL.Begin(PrimitiveType.Quads);
                GL.Vertex3(-0.4f, -0.3f, 0);
                GL.Vertex3(0.4f, -0.3f, 0);
                GL.Vertex3(0.4f, 0.3f, 0);
                GL.Vertex3(-0.4f, 0.3f, 0);
                GL.End();

                // Dibujar las patas de la televisión (dos rectángulos)
                GL.Color4(Color4.Gray);
                GL.Begin(PrimitiveType.Quads);
                GL.Vertex3(-0.6f, -0.5f, 0);
                GL.Vertex3(-0.5f, -0.5f, 0);
                GL.Vertex3(-0.5f, -0.4f, 0);
                GL.Vertex3(-0.6f, -0.4f, 0);

                GL.Vertex3(0.5f, -0.5f, 0);
                GL.Vertex3(0.6f, -0.5f, 0);
                GL.Vertex3(0.6f, -0.4f, 0);
                GL.Vertex3(0.5f, -0.4f, 0);
                GL.End();
            }
        }
        
    }
    
}
