using System;

namespace EZBank.Helpers
{
    //There will probably be only one implementation of a transaction, so creating an Interface is unnecessary
    //Well just keep it as a helper class to aid with data-transfer
    public class Transaction
    {
        public DateTime Date { get; }
        public decimal Amount { get; }
        public string Purpose { get; }
        public string IBAN { get; }
        public int TypeId { get; }

        public int AccountID { get; set; }

        public Transaction(DateTime date, decimal amount, string purpose, string iban, int typeId)
        {
            Date = date;
            Amount = amount;
            Purpose = purpose;
            IBAN = iban;
            TypeId = typeId;
        }
    }
}
