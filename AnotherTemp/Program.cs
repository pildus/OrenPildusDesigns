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
            string err = "";

            PopulateDB.PopulateAll();
            Console.WriteLine(err);
            //var lst = ProductActions.GetProducts();

            //foreach (var item in lst)
            //{
            //    ProductActions.IdentifyProuct(item);
            //    Console.WriteLine("*************************");
            //}

            //var lst = ProductActions.GetProducts(EffectTypes.Overdrive);

            //foreach (var item in lst)
            //{
            //    ProductActions.IdentifyProuct(item);
            //    Console.WriteLine("*************************");
            //}

            //lst = ProductActions.GetProducts(ProductTypes.Component);

            //foreach (var item in lst)
            //{
            //    ProductActions.IdentifyProuct(item);
            //    Console.WriteLine("*************************");
            //}

            //Console.WriteLine(err);
        }
    }
}