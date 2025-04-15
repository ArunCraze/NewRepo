using Banking_System.Entities;
using System;
namespace Banking_System.Dao
{ 
    public interface IBankServiceProvider
    {
        Accounts CreateAccount(Customers customer, string accType, float balance);
        Accounts[] ListAccounts();
        void CalculateInterest();
    }
}
