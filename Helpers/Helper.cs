using System;
using System.Text.RegularExpressions;

namespace ConsoleApp.Helpers
{
    public static class ValidationHelper
    {
        public static bool IsValidEmail(string email)
        {
            var emailRegex = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, emailRegex);
        }

        public static bool IsValidPassword(string password)
        {
            var passwordRegex = @"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$";
            return Regex.IsMatch(password, passwordRegex);
        }
    }
}
