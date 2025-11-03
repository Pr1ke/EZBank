using EZBank.Classes;
using EZBank.Interfaces;

namespace EZBank.Helpers
{
    internal class MSSQLServerConnectionFactory : IDBServerConnectionFactory
    {

        //Specifications require a SQL connection but dont specifiy which flavor,
        //well use a factory pattern here so we could easily replace the dataprovider.

        public IDBServerConnection CreateConnection()
        {
            return new MSSQLServerConnection();

        }
    }
}
