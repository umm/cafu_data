using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CAFU.Core;
using UniRx;
using UniRx.Async;

namespace CAFU.Data.Data.Repository
{
    public interface IStandardCreator : IDataStore
    {
        void Create(Uri uri, IEnumerable<byte> data);
    }

    public interface IObservableCreator : IDataStore
    {
        IObservable<Unit> CreateAsObservable(Uri uri, IEnumerable<byte> data);
    }

    public interface IAsyncCreator : IDataStore
    {
        UniTask CreateAsync(Uri uri, IEnumerable<byte> data);
    }
}