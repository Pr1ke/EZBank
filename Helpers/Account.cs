using System;

namespace EZBank.Helpers
{
    //There will probably be only one implementation of an Account, so creating an Interface is unnecessary
    //Well just keep it as a helper class to aid with data-transfer
    public class Account
    {
        public int AccountId { get; }
        public decimal StartingBalance { get; }
        public string IBAN { get; }
        public int CustomerID { get; }

        public Account(int accountId, decimal startingBalance, string iban, int customerID = -1)
        {
            AccountId = accountId;
            StartingBalance = startingBalance;
            IBAN = iban;
            CustomerID = customerID;
        }
    }
}
