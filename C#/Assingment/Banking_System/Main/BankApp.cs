using Banking_System.Bean;
using Banking_System.Entities;
using Banking_System.Exceptions;
using System;

namespace Banking_System.Main
{
    class BankApp
    {
        static void Main(string[] args)
        {
            BankServiceProviderImpl bank = new BankServiceProviderImpl();
            CustomerServiceProviderImpl cust = new CustomerServiceProviderImpl();

            while (true)
            {
                Console.WriteLine("\n--- Welcome to Simple Banking System ---");
                Console.WriteLine("1. Create Account");
                Console.WriteLine("2. Deposit");
                Console.WriteLine("3. Withdraw");
                Console.WriteLine("4. Get Balance");
                Console.WriteLine("5. Transfer Money");
                Console.WriteLine("6. Get Account Details");
                Console.WriteLine("7. List All Accounts");
                Console.WriteLine("8. Calculate Interest");
                Console.WriteLine("9. Get Transactions by Date");
                Console.WriteLine("10. Exit");
                Console.Write("Enter your choice: ");

                int choice = int.Parse(Console.ReadLine());

                try
                {
                    switch (choice)
                    {
                        case 1:
                            Console.Write("Enter First Name: ");
                            string firstName = Console.ReadLine();
                            Console.Write("Enter Last Name: ");
                            string lastName = Console.ReadLine();
                            Console.Write("Enter Email: ");
                            string email = Console.ReadLine();
                            Console.Write("Enter Phone: ");
                            string phone = Console.ReadLine();
                            Console.Write("Enter Account Type (Savings/Current): ");
                            string accType = Console.ReadLine();
                            Console.Write("Enter Initial Balance: ");
                            float balance = float.Parse(Console.ReadLine());

                            Customers customer = new Customers
                            {
                                FirstName = firstName,
                                LastName = lastName,
                                Email = email,
                                PhoneNumber = phone
                            };

                            Accounts newAcc = bank.CreateAccount(customer, accType, balance);
                            Console.WriteLine("Account created successfully! Account No: " + newAcc.AccountNumber);
                            break;


                        case 2:
                            Console.Write("Enter Account Number: ");
                            long depAcc = long.Parse(Console.ReadLine());
                            Console.Write("Enter Amount to Deposit: ");
                            float depAmt = float.Parse(Console.ReadLine());
                            float updatedDepBal = bank.Deposit(depAcc, depAmt);
                            Console.WriteLine("Updated Balance: " + updatedDepBal);
                            break;

                        case 3:
                            Console.Write("Enter Account Number: ");
                            long withAcc = long.Parse(Console.ReadLine());
                            Console.Write("Enter Amount to Withdraw: ");
                            float withAmt = float.Parse(Console.ReadLine());
                            float updatedWithBal = bank.Withdraw(withAcc, withAmt);
                            Console.WriteLine("Updated Balance: " + updatedWithBal);
                            break;

                        /*case 4:
                            Console.Write("Enter Account Number: ");
                            long balAcc = long.Parse(Console.ReadLine());
                            float balanceAmt = bank.GetBalance(balAcc);
                            Console.WriteLine("Current Balance: " + balanceAmt);
                            break;*/

                        case 5:
                            Console.Write("From Account Number: ");
                            long fromAcc = long.Parse(Console.ReadLine());
                            Console.Write("To Account Number: ");
                            long toAcc = long.Parse(Console.ReadLine());
                            Console.Write("Enter Amount to Transfer: ");
                            float transferAmt = float.Parse(Console.ReadLine());
                            bool isSuccess = bank.Transfer(fromAcc, toAcc, transferAmt);
                            Console.WriteLine(isSuccess ? "Transfer Successful!" : "Transfer Failed.");
                            break;

                        /*case 6:
                            Console.Write("Enter Account Number: ");
                            long detAcc = long.Parse(Console.ReadLine());
                            Accounts acc = cust.GetAccountDetails(detAcc);
                            if (acc != null)
                            {
                                Console.WriteLine($"Account Number: {acc.AccountNumber}");
                                Console.WriteLine($"Account Type: {acc.AccountType}");
                                Console.WriteLine($"Balance: {acc.Balance}");
                                Console.WriteLine($"Customer: {acc.Customer.FirstName} {acc.Customer.LastName}, Email: {acc.Customer.Email}, Phone: {acc.Customer.PhoneNumber}");
                            }
                            else
                            {
                                Console.WriteLine("Account not found.");
                            }
                            break;*/


                        case 7:
                            var allAccounts = bank.ListAccounts();
                            if (allAccounts.Count()== 0)
                            {
                                Console.WriteLine("No accounts found.");
                            }
                            else
                            {
                                foreach (var a in allAccounts)
                                {
                                    Console.WriteLine($"Account No: {a.AccountNumber}, Type: {a.AccountType}, Balance: {a.Balance}, Customer: {a.Customer.FirstName} {a.Customer.LastName}");
                                }
                            }
                            break;


                        case 8:
                            bank.CalculateInterest();
                            Console.WriteLine("Interest calculated and updated successfully.");
                            break;

                        case 9:
                            Console.Write("Enter Account Number: ");
                            long txnAcc = long.Parse(Console.ReadLine());
                            Console.Write("Enter From Date (yyyy-mm-dd): ");
                            DateTime fromDate = DateTime.Parse(Console.ReadLine());
                            Console.Write("Enter To Date (yyyy-mm-dd): ");
                            DateTime toDate = DateTime.Parse(Console.ReadLine());

                            var transactions = bank.GetTransactions(txnAcc, fromDate, toDate);
                            if (transactions.Count == 0)
                            {
                                Console.WriteLine("No transactions found in the given date range.");
                            }
                            else
                            {
                                foreach (var t in transactions)
                                {
                                    Console.WriteLine($"TxnID: {t.TransactionId}, Type: {t.TransactionType}, Amount: {t.Amount}, Date: {t.Date}");
                                }
                            }
                            break;

                        case 10:
                            Console.WriteLine("Thank you for using the Banking System. Goodbye!");
                            return;

                        default:
                            Console.WriteLine("Invalid option. Please try again.");
                            break;
                    }
                }
                catch (InvalidAccountException ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
                catch (InsufficientFundException ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input format. Please enter numbers where required.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Unexpected error: " + ex.Message);
                }
            }
        }
    }
}