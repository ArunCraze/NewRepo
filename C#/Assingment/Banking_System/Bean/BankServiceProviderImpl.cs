using Banking_System.Bean;
using Banking_System.Dao;
using Banking_System.Entities;
using System;
using System.Collections.Generic;

namespace Banking_System.Main
{
    public class BankServiceProviderImpl : CustomerServiceProviderImpl, IBankServiceProvider
    {
        public string BranchName { get; set; } = "Main Branch";
        public string BranchAddress { get; set; } = "City Center";

        public Accounts CreateAccount(Customers customer, string accType, float balance)
        {
            Accounts newAccount;

            if (accType.ToLower() == "savings")
            {
                newAccount = new SavingsAccount();
                if (balance < 500) balance = 500;
            }
            else if (accType.ToLower() == "current")
            {
                newAccount = new CurrentAccount();
            }
            else
            {
                newAccount = new ZeroBalanceAccount();
            }

            newAccount.Customer = customer;
            newAccount.Balance = balance;
            newAccount.AccountType = accType;

            // 🆕 Add a transaction for account creation / initial deposit
            newAccount.TransactionList.Add(new Transaction
            {
                TransactionId = Guid.NewGuid().ToString(),
                Date = DateTime.Now,
                Amount = balance,
                TransactionType = "Deposit"
            });

            accounts.Add(newAccount);

            return newAccount;
        }

        public Accounts[] ListAccounts()
        {
            return accounts.ToArray();
        }

        public void CalculateInterest()
        {
            foreach (var acc in accounts)
            {
                if (acc is SavingsAccount savings)
                {
                    float interest = savings.CalculateInterest();
                    acc.Balance += interest;

                    // 🆕 Record interest as a transaction
                    acc.TransactionList.Add(new Transaction
                    {
                        TransactionId = Guid.NewGuid().ToString(),
                        Date = DateTime.Now,
                        Amount = interest,
                        TransactionType = "Interest"
                    });

                    Console.WriteLine($"Interest of {interest} added to account {acc.AccountNumber}");
                }
            }
        }
    }
}