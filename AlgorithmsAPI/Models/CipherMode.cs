using System.Text.Json.Serialization;

namespace AlgorithmsAPI.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum CipherMode
    {
        Encrypt,
        Decrypt
    }
}
