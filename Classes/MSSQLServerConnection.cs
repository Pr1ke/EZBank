using EZBank.Helpers;
using EZBank.Interfaces;
using System.Data;
using System.Data.SqlClient;

namespace EZBank.Classes
{
    public class MSSQLServerConnection : IDBServerConnection
    {
        private ISession _session;
        private MSSQLCustomerDataAccess _customerData;
        private MSSQLAccountDataAccess _accountData;
        private MSSQLTransactionDataAccess _transactionData;
        private MSSQLTransactionTypeDataAccess _transactionTypeData;

        public string userName => _session.userName;

        public void FillCustomerData(DataTable customerDataTable) => _customerData?.Fill(customerDataTable);
        public void FillAccountData(DataTable accountDataTable) => _accountData?.Fill(accountDataTable);
        public void FillTransactionData(DataTable transactionDataTable) => _transactionData?.Fill(transactionDataTable);

        public void FillTransactionTypeData(DataTable transactionTypeDataTable) => _transactionTypeData?.Fill(transactionTypeDataTable);

        public void UpdateCustomerData(DataTable customerDataTable) => _customerData?.Update(customerDataTable);
        public void UpdateAccountData(DataTable accountDataTable) => _accountData?.Update(accountDataTable);
        public void UpdateTransactionData(DataTable transactionDataTable) => _transactionData?.Update(transactionDataTable);

        public bool ValidateConnection(ISession session)
        {
            try
            {
                _session = session;
                using (SqlConnection connection = new SqlConnection(CreateConnectionString()))
                {
                    connection.Open();
                    string dbConnectionString = CreateConnectionStringWithDB();
                    _customerData = new MSSQLCustomerDataAccess(dbConnectionString);
                    _accountData = new MSSQLAccountDataAccess(dbConnectionString);
                    _transactionData = new MSSQLTransactionDataAccess(dbConnectionString);
                    _transactionTypeData = new MSSQLTransactionTypeDataAccess(dbConnectionString);
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

        private string CreateConnectionStringWithDB()
        {
            return $"Server={_session.serverName};Database={Constants.dbName};User Id={_session.userName};Password={_session.password}";
        }


    }
}
