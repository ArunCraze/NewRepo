using Banking_System.Entities;
using System;
using System.Collections.Generic;

namespace Banking_System.Dao
{
    public interface IBankRepository
    {
        void CreateAccount(Customers customer, long accNo, string accType, float balance);
        List<Accounts> ListAccounts();
        float GetAccountBalance(long accountNumber);
        float Deposit(long accountNumber, float amount);
        float Withdraw(long accountNumber, float amount);
        bool Transfer(long fromAccount, long toAccount, float amount);
        Accounts GetAccountDetails(long accountNumber);
        List<Transaction> GetTransactions(long accountNumber, DateTime fromDate, DateTime toDate);
        void CalculateInterest();
    }
}
