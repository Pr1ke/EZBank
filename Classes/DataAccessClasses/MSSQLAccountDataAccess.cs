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

        public void CreateAccount(Account account)
        {
            if (account == null)
                return;

            string query = @"
            INSERT INTO [Account] ([AccountId], [IBAN], CustomerId)
            VALUES (@AccountId, @IBAN, @CustomerId);";


            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@AccountId", account.AccountId);
                    cmd.Parameters.AddWithValue("@IBAN", account.IBAN);
                    cmd.Parameters.AddWithValue("@CustomerId", account.CustomerID);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }

        }

        public void LinkAccount(int account, int customerId)
        {
            string query = @"
            UPDATE [Account] SET CustomerID = @customerId WHERE AccountId = @AccountID";


            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@customerId", customerId);
                    cmd.Parameters.AddWithValue("@AccountID", account);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }

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
