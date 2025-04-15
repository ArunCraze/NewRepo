using System;
namespace Banking_System.Task4
{
    public class Looping_Array_DataValidation
    {
        public static void Main()
        {
            int[] accno = { 101, 102, 103 };
            double[] balance = { 2500.0, 5000.0, 1800.0 };
            bool valid = false;
            while (!valid)
            {
                Console.WriteLine("Enter account number : ");
                int enteredaccno = Convert.ToInt32(Console.ReadLine());
                for (int i = 0; i < accno.Length; i++)
                {
                    if (accno[i] == enteredaccno)
                    {
                        valid = true;
                        Console.WriteLine("Account number is valid.");
                        Console.WriteLine($"Current balance : {balance[i]}");
                        break;
                    }
                }
                if (!valid)
                {
                    Console.WriteLine("Account number is invalid. Please try again.");
                }
            }
        }
    }

}
