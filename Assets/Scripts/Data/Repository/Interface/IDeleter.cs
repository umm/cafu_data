using System;
using System.Threading;
using CAFU.Core;
using UniRx;
using UniRx.Async;

namespace CAFU.Data.Data.Repository
{
    public interface IStandardDeleter : IDataStore
    {
        void Delete(Uri uri);
    }

    public interface IObservableDeleter : IDataStore
    {
        IObservable<Unit> DeleteAsObservable(Uri uri);
    }

    public interface IAsyncDeleter : IDataStore
    {
        UniTask DeleteAsync(Uri uri, CancellationToken cancellationToken = default);
    }
}