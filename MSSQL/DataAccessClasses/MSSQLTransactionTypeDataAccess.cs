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

        //Shows transaction types, because the app currently cant edit those entries we only need to worry about loading them.

        public MSSQLTransactionTypeDataAccess(string connectionString, string username)
            : base(MSSQLQueries.selectTransactionType, connectionString, username) { }

    } 
}
