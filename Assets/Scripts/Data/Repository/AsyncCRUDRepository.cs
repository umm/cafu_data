using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CAFU.Data.Data.UseCase;
using UniRx.Async;
using Zenject;

namespace CAFU.Data.Data.Repository
{
    public class AsyncCRUDRepository : IAsyncCRUDHandler
    {
        [Inject] private IAsyncCreator Creator { get; set; }
        [Inject] private IAsyncReader Reader { get; set; }
        [Inject] private IAsyncUpdater Updater { get; set; }
        [Inject] private IAsyncDeleter Deleter { get; set; }
        [Inject] private IAsyncChecker Checker { get; set; }

        public async UniTask CreateAsync(Uri uri, IEnumerable<byte> data)
        {
            await Creator.CreateAsync(uri, data);
        }

        public async UniTask<IEnumerable<byte>> ReadAsync(Uri uri)
        {
            return await Reader.ReadAsync(uri);
        }

        public async UniTask UpdateAsync(Uri uri, IEnumerable<byte> data)
        {
            await Updater.UpdateAsync(uri, data);
        }

        public async UniTask DeleteAsync(Uri uri)
        {
            await Deleter.DeleteAsync(uri);
        }

        public async UniTask<bool> ExistsAsync(Uri uri)
        {
            return await Checker.ExistsAsync(uri);
        }
    }
}