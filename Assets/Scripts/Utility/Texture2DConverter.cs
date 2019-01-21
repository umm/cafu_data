using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CAFU.Data.Utility
{
    public static class Texture2DConverter
    {
        public enum EncodeFormat
        {
            PNG,
            JPG,
            EXR,
            TGA,
        }

        public static Texture2D ByteArrayToTexture2D(IEnumerable<byte> bytes)
        {
            var texture2D = new Texture2D(0, 0);
            texture2D.LoadImage(bytes.ToArray());
            return texture2D;
        }

        public static IEnumerable<byte> Texture2DToByteArray(Texture2D texture2D, EncodeFormat encodeFormat)
        {
            switch (encodeFormat)
            {
                case EncodeFormat.PNG:
                    return texture2D.EncodeToPNG();
                case EncodeFormat.JPG:
                    return texture2D.EncodeToJPG();
                case EncodeFormat.EXR:
                    return texture2D.EncodeToEXR();
#if UNITY_2018_3_OR_NEWER
                case EncodeFormat.TGA:
                    return texture2D.EncodeToTGA();
#endif
                default:
                    throw new ArgumentOutOfRangeException(nameof(encodeFormat), encodeFormat, null);
            }
        }
    }
}
