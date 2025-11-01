using EZBank.Helpers;
using EZBank.Interfaces;
using System.Data;
using System.Data.SqlClient;

namespace EZBank.Classes
{
    public class MSSQLServerConnection : IDBServerConnection
    {
        private ISession _session;
        private SqlDataAdapter _customerAdapter;

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

        public void FillCustomerData(DataTable dt)
        {
            CreateCustomerDataAdapter();
            _customerAdapter.Fill(dt);
        }

        private void CreateCustomerDataAdapter()
        {
            string query = "SELECT * FROM Customer";
            SqlConnection conn = new SqlConnection(CreateConnectionStringWithDB());
            SqlCommand cmd = new SqlCommand(query, conn);
            _customerAdapter = new SqlDataAdapter(cmd);
            SqlCommandBuilder builder = new SqlCommandBuilder(_customerAdapter);
        }

        private string CreateConnectionString()
        {
            return $"Server={_session.serverName};User Id={_session.userName};Password={_session.password}";
        }

        private string CreateConnectionStringWithDB()
        {
            return $"Server={_session.serverName};Database={Constants.dbName};User Id={_session.userName};Password={_session.password}";
        }


    }
}
