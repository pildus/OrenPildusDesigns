using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataControl.Model;
using DataControl.Utils;
using DataControl.DataAccess;
using System.Net.Mail;

namespace DataControl
{
    class Program
    {
        static void Main(string[] args)
        {
            User u = new User()
            {
                EmailAddress = "pildus@gmail.com",
                FirstName = "Oren",
                LastName = "Pildus",
                Password = Password_Control.Encrypt_Password("AbCdE123"),
                UserName = "pildus"
            };

            

            

            using (var context = new OPDdbContext())
            {
                context.Add<User>(u);
                context.SaveChanges();
            }

            
            //string pass = "Lev$iha2016!";

            //bool p = Password_Control.Validate_Password_Params(pass);
            //Console.WriteLine(p.ToString());

            //Console.WriteLine(Password_Control.Encrypt_Password(pass));

            //Console.WriteLine(Password_Control.Encrypt_Password(pass)== Password_Control.Encrypt_Password("Lev$iha2016!"));


        }
    }
}