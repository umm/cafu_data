using System;
using System.Collections.Generic;
using System.Threading;
using UniRx;
using UniRx.Async;

namespace CAFU.Data.Data.Repository
{
    public interface IStandardCreator
    {
        void Create(Uri uri, IEnumerable<byte> data);
    }

    public interface IObservableCreator
    {
        IObservable<Unit> CreateAsObservable(Uri uri, IEnumerable<byte> data);
    }

    public interface IAsyncCreator
    {
        UniTask CreateAsync(Uri uri, IEnumerable<byte> data, CancellationToken cancellationToken = default);
    }
}
