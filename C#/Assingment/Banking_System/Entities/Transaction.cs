using System;

namespace Banking_System.Entities
{
    public class Transaction
    {
        public string TransactionId { get; set; }         // Unique ID (use GUID)
        public long AccountNumber { get; set; }           // Link to account
        public string TransactionType { get; set; }       // "Deposit", "Withdraw", "Interest"
        public float Amount { get; set; }                 // Amount of transaction
        public DateTime Date { get; set; }                // Transaction date

        // Default constructor
        public Transaction()
        {
            TransactionId = Guid.NewGuid().ToString();
            Date = DateTime.Now;
        }

        // Optional parameterized constructor
        public Transaction(string type, float amount, long accountNumber)
        {
            TransactionId = Guid.NewGuid().ToString();
            TransactionType = type;
            Amount = amount;
            AccountNumber = accountNumber;
            Date = DateTime.Now;
        }

        // Method to display transaction details
        public void PrintTransactionDetails()
        {
            Console.WriteLine("Transaction Details:");
            Console.WriteLine($"Transaction ID   : {TransactionId}");
            Console.WriteLine($"Account Number   : {AccountNumber}");
            Console.WriteLine($"Type             : {TransactionType}");
            Console.WriteLine($"Amount           : {Amount}");
            Console.WriteLine($"Date             : {Date}");
        }
    }
}
