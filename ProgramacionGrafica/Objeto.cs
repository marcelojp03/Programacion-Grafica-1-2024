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

        //[JsonConstructor]
        public Objeto(List<Parte> partes, Punto centro)
        {
            this.Partes = partes;
            this.Centro = centro;
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

    }

}
