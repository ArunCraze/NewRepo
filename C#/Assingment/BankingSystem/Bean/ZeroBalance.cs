using BankingSystem.Bean;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Bean
{
    public class ZeroBalanceAccount : Accounts
    {
        public ZeroBalanceAccount(Customers customer)
        {
            this.Balance = 0;
            this.Customer = customer;
            this.AccountType = "ZeroBalance";
        }

        public ZeroBalanceAccount() { }
    }
}