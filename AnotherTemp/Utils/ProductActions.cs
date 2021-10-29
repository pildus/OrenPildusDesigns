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


namespace DataControl.Utils
{
    public static class ProductActions
    {
        public static bool DeleteProduct(int ProductID)
        {
            using (var context = new OPDdbContext())
            {
                try
                {
                    var delPrd = context.Products.Single(p => p.ProductId == ProductID);
                    context.Remove<Product>(delPrd);
                    context.SaveChanges();
                }
                catch
                {
                    return false;
                }
            }

            return false;
        }

        public static List<Product> GetProducts()
        {
            try
            {
                using (var context = new OPDdbContext())
                {
                    List<Product> lst = context.Products.ToList();
                    return lst;
                }
            }
            catch
            {
                return null;
            }
        }
        public static List<Product> GetProducts(ProductTypes pt)
        {
            try
            {
                using (var context = new OPDdbContext())
                {
                    List<Product> lst = (from p in context.Products 
                                         where p.ProductType == pt 
                                         select p).ToList();
                    return lst;
                }
            }
            catch
            {
                return null;
            }
            
        }

        public static Product GetProducts(int pID)
        {
            try
            {
                using (var context = new OPDdbContext())
                {
                    Product lst = context.Products.Single(p => p.ProductId == pID);
                    return lst;
                }
            }
            catch
            {
                return null;
            }

        }

        public static List<Product> GetProducts(int minId , int maxID)
        {
            try
            {
                using (var context = new OPDdbContext())
                {
                    List<Product> lst = (from p in context.Products
                                         where p.ProductId >= minId && p.ProductId <= maxID
                                         select p).ToList();
                    return lst;
                }
            }
            catch
            {
                return null;
            }

        }

        public static List<Product> GetProducts(EffectTypes pt)
        {
            try
            {
                using (var context = new OPDdbContext())
                {
                    List<Product> lst = context.Products.Where(p => p.EffectType == pt).ToList();
                    return lst;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }

        }

        public static void IdentifyProuct(Product prd)
        {
            string err = "";

            switch (prd)
            {
                case Pedal p:
                    PedalActions.Display(prd.ProductId, ref err);
                    break;
                case Board b:
                    BoardActions.Display(prd.ProductId, ref err);
                    break;
                case Component c:
                    ComponentActions.Display(prd.ProductId, ref err);
                    break;
                default:
                    break;
            }
        }
    }
}
