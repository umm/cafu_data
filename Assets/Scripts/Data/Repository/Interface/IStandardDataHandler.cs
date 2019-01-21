namespace CAFU.Data.Data.Repository
{
    public interface IStandardDataHandler :
        IStandardCreator,
        IStandardReader,
        IStandardUpdater,
        IStandardDeleter,
        IStandardWriter,
        IChecker
    {
    }
}