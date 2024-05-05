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

        public static void SerializeObject<T>(T obj, string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    string json = JsonConvert.SerializeObject(obj, Formatting.Indented);
                    File.WriteAllText(filePath, json);
                }
                else
                {
                    Console.WriteLine("El archivo ya existe");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }

        public static T DeserializeObject<T>(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    string json = File.ReadAllText(filePath);
                    // Console.WriteLine("Archivo formato string "+json);
                    T deserializedObject = JsonConvert.DeserializeObject<T>(json); //Deserializa un objeto desde un string Json
                    //Console.WriteLine("Archivo serialized "+deserializedObject);
                    return deserializedObject;
                }
                
            }
            catch(Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
            return default(T);

        }

    }
}
