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

        //[JsonConstructor]
        public Objeto(List<Parte> partes, Punto centro,string nombre)
        {
            this.Partes = partes;
            this.Centro = centro;
            this.Nombre = nombre;
        }

        public void AgregarParte(Parte parte)
        {
            this.Partes.Add(parte);
        }

        public void DibujarPartes()
        {
            foreach (var part in Partes)
            {
                part.DibujarPoligonos(this.Centro);
            }
        }

        public void RotateY(float angle)
        {
            foreach (var parte in this.Partes)
            {

                // Calcular el desplazamiento relativo desde el centro del objeto hasta el centro de la parte
                float dx = this.Centro.x - parte.Centro.x;
                float dy = this.Centro.y - parte.Centro.y;
                float dz = this.Centro.z - parte.Centro.z;

                // Aplicar la rotación a la parte con respecto a su centro local
                parte.Translate(-dx, -dy, -dz); // Desplazar al origen
                parte.RotateY(angle); // Rotar alrededor del origen
                parte.Translate(dx, dy, dz); // Desplazar de vuelta al centro original

            }
        }

        public void RotateX(float angle)
        {
            foreach (var parte in this.Partes)
            {

                // Calcular el desplazamiento relativo desde el centro del objeto hasta el centro de la parte
                float dx = this.Centro.x - parte.Centro.x;
                float dy = this.Centro.y - parte.Centro.y;
                float dz = this.Centro.z - parte.Centro.z;

                // Aplicar la rotación a la parte con respecto a su centro local
                parte.Translate(-dx, -dy, -dz); // Desplazar al origen
                parte.RotateX(angle); // Rotar alrededor del origen
                parte.Translate(dx, dy, dz); // Desplazar de vuelta al centro original

            }
        }

        public void RotateZ(float angle)
        {
            foreach (var parte in this.Partes)
            {

                // Calcular el desplazamiento relativo desde el centro del objeto hasta el centro de la parte
                float dx = this.Centro.x - parte.Centro.x;
                float dy = this.Centro.y - parte.Centro.y;
                float dz = this.Centro.z - parte.Centro.z;

                // Aplicar la rotación a la parte con respecto a su centro local
                parte.Translate(-dx, -dy, -dz); // Desplazar al origen
                parte.RotateZ(angle); // Rotar alrededor del origen
                parte.Translate(dx, dy, dz); // Desplazar de vuelta al centro original

            }
        }
        public void Scale(float sx, float sy, float sz)
        {
            foreach (var parte in this.Partes)
            {
                // Calcular el desplazamiento relativo desde el centro del objeto hasta el centro de la parte
                float dx = this.Centro.x - parte.Centro.x;
                float dy = this.Centro.y - parte.Centro.y;
                float dz = this.Centro.z - parte.Centro.z;

                // Aplicar la escala a la parte con respecto a su centro local
                parte.Translate(-dx, -dy, -dz); // Desplazar al origen
                parte.Scale(sx, sy, sz);       
                parte.Translate(dx, dy, dz); // Desplazar de vuelta al centro original
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
