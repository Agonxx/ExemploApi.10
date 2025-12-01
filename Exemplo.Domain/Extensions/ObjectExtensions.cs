using System.Text.Json;

namespace Exemplo.Infra.Extensions
{
    public static class ObjectExtensions
    {
        private static readonly JsonSerializerOptions _options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            WriteIndented = false
        };

        public static string ToJson(this object obj)
        {
            return JsonSerializer.Serialize(obj, _options);
        }

        public static T? FromJson<T>(this string json)
        {
            return JsonSerializer.Deserialize<T>(json, _options);
        }

        public static bool TryFromJson<T>(this string json, out T? result)
        {
            try
            {
                result = JsonSerializer.Deserialize<T>(json, _options);
                return result != null;
            }
            catch
            {
                result = default;
                return false;
            }
        }
    }
}
