using System;
namespace Banking_System.Exceptions
{
    public class InsufficientFundException:Exception
    {
        public InsufficientFundException(string message) : base(message) { }
    }
}
