using System;
namespace Banking_System.Exceptions
{
    public class InvalidAccountException: Exception
    {
        public InvalidAccountException(string message) : base(message) { }
    }
}
