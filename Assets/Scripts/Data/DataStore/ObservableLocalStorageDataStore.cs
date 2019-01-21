using System;
using System.Collections.Generic;
using CAFU.Data.Data.Repository;
using UniRx;

namespace CAFU.Data.Data.DataStore
{
    /// <remarks>Can call ***Async methods, but compromise because we assume access via interface</remarks>
    public class ObservableLocalStorageDataStore : AsyncLocalStorageDataStore, IObservableDataHandler
    {
        public IObservable<Unit> CreateAsObservable(Uri uri, IEnumerable<byte> data)
        {
            return CreateAsync(uri, data).ToObservable();
        }

        public IObservable<IEnumerable<byte>> ReadAsObservable(Uri uri)
        {
            return ReadAsync(uri).ToObservable();
        }

        public IObservable<Unit> UpdateAsObservable(Uri uri, IEnumerable<byte> data)
        {
            return UpdateAsync(uri, data).ToObservable();
        }

        public IObservable<Unit> DeleteAsObservable(Uri uri)
        {
            return DeleteAsync(uri).ToObservable();
        }

        public IObservable<Unit> WriteAsObservable(Uri uri, IEnumerable<byte> data)
        {
            return WriteAsync(uri, data).ToObservable();
        }
    }
}