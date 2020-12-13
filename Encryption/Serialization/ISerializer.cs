using Newtonsoft.Json;

namespace Encryption.Serialization
{
    public interface ISerializer
    {
        string Serialize<T>(T data);

        string Serialize<T>(T data, Formatting formatting);

        T Deserialize<T>(string data);
    }
}