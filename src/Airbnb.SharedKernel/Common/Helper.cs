using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Airbnb.SharedKernel.Common;

public static class Helper
{
    public static string GenerateHash(string str)
    {
        using var sha1 = SHA1.Create();
        var bytes = sha1.ComputeHash(Encoding.UTF8.GetBytes(str));

        var builder = new StringBuilder();
        foreach (var b in bytes)
        {
            builder.Append(b.ToString("x2"));
        }

        return builder.ToString();
    }

    public static object? PopulateObject(string assembly, string payload)
    {
        var type = Type.GetType(assembly);

        if (type is null)
            throw new ArgumentException($"Type '{assembly}' not found.");

        try
        {
            var data = JsonConvert.DeserializeObject<JObject>(payload);
            var instance = Activator.CreateInstance(type);

            foreach (var item in data)
            {
                var property = type.GetProperty(item.Key);
                if (property != null && property.CanWrite)
                {
                    property.SetValue(instance, Convert.ChangeType(item.Value, property.PropertyType), null);
                }
            }

            return instance;
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException($"Failed to populate object from payload. {ex.Message}", ex);
        }
    }
}