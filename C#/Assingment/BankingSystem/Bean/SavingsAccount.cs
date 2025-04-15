using BankingSystem.Bean;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Bean
{
    public class SavingsAccount : Accounts
    {
        // Interest rate applicable to the savings account
        public decimal InterestRate { get; set; }

        // Constructor using base class constructor for AccountType, Balance, and Customer
        public SavingsAccount(decimal balance, Customers customer, decimal interestRate)
            : base("Savings", balance, customer)
        {
            this.InterestRate = interestRate;
        }

        // Parameterless constructor (used during deserialization or object initialization)
        public SavingsAccount() { }
    }
}