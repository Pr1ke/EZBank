using EZBank.Helpers;
using EZBank.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace EZBank.Classes.DataAccessClasses
{
    public class MSSQLTransactionDataAccess : MSSQLBaseDataAccess
    {
        //Handles all transaction related database actions, like deleting entries and showing them, creating transactions

        public MSSQLTransactionDataAccess(string connectionString, string username)
            : base(MSSQLQueries.selectTransactions, connectionString, username) { }

        public void CreateTransaction(Transaction transaction)
        {
            if (transaction == null) 
                return;

            string query = MSSQLQueries.createTransaction;


            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@AccountId", transaction.AccountID);
                    cmd.Parameters.AddWithValue("@TransactionDate", transaction.Date);
                    cmd.Parameters.AddWithValue("@Amount", transaction.Amount);
                    cmd.Parameters.AddWithValue("@Purpose", transaction.Purpose);
                    cmd.Parameters.AddWithValue("@IBAN", transaction.IBAN);
                    cmd.Parameters.AddWithValue("@TransactionTypeId", transaction.TypeId);
                    cmd.Parameters.AddWithValue("@CreatedBy", _username);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }

        }

        //We only update the DeletedBy field of the transaction with the current User
        public void DeleteTransaction(int transactionId)
        {
            string query = MSSQLQueries.updateTransaction;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@userName", _username);
                    cmd.Parameters.AddWithValue("@transactionId", transactionId);
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        public void ShowDeletedTransactionChanged(bool showDeleted)
        {
            if (showDeleted) {
                base.ChangeQuery(MSSQLQueries.selectDeletedTransactions);
                return;
            }

            base.ChangeQuery(MSSQLQueries.selectTransactions);

        }
    }
}
