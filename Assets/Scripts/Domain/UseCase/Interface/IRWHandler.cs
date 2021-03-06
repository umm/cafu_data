using System;
using System.Collections.Generic;
using System.Threading;
using UniRx;
using UniRx.Async;

namespace CAFU.Data.Data.UseCase
{
    public interface IStandardRWHandler
    {
        IEnumerable<byte> Read(Uri uri);
        void Write(Uri uri, IEnumerable<byte> data);
        void Delete(Uri uri);
        bool Exists(Uri uri);
    }

    public interface IObservableRWHandler
    {
        IObservable<IEnumerable<byte>> ReadAsObservable(Uri uri);
        IObservable<Unit> WriteAsObservable(Uri uri, IEnumerable<byte> data);
        IObservable<Unit> DeleteAsObservable(Uri uri);
        IObservable<bool> ExistsAsObservable(Uri uri);
    }

    public interface IAsyncRWHandler
    {
        UniTask<IEnumerable<byte>> ReadAsync(Uri uri, CancellationToken cancellationToken = default);
        UniTask WriteAsync(Uri uri, IEnumerable<byte> data, CancellationToken cancellationToken = default);
        UniTask DeleteAsync(Uri uri, CancellationToken cancellationToken = default);
        UniTask<bool> ExistsAsync(Uri uri, CancellationToken cancellationToken = default);
    }
}
