using System;
using System.Collections.Generic;
using System.Threading;
using UniRx.Async;

namespace CAFU.Data.Data.Repository
{
    public interface IStandardReader
    {
        IEnumerable<byte> Read(Uri uri);
    }

    public interface IObservableReader
    {
        IObservable<IEnumerable<byte>> ReadAsObservable(Uri uri);
    }

    public interface IAsyncReader
    {
        UniTask<IEnumerable<byte>> ReadAsync(Uri uri, CancellationToken cancellationToken = default);
    }
}
