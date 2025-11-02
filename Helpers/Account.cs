using System;

namespace EZBank.Helpers
{
    //There will probably be only one implementation of a Account, so creating an Interface is unnecessary
    //Well just keep it as a helper class to aid with data-transfer
    public class Account
    {
        public decimal StartingBalance { get; }
        public string IBAN { get; }
        public int CustomerID { get; }
        public Account(decimal startingBalance, string iban, int customerID = -1)
        {
            StartingBalance = startingBalance;
            IBAN = iban;
            CustomerID = customerID;
        }
    }
}
