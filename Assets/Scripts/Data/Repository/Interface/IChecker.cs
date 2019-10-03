using System;
using System.Threading;
using UniRx.Async;

namespace CAFU.Data.Data.Repository
{
    public interface IChecker
    {
    }
    public interface IStandardChecker : IChecker
    {
        bool Exists(Uri uri);
    }
    public interface IObservableChecker : IChecker
    {
        IObservable<bool> ExistsAsObservable(Uri uri);
    }
    public interface IAsyncChecker : IChecker
    {
        UniTask<bool> ExistsAsync(Uri uri, CancellationToken cancellationToken = default);
    }
}
