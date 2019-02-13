using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using CAFU.Data.Data.Repository;
using UniRx;
using UniRx.Async;

namespace CAFU.Data.Data.DataStore
{
    public class AsyncWebRequestDataStore : IAsyncDataHandler
    {
        public async UniTask CreateAsync(Uri uri, IEnumerable<byte> data, CancellationToken cancellationToken = default)
        {
            await ObservableUnityWebRequest.Put(uri.ToString(), data.ToArray()).ToUniTask(cancellationToken);
        }

        public async UniTask<IEnumerable<byte>> ReadAsync(Uri uri, CancellationToken cancellationToken = default)
        {
            return await ObservableUnityWebRequest.GetData(uri.ToString()).ToUniTask(cancellationToken);
        }

        public async UniTask UpdateAsync(Uri uri, IEnumerable<byte> data, CancellationToken cancellationToken = default)
        {
            await ObservableUnityWebRequest.Put(uri.ToString(), data.ToArray()).ToUniTask(cancellationToken);
        }

        public async UniTask DeleteAsync(Uri uri, CancellationToken cancellationToken = default)
        {
            await ObservableUnityWebRequest.Delete(uri.ToString()).ToUniTask(cancellationToken);
        }

        public async UniTask WriteAsync(Uri uri, IEnumerable<byte> data, CancellationToken cancellationToken = default)
        {
            await ObservableUnityWebRequest.Put(uri.ToString(), data.ToArray()).ToUniTask(cancellationToken);
        }

        public async UniTask<bool> ExistsAsync(Uri uri, CancellationToken cancellationToken = default)
        {
            return await ObservableUnityWebRequest.Head(uri.ToString())
                .Select(_ => true)
                .Catch((ObservableUnityWebRequest.UnityWebRequestErrorException e) => Observable.Return(false))
                .ToUniTask(cancellationToken);
        }
    }
}