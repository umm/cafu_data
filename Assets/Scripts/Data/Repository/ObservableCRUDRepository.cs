using System;
using System.Collections.Generic;
using CAFU.Data.Data.UseCase;
using UniRx;
using Zenject;

namespace CAFU.Data.Data.Repository
{
    public class ObservableCRUDRepository : IObservableCRUDHandler
    {
        [Inject] private IObservableCreator Creator { get; set; }
        [Inject] private IObservableReader Reader { get; set; }
        [Inject] private IObservableUpdater Updater { get; set; }
        [Inject] private IObservableDeleter Deleter { get; set; }
        [Inject] private IChecker Checker { get; set; }

        public IObservable<Unit> CreateAsObservable(Uri uri, IEnumerable<byte> data)
        {
            return Creator.CreateAsObservable(uri, data);
        }

        public IObservable<IEnumerable<byte>> ReadAsObservable(Uri uri)
        {
            return Reader.ReadAsObservable(uri);
        }

        public IObservable<Unit> UpdateAsObservable(Uri uri, IEnumerable<byte> data)
        {
            return Updater.UpdateAsObservable(uri, data);
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