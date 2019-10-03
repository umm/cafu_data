using System;
using System.Collections.Generic;
using System.Threading;
using UniRx;
using UniRx.Async;

namespace CAFU.Data.Data.Repository
{
    public interface IStandardWriter
    {
        void Write(Uri uri, IEnumerable<byte> data);
    }

    public interface IObservableWriter
    {
        IObservable<Unit> WriteAsObservable(Uri uri, IEnumerable<byte> data);
    }

    public interface IAsyncWriter
    {
        UniTask WriteAsync(Uri uri, IEnumerable<byte> data, CancellationToken cancellationToken = default);
    }
}
