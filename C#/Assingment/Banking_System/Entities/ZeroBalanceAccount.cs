using System;
namespace Banking_System.Entities
{
    public class ZeroBalanceAccount : Accounts
    {
        public ZeroBalanceAccount() : base()
        {
            AccountType = "ZeroBalance";
            Balance = 0;
        }
    }
}
