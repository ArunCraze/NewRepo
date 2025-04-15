using System;
namespace Banking_System.Exceptions
{
    public class OverDraftLimitExceededException: Exception
        
    {
        public OverDraftLimitExceededException() : base("OverDraftLimitExceeded")
        { }
        public OverDraftLimitExceededException(string message) : base(message) { }
    }
}
