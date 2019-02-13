using System;
using System.Collections.Generic;
using System.Threading;
using CAFU.Core;
using UniRx;
using UniRx.Async;

namespace CAFU.Data.Data.Repository
{
    public interface IStandardWriter : IDataStore
    {
        void Write(Uri uri, IEnumerable<byte> data);
    }

    public interface IObservableWriter : IDataStore
    {
        IObservable<Unit> WriteAsObservable(Uri uri, IEnumerable<byte> data);
    }

    public interface IAsyncWriter : IDataStore
    {
        UniTask WriteAsync(Uri uri, IEnumerable<byte> data, CancellationToken cancellationToken = default);
    }
}