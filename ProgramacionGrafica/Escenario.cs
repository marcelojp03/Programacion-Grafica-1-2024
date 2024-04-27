using Newtonsoft.Json;
using OpenTK.Graphics;
using ProgramacionGrafica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using OpenTK;

namespace ProgramacionGrafica
{
    public class Escenario
    {
        public List<Objeto> Objetos;
        //public List<Objeto> ObjetosList;

        public Escenario()
        {
            this.Objetos= new List<Objeto>();
        }

        public void AgregarObjeto(Objeto objeto)
        {
            this.Objetos.Add(objeto);
        }

        //public void CargarObjetos(string fileName)
        //{
        //    //string fileName = "D://Programacion//VisualStudio.net//c#//OpenGL//ProgramacionGrafica//ProgramacionGrafica//puntos/televisor.json";
        //    try
        //    {

        //        dynamic obj = Serialize.DeserializeObject<dynamic>(fileName);

        //        Console.WriteLine("Archivo json deserializado " + obj);

        //        List<Parte> partes = new List<Parte>();

        //        // Procesar partes y polígonos
        //        foreach (var partData in obj.Partes)
        //        {
        //            List<Poligono> poligonos = new List<Poligono>();

        //            foreach (var polygonData in partData.Poligonos)
        //            {
        //                List<Punto> vertices = new List<Punto>();
        //                foreach (var vertexData in polygonData.Vertices)
        //                {
        //                    //Console.WriteLine(vertexData.x.ToString() + "," + vertexData.y.ToString() + " " + vertexData.z.ToString());
        //                    Punto punto = new Punto((float)vertexData.x, (float)vertexData.y, (float)vertexData.z);
        //                    vertices.Add(punto);
        //                }
        //                string tipo=polygonData.Tipo; //Tipo de poligono Quads, Triangle, Line, etc
        //                //Console.WriteLine("Color " + polygonData.Color);
        //                Color4 color = new Color4((byte)polygonData.Color.R, (byte)polygonData.Color.G, (byte)polygonData.Color.B, (byte)polygonData.Color.A);
        //                Poligono poligono = new Poligono(vertices,color,tipo);
        //                poligonos.Add(poligono);
        //            }
        //            Parte parte = new Parte(poligonos);                   
        //            partes.Add(parte);

        //        }
        //        //Console.WriteLine("Centro "+obj.Centro);
        //        Punto centro = new Punto((float)obj.Centro.x, (float)obj.Centro.y, (float)obj.Centro.z);
        //        //Console.WriteLine(centro);
        //        Objeto objeto = new Objeto(partes, centro);
        //        this.AgregarObjeto(objeto);
        //        Console.WriteLine("objeto cargado "+this.Objetos.Count.ToString());

        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Error al procesar el archivo JSON: " + ex.Message);
        //    }

        //}
        public void CargarObjetoDeserializado(string fileName)
        {
            try
            {
                Objeto obj = Serialize.DeserializeObject<Objeto>(fileName);
                this.AgregarObjeto(obj);
                
                //Console.WriteLine("Archivo json deserializado " + fileName);
                //this.rotarObjeto2();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al procesar el archivo JSON"+ ex.Message);
            }
        }

        public async void CargarObjetosv3()
        {
            string url = "http://localhost:5000/api/json"; // Cambia la URL según la dirección de tu API Flask
            try
            {


                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {

                    string result = await response.Content.ReadAsStringAsync();
                    //Console.WriteLine("Respuesta API FLASK=========================================================================");
                    //Console.WriteLine(result);
                    List<Objeto> objetosAPI = JsonConvert.DeserializeObject<List<Objeto>>(result);
                    foreach (var obj in objetosAPI)
                    {
                        this.AgregarObjeto(obj);
                    }
                }
                else
                {
                    Console.WriteLine("Error al obtener JSONs: " + response.StatusCode);
                }

                //Console.WriteLine("objeto cargado " + this.Objetos.Count.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al procesar el archivo JSON: " + ex.Message);
            }

        }
        public void rotarObjeto2(float angle)
        {
            Objeto obj = this.Objetos[0];
            obj.Rotate2(0.01f);

        }
        public void rotarObjeto(Objeto obj,float angle)
        {
            //Objeto obj = this.Objetos[0];
            //Objeto obj2 = this.Objetos[1];
            ////obj.Rotate2(angle);
            //Parte part = obj.Partes[2];
            //Parte part2= obj2.Partes[1];
            //part2.Rotate2(0.05f);
            //part.Rotate2(angle);

    
             obj.Rotate2(angle);

        }

        public void rotarParteObjeto(Objeto obj, Parte part, float angle)
        {
           
        }

        public Objeto GetObjectByName(string name)
        {
            return this.Objetos.FirstOrDefault(obj => obj.Nombre == name);
        }

        public Parte GetParteByName(Objeto obj, string parteName)
        {
            if (obj == null)
            {
                return null;
            }

            return obj.Partes.FirstOrDefault(parte => parte.Nombre == parteName);
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
