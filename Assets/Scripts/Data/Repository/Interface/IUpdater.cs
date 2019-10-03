using System;
using System.Collections.Generic;
using System.Threading;
using UniRx;
using UniRx.Async;

namespace CAFU.Data.Data.Repository
{
    public interface IStandardUpdater
    {
        void Update(Uri uri, IEnumerable<byte> data);
    }

    public interface IObservableUpdater
    {
        IObservable<Unit> UpdateAsObservable(Uri uri, IEnumerable<byte> data);
    }

    public interface IAsyncUpdater
    {
        UniTask UpdateAsync(Uri uri, IEnumerable<byte> data, CancellationToken cancellationToken = default);
    }
}
