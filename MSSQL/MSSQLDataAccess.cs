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

        //This class provides the basic functionality of all DataAccessClasses like creating Adapters and Filling Datatables.

        //The DataAccess classes further provide functionality specifically related to that Dataset,
        //like creating Transactions is handled in the TransactionTypeDataAcces Class.

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
            //This isnt an optimal solution because the Connection and the Command arent disposed properly until we exit the application.
            //Its fine for now, but switching to a async just-in-time loading schema would improve performance and dispose connections and commands.

            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            return adapter;
        }

        //Sometimes we want to Change the basic query of an Adapter, currently this is used to switch between transactions and deleted transactions
        //In the future, this could be used to filter the Customer/Transaction results depending on selection of the parent DataGridView
        protected void ChangeQuery(string query)
        {
            _adapter = CreateDataAdapter(query, _connectionString);
        }

        public void Fill(DataTable table) => _adapter.Fill(table);

    }

}
