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

namespace ProgramacionGrafica
{
    public class Poligono
    {
        //[JsonProperty("Vertices")]
        public List<Punto> Vertices { get; set; }

        //[JsonProperty("Color")]
        public Color4 Color { get; set; }
        //[JsonProperty("Tipo")]
        public string Tipo { get; set; }

        public Poligono(List<Punto> vertices, Color4 color,string tipo)
        {
            this.Vertices = vertices;
            this.Color = color;
            this.Tipo = tipo;
        }

        public void Dibujar(Punto centro)
        {
            GL.PushMatrix();
            GL.Translate(new Vector3(centro.x, centro.y, centro.z));

            if(this.Tipo=="Cuadrado")
            {
                //Console.WriteLine(this.Tipo);
                GL.Begin(PrimitiveType.Quads);
                GL.Color4(color: Color);

                foreach (var vertice in Vertices)
                {
                    GL.Vertex3(new Vector3(vertice.x, vertice.y, vertice.z));
                }
                GL.End();
                GL.PopMatrix();
            }
            else if(this.Tipo=="Triangulo")
            {
                //Console.WriteLine(this.Tipo);
                GL.Begin(PrimitiveType.TriangleFan);
                GL.Color4(color: Color);

                foreach (var vertice in Vertices)
                {
                    GL.Vertex3(new Vector3(vertice.x, vertice.y, vertice.z));
                }
                GL.End();
                GL.PopMatrix();
            }              
        }
    }
}
