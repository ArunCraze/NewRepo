using Banking_System.Dao;
using Banking_System.Entities;
using Banking_System.Exceptions;
using System;
using System.Collections.Generic;

namespace Banking_System.Bean
{
    public class CustomerServiceProviderImpl : ICustomerServiceProvider
    {
        protected List<Accounts> accounts = new List<Accounts>();
        protected List<Transaction> transactions = new List<Transaction>();

        public float Deposit(long accountNumber, float amount)
        {
            foreach (var acc in accounts)
            {
                if (acc.AccountNumber == accountNumber)
                {
                    acc.Balance += amount;

                    // Record deposit
                    transactions.Add(new Transaction
                    {
                        TransactionId = Guid.NewGuid().ToString(),
                        AccountNumber = accountNumber,
                        TransactionType = "Deposit",
                        Amount = amount,
                        Date = DateTime.Now
                    });

                    return acc.Balance;
                }
            }

            throw new InvalidAccountException("Account not found.");
        }

        public float Withdraw(long accountNumber, float amount)
        {
            Accounts acc = accounts.Find(a => a.AccountNumber == accountNumber);
            if (acc == null)
                throw new InvalidAccountException("Account number not found.");

            if (acc is CurrentAccount currentAcc)
            {
                float allowedLimit = currentAcc.Balance + currentAcc.OverdraftLimit;
                if (amount > allowedLimit)
                    throw new OverDraftLimitExceededException("Overdraft limit exceeded.");

                currentAcc.Balance -= amount;
            }
            else if (acc is SavingsAccount)
            {
                if (acc.Balance - amount < 500)
                    throw new InsufficientFundException("Minimum ₹500 balance must be maintained.");

                acc.Balance -= amount;
            }
            else
            {
                if (acc.Balance < amount)
                    throw new InsufficientFundException("Insufficient balance.");

                acc.Balance -= amount;
            }

            // Record withdrawal
            transactions.Add(new Transaction
            {
                TransactionId = Guid.NewGuid().ToString(),
                AccountNumber = accountNumber,
                TransactionType = "Withdrawal",
                Amount = amount,
                Date = DateTime.Now
            });

            return acc.Balance;
        }

        public float GetAccountBalance(long accountNumber)
        {
            foreach (var acc in accounts)
            {
                if (acc.AccountNumber == accountNumber)
                    return acc.Balance;
            }

            throw new InvalidAccountException("Account number not found.");
        }

        public bool Transfer(long fromAcc, long toAcc, float amount)
        {
            Accounts from = accounts.Find(a => a.AccountNumber == fromAcc);
            Accounts to = accounts.Find(a => a.AccountNumber == toAcc);

            if (from == null || to == null)
                throw new InvalidAccountException("One or both account numbers are invalid.");

            if (from is SavingsAccount && from.Balance - amount < 500)
                throw new InsufficientFundException("Savings account must maintain ₹500 after transfer.");

            if (from is CurrentAccount currentFrom)
            {
                float limit = currentFrom.Balance + currentFrom.OverdraftLimit;
                if (amount > limit)
                    throw new OverDraftLimitExceededException("Overdraft limit exceeded on transfer.");
            }
            else if (from.Balance < amount)
                throw new InsufficientFundException("Insufficient balance for transfer.");

            from.Balance -= amount;
            to.Balance += amount;

            // Record both transactions
            transactions.Add(new Transaction
            {
                TransactionId = Guid.NewGuid().ToString(),
                AccountNumber = fromAcc,
                TransactionType = "Transfer - Debit",
                Amount = amount,
                Date = DateTime.Now
            });

            transactions.Add(new Transaction
            {
                TransactionId = Guid.NewGuid().ToString(),
                AccountNumber = toAcc,
                TransactionType = "Transfer - Credit",
                Amount = amount,
                Date = DateTime.Now
            });

            return true;
        }

        public void GetAccountDetails(long accountNumber)
        {
            Accounts acc = accounts.Find(a => a.AccountNumber == accountNumber);
            if (acc == null)
                throw new InvalidAccountException("Account number not found.");

            acc.PrintDetails();
        }

        public List<Transaction> GetTransactions(long accountNumber, DateTime fromDate, DateTime toDate)
        {
            List<Transaction> result = new List<Transaction>();

            foreach (var txn in transactions)
            {
                if (txn.AccountNumber == accountNumber &&
                    txn.Date >= fromDate &&
                    txn.Date <= toDate)
                {
                    result.Add(txn);
                }
            }

            return result;
        }
    }
}
