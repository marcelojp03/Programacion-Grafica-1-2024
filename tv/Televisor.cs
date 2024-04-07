using OpenTK;
using OpenTK.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenTK.Graphics.OpenGL;


namespace tv
{
    public class Televisor
    {
        private float largo, alto, ancho;
        //private Color4 color;
        private Vector3 centro;
        
        //public Televisor(Vector3 centro, float largo, float alto, float ancho)
        public Televisor(Vector3 centro)
        {
            this.centro = centro;
            //this.largo = largo;
            //this.alto = alto;
            //this.ancho = ancho;
        }

        public void Dibujar()
        {

            // Dibujar el marco de la televisión (rectángulo exterior)
            GL.Color4(Color4.DimGray);
            //GL.Color3(2, 3, 7);
            GL.Begin(PrimitiveType.Quads);
            GL.Vertex3(this.centro.X - 0.5f, this.centro.Y - 0.3f, this.centro.Z + 0.1f);
            GL.Vertex3(this.centro.X + 0.5f, this.centro.Y - 0.3f, this.centro.Z + 0.1f);
            GL.Vertex3(this.centro.X + 0.5f, this.centro.Y + 0.3f, this.centro.Z + 0.1f);
            GL.Vertex3(this.centro.X - 0.5f, this.centro.Y + 0.3f, this.centro.Z + 0.1f);
            GL.End();


            // Dibujar las caras laterales del televisor
            GL.Begin(PrimitiveType.Quads);
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
            GL.End();

            // Dibujar las caras superior e inferior del televisor
            GL.Begin(PrimitiveType.Quads);
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
            GL.Vertex3(this.centro.X - 0.3f, this.centro.Y - 0.2f, this.centro.Z + 0.11f);
            GL.Vertex3(this.centro.X + 0.3f, this.centro.Y - 0.2f, this.centro.Z + 0.11f);
            GL.Vertex3(this.centro.X + 0.3f, this.centro.Y + 0.2f, this.centro.Z + 0.11f);
            GL.Vertex3(this.centro.X - 0.3f, this.centro.Y + 0.2f, this.centro.Z + 0.11f);
            GL.End();

            // Dibujar las patas de la televisión (cuatro rectángulos)
            GL.Color4(Color4.Gray);
            GL.Begin(PrimitiveType.Quads);
            // Pata frontal izquierda
            GL.Vertex3(this.centro.X - 0.5f, this.centro.Y - 0.4f, this.centro.Z + 0.1f);
            GL.Vertex3(this.centro.X - 0.4f, this.centro.Y - 0.4f, this.centro.Z + 0.1f);
            GL.Vertex3(this.centro.X - 0.4f, this.centro.Y - 0.3f, this.centro.Z + 0.1f);
            GL.Vertex3(this.centro.X - 0.5f, this.centro.Y - 0.3f, this.centro.Z + 0.1f);

            // Pata frontal derecha
            GL.Vertex3(this.centro.X + 0.4f, this.centro.Y - 0.4f, this.centro.Z + 0.1f);
            GL.Vertex3(this.centro.X + 0.5f, this.centro.Y - 0.4f, this.centro.Z + 0.1f);
            GL.Vertex3(this.centro.X + 0.5f, this.centro.Y - 0.3f, this.centro.Z + 0.1f);
            GL.Vertex3(this.centro.X + 0.4f, this.centro.Y - 0.3f, this.centro.Z + 0.1f);

            // Caras laterales de las patas
            //// Lateral izquierdo frontal
            //GL.Vertex3(this.centro.X - 0.5f, this.centro.Y - 0.4f, this.centro.Z + 0.1f);
            //GL.Vertex3(this.centro.X - 0.5f, this.centro.Y - 0.4f, this.centro.Z - 0.1f);
            //GL.Vertex3(this.centro.X - 0.5f, this.centro.Y - 0.3f, this.centro.Z - 0.1f);
            //GL.Vertex3(this.centro.X - 0.5f, this.centro.Y - 0.3f, this.centro.Z + 0.1f);
            //// Lateral izquierdo trasero
            GL.Vertex3(this.centro.X - 0.5f, this.centro.Y - 0.4f, this.centro.Z + 0.1f);
            GL.Vertex3(this.centro.X - 0.5f, this.centro.Y - 0.4f, this.centro.Z - 0.1f);
            GL.Vertex3(this.centro.X - 0.5f, this.centro.Y - 0.3f, this.centro.Z - 0.1f);
            GL.Vertex3(this.centro.X - 0.5f, this.centro.Y - 0.3f, this.centro.Z + 0.1f);
            // Lateral derecho frontal
            GL.Vertex3(this.centro.X + 0.5f, this.centro.Y - 0.4f, this.centro.Z - 0.1f);
            GL.Vertex3(this.centro.X + 0.5f, this.centro.Y - 0.4f, this.centro.Z + 0.1f);
            GL.Vertex3(this.centro.X + 0.5f, this.centro.Y - 0.3f, this.centro.Z + 0.1f);
            GL.Vertex3(this.centro.X + 0.5f, this.centro.Y - 0.3f, this.centro.Z - 0.1f);
            // Lateral derecho trasero
            GL.Vertex3(this.centro.X + 0.5f, this.centro.Y - 0.4f, this.centro.Z - 0.1f);
            GL.Vertex3(this.centro.X + 0.5f, this.centro.Y - 0.4f, this.centro.Z + 0.1f);
            GL.Vertex3(this.centro.X + 0.5f, this.centro.Y - 0.3f, this.centro.Z + 0.1f);
            GL.Vertex3(this.centro.X + 0.5f, this.centro.Y - 0.3f, this.centro.Z - 0.1f);


            // Pata trasera izquierda
            GL.Vertex3(this.centro.X - 0.5f, this.centro.Y - 0.4f, this.centro.Z - 0.1f);
            GL.Vertex3(this.centro.X - 0.4f, this.centro.Y - 0.4f, this.centro.Z - 0.1f);
            GL.Vertex3(this.centro.X - 0.4f, this.centro.Y - 0.3f, this.centro.Z - 0.1f);
            GL.Vertex3(this.centro.X - 0.5f, this.centro.Y - 0.3f, this.centro.Z - 0.1f);

            // Pata trasera derecha
            GL.Vertex3(this.centro.X + 0.4f, this.centro.Y - 0.4f, this.centro.Z - 0.1f);
            GL.Vertex3(this.centro.X + 0.5f, this.centro.Y - 0.4f, this.centro.Z - 0.1f);
            GL.Vertex3(this.centro.X + 0.5f, this.centro.Y - 0.3f, this.centro.Z - 0.1f);
            GL.Vertex3(this.centro.X + 0.4f, this.centro.Y - 0.3f, this.centro.Z - 0.1f);
            GL.End();



            //// Calcular las coordenadas de los vértices del televisor
            //float xMin = centro.X - ancho / 2;
            //float xMax = centro.X + ancho / 2;
            //float yMin = centro.Y - alto / 2;
            //float yMax = centro.Y + alto / 2;
            //float zMin = centro.Z - largo / 2;
            //float zMax = centro.Z + largo / 2;

            //// Dibujar el marco de la televisión (rectángulo exterior)
            //GL.Color4(Color4.DimGray);
            //GL.Begin(PrimitiveType.Quads);
            //GL.Vertex3(xMin, yMin, zMin);
            //GL.Vertex3(xMax, yMin, zMin);
            //GL.Vertex3(xMax, yMax, zMin);
            //GL.Vertex3(xMin, yMax, zMin);
            //GL.End();

            //// Dibujar la pantalla de la televisión (rectángulo interior)
            //GL.Color4(Color4.Black);
            //GL.Begin(PrimitiveType.Quads);
            //GL.Vertex3(xMin + 0.1f, yMin + 0.1f, zMax - 0.1f); // Ajusta las coordenadas según el tamaño de la pantalla
            //GL.Vertex3(xMax - 0.1f, yMin + 0.1f, zMax - 0.1f);
            //GL.Vertex3(xMax - 0.1f, yMax - 0.1f, zMax - 0.1f);
            //GL.Vertex3(xMin + 0.1f, yMax - 0.1f, zMax - 0.1f);
            //GL.End();

            //// Dibujar las patas de la televisión (dos rectángulos)
            //GL.Color4(Color4.Gray);
            //GL.Begin(PrimitiveType.Quads);
            //GL.Vertex3(xMin, yMin, zMin);
            //GL.Vertex3(xMax, yMin, zMin);
            //GL.Vertex3(xMax, yMin, zMax);
            //GL.Vertex3(xMin, yMin, zMax);

            //GL.Vertex3(xMax, yMin, zMin);
            //GL.Vertex3(xMax, yMax, zMin);
            //GL.Vertex3(xMax, yMax, zMax);
            //GL.Vertex3(xMax, yMin, zMax);
            //GL.End();
        }
    }
}
