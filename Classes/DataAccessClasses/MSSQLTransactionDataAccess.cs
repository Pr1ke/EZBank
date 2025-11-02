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
    public class MSSQLTransactionDataAccess : MSSQLBaseDataAccess
    {
        public MSSQLTransactionDataAccess(string connectionString, string username)
            : base("Select [Transaction].TransactionId, [Transaction].AccountId, [Transaction].[CreatedBy], [Transaction].IBAN, TransactionType.TransactionType, TransactionType.TransactionTypeID, [Transaction].Amount, [Transaction].Purpose, [Transaction].TransactionDate FROM [Transaction] LEFT JOIN TransactionType ON [Transaction].TransactionTypeId = TransactionType.TransactionTypeId WHERE DeletedBy IS NULL", connectionString, username) { }

        public void CreateTransaction(Transaction transaction)
        {
            if (transaction == null)
                return;

            string query = @"
            INSERT INTO [Transaction] (AccountId, TransactionDate, Amount, Purpose, IBAN, TransactionTypeId, CreatedBy)
            VALUES (@AccountId, @TransactionDate, @Amount, @Purpose, @IBAN, @TransactionTypeId, @CreatedBy);";


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
        public void DeleteTransaction(int transactionId)
        {
            string query = "Update [Transaction] SET deletedBy = @username WHERE TransactionID = @TransactionId";
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
    }
}
