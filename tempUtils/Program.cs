using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tempUtils.Model;
using Utils;

namespace tempUtils
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

            Pedal pd = new Pedal();
            pd.Display();


            Product bd = new Board();
            bd.Display();
            



        }
    }
}