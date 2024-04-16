using OpenTK.Graphics;
using ProgramacionGrafica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramacionGrafica
{
    public class Escenario
    {
        public List<Objeto> Objetos;

        public Escenario()
        {
            this.Objetos= new List<Objeto>();
        }

        public void AgregarObjeto(Objeto objeto)
        {
            this.Objetos.Add(objeto);
        }

        public void CargarObjetos(string fileName)
        {
            //string fileName = "D://Programacion//VisualStudio.net//c#//OpenGL//ProgramacionGrafica//ProgramacionGrafica//puntos/televisor.json";
            try
            {

                dynamic obj = Serialize.DeserializeObject<dynamic>(fileName);

                Console.WriteLine("Archivo json deserializado " + obj);

                List<Parte> partes = new List<Parte>();

                // Procesar partes y polígonos
                foreach (var partData in obj.Partes)
                {
                    List<Poligono> poligonos = new List<Poligono>();

                    foreach (var polygonData in partData.Poligonos)
                    {
                        List<Punto> vertices = new List<Punto>();
                        foreach (var vertexData in polygonData.Vertices)
                        {
                            //Console.WriteLine(vertexData.x.ToString() + "," + vertexData.y.ToString() + " " + vertexData.z.ToString());
                            Punto punto = new Punto((float)vertexData.x, (float)vertexData.y, (float)vertexData.z);
                            vertices.Add(punto);
                        }
                        string tipo=polygonData.Tipo; //Tipo de poligono Quads, Triangle, Line, etc
                        //Console.WriteLine("Color " + polygonData.Color);
                        Color4 color = new Color4((byte)polygonData.Color.R, (byte)polygonData.Color.G, (byte)polygonData.Color.B, (byte)polygonData.Color.A);
                        Poligono poligono = new Poligono(vertices,color,tipo);
                        poligonos.Add(poligono);
                    }
                    Parte parte = new Parte(poligonos);                   
                    partes.Add(parte);

                }
                //Console.WriteLine("Centro "+obj.Centro);
                Punto centro = new Punto((float)obj.Centro.x, (float)obj.Centro.y, (float)obj.Centro.z);
                //Console.WriteLine(centro);
                Objeto objeto = new Objeto(partes, centro);
                this.AgregarObjeto(objeto);
                Console.WriteLine("objeto cargado "+this.Objetos.Count.ToString());

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al procesar el archivo JSON: " + ex.Message);
            }

        }

        public void DibujarObjetos() 
        {
            foreach(var obj in  this.Objetos) 
            {
                obj.DibujarPartes();
            }
        }
    }
}
