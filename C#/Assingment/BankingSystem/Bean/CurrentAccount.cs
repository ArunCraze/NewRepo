using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Bean
{
    public class CurrentAccount : Accounts
    {
        // Overdraft limit for current account
        public decimal OverdraftLimit { get; set; }

        // Constructor using base class constructor
        public CurrentAccount(decimal balance, Customers customer, decimal overdraftLimit)
            : base("Current", balance, customer)
        {
            this.OverdraftLimit = overdraftLimit;
        }

        // Parameterless constructor
        public CurrentAccount() { }
    }
}
