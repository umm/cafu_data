using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CAFU.Data.Data.UseCase;
using Zenject;

namespace CAFU.Data.Data.Repository
{
    public class AsyncCRUDRepository : IAsyncCRUDHandler
    {
        [Inject] private IAsyncCreator Creator { get; }
        [Inject] private IAsyncReader Reader { get; }
        [Inject] private IAsyncUpdater Updater { get; }
        [Inject] private IAsyncDeleter Deleter { get; }
        [Inject] private IChecker Checker { get; }

        public async Task CreateAsync(Uri uri, IEnumerable<byte> data)
        {
            await Creator.CreateAsync(uri, data);
        }

        public async Task<IEnumerable<byte>> ReadAsync(Uri uri)
        {
            return await Reader.ReadAsync(uri);
        }

        public async Task UpdateAsync(Uri uri, IEnumerable<byte> data)
        {
            await Updater.UpdateAsync(uri, data);
        }

        public async Task DeleteAsync(Uri uri)
        {
            await Deleter.DeleteAsync(uri);
        }

        public bool Exists(Uri uri)
        {
            return Checker.Exists(uri);
        }
    }
}