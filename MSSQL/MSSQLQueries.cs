using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZBank.Helpers
{
    internal class MSSQLQueries
    {

        //All the MSSQL Queries stored in one place.

        public static string selectTransactionType = @"SELECT * FROM [TransactionType]";

        public static string selectDeletedTransactions = @"SELECT [Transaction].DeletedBy, " +
                                                        "[Transaction].AccountId, [Transaction].[CreatedBy], [Transaction].IBAN, " +
                                                        "TransactionType.TransactionType, [Transaction].Amount, [Transaction].Purpose, " +
                                                        "[Transaction].TransactionDate, [Transaction].TransactionID FROM [Transaction] " +
                                                        "LEFT JOIN TransactionType " +
                                                        "ON [Transaction].TransactionTypeId = TransactionType.TransactionTypeId " +
                                                        "WHERE DeletedBy IS NOT NULL";
         
        public static string selectTransactions = @"SELECT [Transaction].AccountId, [Transaction].[CreatedBy], " +
                                                  "[Transaction].IBAN, TransactionType.TransactionType, [Transaction].Amount, [Transaction].Purpose, " +
                                                  "[Transaction].TransactionDate, [Transaction].TransactionID FROM [Transaction] " +
                                                  "LEFT JOIN TransactionType ON [Transaction].TransactionTypeId = TransactionType.TransactionTypeId " +
                                                  "WHERE DeletedBy IS NULL";

        public static string createTransaction = @"INSERT INTO [Transaction] (AccountId, TransactionDate, Amount, Purpose, IBAN, TransactionTypeId, CreatedBy)
                                                 VALUES (@AccountId, @TransactionDate, @Amount, @Purpose, @IBAN, @TransactionTypeId, @CreatedBy);";

        public static string updateTransaction = @"UPDATE [Transaction] SET deletedBy = @username WHERE TransactionID = @TransactionId";

        public static string updateAccount = @"UPDATE[Account] SET CustomerID = @customerId WHERE AccountId = @AccountID";

        public static string createAccount = @"INSERT INTO [Account] ([AccountId], [IBAN], CustomerId) VALUES (@AccountId, @IBAN, @CustomerId);";

        public static string selectAccounts = @"SELECT Account.AccountId, Account.IBAN, Account.CustomerId, 
                                              vwAccountBalance.TotalBalance FROM Account 
                                              INNER JOIN vwAccountBalance ON Account.AccountId = vwAccountBalance.AccountId";

        public static string selectCustomer = @"SELECT * FROM [Customer]";
     }
}
