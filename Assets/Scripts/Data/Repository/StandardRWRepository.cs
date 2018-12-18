using System;
using System.Collections.Generic;
using CAFU.Data.Data.UseCase;
using Zenject;

namespace CAFU.Data.Data.Repository
{
    public class StandardRWRepository : IStandardRWHandler
    {
        [Inject] private IStandardReader Reader { get; set; }
        [Inject] private IStandardWriter Writer { get; set; }
        [Inject] private IStandardDeleter Deleter { get; set; }
        [Inject] private IChecker Checker { get; set; }

        public IEnumerable<byte> Read(Uri uri)
        {
            return Reader.Read(uri);
        }

        public void Write(Uri uri, IEnumerable<byte> data)
        {
            Writer.Write(uri, data);
        }

        public void Delete(Uri uri)
        {
            Deleter.Delete(uri);
        }

        public bool Exists(Uri uri)
        {
            return Checker.Exists(uri);
        }
    }
}