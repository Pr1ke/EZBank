using EZBank.Helpers;
using EZBank.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZBank.Classes.DataAccessClasses
{
    public class MSSQLTransactionTypeDataAccess : MSSQLBaseDataAccess
    {
        public MSSQLTransactionTypeDataAccess(string connectionString, string username)
            : base("Select * FROM [TransactionType]", connectionString, username) { }

    }
}
