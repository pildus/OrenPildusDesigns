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
    public static class InventoryItemActions
    {
        //Adding inventory data for a specific product 
        // ** only admin user permitted.
        public static bool AddInventoryItem(int ProductId, int Quantity, ref string err, double SpecialPrice = 0)
        {
            if (Constants.SessionUser.IsAdmin == true)
            {
                try
                {
                    using (var context = new OPDdbContext())
                    {
                        var p = context.Products.Single(p => p.ProductId == ProductId); // Verifying Product Id is legit

                        InventoryItem inv = new InventoryItem()
                        {
                            InventoryItemProductID = ProductId,
                            InentoryItemQuantity = Quantity,
                        };

                        if (SpecialPrice > 0)
                            inv.InventoryItemSpecialPrice = SpecialPrice;
                        else
                            inv.InventoryItemSpecialPrice = p.ProductPrice;

                        context.Add<InventoryItem>(inv);
                        context.SaveChanges();
                        err = "Inventory Item Added Successfully";
                        return true;
                    }
                }
                catch
                {
                  err = "You have no permission to perform this";
                return false;

                }
            }
            else
            {
                err = "You have no permission to perform this";
                return false;
            }
        }
    

        //Method to change product's inventory
        // ** To be used for orders commited or returned.
        public static bool ChangeInventoryItemQuantity(int InventoryItemProductID, ref string err,  int NewQuantity)
        {
            try
            {

                using (var context = new OPDdbContext())
                {
                    var inv = context.Inventory.Single(p => p.InventoryItemProductID == InventoryItemProductID);


                    inv.InentoryItemQuantity += NewQuantity;

                    context.SaveChanges();
                    err = "Inventory Item Edited Successfully";
                    return true;
                }
            }
            catch (Exception e)
            {
                err = e.Message;
                return false;
            }
        }

        //Method to get the current inventory of a specific product
        // ** to be used mainly to display current stock in the GUI
        public static int GetProductInventoryStatus(int ProductId)
        {
            try
            {
                using (var context = new OPDdbContext())
                {
                    var checkProduct = context.Inventory.Single(p => p.InventoryItemProductID == ProductId);

                    if (checkProduct != null)
                    {
                        var cnt = context.Inventory.Where(p => p.InventoryItemProductID == ProductId).Sum(c => c.InentoryItemQuantity);
                        return cnt;
                    }
                    else
                    {
                       // err = "No inventory exist for this product ID";
                        return -100;
                    }

                    
                }
            }
            catch (Exception e)
            {
                //err = e.Message;
                return -100;
            }
        }
    }
}
