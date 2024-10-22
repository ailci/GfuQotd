using System.Text.Json;

namespace GfuQotd.Blazor.Wasm.Utilities
{
    public static class Util
    {
        public static string LogAsJson<T>(this T obj) where T : class
        {
            return JsonSerializer.Serialize(obj, new JsonSerializerOptions { WriteIndented = true });
        }
    }
}
