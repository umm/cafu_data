using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CAFU.Core;
using UniRx;
using UniRx.Async;

namespace CAFU.Data.Data.UseCase
{
    public interface IStandardRWHandler : IRepository
    {
        IEnumerable<byte> Read(Uri uri);
        void Write(Uri uri, IEnumerable<byte> data);
        void Delete(Uri uri);
        bool Exists(Uri uri);
    }

    public interface IObservableRWHandler : IRepository
    {
        IObservable<IEnumerable<byte>> ReadAsObservable(Uri uri);
        IObservable<Unit> WriteAsObservable(Uri uri, IEnumerable<byte> data);
        IObservable<Unit> DeleteAsObservable(Uri uri);
        IObservable<bool> ExistsAsObservable(Uri uri);
    }

    public interface IAsyncRWHandler : IRepository
    {
        UniTask<IEnumerable<byte>> ReadAsync(Uri uri, CancellationToken cancellationToken = default);
        UniTask WriteAsync(Uri uri, IEnumerable<byte> data, CancellationToken cancellationToken = default);
        UniTask DeleteAsync(Uri uri, CancellationToken cancellationToken = default);
        UniTask<bool> ExistsAsync(Uri uri, CancellationToken cancellationToken = default);
    }
}