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
        public static bool DeleteProduct(int ProductID, ref string err)
        {
            if (Constants.SessionUser.IsAdmin == true)
            {
                try
                {
                    using (var context = new OPDdbContext())
                    {
                        var delPrd = context.Products.Single(p => p.ProductId == ProductID);
                        context.Remove<Product>(delPrd);
                        context.SaveChanges();

                        err = "Product Deleted Successfully !";
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    err = ex.Message;
                    return false;
                }
            }
            else
            {
                err = "You don't have permissions for this action !";
                return false;
            }
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

                        if (newLst.Any(p => p.ProductId == tmp.ProductId) == false)
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
                                         from c in context.Components
                                         where p.ProductType == ProductTypes.Component && c.ComponentType == ct
                                         && c.ProductId == p.ProductId
                                         select p).ToList();
                    return lst;
                }
            }
            catch
            {
                return null;
            }

        } // returns a list of all products of [Product Type]



        // ** ** ** ** ** ** ** ** ** ** ** **
        // ** Method overloads to adding products
        // ** ** ** ** ** ** ** ** ** ** ** **

        // Add function for Pedals
        public static int AddProduct(string productName, double productPrice, ProductTypes productType, EffectTypes EffectType, string pedalDescr, ref string err)
        {
            if (Constants.SessionUser.IsAdmin == true)
            {
                try
                {
                    using (var context = new OPDdbContext())
                    {
                        Product p = new Pedal()
                        {
                            ProductName = productName,
                            ProductPrice = productPrice,
                            ProductType = productType,
                            EffectType = EffectType,
                            PedalDescription = pedalDescr
                        };

                        context.Add<Product>(p);
                        context.SaveChanges();
                        err = "Product Added Successfully";
                        return p.ProductId;
                    }
                }
                catch (Exception e)
                {
                    err = e.Message;
                    return 0;
                }
            }
            else
            {
                err = "You have no permission to perform this";
                return 0;
            }

        }

        // Add function for Boards
        public static int AddProduct(string productName, double productPrice, ProductTypes productType, EffectTypes EffectType, double width, double height, ref string err)
        {
            if (Constants.SessionUser.IsAdmin == true)
            {
                try
                {
                    using (var context = new OPDdbContext())
                    {
                        Product p = new Board()
                        {
                            ProductName = productName,
                            ProductPrice = productPrice,
                            ProductType = ProductTypes.Board,
                            EffectType = EffectType,
                            BoardWidth = width,
                            BoardHeight = height
                        };

                        context.Add<Product>(p);
                        context.SaveChanges();
                        err = "Product Added Successfully";
                        return p.ProductId;
                    }
                }
                catch (Exception e)
                {
                    err = e.Message;
                    return 0;
                }
            }
            else
            {
                err = "You have no permission to perform this";
                return 0;
            }


        }

        // Add function for Componentss
        public static int AddProduct(string productName, double productPrice, ProductTypes productType,
                                        ComponentTypes ComponentType, int Quantity, ref string err, EffectTypes effectType = EffectTypes.Misc)
        {
            if (Constants.SessionUser.IsAdmin == true)
            {
                try
                {
                    using (var context = new OPDdbContext())
                    {
                        Product p = new Component()
                        {
                            ProductName = productName,
                            ProductPrice = productPrice,
                            ProductType = ProductTypes.Component,
                            ComponentType = ComponentType,
                            QuantityPerLot = Quantity,
                            EffectType = effectType
                        };

                        context.Add<Product>(p);
                        context.SaveChanges();
                        err = "Product Added Successfully";
                        return p.ProductId;
                    }
                }
                catch (Exception e)
                {
                    err = e.Message;
                    return 0;
                }
            }
            else
            {
                err = "You have no permission to perform this";
                return 0;
            }

        }


        // ** ** ** ** ** ** ** ** ** ** ** **
        // ** Method overloads to editing products
        // ** ** ** ** ** ** ** ** ** ** ** **

        // Editing function for Pedals
        public static bool EditProduct(int id, string ProductName, double ProductPrice, EffectTypes EffectType, string PedalDescription, ref string err)
        {
            if (Constants.SessionUser.IsAdmin == true)
            {
                if (!(ProductName == "") || Enum.IsDefined(typeof(EffectTypes), EffectType) || !(ProductPrice < 0))
                {
                    try
                    {
                        using (var context = new OPDdbContext())
                        {
                            var updatePedal = context.Pedals.Single(u => u.ProductId == id);

                            //Verify user exist
                            if (!(updatePedal == null))
                            {
                                //updateUser.EmailAddress = EmailAddress;
                                updatePedal.ProductName = ProductName;
                                updatePedal.ProductPrice = ProductPrice;
                                updatePedal.EffectType = EffectType;
                                updatePedal.PedalDescription = PedalDescription;

                                context.SaveChanges();
                                err = "Good. Pedal updated";
                                return true;
                            }
                            else
                            {
                                err = "No such Pedal";
                                return false;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        err = "No Pedal with this ID";
                        Console.WriteLine(e.Message);
                        return false;
                    }
                }
                else
                {
                    err = "Error in input data";
                    return false;
                }

            }
            else
            {
                err = "You have no permission to perform this";
                return false;
            }

        }

        // Editing function for Boards
        public static bool EditProduct(int id, string ProductName, double ProductPrice, EffectTypes EffectType, double width, double height, ref string err)
        {
            if (Constants.SessionUser.IsAdmin == true)
            {
                if (!(ProductName == "") || Enum.IsDefined(typeof(EffectTypes), EffectType) || !(ProductPrice < 0))
                {
                    try
                    {

                        using (var context = new OPDdbContext())
                        {
                            var updateBoard = context.Boards.Single(u => u.ProductId == id);

                            //Verify user exist
                            if (!(updateBoard == null))
                            {
                                //updateUser.EmailAddress = EmailAddress;
                                updateBoard.ProductName = ProductName;
                                updateBoard.ProductPrice = ProductPrice;
                                updateBoard.EffectType = EffectType;
                                updateBoard.BoardWidth = width;
                                updateBoard.BoardHeight = height;

                                context.SaveChanges();
                                err = "Good. Board updated";
                                return true;
                            }
                            else
                            {
                                err = "No such Board";
                                return false;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        err = "No Board with this ID";
                        Console.WriteLine(e.Message);
                        return false;
                    }
                }
                else
                {
                    err = "Fields data error";
                    return false;
                }

            }
            else
            {
                err = "You have no permission to perform this";
                return false;
            }
        }

        // Editing function for Components
        public static bool EditProduct(int id, string ProductName, double ProductPrice, ComponentTypes ComponentType, int Quantity, ref string err,EffectTypes et = EffectTypes.Misc)
        {
            if (Constants.SessionUser.IsAdmin == true)
            {
                if (!(ProductName == "") || Enum.IsDefined(typeof(ComponentTypes), ComponentType) || !(ProductPrice < 0))
                {
                    try
                    {
                        using (var context = new OPDdbContext())
                        {

                            var updateComponent = context.Components.Single(u => u.ProductId == id);

                            //Verify user exist
                            if (!(updateComponent == null))
                            {
                                //updateUser.EmailAddress = EmailAddress;
                                updateComponent.ProductName = ProductName;
                                updateComponent.ProductPrice = ProductPrice;
                                updateComponent.ComponentType = ComponentType;
                                updateComponent.QuantityPerLot = Quantity;
                                updateComponent.EffectType = et;

                                context.SaveChanges();
                                err = "Good. Component updated";
                                return true;
                            }
                            else
                            {
                                err = "No such Component";
                                return false;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        err = e.Message;
                        return false;
                    }
                }
                else
                {
                    err = "Fields data error";
                    return false;

                }
            }
            else
            {
                err = "You have no permission to perform this";
                return false;
            }
        }

    }
}


