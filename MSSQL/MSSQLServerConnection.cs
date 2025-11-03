using EZBank.Classes.DataAccessClasses;
using EZBank.Helpers;
using EZBank.Interfaces;
using System.Data;
using System.Data.SqlClient;
using System.Security.Principal;

namespace EZBank.Classes
{
    public class MSSQLServerConnection : IDBServerConnection
    {

        //This is the main class for handling MSSQL Data related tasks,
        //it mostly delegates the calls to the internal DataAccess classes

        private Session _session;
        private MSSQLCustomerDataAccess _customerData;
        private MSSQLAccountDataAccess _accountData;
        private MSSQLTransactionDataAccess _transactionData; 
        private MSSQLTransactionTypeDataAccess _transactionTypeData;

        public void FillCustomerData(DataTable customerDataTable) => _customerData?.Fill(customerDataTable);
        public void FillAccountData(DataTable accountDataTable) => _accountData?.Fill(accountDataTable);
        public void FillTransactionData(DataTable transactionDataTable) => _transactionData?.Fill(transactionDataTable);
        public void ShowDeletedTransactionChanged(bool showDeleted) => _transactionData?.ShowDeletedTransactionChanged(showDeleted);
        public void FillTransactionTypeData(DataTable transactionTypeDataTable) => _transactionTypeData?.Fill(transactionTypeDataTable);
        public void UpdateCustomerData(DataTable customerDataTable) => _customerData?.Update(customerDataTable);
        public void CreateTransaction(Transaction transaction) => _transactionData?.CreateTransaction(transaction);
        public void DeleteTransaction(int transactionId) => _transactionData?.DeleteTransaction(transactionId);
        public void DeleteAccount(int accountId) => _accountData?.DeleteAccount(accountId);
        public void CreateAccount(Account account) => _accountData?.CreateAccount(account);
        public void LinkAccount(int accountId, int customerId) => _accountData?.LinkAccount(accountId, customerId);

        public bool ValidateConnection(Session session)
        {
            try
            {
                _session = session;
                using (SqlConnection connection = new SqlConnection(CreateConnectionString()))
                {
                    connection.Open();
                    string dbConnectionString = CreateConnectionStringWithDB();

                    //While we could technically get the username from the connection string, well just pass it directly for ease of use

                    _customerData = new MSSQLCustomerDataAccess(dbConnectionString, _session.userName);
                    _accountData = new MSSQLAccountDataAccess(dbConnectionString, _session.userName);
                    _transactionData = new MSSQLTransactionDataAccess(dbConnectionString, _session.userName);
                    _transactionTypeData = new MSSQLTransactionTypeDataAccess(dbConnectionString, _session.userName);
                    return true; //Looks good, DB connection established
                } 
            }
            catch
            {
                return false; //Couldnt connect to db, credentials are probably wrong.
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
