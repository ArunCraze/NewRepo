using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using BankingSystem.Bean;


namespace BankingSystem.Service
{
    public interface ICustomerServiceProvider
    {
        float GetAccountBalance(long accountNumber);
        float Deposit(long accountNumber, float amount);
        float Withdraw(long accountNumber, float amount);
        void Transfer(long fromAccountNumber, long toAccountNumber, float amount);
        Accounts GetAccountDetails(long accountNumber);
        List<Transaction> GetTransactions(long accountNumber, DateTime fromDate, DateTime toDate);
    }
}