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
        public static bool AddInventoryItem(int ProductId,int Quantity,  ref string err, double SpecialPrice = 0)
        {
            using (var context = new OPDdbContext())
            {
                var p = context.Products.Single(p => p.ProductId == ProductId);
                
                if (p != null)
                {

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
                else
                {
                    err = ("No such Inventory Item");
                    return false;
                }
            }
        }


        public static bool ChangeInventoryItemQuantityOrPrice(int InventoryItemID,  ref string err, double SpecialPrice = 0, int NewQuantity=0)
        {
            using (var context = new OPDdbContext())
            {
                try
                {
                    var inv = context.Inventory.Single(p => p.InventoryItemID == InventoryItemID);
                    

                    if (inv != null)
                    {
                        inv.InentoryItemQuantity += NewQuantity;
                        inv.InventoryItemSpecialPrice = SpecialPrice;

                        context.SaveChanges();
                        err = "Inventory Item Edited Successfully";
                        return true;
                    }
                    else
                    {
                        err = ("No such Invenoty item");
                        return false;
                    }
                }
                catch(Exception e)
                {
                    err = e.Message;
                    return false;
                }
            }
        }
    }
}
