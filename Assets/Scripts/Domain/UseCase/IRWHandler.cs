using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CAFU.Core;
using UniRx;

namespace CAFU.Data.Data.UseCase
{
    public interface IStandardRWHandler : IRepository
    {
        IEnumerable<byte> Read(Uri uri);
        void Write(Uri uri, IEnumerable<byte> data);
    }

    public interface IObservableRWHandler : IRepository
    {
        IObservable<IEnumerable<byte>> ReadAsObservable(Uri uri);
        IObservable<Unit> WriteAsObservable(Uri uri, IEnumerable<byte> data);
    }

    public interface IAsyncRWHandler : IRepository
    {
        Task<IEnumerable<byte>> ReadAsync(Uri uri);
        Task WriteAsync(Uri uri, IEnumerable<byte> data);
    }
}