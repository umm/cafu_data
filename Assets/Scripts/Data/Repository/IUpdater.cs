using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CAFU.Core;
using UniRx;

namespace CAFU.Data.Data.Repository
{
    public interface IStandardUpdater : IDataStore
    {
        void Update(Uri uri, IEnumerable<byte> data);
    }

    public interface IObservableUpdater : IDataStore
    {
        IObservable<Unit> UpdateAsObservable(Uri uri, IEnumerable<byte> data);
    }

    public interface IAsyncUpdater : IDataStore
    {
        Task UpdateAsync(Uri uri, IEnumerable<byte> data);
    }
}