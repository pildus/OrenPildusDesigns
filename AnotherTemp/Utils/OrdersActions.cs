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
    // * * This class is used to extract the full data of an order, generating reflections of the entities related to the order,
    // through wich any property can be accessed
    public class ComplexOrder
    {
        public Order cOrder { get; set; }
        public Product cProduct { get; set; }
        public InventoryItem cinventoryItem { get; set; }
        public User cUser { get; set; }
    }

    public static class OrdersActions
    {

        //Adding an order for a specific user, and a specific inventory item - related to specific product
        // Isconfirmed is used for immidiate order ("Buy Now" option - not implemented in GUI), or for future order (Shopping cart option)
        public static bool AddOrder(int UserId, int InventoryItemProductID, int Quantity, double OrderPrice, ref string err, bool isConfirmed)
        {
            try
            {
                using (var context = new OPDdbContext())
                {
                    var inv = context.Inventory.Any(p => p.InventoryItemProductID == InventoryItemProductID);

                    Order ord = new Order
                    {
                        OrderDate = DateTime.Now,
                        OrderInventoryItemID = InventoryItemProductID,
                        OrderQuantity = Quantity,
                        OrderTotalAmount = Quantity * OrderPrice,
                        OrderUserID = UserId,
                        OrderIsConfirmed = isConfirmed
                    };

                    context.Orders.Add(ord);
                    context.SaveChanges();

                    if (isConfirmed) //if order confirmed - change the inventory accordingly
                    {
                        InventoryItemActions.ChangeInventoryItemQuantity(InventoryItemProductID, ref err, -Quantity);
                        err = "Order place, Inventory updated";
                    }
                    else // add this order to the user's shopping cart property
                    {
                        Constants.SessionUser.ShoppingCart.Add(ord);
                        err = "Order Added to Shopping cart, waiting for confirmation";
                    }


                    return true;

                }
            }
            catch (Exception e)
            {
                err = e.Message;
                return false;
            }
        }


        // ** ** ** ** ** ** ** ** ** ** ** **
        // ** Method overloads to get orders data
        // ** ** ** ** ** ** ** ** ** ** ** **
        public static List<ComplexOrder> GetOrders()
        {
            if (Constants.SessionUser.IsAdmin == true)
            {
                try
                {
                    using (var context = new OPDdbContext())
                    {
                        var lst = (from o in context.Orders
                                   from p in context.Products
                                   from i in context.Inventory
                                   from u in context.Users
                                   where o.OrderInventoryItemID == i.InventoryItemID &&
                                   i.InventoryItemProductID == p.ProductId &&
                                   o.OrderUserID == u.UserID
                                   select new ComplexOrder
                                   {
                                       cOrder = o,
                                       cProduct = p,
                                       cUser = u,
                                       cinventoryItem = i
                                   }).ToList();


                        return lst;
                    }
                }
                catch
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }  // Get all orders in the system - Admin permission required
        public static List<ComplexOrder> GetOrders(int ProductID)
        {
            try
            {
                using (var context = new OPDdbContext())
                {
                    //List< Order> lst = context.Orders.Where(o => o.OrderUserID == UserId).ToList();

                    var lst = (from o in context.Orders
                               from p in context.Products
                               from i in context.Inventory
                               from u in context.Users
                               where o.OrderInventoryItemID == i.InventoryItemID &&
                               i.InventoryItemProductID == p.ProductId &&
                               o.OrderUserID == u.UserID && p.ProductId == ProductID
                               select new ComplexOrder
                               {
                                   cOrder = o,
                                   cProduct = p,
                                   cUser = u,
                                   cinventoryItem = i
                               }).ToList();
                    return lst;
                }
            }
            catch
            {
                return null;
            }
        }  //Get all orders of a specific Product
        public static List<ComplexOrder> GetOrders(string Username)
        {
            try
            {
                using (var context = new OPDdbContext())
                {
                    //List< Order> lst = context.Orders.Where(o => o.OrderUserID == UserId).ToList();

                    var lst = (from o in context.Orders
                               from p in context.Products
                               from i in context.Inventory
                               from u in context.Users
                               where o.OrderInventoryItemID == i.InventoryItemID &&
                               i.InventoryItemProductID == p.ProductId &&
                               o.OrderUserID == u.UserID && u.UserName == Username && o.OrderIsConfirmed == true
                               select new ComplexOrder
                               {
                                   cOrder = o,
                                   cProduct = p,
                                   cUser = u,
                                   cinventoryItem = i
                               }).ToList();

                    return lst;
                }
            }
            catch
            {
                return null;
            }
        } // Get all orders made by a specific user
        public static List<ComplexOrder> GetOrders(ProductTypes pt)
        {
            try
            {
                using (var context = new OPDdbContext())
                {
                    //List< Order> lst = context.Orders.Where(o => o.OrderUserID == UserId).ToList();

                    var lst = (from o in context.Orders
                               from p in context.Products
                               from i in context.Inventory
                               from u in context.Users
                               where o.OrderInventoryItemID == i.InventoryItemID &&
                               i.InventoryItemProductID == p.ProductId && o.OrderUserID == u.UserID &&
                                p.ProductType == pt
                               select new ComplexOrder
                               {
                                   cOrder = o,
                                   cProduct = p,
                                   cUser = u,
                                   cinventoryItem = i
                               }).ToList();

                    return lst;
                }
            }
            catch
            {
                return null;
            }
        } /// Get all orders made for a specific product type
        public static List<ComplexOrder> GetOrders(DateTime OrderDate)
        {
            try
            {
                using (var context = new OPDdbContext())
                {
                    var lst = (from o in context.Orders
                               from p in context.Products
                               from i in context.Inventory
                               from u in context.Users
                               where o.OrderInventoryItemID == i.InventoryItemID &&
                               i.InventoryItemProductID == p.ProductId &&
                               o.OrderUserID == u.UserID && o.OrderDate.Date == OrderDate.Date
                               select new ComplexOrder
                               {
                                   cOrder = o,
                                   cProduct = p,
                                   cUser = u,
                                   cinventoryItem = i
                               }).ToList();
                    return lst;
                }
            }
            catch
            {
                return null;
            }
        } // Get all orders made at a specific date
        public static List<ComplexOrder> GetOrders(DateTime StartOrderDate, DateTime EndOrderDate, int UserID)
        {
            try
            {
                using (var context = new OPDdbContext())
                {
                    var lst = (from o in context.Orders
                               from p in context.Products
                               from i in context.Inventory
                               from u in context.Users
                               where o.OrderInventoryItemID == i.InventoryItemID &&
                               i.InventoryItemProductID == p.ProductId &&
                               o.OrderUserID == u.UserID &&
                               o.OrderDate >= StartOrderDate && o.OrderDate <= EndOrderDate
                               && o.OrderIsConfirmed == true && u.UserID == UserID
                               select new ComplexOrder
                               {
                                   cOrder = o,
                                   cProduct = p,
                                   cUser = u,
                                   cinventoryItem = i
                               }).ToList();
                    return lst;
                }
            }
            catch
            {
                return null;
            }
        } // Get all orders made by a specific user whithin dates range

        // a method to reciect the shopping cart list, confirming the status and update the inventory
        public static bool ProcessShoppingCart(List<Order> lst)
        {
            string err = "";

            try
            {
                using (var context = new OPDdbContext())
                {
                    //List<Order> lst = Constants.SessionUser.ShoppingCart;

                    foreach (Order ord in lst)
                    {
                        InventoryItemActions.ChangeInventoryItemQuantity(ord.OrderInventoryItemID, ref err, 0 - ord.OrderQuantity);
                        ord.OrderIsConfirmed = true;
                        context.Update(ord);
                        context.SaveChanges();
                    }

                    err = "All orders from shopping cart updated";
                    return true;
                }
            }
            catch (Exception e)
            {
                err = e.Message;
                return false;
            }
        }

        //Upon login, this methos extract all unconfirmed order for the logged in user,
        //and assign this list to the user's shopping cart property
        public static bool PopulateShoppingCart(User currentUser, ref string err)
        {
            try
            {
                currentUser.ShoppingCart = new List<Order>();

                using (var context = new OPDdbContext())
                {
                    List<Order> lst = context.Orders.Where(o => o.OrderUserID == currentUser.UserID && o.OrderIsConfirmed == false).ToList();
                    currentUser.ShoppingCart = lst;
                    return true;
                }
            }
            catch (Exception e)
            {
                err = e.Message;
                return false;
            }
        }


        // Delete order mthod. If order was confirmed - delete=return , therefore inventory is updated.
        // if order not confirmed, only deleting from database/shopping cart.
        public static bool DeleteOrder(Order ord, bool IsReturnedAndRefund, ref string err)
        {
            try
            {
                using (var context = new OPDdbContext())
                {
                    if (ord.OrderIsConfirmed == true && IsReturnedAndRefund == true && Constants.SessionUser.IsAdmin == true)
                    {
                        InventoryItemActions.ChangeInventoryItemQuantity(ord.OrderInventoryItemID, ref err, ord.OrderQuantity);
                        context.Remove(ord);
                        context.SaveChanges();
                        err = "Order deleted successfully from database, inventory updated";
                        return true;
                    }
                    else if (ord.OrderIsConfirmed == false)
                    {
                        context.Remove(ord);
                        context.SaveChanges();
                        err = "Order deleted successfully from Shopping cart";
                        return true;
                    }

                    err = "Order can't be deleted - No user permission";
                    return false;
                }
            }
            catch (Exception e)
            {
                err = e.Message;
                return false;
            }
        }

        // Delete order mthod. If order was confirmed - delete=return , therefore inventory is updated.
        // if order not confirmed, only deleting from database/shopping cart.
        public static bool DeleteOrder(int OrderId, bool IsReturnedAndRefund, ref string err)
        {
            try
            {
                using (var context = new OPDdbContext())
                {
                    Order ord = context.Orders.Single(o => o.OrderID == OrderId);

                    if (ord.OrderIsConfirmed == true && IsReturnedAndRefund == true && Constants.SessionUser.IsAdmin == true)
                    {
                        InventoryItemActions.ChangeInventoryItemQuantity(ord.OrderInventoryItemID, ref err, ord.OrderQuantity);
                        context.Remove(ord);
                        context.SaveChanges();
                        err = "Order deleted successfully from database, inventory updated";
                        return true;
                    }
                    else if (ord.OrderIsConfirmed == false)
                    {
                        context.Remove(ord);
                        context.SaveChanges();
                        err = "Order deleted successfully from Shopping cart";
                        return true;
                    }

                    err = "Order can't be deleted - No user permission";
                    return false;
                }
            }
            catch (Exception e)
            {
                err = e.Message;
                return false;
            }
        }
    }

    
}

