﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Security.Cryptography;


namespace Utils
{
    static class Constants
    {
        public const int _passMinLength = 8;
        public const int _passMaxLength = 20;
        public const string _specialChar = @"\|!#$%&/()=?»«@£§€{}.-;'<>_,";
    }


    public static class Password_Control
    {
        // Validation of password length, charachters(Uppercase , numeric, and symbol)
        public static bool Validate_Password_Params(string pass)
        {
            bool _specFlag = false;

            //checking password length
            if (pass.Length < Constants._passMinLength || pass.Length > Constants._passMaxLength)
                return false;

            if (!pass.Any(char.IsUpper) || //Validate at lease one Uppercase char
                !pass.Any(Char.IsLower) || //Validate at lease one lowercase char
                !pass.Any(Char.IsDigit) || //Validate at lease one numeric char
                pass.Any(Char.IsSeparator)) //Validate no spaces or line seperators
                    return false;
            

            //Validate at least one special charchter
            foreach (var c in Constants._specialChar)
            {
                if (pass.Contains(c))
                {
                    _specFlag = true;
                    break;
                }
            }
            if (!_specFlag)
                return false;

            
            return true;
        }

        //Encrypting the password for storing and for login validation
        public static string Encrypt_Password(string pass)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(pass));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
