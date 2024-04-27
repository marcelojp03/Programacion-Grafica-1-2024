using Newtonsoft.Json;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramacionGrafica
{
    public class Objeto
    {
        //[JsonProperty("Partes")]
        public List<Parte> Partes { get; set; }
        //[JsonProperty("Centro")]
        public Punto Centro { get; set; }

        public string Nombre { get; set; }

        public float Angle { get; set; } // Add angle property
        //[JsonConstructor]
        public Objeto(List<Parte> partes, string nombre, float angle)
        {
            this.Partes = partes;
            this.Nombre = nombre;
            this.Angle = 0.0f;
        }

        public void AgregarParte(Parte parte)
        {
            this.Partes.Add(parte);
        }

        public void DibujarPartes()
        {
            foreach (var part in Partes)
            {
                part.DibujarPoligonos();
            }
        }
        public void Rotate(float angle)
        {
            foreach (var part in this.Partes)
            {
                part.Rotate(angle);
            }
        }

        public void Rotate2(float angle)
        {
            foreach (var parte in this.Partes)
            {
                parte.Rotate2(angle);
            }
        }
        public void Scale(float sx, float sy, float sz)
        {
            foreach (var parte in this.Partes)
            {
                parte.Scale(sx, sy, sz);
            }
        }

        public void Translate(float dx, float dy, float dz)
        {
            foreach (var parte in this.Partes)
            {
                parte.Translate(dx, dy, dz);
            }
        }
    }

}
