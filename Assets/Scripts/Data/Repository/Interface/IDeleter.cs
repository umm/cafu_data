using System;
using System.Threading.Tasks;
using CAFU.Core;
using UniRx;

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
        Task DeleteAsync(Uri uri);
    }
}