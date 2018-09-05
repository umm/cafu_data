using System;
using System.Collections.Generic;
using CAFU.Data.Data.UseCase;
using UniRx;
using Zenject;

namespace CAFU.Data.Data.Repository
{
    public class ObservableRWRepository : IObservableRWHandler
    {
        [Inject] private IObservableReader Reader { get; }
        [Inject] private IObservableWriter Writer { get; }

        public IObservable<IEnumerable<byte>> ReadAsObservable(Uri uri)
        {
            return Reader.ReadAsObservable(uri);
        }

        public IObservable<Unit> WriteAsObservable(Uri uri, IEnumerable<byte> data)
        {
            return Writer.WriteAsObservable(uri, data);
        }
    }
}