using System;
using System.Text.RegularExpressions;
namespace Banking_System.Task5
{
    public class PasswordValidation
    {
        static void Main()
        {
            Console.Write("Condition : \nThe password must be at least 8 characters long. \n It must contain at least one uppercase letter. \n It must contain at least one digit. \n Create password : ");
            String pass = Console.ReadLine();
            bool isValid = true;
            if (pass.Length < 8)
            {
                Console.WriteLine("Password must be atleast 8 characters");
                isValid = false;
            }
            if (!Regex.IsMatch(pass, "[A-Z]"))
            {
                Console.WriteLine("It must contain at least one uppercase letter.");
                isValid = false;
            }
            if (!Regex.IsMatch(pass, "[0-9]"))
            {
                Console.WriteLine("It must contain at least one digit.");
                isValid = false;
            }
            if (isValid)
            {
                Console.WriteLine("Password is valid");
            }
            else
            {
                Console.WriteLine("Password is not valid");
            }
        }
     }
}
