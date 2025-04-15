using System;
using System.Collections.Generic;
namespace Banking_System.Task6
{
    public class TransactionHistory
    {
        public static void Main()
        { 
            List<String> transactions= new List<String>();
            double bal = 0;
            while (true)
            {
                Console.WriteLine("Choose one option : \n1.Deposit \n2.Withdrawl \n3.Exit");
                int option=Convert.ToInt32(Console.ReadLine());
                if (option == 1)
                {
                    Console.WriteLine("Enter deposit amount : ");
                    double depamount = Convert.ToDouble(Console.ReadLine());
                    bal += depamount;
                    transactions.Add($"Deposited amount : {depamount:F2} | Total balance : {bal:F2}");
                    Console.WriteLine("Deposit Successful");
                }
                else if (option == 2)
                {
                    Console.WriteLine("Enter withdrawl amount : ");
                    double withdrawamount = Convert.ToDouble(Console.ReadLine());
                    if (withdrawamount <= bal)
                    {
                        bal -= withdrawamount;
                        transactions.Add($"Withdrew amount : {withdrawamount:F2} | Total balance : {bal:F2}");
                        Console.WriteLine("Withdrawl successful");
                    }
                    else
                    {
                        Console.WriteLine("Insufficient balance");
                    }
                }
                else if (option == 3)
                {
                    Console.WriteLine("Exiting");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid Option");
                }
            }
            if (transactions.Count == 0)
            {
                Console.WriteLine("No transaction history");
            }
            else
            {
                foreach (String transaction in transactions)
                {
                    Console.WriteLine(transaction);
                }
            }
            Console.WriteLine($"Final balance : {bal:F2}");
        }
    }
}
