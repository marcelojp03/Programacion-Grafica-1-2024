using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramacionGrafica
{
    public class Menu
    {
        private Escenario escenario = new Escenario();
        private Game game;
        public Menu()
        {
            //this.escenario = escenario;

        }

        public void cargarObjetos()
        {
            this.escenario = new Escenario();
            this.escenario.CargarObjetoDeserializado("../../jsons/televisor.json");
            this.escenario.CargarObjetoDeserializado("../../jsons/parlantes.json");
            this.escenario.CargarObjetoDeserializado("../../jsons/escritorio.json");
            //this.escenario.CargarObjetosv3();
        }
        public void Show()
        {
            while (true)
            {
                this.cargarObjetos();
                this.game = new Game(this.escenario);
                Console.Clear();
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Rotar");
                Console.WriteLine("2. Escalar");
                Console.WriteLine("3. Trasladar");
                Console.WriteLine("4. Salir");
                Console.WriteLine("----------");

                string choice = Console.ReadLine();

                int selection;
                if (int.TryParse(choice, out selection))
                {
                    switch (selection)
                    {
                        case 1:
                            PerformRotation();
                            //this.game.Run();
                            break;
                        case 2:
                            //PerformScaling();
                            break;
                        case 3:
                            //PerformTranslation();
                            break;
                        case 4:
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Opción inválida.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Entrada inválida. Ingrese un número.");
                }
                //this.game = null;
                Console.WriteLine("Presione cualquier tecla para continuar...");
                Console.ReadKey(true);
            }
        }

        private void PerformRotation()
        {
            Console.WriteLine("Seleccione el objeto a rotar:");
            string objectName = this.GetObjectName();
            Console.WriteLine("object name: " + objectName);
            this.game.objetoSeleccionado = this.escenario.GetObjectByName(objectName);
            //Console.WriteLine(this.objetoSeleccionado.Nombre);
            if (this.game.objetoSeleccionado == null)
            {
                Console.WriteLine("Objeto no encontrado.");
                return;
            }

            Console.WriteLine("Seleccione la acción:");
            Console.WriteLine("1. Rotar todo el objeto");
            Console.WriteLine("2. Seleccionar una parte");

            string actionChoice = Console.ReadLine();

            if (actionChoice == "1")
            {
                 
                this.game.rotar = true;
                this.game.Run();
                Console.WriteLine("Objeto rotado.");

                //base.Exit();
                //float angle;
                //Console.Write("Ingrese el ángulo de rotación (grados): ");
                //if (float.TryParse(Console.ReadLine(), out angle))
                //{
                //    //obj.Rotate2(MathHelper.DegreesToRadians(angle)); // Convert degrees to radians
                //    //this.escenario.rotarObjeto(obj,angle);
                //    //this.escenario.rotarObjeto2(angle);
                //    this.rotar = true;
                //    this.Run();
                //    Console.WriteLine("Objeto rotado.");
                //}
                //else
                //{
                //    Console.WriteLine("Valor inválido para el ángulo.");
                //}
            }
            else if (actionChoice == "2")
            {
                Console.WriteLine("Seleccione la parte a rotar:");
                string parteName = GetParteName(this.game.objetoSeleccionado);

                this.game.parteSeleccionada = this.escenario.GetParteByName(this.game.objetoSeleccionado, parteName);

                if (this.game.parteSeleccionada == null)
                {
                    Console.WriteLine("Parte no encontrada.");
                    return;
                }
                this.game.rotar = true;
                this.game.Run();
                Console.WriteLine("Parte rotada.");

                //float angle;
                //Console.Write("Ingrese el ángulo de rotación (grados): ");
                //if (float.TryParse(Console.ReadLine(), out angle))
                //{
                //    //this.part.Rotate(MathHelper.DegreesToRadians(angle));
                //    this.Run();
                //    Console.WriteLine("Parte rotada.");
                //}
                //else
                //{
                //    Console.WriteLine("Valor inválido para el ángulo.");
                //}               
            }
            else
            {
                Console.WriteLine("Opción inválida.");
            }

            //Console.WriteLine(this.objetoSeleccionado.Nombre);

        }

        private string GetObjectName()
        {
            Console.WriteLine("Lista de objetos:");
            int index = 1;
            foreach (var obj in this.escenario.Objetos)
            {
                Console.WriteLine($"{index}. {obj.Nombre}");
                index++;
            }

            Console.Write("Ingrese el número del objeto: ");
            string choice = Console.ReadLine();

            int selection;
            if (int.TryParse(choice, out selection) && selection > 0 && selection <= escenario.Objetos.Count)
            {
                return escenario.Objetos[selection - 1].Nombre;
            }

            return null;
        }

        private string GetParteName(Objeto obj)
        {
            Console.WriteLine("Lista de partes del objeto:");
            int index = 1;
            foreach (var parte in obj.Partes)
            {
                Console.WriteLine($"{index}. {parte.Nombre}");
                index++;
            }

            Console.WriteLine($"{index}. Todo el objeto");

            Console.Write("Ingrese el número de la parte (o todo el objeto): ");
            string choice = Console.ReadLine();

            int selection;
            if (int.TryParse(choice, out selection))
            {
                if (selection > 0 && selection <= obj.Partes.Count)
                {
                    return obj.Partes[selection - 1].Nombre;
                }
                else if (selection == obj.Partes.Count + 1)
                {
                    return null; // Selects entire object (no part name)
                }
            }

            return null;
        }
    }
}
