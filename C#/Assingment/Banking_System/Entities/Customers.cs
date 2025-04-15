using System;
namespace Banking_System.Entities
{
    public class Customers
    {
        public long CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

        public Customers() { }

        public void PrintDetails()
        {
            Console.WriteLine($"Customer: {FirstName} {LastName} ({CustomerID})");
            Console.WriteLine($"Email: {Email}");
            Console.WriteLine($"Phone: {PhoneNumber}");
            Console.WriteLine($"Address: {Address}");
        }
    }
}
