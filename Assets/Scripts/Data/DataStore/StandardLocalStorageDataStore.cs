using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CAFU.Data.Data.Repository;

namespace CAFU.Data.Data.DataStore
{
    public class StandardLocalStorageDataStore :
        IStandardCreator,
        IStandardReader,
        IStandardUpdater,
        IStandardDeleter,
        IStandardWriter
    {
        public void Create(Uri uri, IEnumerable<byte> data)
        {
            if (File.Exists(GetUnescapedAbsolutePath(uri)))
            {
                throw new InvalidOperationException($"File `{GetUnescapedAbsolutePath(uri)}' has already exists. Please consider to use IWritableDataStore.");
            }

            CreateDirectoryIfNeeded(uri);

            File.WriteAllBytes(GetUnescapedAbsolutePath(uri), data.ToArray());
        }

        public IEnumerable<byte> Read(Uri uri)
        {
            if (!File.Exists(GetUnescapedAbsolutePath(uri)))
            {
                throw new FileNotFoundException($"File `{GetUnescapedAbsolutePath(uri)}' does not found.");
            }

            return File.ReadAllBytes(GetUnescapedAbsolutePath(uri));
        }

        public void Update(Uri uri, IEnumerable<byte> data)
        {
            if (!File.Exists(GetUnescapedAbsolutePath(uri)))
            {
                throw new FileNotFoundException($"File `{GetUnescapedAbsolutePath(uri)}' does not found.");
            }

            File.WriteAllBytes(GetUnescapedAbsolutePath(uri), data.ToArray());
        }

        public void Delete(Uri uri)
        {
            if (!File.Exists(GetUnescapedAbsolutePath(uri)))
            {
                throw new FileNotFoundException($"File `{GetUnescapedAbsolutePath(uri)}' does not found.");
            }

            File.Delete(GetUnescapedAbsolutePath(uri));
        }

        public void Write(Uri uri, IEnumerable<byte> data)
        {
            CreateDirectoryIfNeeded(uri);
            File.WriteAllBytes(GetUnescapedAbsolutePath(uri), data.ToArray());
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