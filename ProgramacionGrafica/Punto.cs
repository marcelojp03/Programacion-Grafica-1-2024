using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramacionGrafica
{
    public class Punto
    {
        //[JsonProperty("x")]
        public float x { get; set; }
        //[JsonProperty("y")]
        public float y { get; set; }
        //[JsonProperty("z")]
        public float z { get; set; }
        public Punto(float x, float y, float z)
        {
            this.x= x;
            this.y= y;
            this.z= z;
        }
        public void showPuntos()
        {
            Console.WriteLine(x.ToString()+","+y.ToString()+","+z.ToString());
        }
    }
}
