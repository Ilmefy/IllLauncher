using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IllLauncher.Model
{
    public static class JsonHelper
    {
        public static void SerializeToFile(object obj, string fileName)
        {

            if (!Directory.Exists(Path.GetDirectoryName(fileName)))
                Directory.CreateDirectory(Path.GetDirectoryName(fileName));
            File.WriteAllText(fileName,Serialize(obj));
        }
        public static string Serialize(object obj)=> JsonConvert.SerializeObject(obj, Newtonsoft.Json.Formatting.Indented, new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.Auto });
        public static T Deserialize<T>(string fileName)where T: class, new()
        {
            if(!File.Exists(fileName))
                return new T();
            string fileContent=File.ReadAllText(fileName);
            return JsonConvert.DeserializeObject<T>(fileContent, new JsonSerializerSettings() {TypeNameHandling= TypeNameHandling.Auto });

        }
    }
}
