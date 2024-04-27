using Newtonsoft.Json;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL;

namespace ProgramacionGrafica
{
    public class Parte
    {
        //[JsonProperty("Poligonos")]
        public List<Poligono> Poligonos { get; set; }

        public string Nombre { get; set; }

        public Punto Centro { get; set; }

        //public int Id { get; }

        // Constructor para deserialización
        //[JsonConstructor]
        public Parte(List<Poligono> poligonos, string nombre, Punto centro)
        {
            this.Poligonos = poligonos;
            this.Nombre = nombre;
            this.Centro = centro;
        }
        public void AgregarPoligono(Poligono poligono)
        {
            this.Poligonos.Add(poligono);
        }

        public void DibujarPoligonos()
        {
            foreach (var poligono in this.Poligonos)
            {
                poligono.Dibujar(this.Centro);
            }
        }
        public void Rotate(float angle)
        {
            foreach (var poligono in Poligonos)
            {
                poligono.Rotate(angle);
            }
        }
        public void Rotate2(float angle)
        {
            foreach (var poligono in this.Poligonos)
            {
                poligono.Rotate2(angle);
            }
        }
        public void Scale(float sx, float sy, float sz)
        {
            foreach (var poligono in this.Poligonos)
            {
                poligono.Scale(sx, sy, sz);
            }
        }

        public void Translate(float dx, float dy, float dz)
        {
            foreach (var poligono in this.Poligonos)
            {
                poligono.Translate(dx, dy, dz);
            }
        }
    }

}
