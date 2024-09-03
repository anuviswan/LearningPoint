namespace RxDemo001;
public interface IExecute
{
#pragma warning disable CA2252 // This API requires opting into preview features
    static abstract void Run();
#pragma warning restore CA2252 // This API requires opting into preview features
}
