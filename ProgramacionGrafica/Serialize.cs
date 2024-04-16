using OpenTK;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ProgramacionGrafica
{
    public class Serialize
    {

        public static void SerializeObject<T>(T obj, string fileName)
        {
            string json = JsonConvert.SerializeObject(obj, Formatting.Indented);
            File.WriteAllText(fileName, json);
        }

        public static T DeserializeObject<T>(string fileName)
        {
            if (File.Exists(fileName))
            {
                string json = File.ReadAllText(fileName);
                Console.WriteLine("Archivo formato string "+json);
                T deserializedObject = JsonConvert.DeserializeObject<T>(json); //Deserializa un objeto desde un string Json
                //Console.WriteLine("Archivo serialized "+deserializedObject);
                return deserializedObject;
            }

            return default(T);
        }

    }
}
