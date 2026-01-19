using System.Diagnostics;
using System.Reflection;
using System.Text.Json;

namespace Serialization
{
    internal class Program
    {
        private const int Iterations = 100000;
        static void Main(string[] args)
        {
            var obj = new F().Get();
            var sw = Stopwatch.StartNew();

            string customString = "";
            for (int i = 0; i < Iterations; i++)
            {
                customString = CustomSerialize(obj);
            }
            sw.Stop();
            var customSerializationTime = sw.ElapsedMilliseconds;
            sw.Restart();
            for (int i = 0; i < Iterations; i++)
            {
                CustomDeserialize<F>(customString);
            }
            sw.Stop();
            var customDeserializationTime = sw.ElapsedMilliseconds;

            sw.Restart();
            string jsonString = "";
            for (int i = 0; i < Iterations; i++)
            {
                jsonString = JsonSerializer.Serialize(obj);
            }
            sw.Stop();
            var jsonSerializationTime = sw.ElapsedMilliseconds;

            sw.Restart();
            for (int i = 0; i < Iterations; i++)
            {
                JsonSerializer.Deserialize<F>(jsonString);
            }
            sw.Stop();
            var jsonDeserializationTime = sw.ElapsedMilliseconds;

            Console.WriteLine($"Количество замеров: {Iterations} итераций");
            Console.WriteLine($"Мой рефлекшен: {customString}");
            Console.WriteLine($"Время своей сериализации: {customSerializationTime} мс");
            Console.WriteLine($"Время своей десериализацию: {customDeserializationTime} мс");
            Console.WriteLine("Cтандартный механизм (NewtonsoftJson):");
            Console.WriteLine($"Время на JSON-сериализацию: {jsonSerializationTime} мс");
            Console.WriteLine($"Время на JSON-десериализацию: {jsonDeserializationTime} мс");
            Console.ReadKey();
        }

        private static string CustomSerialize(object obj)
        {
            var fields = obj.GetType().GetFields(BindingFlags.Public | BindingFlags.Instance);
            var parts = new List<string>();
            foreach (var field in fields)
            {
                parts.Add($"{field.Name}:{field.GetValue(obj)}");
            }
            return string.Join(",", parts);
        }

        private static T CustomDeserialize<T>(string data) where T : new()
        {
            var obj = new T();
            var pairs = data.Split(',');
            var type = typeof(T);
            foreach (var pair in pairs)
            {
                var kv = pair.Split(':');
                var field = type.GetField(kv[0]);
                if (field != null)
                {
                    field.SetValue(obj, Convert.ChangeType(kv[1], field.FieldType));
                }
            }
            return obj;
        }
    }
}
