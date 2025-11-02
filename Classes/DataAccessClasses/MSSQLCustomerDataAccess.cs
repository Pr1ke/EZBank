using EZBank.Helpers;
using EZBank.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZBank.Classes.DataAccessClasses
{
    public class MSSQLCustomerDataAccess : MSSQLBaseDataAccess
    {
        public MSSQLCustomerDataAccess(string connectionString, string username)
            : base("Select * FROM [Customer]", connectionString, username) { }

        public void Update(DataTable table)
        {
            _adapter.Update(table);
        }
    }
}
