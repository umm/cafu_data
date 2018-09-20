using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CAFU.Data.Data.Repository;

namespace CAFU.Data.Data.DataStore
{
    public class AsyncLocalStorageDataStore :
        IAsyncCreator,
        IAsyncReader,
        IAsyncUpdater,
        IAsyncDeleter,
        IAsyncWriter,
        IChecker
    {
        public async Task CreateAsync(Uri uri, IEnumerable<byte> data)
        {
            if (Exists(uri))
            {
                throw new InvalidOperationException($"File `{GetUnescapedAbsolutePath(uri)}' has already exists. Please consider to use IWritableDataStore.");
            }

            CreateDirectoryIfNeeded(uri);

            using (var stream = new FileStream(GetUnescapedAbsolutePath(uri), FileMode.CreateNew, FileAccess.ReadWrite, FileShare.ReadWrite))
            {
                var enumerable = data as byte[] ?? data.ToArray();
                await stream.WriteAsync(enumerable, 0, enumerable.Length);
            }
        }

        public async Task<IEnumerable<byte>> ReadAsync(Uri uri)
        {
            if (!Exists(uri))
            {
                throw new FileNotFoundException($"File `{GetUnescapedAbsolutePath(uri)}' does not found.");
            }

            using (var stream = new FileStream(GetUnescapedAbsolutePath(uri), FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite))
            {
                var data = new byte[stream.Length];
                await stream.ReadAsync(data, 0, (int) stream.Length);
                return data;
            }
        }

        public async Task UpdateAsync(Uri uri, IEnumerable<byte> data)
        {
            if (!Exists(uri))
            {
                throw new FileNotFoundException($"File `{GetUnescapedAbsolutePath(uri)}' does not found.");
            }

            using (var stream = new FileStream(GetUnescapedAbsolutePath(uri), FileMode.Truncate, FileAccess.ReadWrite, FileShare.ReadWrite))
            {
                var enumerable = data as byte[] ?? data.ToArray();
                await stream.WriteAsync(enumerable, 0, enumerable.Length);
            }
        }

        public async Task DeleteAsync(Uri uri)
        {
            if (!Exists(uri))
            {
                throw new FileNotFoundException($"File `{GetUnescapedAbsolutePath(uri)}' does not found.");
            }

            await Task
                .Run(
                    () => { File.Delete(GetUnescapedAbsolutePath(uri)); }
                );
        }

        public async Task WriteAsync(Uri uri, IEnumerable<byte> data)
        {
            CreateDirectoryIfNeeded(uri);
            using (var stream = new FileStream(GetUnescapedAbsolutePath(uri), FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite))
            {
                var enumerable = data as byte[] ?? data.ToArray();
                await stream.WriteAsync(enumerable, 0, enumerable.Length);
            }
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

        public bool Exists(Uri uri)
        {
            return File.Exists(GetUnescapedAbsolutePath(uri));
        }
    }
}