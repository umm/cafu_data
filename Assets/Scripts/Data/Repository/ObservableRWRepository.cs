using System;
using System.Collections.Generic;
using CAFU.Data.Data.UseCase;
using UniRx;
using Zenject;

namespace CAFU.Data.Data.Repository
{
    public class ObservableRWRepository : IObservableRWHandler
    {
        [Inject] private IObservableReader Reader { get; set; }
        [Inject] private IObservableWriter Writer { get; set; }
        [Inject] private IObservableDeleter Deleter { get; set; }
        [Inject] private IChecker Checker { get; set; }

        public IObservable<IEnumerable<byte>> ReadAsObservable(Uri uri)
        {
            return Reader.ReadAsObservable(uri);
        }

        public IObservable<Unit> WriteAsObservable(Uri uri, IEnumerable<byte> data)
        {
            return Writer.WriteAsObservable(uri, data);
        }

        public IObservable<Unit> DeleteAsObservable(Uri uri)
        {
            return Deleter.DeleteAsObservable(uri);
        }

        public bool Exists(Uri uri)
        {
            return Checker.Exists(uri);
        }
    }
}