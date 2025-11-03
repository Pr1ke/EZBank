using EZBank.Classes;
using EZBank.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZBank.Interfaces
{
    //The specifications require SQL connection but dont specify which flavor of SQL
    //So well encapsulate DBServerConnection and use a factory pattern for easy modification in case the specifications changes

    //Ill use MSSQL because thats what Im most comfortable with
    public interface IDBServerConnection 
    {
        bool ValidateConnection(Session session); //Are credentials correct?

        //Load the DataTables from DB
        void FillCustomerData(DataTable customerDataTable); 
        void FillAccountData(DataTable accountDataTable);
        void FillTransactionData(DataTable transactionDataTable);
        void FillTransactionTypeData(DataTable transactionTypeDataTable);

        //Switch between deleted transactions and normal transactions
        //Datatables and DataGridView need to be refreshed after calling this to show changes!
        void ShowDeletedTransactionChanged(bool showDeletedTransaction);

        //CRUD on Customer Table
        void UpdateCustomerData(DataTable customerDataTable);

        //Transaction handling
        void CreateTransaction(Transaction transaction);
        void DeleteTransaction(int transactionId);

        //Account Handling
        void CreateAccount(Account account);
        void DeleteAccount(int accountId);

        //Links the account with the provided customerId, overwrites in case there is already an existing link
        void LinkAccount(int accountId, int customerId);

    }
}
