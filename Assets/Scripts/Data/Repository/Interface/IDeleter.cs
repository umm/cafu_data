using System;
using System.Threading;
using UniRx;
using UniRx.Async;

namespace CAFU.Data.Data.Repository
{
    public interface IStandardDeleter
    {
        void Delete(Uri uri);
    }

    public interface IObservableDeleter
    {
        IObservable<Unit> DeleteAsObservable(Uri uri);
    }

    public interface IAsyncDeleter
    {
        UniTask DeleteAsync(Uri uri, CancellationToken cancellationToken = default);
    }
}
