using System.Text.Json;

namespace TestAutomation.Utils
{
    public static class DataReader
    {
        public static List<T> ReadJson<T>(string filePath)
        {
            var json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<T>>(json);
        }
    }
}
