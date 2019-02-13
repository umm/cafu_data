using System;
using System.Collections.Generic;
using CAFU.Core;
using JetBrains.Annotations;
using UniRx;
using UniRx.Async;

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
        IObservable<bool> ExistsAsObservable(Uri uri);
    }

    [PublicAPI]
    public interface IAsyncCRUDHandler : IRepository
    {
        UniTask CreateAsync(Uri uri, IEnumerable<byte> data);
        UniTask<IEnumerable<byte>> ReadAsync(Uri uri);
        UniTask UpdateAsync(Uri uri, IEnumerable<byte> data);
        UniTask DeleteAsync(Uri uri);
        UniTask<bool> ExistsAsync(Uri uri);
    }
}