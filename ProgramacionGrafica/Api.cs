using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ProgramacionGrafica
{
    public class Api
    {

        HttpClient httpClient;
        string baseUri = "http://localhost:5000/";

        public Escenario escenario = new Escenario();
        private Objeto objetoSeleccionado;
        private Parte parteSeleccionada;

        int codigo = 0;

        public Api(Escenario escenario)
        {
            this.httpClient = new HttpClient();
            this.httpClient.BaseAddress = new Uri(this.baseUri);
            this.escenario = escenario;
        }


        public async void obtenerDatosAPI()
        {
            try
            {
                HttpResponseMessage response = await this.httpClient.GetAsync("obtener-datos");
                response.EnsureSuccessStatusCode(); // Lanza una excepción si la solicitud no fue exitosa

                string responseBody = await response.Content.ReadAsStringAsync();
                ApiResponse datos = JsonConvert.DeserializeObject<ApiResponse>(responseBody);

                if (this.codigo != datos.Codigo)
                {
                    //console.writeline($"datos recibidos: {datoscontent}");

                    //Logica para manejar las transformaciones en base a los datos obtenidos 
                    this.codigo = datos.Codigo;
                    manejarTransformaciones(datos);
                }
            }
            catch (Exception ex)
            {
                // Manejar errores de conexión
                Console.WriteLine($"Error al obtener los datos: {ex.Message}");
            }
        }

        private void manejarTransformaciones(ApiResponse datos)
        {
            if (datos.Transformacion == "Rotacion")
            {
                Rotacion(datos);
            }
            if (datos.Transformacion == "Traslacion")
            {
                Traslacion(datos);
            }
            if (datos.Transformacion == "Escalacion")
            {
                Escalacion(datos);
            }
        }

        private void Rotacion(ApiResponse datos)
        {
            string objectName = datos.Objeto;
            Console.WriteLine(objectName);
            this.objetoSeleccionado = this.escenario.GetObjectByName(objectName);

            if (datos.Escenario == "Todo el escenario")
            {

                if (datos.Eje == "X")
                {
                    this.escenario.rotarEscenarioX(datos.Valor);
                }
                if (datos.Eje == "Y")
                {
                    this.escenario.rotarEscenarioY(datos.Valor);
                }
                if (datos.Eje == "Z")
                {
                    this.escenario.rotarEscenarioZ(datos.Valor);
                }
                Console.WriteLine("Escenario rotado");

            }
            else if (datos.Parte == "Todo el objeto")
            {

                if (this.objetoSeleccionado == null)
                {
                    Console.WriteLine("Objeto no encontrado.");
                    return;
                }
                if (datos.Eje == "X")
                {
                    this.objetoSeleccionado.RotateX(datos.Valor);
                }
                if (datos.Eje == "Y")
                {
                    this.objetoSeleccionado.RotateY(datos.Valor);
                }
                if (datos.Eje == "Z")
                {
                    this.objetoSeleccionado.RotateZ(datos.Valor);
                }
                Console.WriteLine("Objeto rotado " + this.objetoSeleccionado.Nombre);
            }
            else if (datos.Parte != "Ninguno")
            {
                string parteName = datos.Parte;
                Console.WriteLine(parteName);

                this.parteSeleccionada = this.escenario.GetParteByName(this.objetoSeleccionado, parteName);

                if (this.parteSeleccionada == null)
                {
                    Console.WriteLine("Parte no encontrada.");
                    return;
                }
                if (datos.Eje == "X")
                {
                    this.parteSeleccionada.RotateX(datos.Valor);
                }
                if (datos.Eje == "Y")
                {
                    this.parteSeleccionada.RotateY(datos.Valor);
                }
                if (datos.Eje == "Z")
                {
                    this.parteSeleccionada.RotateZ(datos.Valor);
                }
                Console.WriteLine("Parte rotada " + this.parteSeleccionada.Nombre);
            }
            else
            {
                Console.WriteLine("Opción inválida.");
            }
        }

        private void Traslacion(ApiResponse datos)
        {
            string objectName = datos.Objeto;
            Console.WriteLine(objectName);
            this.objetoSeleccionado = this.escenario.GetObjectByName(objectName);

            if (datos.Escenario == "Todo el escenario")
            {

                if (datos.Eje == "X")
                {
                    this.escenario.trasladarEscenario(datos.Valor, 0, 0);
                }
                if (datos.Eje == "Y")
                {
                    this.escenario.trasladarEscenario(0, datos.Valor, 0);
                }
                if (datos.Eje == "Z")
                {
                    this.escenario.trasladarEscenario(0, 0, datos.Valor);
                }
                Console.WriteLine("Escenario trasladado");

            }
            else if (datos.Parte == "Todo el objeto")
            {

                if (this.objetoSeleccionado == null)
                {
                    Console.WriteLine("Objeto no encontrado.");
                    return;
                }
                if (datos.Eje == "X")
                {
                    this.objetoSeleccionado.Translate(datos.Valor, 0, 0);
                }
                if (datos.Eje == "Y")
                {
                    this.objetoSeleccionado.Translate(0, datos.Valor, 0);
                }
                if (datos.Eje == "Z")
                {
                    this.objetoSeleccionado.Translate(0, 0, datos.Valor);
                }
                Console.WriteLine("Objeto trasladado " + this.objetoSeleccionado.Nombre);

            }
            else if (datos.Parte != "Ninguno")
            {
                string parteName = datos.Parte;
                Console.WriteLine(parteName);

                this.parteSeleccionada = this.escenario.GetParteByName(this.objetoSeleccionado, parteName);

                if (this.parteSeleccionada == null)
                {
                    Console.WriteLine("Parte no encontrada.");
                    return;
                }
                if (datos.Eje == "X")
                {
                    this.parteSeleccionada.Translate(datos.Valor, 0, 0);
                }
                if (datos.Eje == "Y")
                {
                    this.parteSeleccionada.Translate(0, datos.Valor, 0);
                }
                if (datos.Eje == "Z")
                {
                    this.parteSeleccionada.Translate(0, 0, datos.Valor);
                }
                Console.WriteLine("Parte trasladada " + this.parteSeleccionada.Nombre);
            }
            else
            {
                Console.WriteLine("Opción inválida.");
            }
        }

        private void Escalacion(ApiResponse datos)
        {
            string objectName = datos.Objeto;
            this.objetoSeleccionado = this.escenario.GetObjectByName(objectName);

            if (datos.Escenario == "Todo el escenario")
            {

                //if (datos.Eje == "X")
                //{
                //    this.escenario.escalarEscenario(2, 0, 0);
                //}
                //if (datos.Eje == "Y")
                //{
                //    this.escenario.escalarEscenario(0, 2, 0);
                //}
                //if (datos.Eje == "Z")
                //{
                //    this.escenario.escalarEscenario(0, 0, 2);
                //}
                this.escenario.escalarEscenario(datos.Valor * 20, datos.Valor * 20, datos.Valor * 20);
                //Console.WriteLine(datos.Valor * 20);
                Console.WriteLine("Escenario escalado");

            }
            else if (datos.Parte == "Todo el objeto")
            {

                if (this.objetoSeleccionado == null)
                {
                    Console.WriteLine("Objeto no encontrado.");
                    return;
                }
                //if (datos.Eje == "X")
                //{
                //    this.objetoSeleccionado.Scale(2, 0, 0);
                //}
                //if (datos.Eje == "Y")
                //{
                //    this.objetoSeleccionado.Scale(0, 2, 0);
                //}
                //if (datos.Eje == "Z")
                //{
                //    this.objetoSeleccionado.Scale(0, 0, 2);
                //}
                this.objetoSeleccionado.Scale(2, 2, 2);
                Console.WriteLine("Objeto escalado " + this.objetoSeleccionado.Nombre);

            }
            else if (datos.Parte != "Ninguno")
            {
                string parteName = datos.Parte;
                Console.WriteLine(parteName);

                this.parteSeleccionada = this.escenario.GetParteByName(this.objetoSeleccionado, parteName);

                if (this.parteSeleccionada == null)
                {
                    Console.WriteLine("Parte no encontrada.");
                    return;
                }
                //if (datos.Eje == "X")
                //{
                //    this.parteSeleccionada.Scale(2, 0, 0);
                //}
                //if (datos.Eje == "Y")
                //{
                //    this.parteSeleccionada.Scale(0, 2, 0);
                //}
                //if (datos.Eje == "Z")
                //{
                //    this.parteSeleccionada.Scale(0, 0, 2);
                //}
                this.parteSeleccionada.Scale(2, 2, 2);
                Console.WriteLine("Parte escalada " + this.parteSeleccionada.Nombre);
            }
            else
            {
                Console.WriteLine("Opción inválida.");
            }
        }

    }
}
