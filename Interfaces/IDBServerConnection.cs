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
        bool ValidateConnection(ISession session);
        void FillCustomerData(DataTable customerDataTable);
        void FillAccountData(DataTable accountDataTable);
        void FillTransactionData(DataTable transactionDataTable);
        void FillTransactionTypeData(DataTable transactionTypeDataTable);
        void UpdateCustomerData(DataTable customerDataTable);
        void UpdateAccountData(DataTable accountDataTable);
        void UpdateTransactionData(DataTable transactionDataTable);
        string userName { get; }

    }
}
