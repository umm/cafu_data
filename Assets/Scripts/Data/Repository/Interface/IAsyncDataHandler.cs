namespace CAFU.Data.Data.Repository
{
    public interface IAsyncDataHandler :
        IAsyncCreator,
        IAsyncReader,
        IAsyncUpdater,
        IAsyncDeleter,
        IAsyncWriter,
        IAsyncChecker
    {
    }
}