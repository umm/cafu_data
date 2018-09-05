using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CAFU.Core;
using UniRx;

namespace CAFU.Data.Data.Repository
{
    public interface IStandardWriter : IDataStore
    {
        void Write(Uri uri, IEnumerable<byte> data);
    }

    public interface IObservableWriter : IDataStore
    {
        IObservable<Unit> WriteAsObservable(Uri uri, IEnumerable<byte> data);
    }

    public interface IAsyncWriter : IDataStore
    {
        Task WriteAsync(Uri uri, IEnumerable<byte> data);
    }
}