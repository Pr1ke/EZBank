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
        private SqlDataAdapter _accountAdapter;
        private SqlDataAdapter _transactionAdapter;

        public bool ValidateConnection(ISession session)
        {
            try
            {
                _session = session;
                using (SqlConnection connection = new SqlConnection(CreateConnectionString()))
                {
                    connection.Open();
                    CreateCustomerDataAdapter();
                    CreateAccountDataAdapter();
                    CreateTransactionDataAdapter();
                    return true;
                }
            }
            catch
            {
                return false;
            }

        }

        public void FillCustomerData(DataTable customerDataTable)
        {
            _customerAdapter.Fill(customerDataTable);
        }

        public void FillAccountData(DataTable accountDataTable)
        {
            _accountAdapter.Fill(accountDataTable);
        }

        public void FillTransactionData(DataTable transactionDataTable)
        {
            _transactionAdapter.Fill(transactionDataTable);
        }

        public void UpdateCustomerData(DataTable customerDataTable)
        {
            _customerAdapter.Update(customerDataTable);
        }

        public void UpdateAccountData(DataTable accountDataTable)
        {
            _accountAdapter.Update(accountDataTable);
        }

        public void UpdateTransactionData(DataTable transactionDataTable)
        {
            _transactionAdapter.Update(transactionDataTable);
        }

        private void CreateCustomerDataAdapter()
        {
            string query = "SELECT * FROM [Customer]";
            _customerAdapter = CreateDataAdapter(query);
        }

        private void CreateAccountDataAdapter()
        {
            string query = "SELECT * FROM [Account]";
            _accountAdapter = CreateDataAdapter(query);
        }

        private void CreateTransactionDataAdapter()
        {
            string query = "SELECT * FROM [Transaction]";
            _transactionAdapter = CreateDataAdapter(query);
        }

        private SqlDataAdapter CreateDataAdapter(string query)
        {
            SqlConnection conn = new SqlConnection(CreateConnectionStringWithDB());
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            return adapter;
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
