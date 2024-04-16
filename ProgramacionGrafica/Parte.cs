using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramacionGrafica
{
    public class Parte
    {
        //[JsonProperty("Poligonos")]
        public List<Poligono> Poligonos { get; set; }

        //public int Id { get; }

        // Constructor para deserialización
        //[JsonConstructor]
        public Parte(List<Poligono> poligonos)
        {
            this.Poligonos = poligonos;
            //this.Id = id;
        }
        public void AgregarPoligono(Poligono poligono)
        {
            this.Poligonos.Add(poligono);
        }

        public void DibujarPoligonos(Punto centro)
        {
            foreach (var poligono in this.Poligonos)
            {
                poligono.Dibujar(centro);
            }
        }


    }

}
