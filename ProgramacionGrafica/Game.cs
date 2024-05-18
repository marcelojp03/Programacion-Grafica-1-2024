using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL;
using OpenTK;
using OpenTK.Graphics;
using System.Drawing;
using OpenTK.Input;
using ProgramacionGrafica;
using System.IO;
using System.Threading;
using System.ComponentModel;
using System.Net.Http;
using Newtonsoft.Json;


namespace ProgramacionGrafica
{

    public class Game : GameWindow
    {
        int vertexBufferObject;
        private bool isDragging = false;
        private Vector2 lastMousePos; // Almacena la posición del ratón anterior
        private float sensitivity = 0.25f; // Sensibilidad del ratón para la rotación
        private Vector3 cameraRotation = Vector3.Zero; // Almacena los ángulos de rotación de la cámara
        private float fov = 45.0f; // Campo de visión inicial de la cámara
        private float minFov = 1.0f; // Minimum allowed field of view
        private float maxFov = 45.0f; // Maximum allowed field of view

        public Escenario escenario = new Escenario();
        public Objeto objetoSeleccionado;
        public Parte parteSeleccionada;


        bool startCount = false;
        float time = 0.0f;
        bool bajadaLapiz = true;
        bool caidaParlante = true;

        //private bool running = false;
        public bool rotarY = false, rotarX = false, rotarZ = false;
        public bool rotarEscenarioY = false, rotarEscenarioX = false, rotarEscenarioZ = false;

        public Api api;
        bool habilitarAPI = false;

        public Game(Escenario escenario, int width = 1366, int height = 768, string title = "TV") : base(width, height, GraphicsMode.Default, title)
        {
            Title = title;
            Size = new Size(width, height);
            this.escenario = escenario;
            this.api = new Api(this.escenario);

        }


        public void StartAnimation()
        {
            this.startCount = true;
        }
        public void cargarLapiz()
        {
            this.escenario.CargarObjetoDeserializado("../../jsons/lapiz.json");
        }

        public void CargarObjetos()
        {
            this.escenario.CargarObjetoDeserializado("../../jsons/televisor.json");
            this.escenario.CargarObjetoDeserializado("../../jsons/parlantes.json");
            this.escenario.CargarObjetoDeserializado("../../jsons/escritorio.json");
            this.escenario.CargarObjetoDeserializado("../../jsons/lapiz.json");
        }
        protected override void OnResize(EventArgs e)
        {
            GL.Viewport(0, 0, Width, Height);

            //// Definir una matriz de proyección ortográfica
            //Matrix4 ortho = Matrix4.CreateOrthographic(Width, Height, -1f, 1f); // Ajusta los valores de la proyección según sea necesario
            //GL.MatrixMode(MatrixMode.Projection);
            //GL.LoadMatrix(ref ortho);

            // Definir una matriz de proyección perspectiva
            //float aspectRatio = (float)Width / Height;
            //Matrix4 projection = Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(45.0f), aspectRatio, 0.1f, 100.0f);
            //GL.MatrixMode(MatrixMode.Projection);
            //GL.LoadMatrix(ref projection);
            //GL.MatrixMode(MatrixMode.Modelview);
            //GL.LoadIdentity();




            base.OnResize(e);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            //this.Menu();
            //this.escenario.CargarObjetos("D://Programacion//VisualStudio.net//c#//OpenGL//ProgramacionGrafica//ProgramacionGrafica//puntos/televisor.json");
            //this.escenario.CargarObjetos("../../jsons/televisor.json");
            //this.escenario.CargarObjetos("../../jsons/parlantes.json");


            //this.escenario.CargarObjetosv3();

            //this.escenario.CargarObjetoDeserializado("../../jsons/televisor.json");
            //this.escenario.CargarObjetoDeserializado("../../jsons/parlantes.json");
            //this.escenario.CargarObjetoDeserializado("../../jsons/escritorio.json");

            //WindowState = WindowState.Maximized;
            //Mouse.SetPosition(900, 500);
            //Mouse.SetPosition(Width/2,Height/2);

            CursorVisible = false;

            GL.ClearColor(Color4.SteelBlue); //Color de fondo
            this.vertexBufferObject = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, this.vertexBufferObject);

            //Matrix4 perspective = Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(45.0f), (float)Width / Height, 0.1f, 100.0f);
            //GL.MatrixMode(MatrixMode.Projection);
            //GL.LoadMatrix(ref perspective);

