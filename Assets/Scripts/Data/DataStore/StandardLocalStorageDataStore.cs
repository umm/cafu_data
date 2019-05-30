using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CAFU.Data.Data.Repository;

namespace CAFU.Data.Data.DataStore
{
    /// <remarks>Can call ***Async methods, but compromise because we assume access via interface</remarks>
    public class StandardLocalStorageDataStore : IStandardDataHandler
    {
        public void Create(Uri uri, IEnumerable<byte> data)
        {
            if (Exists(uri))
            {
                throw new InvalidOperationException(
                    $"File `{GetUnescapedAbsolutePath(uri)}' has already exists. Please consider to use IWritableDataStore."
                );
            }

            CreateDirectoryIfNeeded(uri);

            using (var stream = new FileStream(GetUnescapedAbsolutePath(uri), FileMode.CreateNew, FileAccess.ReadWrite,
                FileShare.ReadWrite))
            {
                var enumerable = data as byte[] ?? data.ToArray();
                stream.Write(enumerable, 0, enumerable.Length);
            }
        }

        public IEnumerable<byte> Read(Uri uri)
        {
            if (!Exists(uri))
            {
                throw new FileNotFoundException($"File `{GetUnescapedAbsolutePath(uri)}' does not found.");
            }

            using (var stream = new FileStream(GetUnescapedAbsolutePath(uri), FileMode.Open, FileAccess.ReadWrite,
                FileShare.ReadWrite))
            {
                var data = new byte[stream.Length];
                stream.Read(data, 0, (int) stream.Length);
                return data;
            }
        }

        public void Update(Uri uri, IEnumerable<byte> data)
        {
            if (!Exists(uri))
            {
                throw new FileNotFoundException($"File `{GetUnescapedAbsolutePath(uri)}' does not found.");
            }

            using (var stream = new FileStream(GetUnescapedAbsolutePath(uri), FileMode.Truncate, FileAccess.ReadWrite,
                FileShare.ReadWrite))
            {
                var enumerable = data as byte[] ?? data.ToArray();
                stream.Write(enumerable, 0, enumerable.Length);
            }
        }

        public void Delete(Uri uri)
        {
            if (!Exists(uri))
            {
                throw new FileNotFoundException($"File `{GetUnescapedAbsolutePath(uri)}' does not found.");
            }

            File.Delete(GetUnescapedAbsolutePath(uri));
        }

        public void Write(Uri uri, IEnumerable<byte> data)
        {
            CreateDirectoryIfNeeded(uri);

            using (var stream = new FileStream(GetUnescapedAbsolutePath(uri), FileMode.Create, FileAccess.ReadWrite,
                FileShare.ReadWrite))
            {
                var enumerable = data as byte[] ?? data.ToArray();
                stream.Write(enumerable, 0, enumerable.Length);
            }
        }

        public bool Exists(Uri uri)
        {
            return File.Exists(GetUnescapedAbsolutePath(uri));
        }

        private static void CreateDirectoryIfNeeded(Uri uri)
        {
            if (!Directory.Exists(Path.GetDirectoryName(GetUnescapedAbsolutePath(uri))))
            {
                // ReSharper disable once AssignNullToNotNullAttribute
                Directory.CreateDirectory(Path.GetDirectoryName(GetUnescapedAbsolutePath(uri)));
            }
        }

        private static string GetUnescapedAbsolutePath(Uri uri)
        {
            return Uri.UnescapeDataString(uri.AbsolutePath);
        }
    }
}