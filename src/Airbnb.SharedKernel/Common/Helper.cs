using System.Security.Cryptography;
using System.Text;

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
}