using EZBank.Classes;
using EZBank.Helpers;
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
        protected string _connectionString;
        protected string _username;

        protected MSSQLBaseDataAccess(string query, string connectionString, string username)
        {
            _connectionString = connectionString;
            _adapter = CreateDataAdapter(query, connectionString);
            _username = username;
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

    }

}
