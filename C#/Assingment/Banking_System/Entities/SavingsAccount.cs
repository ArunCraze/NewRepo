using System;
namespace Banking_System.Entities
{
    public class SavingsAccount : Accounts
    {
        public float InterestRate { get; set; } = 4.5f;
        public SavingsAccount() : base() 
        {
            AccountType = "Savings";
            if (Balance < 500)
            {
                Balance = 500; 
            }
        }
        public float CalculateInterest()
        {
            return Balance * (InterestRate / 100);
        }
    }
}
