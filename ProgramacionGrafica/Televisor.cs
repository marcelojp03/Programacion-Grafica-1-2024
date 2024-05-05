using OpenTK;
using OpenTK.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenTK.Graphics.OpenGL;


namespace ProgramacionGrafica
{
    public class Televisor
    {
        //private Color4 color;
        private Vector3 centro;
        public Vector3 Centro { get; set; }
        public string Nombre { get; set; } = "Televisor";
        public List<Poligono> Partes { get; set; } = new List<Poligono>();

        //public Televisor(Vector3 centro, float largo, float alto, float ancho)
        public Televisor(Vector3 centro)
        {
            this.centro = centro;
        }

        //public Dictionary<string, object> ToJson()
        //{
        //    var partesJson = Partes.Select(p => p.ToJson()).ToList();
        //    return new Dictionary<string, object>()
        //    {
        //        { "Nombre", Nombre },
        //        { "Centro", new Dictionary<string, object>() { { "X", Centro.X }, { "Y", Centro.Y }, { "Z", Centro.Z } } },
        //        { "Partes", partesJson }
        //    };
        //}

        public void Dibujar()
        {
            // Dibujar el marco de la televisión (rectángulo exterior)
            GL.Color4(Color4.DimGray);
            //Cara delantera
            GL.Begin(PrimitiveType.Quads);
            //GL.Begin(PrimitiveType.ci)

            GL.Vertex3(this.centro.X - 0.5f, this.centro.Y - 0.3f, this.centro.Z + 0.1f);
            GL.Vertex3(this.centro.X + 0.5f, this.centro.Y - 0.3f, this.centro.Z + 0.1f);
            GL.Vertex3(this.centro.X + 0.5f, this.centro.Y + 0.3f, this.centro.Z + 0.1f);
            GL.Vertex3(this.centro.X - 0.5f, this.centro.Y + 0.3f, this.centro.Z + 0.1f);
            //GL.End();

            // Cara Trasera
            //GL.Begin(PrimitiveType.Quads);
            GL.Vertex3(this.centro.X - 0.5f, this.centro.Y - 0.3f, this.centro.Z - 0.1f);
            GL.Vertex3(this.centro.X + 0.5f, this.centro.Y - 0.3f, this.centro.Z - 0.1f);
            GL.Vertex3(this.centro.X + 0.5f, this.centro.Y + 0.3f, this.centro.Z - 0.1f);
            GL.Vertex3(this.centro.X - 0.5f, this.centro.Y + 0.3f, this.centro.Z - 0.1f);
            //GL.End();


            // Dibujar las caras laterales del televisor
            //GL.Begin(PrimitiveType.Quads);
            // Lateral izquierdo
            GL.Vertex3(this.centro.X - 0.5f, this.centro.Y - 0.3f, this.centro.Z + 0.1f);
            GL.Vertex3(this.centro.X - 0.5f, this.centro.Y - 0.3f, this.centro.Z - 0.1f);
            GL.Vertex3(this.centro.X - 0.5f, this.centro.Y + 0.3f, this.centro.Z - 0.1f);
            GL.Vertex3(this.centro.X - 0.5f, this.centro.Y + 0.3f, this.centro.Z + 0.1f);
            // Lateral derecho
            GL.Vertex3(this.centro.X + 0.5f, this.centro.Y - 0.3f, this.centro.Z - 0.1f);
            GL.Vertex3(this.centro.X + 0.5f, this.centro.Y - 0.3f, this.centro.Z + 0.1f);
            GL.Vertex3(this.centro.X + 0.5f, this.centro.Y + 0.3f, this.centro.Z + 0.1f);
            GL.Vertex3(this.centro.X + 0.5f, this.centro.Y + 0.3f, this.centro.Z - 0.1f);
            //GL.End();

            // Dibujar las caras superior e inferior del televisor
            //GL.Begin(PrimitiveType.Quads);
            // Cara superior
            GL.Vertex3(this.centro.X - 0.5f, this.centro.Y + 0.3f, this.centro.Z + 0.1f);
            GL.Vertex3(this.centro.X + 0.5f, this.centro.Y + 0.3f, this.centro.Z + 0.1f);
            GL.Vertex3(this.centro.X + 0.5f, this.centro.Y + 0.3f, this.centro.Z - 0.1f);
            GL.Vertex3(this.centro.X - 0.5f, this.centro.Y + 0.3f, this.centro.Z - 0.1f);
            // Cara inferior
            GL.Vertex3(this.centro.X - 0.5f, this.centro.Y - 0.3f, this.centro.Z + 0.1f);
            GL.Vertex3(this.centro.X + 0.5f, this.centro.Y - 0.3f, this.centro.Z + 0.1f);
            GL.Vertex3(this.centro.X + 0.5f, this.centro.Y - 0.3f, this.centro.Z - 0.1f);
            GL.Vertex3(this.centro.X - 0.5f, this.centro.Y - 0.3f, this.centro.Z - 0.1f);
            GL.End();

            // Dibujar la pantalla de la televisión (rectángulo interior)
            GL.Color4(Color4.Black);
            GL.Begin(PrimitiveType.Quads);
            GL.Vertex3(this.centro.X - 0.48f, this.centro.Y - 0.28f, this.centro.Z + 0.11f);
            GL.Vertex3(this.centro.X + 0.48f, this.centro.Y - 0.28f, this.centro.Z + 0.11f);
            GL.Vertex3(this.centro.X + 0.48f, this.centro.Y + 0.28f, this.centro.Z + 0.11f);
            GL.Vertex3(this.centro.X - 0.48f, this.centro.Y + 0.28f, this.centro.Z + 0.11f);
            GL.End();



            // Dibujar las patas de la televisión (cuatro rectángulos)
            GL.Color4(Color4.Gray);
            GL.Begin(PrimitiveType.Quads);

            // Pata frontal izquierda
            GL.Vertex3(this.centro.X - 0.5f, this.centro.Y - 0.3f, this.centro.Z + 0.1f);
            GL.Vertex3(this.centro.X - 0.5f, this.centro.Y - 0.4f, this.centro.Z + 0.1f);
            GL.Vertex3(this.centro.X - 0.4f, this.centro.Y - 0.4f, this.centro.Z + 0.1f);
            GL.Vertex3(this.centro.X - 0.4f, this.centro.Y - 0.3f, this.centro.Z + 0.1f);

            // Pata frontal derecha
            GL.Vertex3(this.centro.X + 0.5f, this.centro.Y - 0.3f, this.centro.Z + 0.1f);
            GL.Vertex3(this.centro.X + 0.5f, this.centro.Y - 0.4f, this.centro.Z + 0.1f);
            GL.Vertex3(this.centro.X + 0.4f, this.centro.Y - 0.4f, this.centro.Z + 0.1f);
            GL.Vertex3(this.centro.X + 0.4f, this.centro.Y - 0.3f, this.centro.Z + 0.1f);

            // Pata trasera izquierda
            GL.Vertex3(this.centro.X - 0.5f, this.centro.Y - 0.3f, this.centro.Z - 0.1f);
            GL.Vertex3(this.centro.X - 0.5f, this.centro.Y - 0.4f, this.centro.Z - 0.1f);
            GL.Vertex3(this.centro.X - 0.4f, this.centro.Y - 0.4f, this.centro.Z - 0.1f);
            GL.Vertex3(this.centro.X - 0.4f, this.centro.Y - 0.3f, this.centro.Z - 0.1f);

            // Pata trasera derecha
            GL.Vertex3(this.centro.X + 0.5f, this.centro.Y - 0.3f, this.centro.Z - 0.1f);
            GL.Vertex3(this.centro.X + 0.5f, this.centro.Y - 0.4f, this.centro.Z - 0.1f);
            GL.Vertex3(this.centro.X + 0.4f, this.centro.Y - 0.4f, this.centro.Z - 0.1f);
            GL.Vertex3(this.centro.X + 0.4f, this.centro.Y - 0.3f, this.centro.Z - 0.1f);
            //GL.End();

            //GL.Begin(PrimitiveType.Quads);
            // Caras laterales de las patas
            // Lateral izquierdo pata izquierda
            GL.Vertex3(this.centro.X - 0.5f, this.centro.Y - 0.3f, this.centro.Z + 0.1f);
            GL.Vertex3(this.centro.X - 0.5f, this.centro.Y - 0.3f, this.centro.Z - 0.1f);
            GL.Vertex3(this.centro.X - 0.5f, this.centro.Y - 0.4f, this.centro.Z - 0.1f);
            GL.Vertex3(this.centro.X - 0.5f, this.centro.Y - 0.4f, this.centro.Z + 0.1f);

            // Lateral derecho pata izquierda
            GL.Vertex3(this.centro.X - 0.4f, this.centro.Y - 0.3f, this.centro.Z + 0.1f);
            GL.Vertex3(this.centro.X - 0.4f, this.centro.Y - 0.3f, this.centro.Z - 0.1f);
            GL.Vertex3(this.centro.X - 0.4f, this.centro.Y - 0.4f, this.centro.Z - 0.1f);
            GL.Vertex3(this.centro.X - 0.4f, this.centro.Y - 0.4f, this.centro.Z + 0.1f);

            //// Lateral izquierdo pata derecha
            GL.Vertex3(this.centro.X + 0.4f, this.centro.Y - 0.3f, this.centro.Z + 0.1f);
            GL.Vertex3(this.centro.X + 0.4f, this.centro.Y - 0.3f, this.centro.Z - 0.1f);
            GL.Vertex3(this.centro.X + 0.4f, this.centro.Y - 0.4f, this.centro.Z - 0.1f);
            GL.Vertex3(this.centro.X + 0.4f, this.centro.Y - 0.4f, this.centro.Z + 0.1f);
            // Lateral derecho frontal
            GL.Vertex3(this.centro.X + 0.5f, this.centro.Y - 0.3f, this.centro.Z + 0.1f);
            GL.Vertex3(this.centro.X + 0.5f, this.centro.Y - 0.3f, this.centro.Z - 0.1f);
            GL.Vertex3(this.centro.X + 0.5f, this.centro.Y - 0.4f, this.centro.Z - 0.1f);
            GL.Vertex3(this.centro.X + 0.5f, this.centro.Y - 0.4f, this.centro.Z + 0.1f);

            //GL.End();

            GL.Begin(PrimitiveType.Quads);
            //Cara superior pata izquierda
            GL.Vertex3(this.centro.X - 0.5f, this.centro.Y - 0.3f, this.centro.Z + 0.1f);
            GL.Vertex3(this.centro.X - 0.5f, this.centro.Y - 0.3f, this.centro.Z - 0.1f);
            GL.Vertex3(this.centro.X - 0.4f, this.centro.Y - 0.3f, this.centro.Z - 0.1f);
            GL.Vertex3(this.centro.X - 0.4f, this.centro.Y - 0.3f, this.centro.Z + 0.1f);

            //Cara inferior pata izquierda
            GL.Vertex3(this.centro.X - 0.5f, this.centro.Y - 0.4f, this.centro.Z + 0.1f);
            GL.Vertex3(this.centro.X - 0.5f, this.centro.Y - 0.4f, this.centro.Z - 0.1f);
            GL.Vertex3(this.centro.X - 0.4f, this.centro.Y - 0.4f, this.centro.Z - 0.1f);
            GL.Vertex3(this.centro.X - 0.4f, this.centro.Y - 0.4f, this.centro.Z + 0.1f);


            //Cara superior pata derecho
            GL.Vertex3(this.centro.X + 0.5f, this.centro.Y - 0.3f, this.centro.Z + 0.1f);
            GL.Vertex3(this.centro.X + 0.5f, this.centro.Y - 0.3f, this.centro.Z - 0.1f);
            GL.Vertex3(this.centro.X + 0.4f, this.centro.Y - 0.3f, this.centro.Z - 0.1f);
            GL.Vertex3(this.centro.X + 0.4f, this.centro.Y - 0.3f, this.centro.Z + 0.1f);

            //Cara inferior pata derecha
            GL.Vertex3(this.centro.X + 0.5f, this.centro.Y - 0.4f, this.centro.Z + 0.1f);
            GL.Vertex3(this.centro.X + 0.5f, this.centro.Y - 0.4f, this.centro.Z - 0.1f);
            GL.Vertex3(this.centro.X + 0.4f, this.centro.Y - 0.4f, this.centro.Z - 0.1f);
            GL.Vertex3(this.centro.X + 0.4f, this.centro.Y - 0.4f, this.centro.Z + 0.1f);


            GL.End();

            // Dibujar la pantalla de la televisión (rectángulo interior)
            GL.Color4(Color4.Black);
            GL.Begin(PrimitiveType.Quads);
            GL.Vertex3(this.centro.X - 1.2f, this.centro.Y - 0.41f, this.centro.Z + 0.1f);
            GL.Vertex3(this.centro.X + 1.2f, this.centro.Y - 0.41f, this.centro.Z + 0.1f);
            GL.Vertex3(this.centro.X + 1.2f, this.centro.Y - 0.41f, this.centro.Z - 0.1f);
            GL.Vertex3(this.centro.X - 1.2f, this.centro.Y - 0.41f, this.centro.Z - 0.1f);
            GL.End();

        }

