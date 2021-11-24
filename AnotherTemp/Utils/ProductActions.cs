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


        // ** ** ** ** ** ** ** ** ** ** ** **
        // ** Method overloads to get products data
        // ** ** ** ** ** ** ** ** ** ** ** **
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
        }// Returns a list of all products available in Products table.
        public static List<Product> GetProducts(Random random, int count)
        {
            try
            {
                using (var context = new OPDdbContext())
                {
                    List<Product> lst = context.Products.ToList();
                    List<Product> newLst = new List<Product>();
                    Product tmp;
                    for (int i = 0; i < count; i++)
                    {
                        tmp = lst[random.Next(lst.Count)];
                        
                        if (newLst.Any(p => p.ProductId ==tmp.ProductId) == false)
                       // if (newLst.Any(p => p.ProductId == lst[3].ProductId == false))
                            newLst.Add(tmp);
                        else
                            i--;
                    }
                    
                    return newLst;
                }
            }
            catch
            {
                return null;
            }
        }// Returns a list of all products available in Products table.
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

        } // returns a list of all products of [Product Type]
        public static Product GetProducts(int pID)
        {
            try
            {
                using (var context = new OPDdbContext())
                {
                    var lst = context.Products.Single(p => p.ProductId == pID);
                    //return new List<Product>() { lst } ;
                    return lst;
                }
            }
            catch
            {
                return null;
            }

        } //return a Product object of a specific [ProductID]

        public static Product GetProducts(Order ord)
        {
            try
            {
                using (var context = new OPDdbContext())
                {
                    var lst = (from p in context.Products
                              from i in context.Inventory
                              from o in context.Orders
                              where i.InventoryItemProductID == p.ProductId && o.OrderInventoryItemID == i.InventoryItemID
                              && ord.OrderID == o.OrderID
                              select p).Single();
                    //return new List<Product>() { lst } ;
                    return lst;
                }
            }
            catch
            {
                return null;
            }

        } //return a Product object of a specific [ProductID]

        public static List<Product> GetProducts(int minId, int maxID)
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

        } //return a list of products from a range of [ProductID]
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

        } // Return a list of all products containig a specific [Effect Type]

        public static List<Product> GetProducts(ProductTypes pt, EffectTypes et)
        {
            try
            {
                using (var context = new OPDdbContext())
                {
                    List<Product> lst = (from p in context.Products
                                         where p.ProductType == pt && p.EffectType == et
                                         select p).ToList();
                    return lst;
                }
            }
            catch
            {
                return null;
            }

        } // returns a list of all products of [Product Type]

        public static List<Product> GetProducts(ProductTypes pt, ComponentTypes ct)
        {
            try
            {
                using (var context = new OPDdbContext())
                {
                    List<Product> lst = (from p in context.Products
                                         where p.ProductType == ProductTypes.Component && p.ComponentType == ct
                                         select p).ToList();
                    return lst;
                }
            }
            catch
            {
                return null;
            }

        } // returns a list of all products of [Product Type]

        // Methods to call the display method for ecah product type
        public static void ProuctDisplay(Product prd)
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
