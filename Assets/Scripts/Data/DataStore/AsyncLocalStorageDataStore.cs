using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CAFU.Data.Data.Repository;
using UniRx.Async;

namespace CAFU.Data.Data.DataStore
{
    public class AsyncLocalStorageDataStore : IAsyncDataHandler
    {
        public async UniTask CreateAsync(Uri uri, IEnumerable<byte> data, CancellationToken cancellationToken = default)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                cancellationToken.ThrowIfCancellationRequested();
            }

            if (await ExistsAsync(uri, cancellationToken))
            {
                throw new InvalidOperationException($"File `{GetUnescapedAbsolutePath(uri)}' has already exists. Please consider to use IWritableDataStore.");
            }

            CreateDirectoryIfNeeded(uri);

            using (var stream = new FileStream(GetUnescapedAbsolutePath(uri), FileMode.CreateNew, FileAccess.ReadWrite, FileShare.ReadWrite))
            {
                var enumerable = data as byte[] ?? data.ToArray();
                await stream.WriteAsync(enumerable, 0, enumerable.Length, cancellationToken);
            }
        }

        public async UniTask<IEnumerable<byte>> ReadAsync(Uri uri, CancellationToken cancellationToken = default)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                cancellationToken.ThrowIfCancellationRequested();
            }

            if (!await ExistsAsync(uri, cancellationToken))
            {
                throw new FileNotFoundException($"File `{GetUnescapedAbsolutePath(uri)}' does not found.");
            }

            using (var stream = new FileStream(GetUnescapedAbsolutePath(uri), FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite))
            {
                var data = new byte[stream.Length];
                await stream.ReadAsync(data, 0, (int) stream.Length, cancellationToken);
                return data;
            }
        }

        public async UniTask UpdateAsync(Uri uri, IEnumerable<byte> data, CancellationToken cancellationToken = default)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                cancellationToken.ThrowIfCancellationRequested();
            }

            if (!await ExistsAsync(uri, cancellationToken))
            {
                throw new FileNotFoundException($"File `{GetUnescapedAbsolutePath(uri)}' does not found.");
            }

            using (var stream = new FileStream(GetUnescapedAbsolutePath(uri), FileMode.Truncate, FileAccess.ReadWrite, FileShare.ReadWrite))
            {
                var enumerable = data as byte[] ?? data.ToArray();
                await stream.WriteAsync(enumerable, 0, enumerable.Length, cancellationToken);
            }
        }

        public async UniTask DeleteAsync(Uri uri, CancellationToken cancellationToken = default)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                cancellationToken.ThrowIfCancellationRequested();
            }

            if (!await ExistsAsync(uri, cancellationToken))
            {
                throw new FileNotFoundException($"File `{GetUnescapedAbsolutePath(uri)}' does not found.");
            }

            await Task
                .Run(
                    () => { File.Delete(GetUnescapedAbsolutePath(uri)); },
                    cancellationToken
                );
        }

        public async UniTask WriteAsync(Uri uri, IEnumerable<byte> data, CancellationToken cancellationToken = default)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                cancellationToken.ThrowIfCancellationRequested();
            }

            CreateDirectoryIfNeeded(uri);
            using (var stream = new FileStream(GetUnescapedAbsolutePath(uri), FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite))
            {
                var enumerable = data as byte[] ?? data.ToArray();
                await stream.WriteAsync(enumerable, 0, enumerable.Length, cancellationToken);
            }
        }

        public async UniTask<bool> ExistsAsync(Uri uri, CancellationToken cancellationToken = default)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                cancellationToken.ThrowIfCancellationRequested();
            }

            return await UniTask.FromResult(File.Exists(GetUnescapedAbsolutePath(uri)));
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