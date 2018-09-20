using System;
using System.Collections.Generic;
using CAFU.Data.Data.UseCase;
using Zenject;

namespace CAFU.Data.Data.Repository
{
    public class StandardCRUDRepository : IStandardCRUDHandler
    {
        [Inject] private IStandardCreator Creator { get; }
        [Inject] private IStandardReader Reader { get; }
        [Inject] private IStandardUpdater Updater { get; }
        [Inject] private IStandardDeleter Deleter { get; }
        [Inject] private IChecker Checker { get; }

        public void Create(Uri uri, IEnumerable<byte> data)
        {
            Creator.Create(uri, data);
        }

        public IEnumerable<byte> Read(Uri uri)
        {
            return Reader.Read(uri);
        }

        public void Update(Uri uri, IEnumerable<byte> data)
        {
            Updater.Update(uri, data);
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