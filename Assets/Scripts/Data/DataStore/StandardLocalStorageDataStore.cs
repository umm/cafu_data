using System;
using System.Collections.Generic;
using CAFU.Data.Data.Repository;

namespace CAFU.Data.Data.DataStore
{
    /// <remarks>Can call ***Async methods, but compromise because we assume access via interface</remarks>
    public class StandardLocalStorageDataStore : AsyncLocalStorageDataStore,
        IStandardCreator,
        IStandardReader,
        IStandardUpdater,
        IStandardDeleter,
        IStandardWriter
    {
        public void Create(Uri uri, IEnumerable<byte> data)
        {
            CreateAsync(uri, data).Wait();
        }

        public IEnumerable<byte> Read(Uri uri)
        {
            return ReadAsync(uri).Result;
        }

        public void Update(Uri uri, IEnumerable<byte> data)
        {
            UpdateAsync(uri, data).Wait();
        }

        public void Delete(Uri uri)
        {
            DeleteAsync(uri).Wait();
        }

        public void Write(Uri uri, IEnumerable<byte> data)
        {
            WriteAsync(uri, data).Wait();
        }
    }
}