        public void DibujarParlantes()
        {
            // Dibujar parlante izquierdo
            GL.Color4(Color4.SaddleBrown);
            GL.Begin(PrimitiveType.Quads);
            GL.Vertex3(this.centro.X - 0.9f, this.centro.Y - 0.1f, this.centro.Z + 0.1f);
            GL.Vertex3(this.centro.X - 0.6f, this.centro.Y - 0.1f, this.centro.Z + 0.1f);
            GL.Vertex3(this.centro.X - 0.6f, this.centro.Y - 0.4f, this.centro.Z + 0.1f);
            GL.Vertex3(this.centro.X - 0.9f, this.centro.Y - 0.4f, this.centro.Z + 0.1f);


            GL.Vertex3(this.centro.X - 0.9f, this.centro.Y - 0.1f, this.centro.Z - 0.1f);
            GL.Vertex3(this.centro.X - 0.6f, this.centro.Y - 0.1f, this.centro.Z - 0.1f);
            GL.Vertex3(this.centro.X - 0.6f, this.centro.Y - 0.4f, this.centro.Z - 0.1f);
            GL.Vertex3(this.centro.X - 0.9f, this.centro.Y - 0.4f, this.centro.Z - 0.1f);


            GL.Vertex3(this.centro.X - 0.9f, this.centro.Y - 0.1f, this.centro.Z + 0.1f);
            GL.Vertex3(this.centro.X - 0.9f, this.centro.Y - 0.4f, this.centro.Z + 0.1f);
            GL.Vertex3(this.centro.X - 0.9f, this.centro.Y - 0.4f, this.centro.Z - 0.1f);
            GL.Vertex3(this.centro.X - 0.9f, this.centro.Y - 0.1f, this.centro.Z - 0.1f);

            GL.Vertex3(this.centro.X - 0.6f, this.centro.Y - 0.1f, this.centro.Z + 0.1f);
            GL.Vertex3(this.centro.X - 0.6f, this.centro.Y - 0.4f, this.centro.Z + 0.1f);
            GL.Vertex3(this.centro.X - 0.6f, this.centro.Y - 0.4f, this.centro.Z - 0.1f);
            GL.Vertex3(this.centro.X - 0.6f, this.centro.Y - 0.1f, this.centro.Z - 0.1f);

            GL.Vertex3(this.centro.X - 0.9f, this.centro.Y - 0.1f, this.centro.Z + 0.1f);
            GL.Vertex3(this.centro.X - 0.9f, this.centro.Y - 0.1f, this.centro.Z - 0.1f);
            GL.Vertex3(this.centro.X - 0.6f, this.centro.Y - 0.1f, this.centro.Z - 0.1f);
            GL.Vertex3(this.centro.X - 0.6f, this.centro.Y - 0.1f, this.centro.Z + 0.1f);

            GL.Vertex3(this.centro.X - 0.9f, this.centro.Y - 0.4f, this.centro.Z + 0.1f);
            GL.Vertex3(this.centro.X - 0.9f, this.centro.Y - 0.4f, this.centro.Z - 0.1f);
            GL.Vertex3(this.centro.X - 0.6f, this.centro.Y - 0.4f, this.centro.Z - 0.1f);
            GL.Vertex3(this.centro.X - 0.6f, this.centro.Y - 0.4f, this.centro.Z + 0.1f);

            GL.End();

            // Dibujar bocina izquierda
            GL.Color4(Color4.White);
            GL.Begin(PrimitiveType.TriangleFan);
            GL.Vertex3(0 - 0.75f, this.centro.Y - 0.25f, this.centro.Z + 0.11f); // Punto central
            int c = 0;
            for (int i = 0; i <= 360; i += 10) // Dibujar un círculo de puntos
            {
                double angle = Math.PI * i / 180.0;
                //Console.WriteLine("angle " + angle.ToString());
                
                //Console.WriteLine(c++.ToString()+": "+(0 - 0.75f + (float)Math.Cos(angle) * 0.1f).ToString()+","+(this.centro.Y - 0.25f + (float)Math.Sin(angle) * 0.1f).ToString()+","+(this.centro.Z + 0.11f).ToString());
                GL.Vertex3(0 - 0.75f + (float)Math.Cos(angle) * 0.1f, this.centro.Y - 0.25f + (float)Math.Sin(angle) * 0.1f, this.centro.Z + 0.11f);
            }
            GL.End();

            // Dibujar parlante derecho
            GL.Color4(Color4.SaddleBrown);
            GL.Begin(PrimitiveType.Quads);
            GL.Vertex3(this.centro.X + 0.9f, this.centro.Y - 0.1f, this.centro.Z + 0.1f);
            GL.Vertex3(this.centro.X + 0.6f, this.centro.Y - 0.1f, this.centro.Z + 0.1f);
            GL.Vertex3(this.centro.X + 0.6f, this.centro.Y - 0.4f, this.centro.Z + 0.1f);
            GL.Vertex3(this.centro.X + 0.9f, this.centro.Y - 0.4f, this.centro.Z + 0.1f);


            GL.Vertex3(this.centro.X + 0.9f, this.centro.Y - 0.1f, this.centro.Z - 0.1f);
            GL.Vertex3(this.centro.X + 0.6f, this.centro.Y - 0.1f, this.centro.Z - 0.1f);
            GL.Vertex3(this.centro.X + 0.6f, this.centro.Y - 0.4f, this.centro.Z - 0.1f);
            GL.Vertex3(this.centro.X + 0.9f, this.centro.Y - 0.4f, this.centro.Z - 0.1f);


            GL.Vertex3(this.centro.X + 0.9f, this.centro.Y - 0.1f, this.centro.Z + 0.1f);
            GL.Vertex3(this.centro.X + 0.9f, this.centro.Y - 0.4f, this.centro.Z + 0.1f);
            GL.Vertex3(this.centro.X + 0.9f, this.centro.Y - 0.4f, this.centro.Z - 0.1f);
            GL.Vertex3(this.centro.X + 0.9f, this.centro.Y - 0.1f, this.centro.Z - 0.1f);

            GL.Vertex3(this.centro.X + 0.6f, this.centro.Y - 0.1f, this.centro.Z + 0.1f);
            GL.Vertex3(this.centro.X + 0.6f, this.centro.Y - 0.4f, this.centro.Z + 0.1f);
            GL.Vertex3(this.centro.X + 0.6f, this.centro.Y - 0.4f, this.centro.Z - 0.1f);
            GL.Vertex3(this.centro.X + 0.6f, this.centro.Y - 0.1f, this.centro.Z - 0.1f);

            GL.Vertex3(this.centro.X + 0.9f, this.centro.Y - 0.1f, this.centro.Z + 0.1f);
            GL.Vertex3(this.centro.X + 0.9f, this.centro.Y - 0.1f, this.centro.Z - 0.1f);
            GL.Vertex3(this.centro.X + 0.6f, this.centro.Y - 0.1f, this.centro.Z - 0.1f);
            GL.Vertex3(this.centro.X + 0.6f, this.centro.Y - 0.1f, this.centro.Z + 0.1f);

            GL.Vertex3(this.centro.X + 0.9f, this.centro.Y - 0.4f, this.centro.Z + 0.1f);
            GL.Vertex3(this.centro.X + 0.9f, this.centro.Y - 0.4f, this.centro.Z - 0.1f);
            GL.Vertex3(this.centro.X + 0.6f, this.centro.Y - 0.4f, this.centro.Z - 0.1f);
            GL.Vertex3(this.centro.X + 0.6f, this.centro.Y - 0.4f, this.centro.Z + 0.1f);

            GL.End();

            // Dibujar bocina derecha
            GL.Color4(Color4.White);
            GL.Begin(PrimitiveType.TriangleFan);
            GL.Vertex3(this.centro.X + 0.75f, this.centro.Y - 0.25f, this.centro.Z + 0.11f); // Punto central
             c = 0;
            for (int i = 0; i <= 360; i += 10) // Dibujar un círculo de puntos
            {
                double angle = Math.PI * i / 180.0;
                //Console.WriteLine(c++.ToString() + ": " + (0 + 0.75f + (float)Math.Cos(angle) * 0.1f).ToString() + "," + (this.centro.Y - 0.25f + (float)Math.Sin(angle) * 0.1f).ToString() + "," + (this.centro.Z + 0.11f).ToString());
                GL.Vertex3(0+ 0.75f + (float)Math.Cos(angle) * 0.1f, this.centro.Y - 0.25f + (float)Math.Sin(angle) * 0.1f, this.centro.Z + 0.11f);
            }
            GL.End();
        }

    }
}
