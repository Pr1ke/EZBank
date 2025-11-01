namespace EZBank.Interfaces
{
    public interface ISession
    {
        string userName { get; }
        string password { get; }
        string serverName { get; }
    }
}
