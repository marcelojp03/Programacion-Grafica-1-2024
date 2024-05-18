using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramacionGrafica
{
    public class ApiResponse
    {
        public int Codigo { get; set; }
        public string Objeto { get; set; }
        public string Parte { get; set; }
        public string Escenario { get; set; }
        public string Transformacion { get; set; }
        public string Eje { get; set; }
        public float Valor { get; set; }
        public ApiResponse(int Codigo, string Objeto, string Parte, string Escenario, string Transformacion,
            string Eje, float Valor)
        {
            this.Codigo = Codigo;
            this.Objeto = Objeto;
            this.Parte = Parte;
            this.Escenario = Escenario;
            this.Transformacion = Transformacion;
            this.Eje = Eje;
            this.Valor = Valor;
        }
    }
}
