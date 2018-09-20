using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CAFU.Core;

namespace CAFU.Data.Data.Repository
{
    public interface IStandardReader : IDataStore
    {
        IEnumerable<byte> Read(Uri uri);
    }

    public interface IObservableReader : IDataStore
    {
        IObservable<IEnumerable<byte>> ReadAsObservable(Uri uri);
    }

    public interface IAsyncReader : IDataStore
    {
        Task<IEnumerable<byte>> ReadAsync(Uri uri);
    }
}