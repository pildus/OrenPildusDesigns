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
    public static class ComponentActions
    {

        // Add function for Boards
        public static bool AddComponent(string productName, double productPrice, ProductTypes productType, 
                                        ComponentTypes ComponentType, int Quantity,ref string err,EffectTypes effectType = EffectTypes.Misc)
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
                        return true;
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
                err = "You have no permission to perform this";
                return false;
            }
        }

        //Editing Component details to database
        public static bool EditComponent(int id,
        string ProductName,
        double ProductPrice,
        ComponentTypes ComponentType,
        int Quantity,
        ref string err)
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

        //Method for Component display - To be changed when switching to WPF GUI
        public static void Display(int ProductID, ref string err)
        {
            using (var context = new OPDdbContext())
            {

                    var displayPrd = context.Components.Single(p => p.ProductId == ProductID);
                    Console.WriteLine($"Component Name : {displayPrd.ProductName} ");
                    Console.WriteLine($"Qty/Lot : {displayPrd.QuantityPerLot}");
                    Console.WriteLine($"Component Price : {displayPrd.ProductPrice} NIS ");
                }

            }
        }
    }

