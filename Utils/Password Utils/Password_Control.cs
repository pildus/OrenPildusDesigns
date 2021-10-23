using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Utils
{
    static class Constants
    {
        public const int _passMinLength = 6;
        public const int _passMaxLength = 12;
    }


    public class Password_Control
    {
        // Validation of password length, charachters(Uppercase , numeric, and symbol)
        public static bool Validate_Password_Params(string pass)
        {
            //checking password length
            if (pass.Length < Constants._passMinLength || pass.Length > Constants._passMaxLength)
                return false;

            if (!pass.Any(char.IsUpper))
                return false;

            return true;
        }
    }
}
