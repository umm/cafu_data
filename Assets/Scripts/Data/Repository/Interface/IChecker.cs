using System;
using CAFU.Core;

namespace CAFU.Data.Data.Repository
{
    public interface IChecker : IDataStore
    {
        bool Exists(Uri uri);
    }
}