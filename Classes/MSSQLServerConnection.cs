using EZBank.Interfaces;

namespace EZBank.Classes
{
    public class MSSQLServerConnection : IDBServerConnection
    {
        public bool ValidateConnection(ISession session)
        {
            return false;
        }
    }
}
