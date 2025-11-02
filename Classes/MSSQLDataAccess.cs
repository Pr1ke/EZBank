using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZBank.Interfaces
{
    public abstract class MSSQLBaseDataAccess
    {
        protected SqlDataAdapter _adapter;

        protected MSSQLBaseDataAccess(string query, string connectionString)
        {
            _adapter = CreateDataAdapter(query, connectionString);
        }

        private SqlDataAdapter CreateDataAdapter(string query, string connectionString)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            return adapter;
        }

        public void Fill(DataTable table) => _adapter.Fill(table);
        public void Update(DataTable table) => _adapter.Update(table);

    }

    public class MSSQLCustomerDataAccess : MSSQLBaseDataAccess
    {
        public MSSQLCustomerDataAccess(string connectionString)
            : base("Select * FROM [Customer]", connectionString) { }
    }

    public class MSSQLAccountDataAccess : MSSQLBaseDataAccess
    {
        public MSSQLAccountDataAccess(string connectionString)
            : base("Select * FROM [Account]", connectionString) { }
    }

    public class MSSQLTransactionDataAccess : MSSQLBaseDataAccess
    {
        public MSSQLTransactionDataAccess(string connectionString)
            : base("Select * FROM [Transaction]", connectionString) { }
    }

}
