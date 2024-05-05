using OpenTK;
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
        private Objeto objetoSeleccionado;
        private Parte parteSeleccionada;
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
                Console.WriteLine("4. Mostrar escenario");
                Console.WriteLine("5. Salir");
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
                            PerformScaling();
                            //this.game.Run();
                            break;
                        case 3:
                            PerformTranslation();
                            //this.game.Run();
                            break;
                        case 4:
                            this.game.Run();
                            break;
                        case 5:
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
                Console.WriteLine("Presione cualquier tecla para continuar...");
                Console.ReadKey(true);
            }
        }

        private void PerformRotation()
        {
            Console.WriteLine("Seleccione el objeto a rotar:");
            string objectName = this.GetObjectName();
            if(objectName=="All")
            {
                Console.WriteLine("Seleccione el eje de rotación para el escenario:");
                Console.WriteLine("1. Eje X");
                Console.WriteLine("2. Eje Y");
                Console.WriteLine("3. Eje Z");

                string axisChoice = Console.ReadLine();

                switch (axisChoice)
                {
                    case "1":
                        this.game.rotarEscenarioX = true;
                        break;
                    case "2":
                        this.game.rotarEscenarioY = true;
                        break;
                    case "3":
                        this.game.rotarEscenarioZ = true;
                        break;
                    default:
                        Console.WriteLine("Opción inválida para el eje de rotación.");
                        return;
                }

                this.game.Run();
                return;
            }
            Console.WriteLine("object name: " + objectName);
            this.game.objetoSeleccionado = this.escenario.GetObjectByName(objectName);

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

                Console.WriteLine("Seleccione el eje de rotación:");
                Console.WriteLine("1. Eje X");
                Console.WriteLine("2. Eje Y");
                Console.WriteLine("3. Eje Z");

                string axisChoice = Console.ReadLine();

                switch (axisChoice)
                {
                    case "1":
                        this.game.rotarX = true;
                        break;
                    case "2":
                        this.game.rotarY = true;
                        break;
                    case "3":
                        this.game.rotarZ = true;
                        break;
                    default:
                        Console.WriteLine("Opción inválida para el eje de rotación.");
                        return;
                }

                this.game.Run();
                Console.WriteLine("Objeto rotado.");
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
                Console.WriteLine("Seleccione el eje de rotación:");
                Console.WriteLine("1. Eje X");
                Console.WriteLine("2. Eje Y");
                Console.WriteLine("3. Eje Z");

                string axisChoice = Console.ReadLine();

                switch (axisChoice)
                {
                    case "1":
                        this.game.rotarX = true;
                        break;
                    case "2":
                        this.game.rotarY = true;
                        break;
                    case "3":
                        this.game.rotarZ = true;
                        break;
                    default:
                        Console.WriteLine("Opción inválida para el eje de rotación.");
                        return;
                }

                this.game.Run();
                Console.WriteLine("Parte rotada.");
            }
            else
            {
                Console.WriteLine("Opción inválida.");
            }
        }

        private void PerformTranslation()
        {
            Console.WriteLine("Seleccione el objeto a trasladar:");
            string objectName = this.GetObjectName();
            if (objectName == "All")
            {
                Console.WriteLine("Ingrese los valores de traslación en x, y, z:");
                Console.Write("x: ");
                float tx = float.Parse(Console.ReadLine());
                Console.Write("y: ");
                float ty = float.Parse(Console.ReadLine());
                Console.Write("z: ");
                float tz = float.Parse(Console.ReadLine());

                this.escenario.trasladarEscenario(tx, ty, tz);
                this.game.Run();
                Console.WriteLine("Escenario trasladado.");
                return;
            }
            Console.WriteLine("object name: " + objectName);
            this.objetoSeleccionado = this.escenario.GetObjectByName(objectName);

            if (this.objetoSeleccionado == null)
            {
                Console.WriteLine("Objeto no encontrado.");
                return;
            }


            Console.WriteLine("Seleccione la acción:");
            Console.WriteLine("1. Trasladar todo el objeto");
            Console.WriteLine("2. Trasladar una parte");

            string actionChoice = Console.ReadLine();

            if(actionChoice=="1")
            {
                Console.WriteLine("Ingrese los valores de traslación en x, y, z:");
                Console.Write("x: ");
                float tx = float.Parse(Console.ReadLine());
                Console.Write("y: ");
                float ty = float.Parse(Console.ReadLine());
                Console.Write("z: ");
                float tz = float.Parse(Console.ReadLine());


                this.objetoSeleccionado.Translate(tx, ty, tz);
                this.game.Run();
                Console.WriteLine("Objeto trasladado.");
            }
            else if (actionChoice == "2")
            {
                Console.WriteLine("Seleccione la parte a rotar:");
                string parteName = GetParteName(this.objetoSeleccionado);

                this.parteSeleccionada = this.escenario.GetParteByName(this.objetoSeleccionado, parteName);

                if (this.parteSeleccionada == null)
                {
                    Console.WriteLine("Parte no encontrada.");
                    return;
                }
                Console.WriteLine("Ingrese los valores de traslación en x, y, z:");
                Console.Write("x: ");
                float tx = float.Parse(Console.ReadLine());
                Console.Write("y: ");
                float ty = float.Parse(Console.ReadLine());
                Console.Write("z: ");
                float tz = float.Parse(Console.ReadLine());

         
                this.parteSeleccionada.Translate(tx, ty, tz);
                this.game.Run();
                Console.WriteLine("Parte trasladada.");
            }
            else
            {
                Console.WriteLine("Opción inválida.");
            }
        }

        private void PerformScaling()
        {
            Console.WriteLine("Seleccione el objeto a escalar:");
            string objectName = this.GetObjectName();
            if (objectName == "All")
            {
                Console.WriteLine("Ingrese el factor de escala para x, y, z:");
                Console.Write("Factor de escala: ");
                float scale = float.Parse(Console.ReadLine());
                this.escenario.escalarEscenario(scale, scale, scale);
                this.game.Run();
                Console.WriteLine("Escenario escalado.");
                return;
            }
            Console.WriteLine("object name: " + objectName);
            this.objetoSeleccionado = this.escenario.GetObjectByName(objectName);

            if (this.objetoSeleccionado == null)
            {
                Console.WriteLine("Objeto no encontrado.");
                return;
            }

            Console.WriteLine("Seleccione la acción:");
            Console.WriteLine("1. Escalar todo el objeto");
            Console.WriteLine("2. Escalar una parte");

            string actionChoice = Console.ReadLine();

            if (actionChoice == "1")
            {
                Console.WriteLine("Ingrese el factor de escala para x, y, z:");
                Console.Write("Factor de escala: ");
                float scale = float.Parse(Console.ReadLine());

                this.objetoSeleccionado.Scale(scale, scale, scale);
                this.game.Run();
                Console.WriteLine("Objeto escalado.");
            }
            else if (actionChoice == "2")
            {
                Console.WriteLine("Seleccione la parte a escalar:");
                string parteName = GetParteName(this.objetoSeleccionado);

                this.parteSeleccionada = this.escenario.GetParteByName(this.objetoSeleccionado, parteName);

                if (this.parteSeleccionada == null)
                {
                    Console.WriteLine("Parte no encontrada.");
                    return;
                }
                Console.WriteLine("Ingrese el factor de escala para x, y, z:");
                Console.Write("Factor de escala: ");
                float scale = float.Parse(Console.ReadLine());

                this.parteSeleccionada.Scale(scale, scale, scale);
                this.game.Run();
                Console.WriteLine("Parte escalada.");
            }
            else
            {
                Console.WriteLine("Opción inválida.");
            }
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
            Console.WriteLine($"{index}. Rotar todo el escenario");

            Console.Write("Ingrese el número del objeto: ");
            string choice = Console.ReadLine();

            int selection;
            if (int.TryParse(choice, out selection) && selection > 0 && selection <= escenario.Objetos.Count)
            {
                return escenario.Objetos[selection - 1].Nombre;
            }
            else if(selection>0 && selection== escenario.Objetos.Count+1)
            {
                return "All";
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

            //Console.WriteLine($"{index}. Todo el objeto");

            Console.Write("Ingrese el número de la parte (o todo el objeto): ");
            string choice = Console.ReadLine();

            int selection;
            if (int.TryParse(choice, out selection))
            {
                if (selection > 0 && selection <= obj.Partes.Count)
                {
                    return obj.Partes[selection - 1].Nombre;
                }
                //else if (selection == obj.Partes.Count + 1)
                //{
                //    return null; // Selects entire object (no part name)
                //}
            }

            return null;
        }
    }
}
