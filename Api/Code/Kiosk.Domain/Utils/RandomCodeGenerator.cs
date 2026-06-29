using System.Security.Cryptography;
using System.Text;

namespace Kiosk.Domain.Utils;

public static class RandomCodeGenerator
{
    public static string Generate(string source, int length)
    {
        StringBuilder result = new StringBuilder(8);

        for (int i = 0; i < length; i++)
        {
            int index = RandomNumberGenerator.GetInt32(source.Length);
            result.Append(source[index]);
        }
        return result.ToString();
    }
}