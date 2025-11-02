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
    public class MSSQLAccountDataAccess : MSSQLBaseDataAccess
    {
        public MSSQLAccountDataAccess(string connectionString, string username)
            : base("SELECT Account.AccountId, Account.IBAN, Account.CustomerId, vwAccountBalance.TotalBalance FROM Account INNER JOIN vwAccountBalance ON Account.AccountId = vwAccountBalance.AccountId", connectionString, username) { }

        public void CreateAccount(Transaction transaction)
        {

            //TODO

            //if (transaction == null)
            //    return;

            //string query = @"
            //INSERT INTO [Account] ([IBAN], Amount, Purpose, IBAN, TransactionTypeId, [User])
            //VALUES (@AccountId, @Date, @Amount, @Purpose, @IBAN, @TransactionTypeId, @User);";


            //using (SqlConnection conn = new SqlConnection(_connectionString))
            //{
            //    using (SqlCommand cmd = new SqlCommand(query, conn))
            //    {
            //        // Add parameters
            //        cmd.Parameters.AddWithValue("@AccountId", transaction.AccountID);
            //        cmd.Parameters.AddWithValue("@Date", transaction.Date);
            //        cmd.Parameters.AddWithValue("@Amount", transaction.Amount);
            //        cmd.Parameters.AddWithValue("@Purpose", transaction.Purpose);
            //        cmd.Parameters.AddWithValue("@IBAN", transaction.IBAN);
            //        cmd.Parameters.AddWithValue("@TransactionTypeId", transaction.TypeId);
            //        cmd.Parameters.AddWithValue("@User", _username);
            //        conn.Open();
            //        cmd.ExecuteNonQuery();
            //        conn.Close();
            //    }
            //}

        }
        public void DeleteAccount(int transactionId)
        {
            //TODO


            //string query = "Update [Transaction] SET deletedBy = @username WHERE TransactionID = @TransactionId";
            //using (SqlConnection connection = new SqlConnection(_connectionString))
            //{
            //    using (SqlCommand cmd = new SqlCommand(query, connection))
            //    {
            //        cmd.Parameters.AddWithValue("@userName", _username);
            //        cmd.Parameters.AddWithValue("@transactionId", transactionId);
            //        connection.Open();
            //        cmd.ExecuteNonQuery();
            //        connection.Close();
            //    }
            //}
        }

    }
}
