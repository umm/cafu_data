using System;
using System.Collections.Generic;
using CAFU.Data.Data.UseCase;
using Zenject;

namespace CAFU.Data.Data.Repository
{
    public class StandardRWRepository : IStandardRWHandler
    {
        [Inject] private IStandardReader Reader { get; }
        [Inject] private IStandardWriter Writer { get; }

        public IEnumerable<byte> Read(Uri uri)
        {
            return Reader.Read(uri);
        }

        public void Write(Uri uri, IEnumerable<byte> data)
        {
            Writer.Write(uri, data);
        }
    }
}