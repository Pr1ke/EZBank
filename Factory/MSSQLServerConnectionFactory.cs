using EZBank.Classes;
using EZBank.Interfaces;

namespace EZBank.Helpers
{
    internal class MSSQLServerConnectionFactory : IDBServerConnectionFactory
    {
        public IDBServerConnection CreateConnection()
        {
            return new MSSQLServerConnection();

        }
    }
}
