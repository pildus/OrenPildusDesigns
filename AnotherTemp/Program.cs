using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnotherTemp.Model;
using AnotherTemp.Utils;

namespace AnotherTemp
{
    class Program
    {
        static void Main(string[] args)
        {
            string pass = "Lev$iha2016!";

            bool p = Password_Control.Validate_Password_Params(pass);
            Console.WriteLine(p.ToString());

            Console.WriteLine(Password_Control.Encrypt_Password(pass));

            Console.WriteLine(Password_Control.Encrypt_Password(pass)== Password_Control.Encrypt_Password("Lev$iha2016!"));

            



        }
    }
}