using Banking_System.Entities;
using System;
using System.Collections.Generic;

namespace Banking_System.Dao
{
    public interface ICustomerServiceProvider
    {
        float Deposit(long accountNumber, float amount);
        float Withdraw(long accountNumber, float amount);
        float GetAccountBalance(long accountNumber);
        bool Transfer(long fromAcc, long toAcc, float amount);
        void GetAccountDetails(long accountNumber);

        List<Transaction> GetTransactions(long accountNumber, DateTime fromDate, DateTime toDate);
    }
}
