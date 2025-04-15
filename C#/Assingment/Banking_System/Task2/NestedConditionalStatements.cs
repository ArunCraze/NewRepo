using System;
namespace Banking_System.Task2
{
    public class NestedConditionalStatements
    {
        public static void Main()
        {
            Console.Write("Enter current balance : ");
            double currentBalance = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("1-Check balance\t 2-Withdrawl\t 3-Deposit");
            Console.Write("Enter your Option : ");
            int Option = Convert.ToInt32(Console.ReadLine());
            if (Option == 1)
            {
                Console.Write($"Current balance : {currentBalance}");
            }
            else if (Option == 2)
            {
                Console.Write("Enter withdrwal amount : ");
                double withdrawlAmount = Convert.ToDouble(Console.ReadLine());
                if (withdrawlAmount < currentBalance)
                {
                    if (withdrawlAmount % 100 == 0 && withdrawlAmount % 500 == 0)
                    {
                        currentBalance -= withdrawlAmount;
                        Console.WriteLine($"Withdrawl successful\nCurrent balance : {currentBalance}");
                    }
                    else
                    {
                        Console.WriteLine("Amount must be in multiples of 100 or 500.");

                    }
                }
                else
                {
                    Console.WriteLine("Insufficient balance.");
                }
            }
            else if (Option == 3)
            {
                Console.Write("Enter deposit amount : ");
                double depositAmount = Convert.ToDouble(Console.ReadLine());
                currentBalance += depositAmount;
                Console.WriteLine($"Current balance : {currentBalance}");
            }
            else
            {
                Console.WriteLine("Invalid Option.");
            }
        }
    }
}
