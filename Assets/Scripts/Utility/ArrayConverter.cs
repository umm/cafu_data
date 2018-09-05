using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using UnityEngine;

namespace CAFU.Data.Utility
{
    public static class ArrayConverter
    {
        public static IEnumerable<Color32> ByteArrayToColor32Array(IEnumerable<byte> bytes)
        {
            var enumerable = bytes as byte[] ?? bytes.ToArray();
            if (enumerable.Length == 0)
            {
                return null;
            }

            var sizeOfColor32 = Marshal.SizeOf(typeof(Color32));
            var length = enumerable.Length / sizeOfColor32;
            var colors = new Color32[length];

            for (var i = 0; i < length; i++)
            {
                colors[i] = new Color32(
                    enumerable[i * sizeOfColor32 + 0],
                    enumerable[i * sizeOfColor32 + 1],
                    enumerable[i * sizeOfColor32 + 2],
                    enumerable[i * sizeOfColor32 + 3]
                );
            }

            return colors;
        }

        public static IEnumerable<byte> Color32ArrayToByteArray(IEnumerable<Color32> colors)
        {
            var enumerable = colors as Color32[] ?? colors.ToArray();
            if (enumerable.Length == 0)
            {
                return null;
            }

            var lengthOfColor32 = Marshal.SizeOf(typeof(Color32));
            var length = lengthOfColor32 * enumerable.Length;
            var bytes = new byte[length];

            var handle = default(GCHandle);
            try
            {
                handle = GCHandle.Alloc(colors, GCHandleType.Pinned);
                var ptr = handle.AddrOfPinnedObject();
                Marshal.Copy(ptr, bytes, 0, length);
            }
            finally
            {
                if (handle != default(GCHandle))
                {
                    handle.Free();
                }
            }

            return bytes;
        }
    }
}