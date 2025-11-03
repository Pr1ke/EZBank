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

        //Handles all Customer related data actions, in this case we only need to worry about updating the table for CRUD operations
         
        public MSSQLCustomerDataAccess(string connectionString, string username)
            : base(MSSQLQueries.selectCustomer, connectionString, username) { }

        public void Update(DataTable table)
        {
            _adapter.Update(table);
        }
    }
}
