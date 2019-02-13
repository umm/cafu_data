using System;
using System.Collections.Generic;
using System.Threading;
using CAFU.Data.Data.UseCase;
using UniRx.Async;
using Zenject;

namespace CAFU.Data.Data.Repository
{
    public class AsyncRWRepository : IAsyncRWHandler
    {
        [Inject] private IAsyncReader Reader { get; set; }
        [Inject] private IAsyncWriter Writer { get; set; }
        [Inject] private IAsyncDeleter Deleter { get; set; }
        [Inject] private IAsyncChecker Checker { get; set; }

        public async UniTask<IEnumerable<byte>> ReadAsync(Uri uri, CancellationToken cancellationToken = default)
        {
            return await Reader.ReadAsync(uri, cancellationToken);
        }

        public async UniTask WriteAsync(Uri uri, IEnumerable<byte> data, CancellationToken cancellationToken = default)
        {
            await Writer.WriteAsync(uri, data, cancellationToken);
        }

        public async UniTask DeleteAsync(Uri uri, CancellationToken cancellationToken = default)
        {
            await Deleter.DeleteAsync(uri, cancellationToken);
        }

        public async UniTask<bool> ExistsAsync(Uri uri, CancellationToken cancellationToken = default)
        {
            return await Checker.ExistsAsync(uri, cancellationToken);
        }
    }
}