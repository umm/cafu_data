namespace CAFU.Data.Data.Repository
{
    public interface IObservableDataHandler :
        IObservableCreator,
        IObservableReader,
        IObservableUpdater,
        IObservableDeleter,
        IObservableWriter,
        IChecker
    {
    }
}