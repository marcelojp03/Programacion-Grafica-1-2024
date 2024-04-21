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
        public Color Color { get; set; }
        
        //[JsonProperty("Tipo")]
        public string Tipo { get; set; }

        public string Nombre { get; set; }

        public Poligono(List<Punto> vertices, Color color,string tipo, string nombre)
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

            if(this.Tipo=="Cuadrado")
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
            else if(this.Tipo=="Triangulo")
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
    }
}
