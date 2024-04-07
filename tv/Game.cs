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
                // Definir una matriz de proyección perspectiva
                Matrix4 perspective = Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(45.0f), (float)Width / Height, 0.1f, 100.0f);
                GL.MatrixMode(MatrixMode.Projection);
                GL.LoadMatrix(ref perspective);

                ////// Definir una matriz de proyección ortográfica
                //Matrix4 ortho = Matrix4.CreateOrthographic(Width, Height, -1f, 1f); // Ajusta los valores de la proyección según sea necesario
                //GL.MatrixMode(MatrixMode.Projection);
                //GL.LoadMatrix(ref ortho);

                float aspectRatio = (float)Width / Height;
                Matrix4 projection = Matrix4.CreatePerspectiveFieldOfView(
                    MathHelper.DegreesToRadians(45.0f), aspectRatio, 0.1f, 100.0f);
                GL.MatrixMode(MatrixMode.Projection);
                GL.LoadMatrix(ref projection);
                GL.MatrixMode(MatrixMode.Modelview);
                GL.LoadIdentity();


                // Definir una matriz de vista para simular una cámara que observa la TV desde una posición y orientación específicas
                Matrix4 view = Matrix4.LookAt(new Vector3(3, 1, 2), Vector3.Zero, Vector3.UnitY);
                GL.MatrixMode(MatrixMode.Modelview);
                GL.LoadMatrix(ref view);


                base.OnResize(e);
            }

            protected override void OnLoad(EventArgs e)
            {
                GL.ClearColor(Color4.SteelBlue); //Color de fondo
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
               
                GL.Clear(ClearBufferMask.ColorBufferBit|ClearBufferMask.DepthBufferBit);
                GL.BindBuffer(BufferTarget.ArrayBuffer, this.vertexBufferObject);

                GL.Enable(EnableCap.DepthTest);

                //GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 0, 0);

                GL.Rotate(MathHelper.DegreesToRadians(45.0f), 0.0f,1.0f,0.0f);  

                // Dibujar la TV
                //DrawTV();
                //Televisor c1 = new Televisor( new Vector3(0,0,0),0.5f,0.3f,0.2f);
                Televisor c1 = new Televisor(new Vector3(0.5f,0.3f,0.8f));
                Televisor c2= new Televisor(new Vector3(0.0f, 0.0f, 0.0f));
                Televisor c3 = new Televisor(new Vector3(-0.5f, -0.3f, -0.8f));

                c1.Dibujar();
                c2.Dibujar();
                c3.Dibujar();

                this.Context.SwapBuffers();

                base.OnRenderFrame(args);
            }

            private void DrawTV()
            {
                // Dibujar el marco de la televisión (rectángulo exterior)
                GL.Color4(Color4.DimGray);
                //GL.Color3(2, 3, 7);
                GL.Begin(PrimitiveType.Quads);
                GL.Vertex3(-0.5f, -0.3f, 0.1f);
                GL.Vertex3(0.5f, -0.3f, 0.1f);
                GL.Vertex3(0.5f, 0.3f, 0.1f);
                GL.Vertex3(-0.5f, 0.3f, 0.1f);
                GL.End();


                // Cara trasera
                GL.Begin(PrimitiveType.Quads);
                GL.Vertex3(-0.5f, -0.3f, -0.1f);
                GL.Vertex3(0.5f, -0.3f, -0.1f);
                GL.Vertex3(0.5f, 0.3f, -0.1f);
                GL.Vertex3(-0.5f, 0.3f, -0.1f);
                GL.End();

                // Caras laterales
                GL.Begin(PrimitiveType.Quads);
                // Lateral izquierdo
                GL.Vertex3(-0.5f, -0.3f, -0.1f);
                GL.Vertex3(-0.5f, -0.3f, 0.1f);
                GL.Vertex3(-0.5f, 0.3f, 0.1f);
                GL.Vertex3(-0.5f, 0.3f, -0.1f);
                // Lateral derecho
                GL.Vertex3(0.5f, -0.3f, 0.1f);
                GL.Vertex3(0.5f, -0.3f, -0.1f);
                GL.Vertex3(0.5f, 0.3f, -0.1f);
                GL.Vertex3(0.5f, 0.3f, 0.1f);
                GL.End();

                // Cara superior
                GL.Begin(PrimitiveType.Quads);
                GL.Vertex3(-0.5f, 0.3f, -0.1f);
                GL.Vertex3(0.5f, 0.3f, -0.1f);
                GL.Vertex3(0.5f, 0.3f, 0.1f);
                GL.Vertex3(-0.5f, 0.3f, 0.1f);
                GL.End();

                // Cara inferior
                GL.Begin(PrimitiveType.Quads);
                GL.Vertex3(-0.5f, -0.3f, 0.1f);
                GL.Vertex3(0.5f, -0.3f, 0.1f);
                GL.Vertex3(0.5f, -0.3f, -0.1f);
                GL.Vertex3(-0.5f, -0.3f, -0.1f);
                GL.End();


                // Dibujar la pantalla de la televisión (rectángulo interior)
                GL.Color4(Color4.Black);
                GL.Begin(PrimitiveType.Quads);
                GL.Vertex3(-0.3f, -0.2f, 0.11f);
                GL.Vertex3(0.3f, -0.2f, 0.11f);
                GL.Vertex3(0.3f, 0.2f, 0.11f);
                GL.Vertex3(-0.3f, 0.2f, 0.11f);
                GL.End();

                // Dibujar las patas de la televisión (dos rectángulos)
                GL.Color4(Color4.Gray);
                GL.Begin(PrimitiveType.Quads);
                // Pata frontal izquierda
                GL.Vertex3(-0.5f, -0.4f, 0.1f);
                GL.Vertex3(-0.4f, -0.4f, 0.1f);
                GL.Vertex3(-0.4f, -0.3f, 0.1f);
                GL.Vertex3(-0.5f, -0.3f, 0.1f);
                // Pata frontal derecha
                GL.Vertex3(0.4f, -0.4f, 0.1f);
                GL.Vertex3(0.5f, -0.4f, 0.1f);
                GL.Vertex3(0.5f, -0.3f, 0.1f);
                GL.Vertex3(0.4f, -0.3f, 0.1f);
                // Pata trasera izquierda
                GL.Vertex3(-0.5f, -0.4f, -0.1f);
                GL.Vertex3(-0.4f, -0.4f, -0.1f);
                GL.Vertex3(-0.4f, -0.3f, -0.1f);
                GL.Vertex3(-0.5f, -0.3f, -0.1f);
                // Pata trasera derecha
                GL.Vertex3(0.4f, -0.4f, -0.1f);
                GL.Vertex3(0.5f, -0.4f, -0.1f);
                GL.Vertex3(0.5f, -0.3f, -0.1f);
                GL.Vertex3(0.4f, -0.3f, -0.1f);

                // Cara inferior
                GL.Vertex3(-0.5f, -0.4f, -0.1f);
                GL.Vertex3(-0.4f, -0.4f, -0.1f);
                GL.Vertex3(-0.4f, -0.4f, 0.1f);
                GL.Vertex3(-0.5f, -0.4f, 0.1f);
                // Cara inferior
                GL.Vertex3(0.4f, -0.4f, 0.1f);
                GL.Vertex3(0.5f, -0.4f, 0.1f);
                GL.Vertex3(0.5f, -0.4f, -0.1f);
                GL.Vertex3(0.4f, -0.4f, -0.1f);
                
                GL.End();
            }
        }
        
    }
    
}
