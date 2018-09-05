using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace CAFU.Data.Utility
{
    public static class HashCalculator
    {
        public static IEnumerable<byte> CalculateHash512(IEnumerable<byte> data)
        {
            var algorithm = new SHA512CryptoServiceProvider();
            var result = algorithm.ComputeHash(data.ToArray());
            algorithm.Clear();
            return result;
        }
    }

    public static class ByteArrayExtensions
    {
        public static string AsString(this IEnumerable<byte> data)
        {
            var sb = new StringBuilder();
            foreach (var b in data)
            {
                sb.Append(b.ToString("X2"));
            }

            return sb.ToString();
        }
    }
}