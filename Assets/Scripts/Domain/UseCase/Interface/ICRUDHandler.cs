using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CAFU.Core;
using JetBrains.Annotations;
using UniRx;

namespace CAFU.Data.Data.UseCase
{
    [PublicAPI]
    public interface IStandardCRUDHandler : IRepository
    {
        void Create(Uri uri, IEnumerable<byte> data);
        IEnumerable<byte> Read(Uri uri);
        void Update(Uri uri, IEnumerable<byte> data);
        void Delete(Uri uri);
        bool Exists(Uri uri);
    }

    [PublicAPI]
    public interface IObservableCRUDHandler : IRepository
    {
        IObservable<Unit> CreateAsObservable(Uri uri, IEnumerable<byte> data);
        IObservable<IEnumerable<byte>> ReadAsObservable(Uri uri);
        IObservable<Unit> UpdateAsObservable(Uri uri, IEnumerable<byte> data);
        IObservable<Unit> DeleteAsObservable(Uri uri);
        bool Exists(Uri uri);
    }

    [PublicAPI]
    public interface IAsyncCRUDHandler : IRepository
    {
        Task CreateAsync(Uri uri, IEnumerable<byte> data);
        Task<IEnumerable<byte>> ReadAsync(Uri uri);
        Task UpdateAsync(Uri uri, IEnumerable<byte> data);
        Task DeleteAsync(Uri uri);
        bool Exists(Uri uri);
    }
}