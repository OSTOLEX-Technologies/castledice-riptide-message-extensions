using Riptide;

namespace castledice_riptide_dto_adapters;

public abstract class DataAdder<T>
{
    protected readonly Message Message;

    protected DataAdder(Message message)
    {
        Message = message;
    }
    
    internal abstract void AddData(T data);
}