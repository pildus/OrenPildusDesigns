using DataControl.Model;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataControl.Utils;

namespace DataControl.DataAccess
{
    public static class PopulateDB
    {
        public static bool CheckDBExist()
        {
            using (var context = new OPDdbContext())
            {
                if (!context.Database.CanConnect())
                {
                    context.Database.Migrate();
                    PopulateAll();
                }

                return true;
            }
        }

        private static void PopulateAll()
        {
            string err = "";
            Constants.SessionUser.IsAdmin = true;

            // ClearData();
            #region CreateUserTypes
            UserActions.CreateUserType("Admin", ref err);
            Console.WriteLine(err);
            UserActions.CreateUserType("Moderator", ref err);
            Console.WriteLine(err);
            UserActions.CreateUserType("Regular", ref err);
            Console.WriteLine(err);
            #endregion

            #region CreateUsers
            string EmailAddress = "admin@admin.com";
            string Password = "Admin123!";
            string FirstName = "Admin";
            string LastName = "Admin";
            string UserName = "Admin";
            bool IsAdmin = true;
            UserActions.UserSignUp(UserName, FirstName, LastName, Password, EmailAddress, IsAdmin,1, ref err);
            Console.WriteLine(err);

            EmailAddress = "user@user.com";
            Password = "User123!";
            FirstName = "User";
            LastName = "User";
            UserName = "User";
            IsAdmin = false;
            UserActions.UserSignUp(UserName, FirstName, LastName, Password, EmailAddress, IsAdmin,2, ref err);
            Console.WriteLine(err);
            #endregion

            #region CreatePedals
            ProductActions.AddProduct("Screaming Crow", 250, ProductTypes.Pedal, EffectTypes.Overdrive, "Tube Screamer Clone", ref err);
            Console.WriteLine(err);
            InventoryItemActions.AddInventoryItem(1, 3, ref err, 250);
            Console.WriteLine(err);
            ProductActions.AddProduct("The Bats Cave", 250, ProductTypes.Pedal, EffectTypes.Delay, "PT2399 Based Delay", ref err);
            Console.WriteLine(err);
            InventoryItemActions.AddInventoryItem(2, 2, ref err, 200);
            Console.WriteLine(err);
            ProductActions.AddProduct("The Parrot", 100, ProductTypes.Pedal, EffectTypes.Misc, "Marshall Amp simulator", ref err);
            Console.WriteLine(err);
            InventoryItemActions.AddInventoryItem(3, 1, ref err, 80);
            Console.WriteLine(err);
            ProductActions.AddProduct("The Girrafe", 150, ProductTypes.Pedal, EffectTypes.Boost, "Clean Boost (Jfet)", ref err);
            Console.WriteLine(err);
            InventoryItemActions.AddInventoryItem(4, 2, ref err, 150);
            Console.WriteLine(err);
            ProductActions.AddProduct("The Chameleon", 200, ProductTypes.Pedal, EffectTypes.Phaser, "Ross Phaser Clone", ref err);
            Console.WriteLine(err);
            InventoryItemActions.AddInventoryItem(5, 1, ref err, 180);
            Console.WriteLine(err);
            ProductActions.AddProduct("Cerberus", 150, ProductTypes.Pedal, EffectTypes.Distortion, "MXR Distortion+ Clone", ref err);
            Console.WriteLine(err);
            InventoryItemActions.AddInventoryItem(6, 1, ref err, 150);
            Console.WriteLine(err);
            ProductActions.AddProduct("Rattle Snake 2.0", 180, ProductTypes.Pedal, EffectTypes.Tremolo, "EHX Pulsar Tremolo Clone", ref err);
            Console.WriteLine(err);
            InventoryItemActions.AddInventoryItem(7, 2, ref err, 180);
            Console.WriteLine(err);
            ProductActions.AddProduct("The Catterpillar 2.0", 220, ProductTypes.Pedal, EffectTypes.Overdrive, "Fulltone OCD Clone", ref err);
            Console.WriteLine(err);
            InventoryItemActions.AddInventoryItem(8, 2, ref err, 220);
            Console.WriteLine(err); 
            ProductActions.AddProduct("Amelia", 250, ProductTypes.Pedal, EffectTypes.Chorus, "BOSS CE2 Clone", ref err);
            Console.WriteLine(err);
            InventoryItemActions.AddInventoryItem(9, 1, ref err, 250);
            Console.WriteLine(err);
            ProductActions.AddProduct("Centaur", 150, ProductTypes.Pedal, EffectTypes.Misc, "Splitter/Blender Unit", ref err);
            Console.WriteLine(err);
            InventoryItemActions.AddInventoryItem(10, 2, ref err, 120);
            Console.WriteLine(err);
            ProductActions.AddProduct("Growling Bear 2.0", 200, ProductTypes.Pedal, EffectTypes.Overdrive, "JHS Morning Glory Clone", ref err);
            Console.WriteLine(err);
            InventoryItemActions.AddInventoryItem(11, 1, ref err, 200);
            Console.WriteLine(err);
            #endregion

            #region AddBoards
            ProductActions.AddProduct("Screaming Crow Board", 80, ProductTypes.Board, EffectTypes.Overdrive, 6.5, 6.5, ref err);
            Console.WriteLine(err);
            InventoryItemActions.AddInventoryItem(12, 5, ref err, 80);
            Console.WriteLine(err);
            ProductActions.AddProduct("Chameleon Board", 80, ProductTypes.Board, EffectTypes.Phaser, 3.5, 4.5, ref err);
            Console.WriteLine(err);
            InventoryItemActions.AddInventoryItem(13, 5, ref err, 80);
            Console.WriteLine(err);
            ProductActions.AddProduct("3PDT Board", 60, ProductTypes.Board, EffectTypes.Misc, 2.8, 2.8, ref err);
            Console.WriteLine(err);
            InventoryItemActions.AddInventoryItem(14, 8, ref err, 50);
            Console.WriteLine(err);
            ProductActions.AddProduct("Amelia Board", 120, ProductTypes.Board, EffectTypes.Chorus, 7.5, 7.5, ref err);
            Console.WriteLine(err);
            InventoryItemActions.AddInventoryItem(15, 4, ref err, 120);
            Console.WriteLine(err);
            ProductActions.AddProduct("African Gray Board", 80, ProductTypes.Board, EffectTypes.Fuzz, 2.8, 3.2, ref err);
            Console.WriteLine(err);
            InventoryItemActions.AddInventoryItem(16, 8, ref err, 80);
            Console.WriteLine(err);
            ProductActions.AddProduct("Girrafe Board", 80, ProductTypes.Board, EffectTypes.Boost, 3.5, 4.5, ref err);
            Console.WriteLine(err);
            InventoryItemActions.AddInventoryItem(17, 10, ref err, 80);
            Console.WriteLine(err);
            ProductActions.AddProduct("Rattle Snake 2.0", 100, ProductTypes.Board, EffectTypes.Tremolo,4.2,4.5, ref err);
            Console.WriteLine(err);
            InventoryItemActions.AddInventoryItem(18, 6, ref err, 90);
            Console.WriteLine(err);
            ProductActions.AddProduct("Centaur Board", 80, ProductTypes.Board, EffectTypes.Misc, 4.2, 4.5, ref err);
            Console.WriteLine(err);
            InventoryItemActions.AddInventoryItem(19, 6, ref err, 80);
            Console.WriteLine(err);
            ProductActions.AddProduct("Soaring Eagle Board", 80, ProductTypes.Board, EffectTypes.Fuzz, 3, 3, ref err);
            Console.WriteLine(err);
            InventoryItemActions.AddInventoryItem(20, 9, ref err, 80);
            Console.WriteLine(err);

            #endregion

            #region AddComponents
            ProductActions.AddProduct("TL072", 40, ProductTypes.Component, ComponentTypes.IC, 2, ref err);
            Console.WriteLine(err);
            InventoryItemActions.AddInventoryItem(21, 10, ref err, 40);
            Console.WriteLine(err);
            ProductActions.AddProduct("LM13600", 50, ProductTypes.Component, ComponentTypes.IC, 3, ref err,EffectTypes.Phaser);
            Console.WriteLine(err);
            InventoryItemActions.AddInventoryItem(22, 4, ref err, 40);
            Console.WriteLine(err);
            ProductActions.AddProduct("100nF Ceramic", 10, ProductTypes.Component, ComponentTypes.Capacitor, 10, ref err);
            Console.WriteLine(err);
            InventoryItemActions.AddInventoryItem(23, 50, ref err, 10);
            Console.WriteLine(err);
            ProductActions.AddProduct("470k", 10, ProductTypes.Component, ComponentTypes.Resistor, 10, ref err);
            Console.WriteLine(err);
            InventoryItemActions.AddInventoryItem(24, 800, ref err, 10);
            Console.WriteLine(err);
            ProductActions.AddProduct("10uF Polar", 10, ProductTypes.Component, ComponentTypes.PolCapacitor, 5, ref err);
            Console.WriteLine(err);
            InventoryItemActions.AddInventoryItem(25, 15, ref err, 10);
            Console.WriteLine(err);
            ProductActions.AddProduct("3PDT FootSwitch", 30, ProductTypes.Component, ComponentTypes.Switch, 1, ref err);
            Console.WriteLine(err);
            InventoryItemActions.AddInventoryItem(26, 10, ref err, 30);
            Console.WriteLine(err);
            ProductActions.AddProduct("3PDT Toggle Switch", 20, ProductTypes.Component, ComponentTypes.Switch, 2, ref err);
            Console.WriteLine(err);
            InventoryItemActions.AddInventoryItem(27, 15, ref err, 20);
            Console.WriteLine(err);
            ProductActions.AddProduct("1N4001", 10, ProductTypes.Component, ComponentTypes.Diode, 5, ref err);
            Console.WriteLine(err);
            InventoryItemActions.AddInventoryItem(28, 40, ref err, 10);
            Console.WriteLine(err);
            #endregion
        }

