using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CAFU.Data.Data.UseCase;
using Zenject;

namespace CAFU.Data.Data.Repository
{
    public class AsyncRWRepository : IAsyncRWHandler
    {
        [Inject] private IAsyncReader Reader { get; }
        [Inject] private IAsyncWriter Writer { get; }
        [Inject] private IChecker Checker { get; }

        public async Task<IEnumerable<byte>> ReadAsync(Uri uri)
        {
            return await Reader.ReadAsync(uri);
        }

        public async Task WriteAsync(Uri uri, IEnumerable<byte> data)
        {
            await Writer.WriteAsync(uri, data);
        }

        public bool Exists(Uri uri)
        {
            return Checker.Exists(uri);
        }
    }
}