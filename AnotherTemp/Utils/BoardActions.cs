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
    public static class BoardActions
    {

        // Add function for Boards
        public static bool AddBoard(string productName, double productPrice, ProductTypes productType, EffectTypes EffectType, double width, double height, ref string err)
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


        //Editing Board details to database
        public static bool EditBoard(int id,
        string ProductName,
        double ProductPrice,
        EffectTypes EffectType,
        double width, double height,
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


        public static void Display(int ProductID, ref string err)
        {
            using (var context = new OPDdbContext())
            {
                try
                {
                    var displayPrd = context.Boards.Single(p => p.ProductId == ProductID);
                    Console.WriteLine($"Board Name : {displayPrd.ProductName} ");
                    Console.WriteLine($"Board Dimensions : {displayPrd.BoardWidth * 10}mm X {displayPrd.BoardHeight * 10}mm");
                    Console.WriteLine($"Board Price : {displayPrd.ProductPrice} NIS ");
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
