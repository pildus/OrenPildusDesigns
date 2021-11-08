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
            //PopulateDB.PopulateAll();
            //Constants.SessionUser.IsAdmin = true;
            string err = "";
            UserActions.UserLogin("pildus@hotmail.com", "Leviha2016!",ref err);

            //OrdersActions.AddOrder(4, 5, 1, 600, ref err, false);
            //OrdersActions.AddOrder(4, 3, 250, 0.90, ref err, false);
            //OrdersActions.AddOrder(4, 2, 2, 110, ref err, false);
            //OrdersActions.AddOrder(4, 4, 3, 110, ref err, false);

            //var lst = OrdersActions.GetOrders();

            //foreach (var item in lst)
            //{
            //    OrdersActions.DeleteOrder(item.cOrder,true,ref err);
            //}





        }
    }
}