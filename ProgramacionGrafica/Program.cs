using ProgramacionGrafica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProgramacionGrafica.television;
using Newtonsoft.Json;
using System.Drawing;
using OpenTK.Graphics;

namespace ProgramacionGrafica
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            using (Game game= new Game())
            {
                game.Run();
            }
        }
    }
}
