using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CAFU.Core;
using UniRx;

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
        Task CreateAsync(Uri uri, IEnumerable<byte> data);
    }
}