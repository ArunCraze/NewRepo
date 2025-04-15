using System;
namespace Banking_System.Entities
{
    public class CurrentAccount : Accounts
    {
        public float OverdraftLimit { get; set; } = 10000;
        public CurrentAccount() : base()
        {
            AccountType = "Current";
        }
        public bool Withdraw(float amount)
        {
            if (Balance + OverdraftLimit >= amount)
            {
                Balance -= amount;
                return true;
            }
            else
            {
                Console.WriteLine("Overdraft limit exceeded.");
                return false;
            }
        }
    }
}
