namespace EZBank.Interfaces
{
    public interface IDBServerConnectionFactory
    {
        IDBServerConnection CreateConnection();

    }
}
