using ProgramacionGrafica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Drawing;
using OpenTK.Graphics;

namespace ProgramacionGrafica
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Escenario escenario = new Escenario();
            escenario.CargarObjetoDeserializado("../../jsons/televisor.json");
            escenario.CargarObjetoDeserializado("../../jsons/parlantes.json");
            escenario.CargarObjetoDeserializado("../../jsons/escritorio.json");
            //using (Game game = new Game(escenario))
            //{
            //    game.Run();

            //}

            Menu menu = new Menu();
            menu.Show();
        }

    }
}
