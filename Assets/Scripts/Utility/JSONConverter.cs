using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace CAFU.Data.Utility
{
    public static class JSONConverter
    {
        public static IEnumerable<byte> ToByteArray<T>(this T element)
        {
            return Encoding.UTF8.GetBytes(JsonUtility.ToJson(element));
        }

        public static T FromByteArray<T>(this IEnumerable<byte> bytes)
        {
            return JsonUtility.FromJson<T>(Encoding.UTF8.GetString(bytes.ToArray()));
        }
    }
}