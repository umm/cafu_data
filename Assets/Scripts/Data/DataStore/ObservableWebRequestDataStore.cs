using System;
using System.Collections.Generic;
using CAFU.Data.Data.Repository;
using UniRx;
using UniRx.Async;

namespace CAFU.Data.Data.DataStore
{
    public class ObservableWebRequestDataStore : AsyncWebRequestDataStore, IObservableDataHandler
    {
        public IObservable<Unit> CreateAsObservable(Uri uri, IEnumerable<byte> data)
        {
            return CreateAsync(uri, data).ToObservable().AsUnitObservable();
        }

        public IObservable<IEnumerable<byte>> ReadAsObservable(Uri uri)
        {
            return ReadAsync(uri).ToObservable();
        }

        public IObservable<Unit> UpdateAsObservable(Uri uri, IEnumerable<byte> data)
        {
            return UpdateAsync(uri, data).ToObservable().AsUnitObservable();
        }

        public IObservable<Unit> DeleteAsObservable(Uri uri)
        {
            return DeleteAsync(uri).ToObservable().AsUnitObservable();
        }

        public IObservable<Unit> WriteAsObservable(Uri uri, IEnumerable<byte> data)
        {
            return WriteAsync(uri, data).ToObservable().AsUnitObservable();
        }

        public IObservable<bool> ExistsAsObservable(Uri uri)
        {
            return ExistsAsync(uri).ToObservable();
        }
    }
}