using System;
using System.Collections.Generic;
using System.Threading;
using CAFU.Core;
using UniRx.Async;

namespace CAFU.Data.Data.Repository
{
    public interface IStandardReader : IDataStore
    {
        IEnumerable<byte> Read(Uri uri);
    }

    public interface IObservableReader : IDataStore
    {
        IObservable<IEnumerable<byte>> ReadAsObservable(Uri uri);
    }

    public interface IAsyncReader : IDataStore
    {
        UniTask<IEnumerable<byte>> ReadAsync(Uri uri, CancellationToken cancellationToken = default);
    }
}