using System;
namespace Banking_System.Task1
{
    internal class ConditionalStatements
    {
        static void Main()
        {
            Console.Write("Enter credit score : ");
            int creditScore = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter annual income : ");
            long annualIncome = Convert.ToInt64(Console.ReadLine());
            if(creditScore>700 && annualIncome>50000)
            {
                Console.WriteLine("Customer is eligible for a loan.");
            }
            else
            {
                Console.WriteLine("Customer is not eligible for a loan.");
            }
        }
    }
}
