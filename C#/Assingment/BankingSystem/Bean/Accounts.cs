using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Bean
{
    public abstract class Accounts
    {
        // Static variable to generate unique account numbers
        private static int lastAccNo = 1000;

        // Properties
        public int AccountNumber { get; set; }
        public decimal Balance { get; set; }
        public string AccountType { get; set; }
        public Customers Customer { get; set; }

        // Default constructor
        public Accounts() { }

        // Parameterized constructor
        public Accounts(string accountType, decimal balance, Customers customer)
        {
            AccountNumber = ++lastAccNo; // Auto-increment account number
            AccountType = accountType;
            Balance = balance;
            Customer = customer;
        }

        // Override ToString() to display account details
        public override string ToString()
        {
            return $"Account No: {AccountNumber}, Type: {AccountType}, Balance: {Balance}, Customer: {Customer.FirstName} {Customer.LastName}";
        }
    }
}