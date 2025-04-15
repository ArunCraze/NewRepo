using System;
namespace Banking_System.Task3
{
    internal class LoopStructures
    {
        public static void Main()
        {
            Console.Write("Enter no of customers : ");
            int n=int.Parse(Console.ReadLine());
            for(int i=1;i<=n;i++)
            {
                Console.Write($"Customer : {i} \n");
                Console.WriteLine("Enter initial balance");
                double initialBalance = double.Parse(Console.ReadLine());
                Console.WriteLine("Enter annual interest rate : ");
                double annualInterestRate = double.Parse(Console.ReadLine());
                Console.WriteLine("Enter no of years : ");
                int years = int.Parse(Console.ReadLine());
                double futureBalance = initialBalance * Math.Pow((1 + annualInterestRate / 100),years);
                Console.WriteLine($"Future Balance : {futureBalance:F2}");
            }
        }
    }
}
