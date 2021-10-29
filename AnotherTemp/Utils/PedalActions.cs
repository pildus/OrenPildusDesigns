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
    public static class PedalActions
    {
        // Add function for Pedals
        public static bool AddPedal(string productName, double productPrice, ProductTypes productType, EffectTypes EffectType, string pedalDescr, ref string err)
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
                            ProductType = ProductTypes.Pedal,
                            EffectType = EffectType,
                            PedalDescription = pedalDescr
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

        //Editing Pedal details to database
        public static bool EditPedal(int id,
        string ProductName,
        double ProductPrice,
        EffectTypes EffectType,
        string PedalDescription,
        ref string err)
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


        public static void Display(int ProductID, ref string err)
        {
            using (var context = new OPDdbContext())
            {
                try
                {
                    var displayPrd = context.Pedals.Single(p => p.ProductId == ProductID);
                    Console.WriteLine($"Pedal Name : {displayPrd.ProductName} ");
                    Console.WriteLine($"Pedal Description : {displayPrd.PedalDescription} ");
                    Console.WriteLine($"Pedal Price : {displayPrd.ProductPrice} NIS ");
                }
                catch (Exception e)
                {
                    err = e.Message;
                    Console.WriteLine(err);
                }
            }
        }
    }
}
