using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IllLauncher.Model
{
    public class JsonHelper
    {
        public void SerializeToFile(object obj, string fileName)
        {

            if (!Directory.Exists(Path.GetDirectoryName(fileName)))
                Directory.CreateDirectory(Path.GetDirectoryName(fileName));
            File.WriteAllText(fileName, Serialize(obj));
        }
        public string Serialize(object obj)
        {
            string serializedContent = JsonConvert.SerializeObject(obj, Newtonsoft.Json.Formatting.Indented, new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.Auto });
            SerializingFinishedEvent?.Invoke(this, new DefaultEventArgs(serializedContent));
            return serializedContent;
        }

        public T Deserialize<T>(string fileName) where T : class, new()
        {
            if (!File.Exists(fileName))
                return new T();
            string fileContent = File.ReadAllText(fileName);
            T deserializedItem = JsonConvert.DeserializeObject<T>(fileContent, new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.Auto });
            DeserializeFinishedEvent?.Invoke(null, new DefaultEventArgs(deserializedItem));
            return deserializedItem;
        }
        public async Task<T> DeserializeAsync<T>(string fileName) where T:class, new ()
            {
            DeserializeFinishedEvent += JsonHelper_DeserializeFinishedEvent;

            if (!File.Exists(fileName))
                return new T();
            string fileContent = File.ReadAllText(fileName);
            T deserializedItem = JsonConvert.DeserializeObject<T>(fileContent, new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.Auto });
            DeserializeFinishedEvent?.Invoke(null, new DefaultEventArgs(deserializedItem));
            return deserializedItem;
            }

        private void JsonHelper_DeserializeFinishedEvent(object sender, DefaultEventArgs e)
        {
            DeserializeAsyncFinishedEvent?.Invoke(sender, e);
        }

        public delegate void SerializingFinishedHandler(object sender, DefaultEventArgs e);
        public event SerializingFinishedHandler SerializingFinishedEvent;

        public delegate void DeserializeFinishedHandler(object sender, DefaultEventArgs e);
        public event DeserializeFinishedHandler DeserializeFinishedEvent;

        public delegate void DeserializeAsyncFinishedHandler(object sender, DefaultEventArgs e);
        public event DeserializeAsyncFinishedHandler DeserializeAsyncFinishedEvent;
    }
}
