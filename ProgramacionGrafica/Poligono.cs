using OpenTK.Graphics;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL;
using Newtonsoft.Json;
using System.Drawing;
using System.Reflection;

namespace ProgramacionGrafica
{
    public class Poligono
    {
        //[JsonProperty("Vertices")]
        public List<Punto> Vertices { get; set; }

        //[JsonProperty("Color")]
        public Color Color { get; set; }

        //[JsonProperty("Tipo")]
        public string Tipo { get; set; }

        public string Nombre { get; set; }

        public Poligono(List<Punto> vertices, Color color, string tipo, string nombre)
        {
            this.Vertices = vertices;
            this.Color = color;
            this.Tipo = tipo;
            this.Nombre = nombre;
        }

        public void Dibujar(Punto centro)
        {
            //GL.PushMatrix();
            //GL.Translate(new Vector3(centro.x, centro.y, centro.z));

            if (this.Tipo == "Cuadrado")
            {
                //Console.WriteLine(this.Tipo);
                GL.Begin(PrimitiveType.Quads);
                //Color4 color = new Color4(Color.R, Color.G, Color.B, Color.A);
                //Console.WriteLine(color.ToString());
                GL.Color4(this.Color.getColor());

                foreach (var vertice in this.Vertices)
                {
                    GL.Vertex3(new Vector3(centro.x + vertice.x, centro.y + vertice.y, centro.z + vertice.z));
                }
                GL.End();
                //GL.PopMatrix();
            }
            else if (this.Tipo == "Triangulo")
            {
                //Console.WriteLine(this.Tipo);
                GL.Begin(PrimitiveType.TriangleFan);
                //Color4 color = new Color4(Color.R, Color.G, Color.B, Color.A);
                //Console.WriteLine(color.ToString());
                GL.Color4(this.Color.getColor());

                foreach (var vertice in this.Vertices)
                {
                    GL.Vertex3(new Vector3(centro.x + vertice.x, centro.y + vertice.y, centro.z + vertice.z));
                    //GL.Vertex3(new Vector3(vertice.x, vertice.y, vertice.z));
                }
                GL.End();
                //GL.PopMatrix();
            }
        }
        public void Rotate(float angle)
        {
            for (int i = 0; i < Vertices.Count; i++)
            {
                Vertices[i] = RotateVertexY(Vertices[i], angle);
            }
        }

        public void Rotate2(float angle)
        {
            // Apply rotation to each vertex
            for (int i = 0; i < Vertices.Count; i++)
            {
                Vertices[i] = Vertices[i].RotateY(angle);
            }
        }

        public void Scale(float sx, float sy, float sz)
        {
            // Apply scaling to each vertex
            for (int i = 0; i < Vertices.Count; i++)
            {
                Vertices[i] = Vertices[i].Scale(sx, sy, sz);
            }
        }

        public void Translate(float dx, float dy, float dz)
        {
            // Apply translation to each vertex
            for (int i = 0; i < Vertices.Count; i++)
            {
                Vertices[i] = Vertices[i].Translate(dx, dy, dz);
            }
        }

        private Punto RotateVertexY(Punto vertex, float angle)
        {
            float cosA = (float)Math.Cos(angle);
            float sinA = (float)Math.Sin(angle);
            float x = vertex.x * cosA - vertex.z * sinA;
            float z = vertex.x * sinA + vertex.z * cosA;
            return new Punto(x, vertex.y, z);
        }
    }
}
