﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankingSystem.Bean;


namespace BankingSystem.Service
{
    public interface IBankServiceProvider
    {
        // Create a new bank account for the given customer
        void CreateAccount(Customers customer, string accType, decimal balance);

        // Returns a list of all existing accounts
        List<Accounts> ListAccounts();

        // Returns account details for a specific account number
        Accounts GetAccountDetails(long accountNumber); // Same as in ICustomerServiceProvider

        // Calculates interest for all applicable accounts (like savings)
        void CalculateInterest();

        //  New Method: Returns the current balance of an account
        decimal GetBalance(int accountId);

        //  New Method: Transfers funds between accounts
        void TransferFunds(int fromAccountId, int toAccountId, decimal amount);
    }
}