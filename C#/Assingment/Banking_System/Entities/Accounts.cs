using System;
using System.Collections.Generic;

namespace Banking_System.Entities
{
    public class Accounts
    {
        public static long lastAccNo = 1000;
        public long AccountNumber { get; set; }
        public string AccountType { get; set; }
        public float Balance { get; set; }
        public Customers Customer { get; set; }

        // 🆕 Add transaction list
        public List<Transaction> TransactionList { get; set; }

        public Accounts()
        {
            AccountNumber = ++lastAccNo;
            TransactionList = new List<Transaction>(); // initialize the list
        }

        public void PrintDetails()
        {
            Console.WriteLine($"Account Number: {AccountNumber}");
            Console.WriteLine($"Account Type: {AccountType}");
            Console.WriteLine($"Balance: ${Balance}");
            Customer.PrintDetails();
        }

        // 🆕 Optional method to print all transactions
        public void PrintAllTransactions()
        {
            Console.WriteLine($"--- Transactions for Account {AccountNumber} ---");
            foreach (var transaction in TransactionList)
            {
                transaction.PrintTransactionDetails();
            }
        }
    }
}
