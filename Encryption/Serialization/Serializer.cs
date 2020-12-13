using Newtonsoft.Json;

namespace Encryption.Serialization
{
    public class Serializer : ISerializer
    {
        public string Serialize<T>(T data)
        {
            return JsonConvert.SerializeObject(data);
        }

        public T Deserialize<T>(string data)
        {
            return JsonConvert.DeserializeObject<T>(data);
        }

        public string Serialize<T>(T data, Formatting formatting)
        {
            return JsonConvert.SerializeObject(data, formatting);
        }
    }
}