        //private static void ClearData()
        //{
        //    using (var context = new OPDdbContext())
        //    {
        //        var users = context.Users.ToList();
        //        context.RemoveRange(users);
        //        context.SaveChanges();
        //        context.Database.ExecuteSqlRaw("DBCC CHECKIDENT('Users', RESEED, 0)"); //Reset AUTO_INCREMENT

        //        var products = context.Products.ToList();
        //        context.RemoveRange(products);
        //        context.SaveChanges();
        //        context.Database.ExecuteSqlRaw("DBCC CHECKIDENT('products', RESEED, 0)"); //Reset AUTO_INCREMENT
        //                                                                                  //
        //        var Pedals = context.Pedals.ToList();
        //        context.RemoveRange(Pedals);
        //        context.SaveChanges();
                

        //        var Boards = context.Boards.ToList();
        //        context.RemoveRange(Boards);
        //        context.SaveChanges();
                

        //        var Components = context.Components.ToList();
        //        context.RemoveRange(Components);
        //        context.SaveChanges();
                


        //        var Inventory = context.Inventory.ToList();
        //        context.RemoveRange(Inventory);
        //        context.SaveChanges();
        //        context.Database.ExecuteSqlRaw("DBCC CHECKIDENT('Inventory', RESEED, 0)"); //Reset AUTO_INCREMENT

        //        var Orders = context.Orders.ToList();
        //        context.RemoveRange(Orders);
        //        context.SaveChanges();
        //        context.Database.ExecuteSqlRaw("DBCC CHECKIDENT('Orders', RESEED, 0)"); //Reset AUTO_INCREMENT


        //    }
        //}
    }


}
