using EZBank.Helpers;
using EZBank.Interfaces;
using System.Data.SqlClient;

namespace EZBank.Classes
{
    public class MSSQLServerConnection : IDBServerConnection
    {
        private ISession _session;

        public bool ValidateConnection(ISession session)
        {
            try
            {
                _session = session;
                using (SqlConnection connection = new SqlConnection(CreateConnectionString()))
                {
                    connection.Open();
                    return true;
                }
            }
            catch
            {
                return false;
            }

        }

        private string CreateConnectionString()
        {
            return $"Server={_session.serverName};User Id={_session.userName};Password={_session.password}";
        }


    }
}
