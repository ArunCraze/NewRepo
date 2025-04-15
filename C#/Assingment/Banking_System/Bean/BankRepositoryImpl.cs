using Banking_System.Dao;
using Banking_System.Entities;
using Banking_System.Util;
using Banking_System.Exceptions;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Banking_System.Bean
{
    public class BankRepositoryImpl : IBankRepository
    {
        SqlConnection sqlCon = DBConnUtil.GetConnection("appsettings.json");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;

        public void CreateAccount(Customers customer, long accNo, string accType, float balance)
        {
            try
            {
                cmd.Connection = sqlCon;
                StringBuilder query = new StringBuilder();
                query.Append($"INSERT INTO Accounts (AccountNumber, CustomerID, AccountType, Balance) ");
                query.Append($"VALUES ({accNo}, {customer.CustomerID}, '{accType}', {balance})");
                cmd.CommandText = query.ToString();

                if (sqlCon.State == System.Data.ConnectionState.Closed)
                    sqlCon.Open();

                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error: " + ex.Message);
            }
            finally
            {
                sqlCon.Close();
            }
        }

        public List<Accounts> ListAccounts()
        {
            List<Accounts> accounts = new List<Accounts>();
            try
            {
                cmd.Connection = sqlCon;
                cmd.CommandText = "SELECT * FROM Accounts";

                if (sqlCon.State == System.Data.ConnectionState.Closed)
                    sqlCon.Open();

                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Accounts acc = new Accounts
                    {
                        AccountNumber = Convert.ToInt64(dr["AccountNumber"]),
                        //CustomerID = Convert.ToInt32(dr["CustomerID"]),
                        AccountType = Convert.ToString(dr["AccountType"]),
                        Balance = Convert.ToSingle(dr["Balance"])
                    };
                    accounts.Add(acc);
                }
                dr.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error: " + ex.Message);
            }
            finally
            {
                sqlCon.Close();
            }
            return accounts;
        }

        public float GetAccountBalance(long accountNumber)
        {
            try
            {
                cmd.Connection = sqlCon;
                cmd.CommandText = $"SELECT Balance FROM Accounts WHERE AccountNumber = {accountNumber}";

                if (sqlCon.State == System.Data.ConnectionState.Closed)
                    sqlCon.Open();

                object result = cmd.ExecuteScalar();
                return result != null ? Convert.ToSingle(result) : 0;
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error: " + ex.Message);
                return 0;
            }
            finally
            {
                sqlCon.Close();
            }
        }

        public float Deposit(long accountNumber, float amount)
        {
            try
            {
                float currentBalance = GetAccountBalance(accountNumber);
                float newBalance = currentBalance + amount;

                cmd.Connection = sqlCon;
                cmd.CommandText = $"UPDATE Accounts SET Balance = {newBalance} WHERE AccountNumber = {accountNumber}";

                if (sqlCon.State == System.Data.ConnectionState.Closed)
                    sqlCon.Open();

                cmd.ExecuteNonQuery();
                return newBalance;
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error: " + ex.Message);
                return 0;
            }
            finally
            {
                sqlCon.Close();
            }
        }

        public float Withdraw(long accountNumber, float amount)
        {
            try
            {
                float currentBalance = GetAccountBalance(accountNumber);
                if (currentBalance < amount)
                {
                    Console.WriteLine("Insufficient balance.");
                    return currentBalance;
                }

                float newBalance = currentBalance - amount;

                cmd.Connection = sqlCon;
                cmd.CommandText = $"UPDATE Accounts SET Balance = {newBalance} WHERE AccountNumber = {accountNumber}";

                if (sqlCon.State == System.Data.ConnectionState.Closed)
                    sqlCon.Open();

                cmd.ExecuteNonQuery();
                return newBalance;
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error: " + ex.Message);
                return 0;
            }
            finally
            {
                sqlCon.Close();
            }
        }

        public bool Transfer(long fromAccount, long toAccount, float amount)
        {
            try
            {
                float fromBalance = GetAccountBalance(fromAccount);
                if (fromBalance < amount)
                {
                    Console.WriteLine("Insufficient balance for transfer.");
                    return false;
                }

                Withdraw(fromAccount, amount);
                Deposit(toAccount, amount);

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error during transfer: " + ex.Message);
                return false;
            }
        }

        public Accounts GetAccountDetails(long accountNumber)
        {
            try
            {
                cmd.Connection = sqlCon;
                cmd.CommandText = $"SELECT * FROM Accounts WHERE AccountNumber = {accountNumber}";

                if (sqlCon.State == System.Data.ConnectionState.Closed)
                    sqlCon.Open();

                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    Accounts acc = new Accounts
                    {
                        AccountNumber = Convert.ToInt64(dr["AccountNumber"]),
                        //CustomerID = Convert.ToInt32(dr["CustomerID"]),
                        AccountType = Convert.ToString(dr["AccountType"]),
                        Balance = Convert.ToSingle(dr["Balance"])
                    };
                    dr.Close();
                    return acc;
                }
                dr.Close();
                return null;
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error: " + ex.Message);
                return null;
            }
            finally
            {
                sqlCon.Close();
            }
        }

        public List<Transaction> GetTransactions(long accountNumber, DateTime fromDate, DateTime toDate)
        {
            List<Transaction> transactions = new List<Transaction>();
            try
            {
                cmd.Connection = sqlCon;
                cmd.CommandText = $"SELECT * FROM Transactions WHERE AccountNumber = {accountNumber} AND TransactionDate BETWEEN '{fromDate}' AND '{toDate}'";

                if (sqlCon.State == System.Data.ConnectionState.Closed)
                    sqlCon.Open();

                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Transaction txn = new Transaction
                    {
                        TransactionId = dr["TransactionId"].ToString(),
                        AccountNumber = Convert.ToInt64(dr["AccountNumber"]),
                        TransactionType = Convert.ToString(dr["TransactionType"]),
                        Amount = Convert.ToSingle(dr["Amount"]),
                        Date = Convert.ToDateTime(dr["TransactionDate"])
                    };
                    transactions.Add(txn);
                }
                dr.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error: " + ex.Message);
            }
            finally
            {
                sqlCon.Close();
            }
            return transactions;
        }

        public void CalculateInterest()
        {
            try
            {
                cmd.Connection = sqlCon;
                cmd.CommandText = $"UPDATE Accounts SET Balance = Balance + (Balance * 0.04) WHERE AccountType = 'Savings'";

                if (sqlCon.State == System.Data.ConnectionState.Closed)
                    sqlCon.Open();

                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error: " + ex.Message);
            }
            finally
            {
                sqlCon.Close();
            }
        }
    }
}