            //Matrix4 view = Matrix4.LookAt(new Vector3(0, 1, 0), Vector3.Zero, Vector3.UnitY);
            //GL.MatrixMode(MatrixMode.Modelview);
            //GL.LoadMatrix(ref view);

            //this.StartAnimation();

        }

        protected override void OnUnload(EventArgs e)
        {
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            GL.DeleteBuffer(this.vertexBufferObject);
            //this.rotar = false;

            base.OnUnload(e);

        }
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);
            //if(rotarY)
            //{
            //    if(this.objetoSeleccionado!=null)
            //    {
            //        if (this.parteSeleccionada != null)
            //        {
            //            this.parteSeleccionada.RotateY((float)e.Time);
            //        }
            //        else
            //        {
            //            this.objetoSeleccionado.RotateY((float)e.Time);
            //        }
            //    }

            //}
            //if (rotarX)
            //{
            //    if (this.objetoSeleccionado != null)
            //    {
            //        if (this.parteSeleccionada != null)
            //        {
            //            this.parteSeleccionada.RotateX((float)e.Time);
            //        }
            //        else
            //        {
            //            this.objetoSeleccionado.RotateX((float)e.Time);
            //        }
            //    }

            //}
            //if (rotarZ)
            //{
            //    if (this.objetoSeleccionado != null)
            //    {
            //        if (this.parteSeleccionada != null)
            //        {
            //            this.parteSeleccionada.RotateZ((float)e.Time);
            //        }
            //        else
            //        {
            //            this.objetoSeleccionado.RotateZ((float)e.Time);
            //        }
            //    }

            //}
            //if(this.rotarEscenarioY)
            //{
            //    this.escenario.rotarEscenarioY((float)e.Time);
            //}
            //if (this.rotarEscenarioX)
            //{
            //    this.escenario.rotarEscenarioX((float)e.Time);
            //}
            //if (this.rotarEscenarioZ)
            //{
            //    this.escenario.rotarEscenarioZ((float)e.Time);
            //}
            //this.api.obtenerDatosAPI();
            if (this.startCount)
            {
                this.time = this.time + (float)e.Time;
                //this.contadorBajada += (float)e.Time;
                //this.contadorSubida += (float)e.Time;
                Console.WriteLine(time);
                this.Animacion();
            }

            if (this.habilitarAPI)
            {
                this.api.obtenerDatosAPI();
            }

        }

        protected override void OnKeyDown(KeyboardKeyEventArgs e)
        {
            base.OnKeyDown(e);

            // Verifica si se presionó la tecla Escape
            if (e.Key == Key.Escape)
            {
                Exit();
            }

            if (e.Key == Key.S)
            {
                this.StartAnimation();
            }

            if (e.Key == Key.C)
            {
                this.cargarLapiz();
            }

            if (e.Key == Key.Z)
            {
                this.habilitarAPI = true;
            }
            if (e.Key == Key.X)
            {
                this.habilitarAPI = false;
            }

        }

        protected override void OnMouseDown(MouseButtonEventArgs e)
        {
            base.OnMouseDown(e);
            this.isDragging = true;
            this.lastMousePos = new Vector2(e.X, e.Y);
        }

        protected override void OnMouseUp(MouseButtonEventArgs e)
        {
            base.OnMouseUp(e);
            this.isDragging = false;
        }

        protected override void OnMouseMove(MouseMoveEventArgs e)
        {
            base.OnMouseMove(e);

            if (this.isDragging)
            {

                // Get the current mouse position in window coordinates
                Vector2 currentMousePos = new Vector2(e.X, e.Y);

                // Calculate the difference in mouse movement since the last event
                float deltaX = (float)currentMousePos.X - this.lastMousePos.X;
                float deltaY = (float)currentMousePos.Y - this.lastMousePos.Y;

                // Update the camera rotation based on mouse movement
                cameraRotation.X -= deltaY * sensitivity;
                cameraRotation.Y -= deltaX * sensitivity;

                // Clamp the rotation angles to prevent extreme values
                cameraRotation.X = MathHelper.Clamp(cameraRotation.X, -90.0f, 90.0f);
                cameraRotation.Y = MathHelper.Clamp(cameraRotation.Y, -180.0f, 180.0f);

                // Update the last mouse position for the next event
                this.lastMousePos = currentMousePos;

                //this.lastMousePosition=new Vector2(e.X, e.Y);
                //Console.WriteLine(this.lastMousePosition);
            }
        }

        protected override void OnMouseWheel(MouseWheelEventArgs e)
        {
            base.OnMouseWheel(e);

            // Adjust the field of view based on mouse wheel delta (with clamping)
            //FOV (Field of View) Campo de visión
            this.fov -= e.Delta; // Adjust sensitivity as needed
            this.fov = MathHelper.Clamp(fov, this.minFov, this.maxFov);
        }

        protected override void OnRenderFrame(FrameEventArgs args)
        {

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.BindBuffer(BufferTarget.ArrayBuffer, this.vertexBufferObject);

            GL.Enable(EnableCap.DepthTest);


            // Definir una matriz de vista para simular una cámara que observa la TV desde una posición y orientación específicas
            Matrix4 view = Matrix4.LookAt(new Vector3(0, 1, 4), Vector3.Zero, Vector3.UnitY);


            // Aplica la rotación de la cámara a la matriz de vista
            Matrix4 rotationMatrix = Matrix4.CreateRotationX(MathHelper.DegreesToRadians(this.cameraRotation.X)) *
                                        Matrix4.CreateRotationY(MathHelper.DegreesToRadians(this.cameraRotation.Y));
            view = rotationMatrix * view;
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref view);


            // Calcula la matriz de proyección de perspectiva con el campo de visión actual (fov)
            float aspectRatio = (float)Width / Height;
            Matrix4 projection = Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(this.fov), aspectRatio, 0.01f, 100f);

            // Establece la matriz de proyección como la matriz de proyección actual
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref projection);


            //GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 0, 0);

            //GL.Rotate(MathHelper.DegreesToRadians(45.0f), 0.0f,1.0f,0.0f);  

            this.escenario.DibujarObjetos(); //Dibuja el escenario con los objetos cargados


            // Dibujar la TV
            //DrawTV();
            //Televisor c1 = new Televisor( new Vector3(0,0,0),0.5f,0.3f,0.2f);
            //Televisor c1 = new Televisor(new Vector3(0.5f,0.3f,0.8f));
            //Televisor c2= new Televisor(new Vector3(-0.75f, 0.0f, 0.0f));
            //Televisor c3 = new Televisor(new Vector3(-0.5f, -0.3f, -0.8f));

            //c1.Dibujar();
            //c2.Dibujar();
            //c2.DibujarParlantes();
            //c3.Dibujar();

            this.Context.SwapBuffers(); //Renderiza la escena 

            base.OnRenderFrame(args);


            //api.obtenerDatosAPI();

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


        private void Animacion()
        {
            this.objetoSeleccionado = this.escenario.GetObjectByName("Lapiz");


            if (Math.Round(this.time, 2) >= 2.00f && this.bajadaLapiz) // cae el lapiz hasta chocar con el parlante
            {
                //Console.WriteLine("ANIMACION INICIADA");
                if (this.bajadaLapiz)
                {
                    this.objetoSeleccionado.Translate(0, -0.0124f, 0);
                    if (Math.Round(this.time, 2) >= 4.00f)
                    {
                        this.bajadaLapiz = false;

                    }
                }

            }
            else
            {
                this.CaidaParlante(); // se cae el parlante
            }


        }

        private void CaidaParlante()
        {
            this.objetoSeleccionado = this.escenario.GetObjectByName("Parlantes");
            this.parteSeleccionada = this.escenario.GetParteByName(this.objetoSeleccionado, "Parlante Izquierdo");
            if (Math.Round(this.time, 2) > 4.00f && this.caidaParlante) // el parlante se cae del escritorio
            {
                this.parteSeleccionada.RotateX(0.015f);
                this.parteSeleccionada.Translate(0, 0, 0.015f);
                if (Math.Round(this.time, 2) >= 4.10f && Math.Round(this.time, 2) <= 4.55f) //sigue cayendo el lapiz
                {

                    this.objetoSeleccionado = this.escenario.GetObjectByName("Lapiz");
                    this.objetoSeleccionado.Translate(0, -0.011f, 0);


                }
                //if (Math.Round(this.time, 2) >= 4.55f)
                //{
                //    this.objetoSeleccionado = this.escenario.GetObjectByName("Lapiz");
                //    this.objetoSeleccionado.RotateX(0.015f);
                //    this.objetoSeleccionado.Translate(0, 0, 0.015f);
                //}
                if (Math.Round(this.time, 2) >= 5.70f) // se detiene el parlante
                {
                    this.caidaParlante = false;

                }
            }
        }

    }



}
