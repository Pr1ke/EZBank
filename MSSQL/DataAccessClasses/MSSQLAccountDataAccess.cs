using EZBank.Helpers;
using EZBank.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EZBank.Classes.DataAccessClasses
{
    public class MSSQLAccountDataAccess : MSSQLBaseDataAccess
    {
        //Handles all account related data actions, like creating linking and deleting

        public MSSQLAccountDataAccess(string connectionString, string username) 
            : base(MSSQLQueries.selectAccounts, connectionString, username) { }

        public void CreateAccount(Account account)
        {
            if (account == null)
                return;

            string query = MSSQLQueries.createAccount;

            try
            {
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
            catch (SqlException ex)
            {
                //TODO Implement a proper PrimaryKey check instead of relying on try/catch
                MessageBox.Show("Couldnt create Account, does the ID already exist?");
            }


        }

        public void LinkAccount(int account, int customerId)
        {
            string query = MSSQLQueries.updateAccount;


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
