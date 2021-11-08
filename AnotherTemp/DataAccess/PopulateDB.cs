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
        public static void PopulateAll()
        {
            string err = "";
            Constants.SessionUser.IsAdmin = true;
            PedalActions.AddPedal("Screaming Crow", 250, ProductTypes.Pedal, EffectTypes.Overdrive, "Trying to add product", ref err);
            Console.WriteLine(err);
            BoardActions.AddBoard("Screaming Crow Board", 80, ProductTypes.Board, EffectTypes.Overdrive, 5, 6, ref err);
            Console.WriteLine(err);
            BoardActions.AddBoard("Chameleon Board", 80, ProductTypes.Board, EffectTypes.Phaser, 3.5, 4.5, ref err);
            Console.WriteLine(err);
            ComponentActions.AddComponent("TL072", 50, ProductTypes.Component, ComponentTypes.IC, 10, ref err);
            Console.WriteLine(err);
            PedalActions.AddPedal("The Bats Cave", 250, ProductTypes.Pedal, EffectTypes.Delay, "A PT2399 Based Delay", ref err);
            Console.WriteLine(err);
            BoardActions.AddBoard("Amelia Board", 120, ProductTypes.Board, EffectTypes.Chorus, 7.5, 7.5, ref err);
            Console.WriteLine(err);
            BoardActions.AddBoard("Girrafe Board", 80, ProductTypes.Board, EffectTypes.Boost, 3.5, 4.5, ref err);
            Console.WriteLine(err);
            ComponentActions.AddComponent("LM13600", 50, ProductTypes.Component, ComponentTypes.IC, 10, ref err);
            Console.WriteLine(err);
            ComponentActions.AddComponent("PT2399", 40, ProductTypes.Component, ComponentTypes.IC, 2, ref err, EffectTypes.Delay);
            Console.WriteLine(err);
            BoardActions.AddBoard("3PDT Board", 40, ProductTypes.Board, EffectTypes.Misc, 2.8, 2.8, ref err);
            Console.WriteLine(err);
            PedalActions.AddPedal("The Parrot", 100, ProductTypes.Pedal, EffectTypes.Misc, "marshall Amp simulator", ref err);
            Console.WriteLine(err);

            string EmailAddress = "pildus@gmail.com";
            string Password = "Leviha2016!";
            string FirstName = "Oren";
            string LastName = "Pildus";
            string UserName = "Pildus";
            bool IsAdmin = true;
            UserActions.UserSignUp(UserName, FirstName, LastName, Password, EmailAddress, IsAdmin, ref err);
            Console.WriteLine(err);

            EmailAddress = "atara@gmail.com";
            Password = "Atara12Delange!";
            FirstName = "Atara";
            LastName = "De Lange";
            UserName = "Atara";
            IsAdmin = false;
            UserActions.UserSignUp(UserName, FirstName, LastName, Password, EmailAddress, IsAdmin, ref err);
            Console.WriteLine(err);
            
            EmailAddress = "victor@gmail.com";
            Password = "VictorY123!";
            FirstName = "Victor";
            LastName = "Yampolski";
            UserName = "victory";
            IsAdmin = true;
            UserActions.UserSignUp(UserName, FirstName, LastName, Password, EmailAddress, IsAdmin, ref err);
            Console.WriteLine(err);

            InventoryItemActions.AddInventoryItem(2, 10, ref err, 72);
            Console.WriteLine(err);
            InventoryItemActions.AddInventoryItem(2, 10, ref err, 72);
            Console.WriteLine(err);
            InventoryItemActions.AddInventoryItem(4, 2700, ref err);
            Console.WriteLine(err);
            InventoryItemActions.AddInventoryItem(3, 5, ref err, 25);
            Console.WriteLine(err);
            InventoryItemActions.AddInventoryItem(1, 2, ref err, 250);
            Console.WriteLine(err);


            OrdersActions.AddOrder(1, 3, 150, 1.5, ref err, true);
            Console.WriteLine(err);
            OrdersActions.AddOrder(1, 4, 1, 250, ref err, false);
            Console.WriteLine(err);
            OrdersActions.AddOrder(1, 1, 2, 450, ref err, false);
            Console.WriteLine(err); 
            OrdersActions.AddOrder(3, 3, 150, 1.5, ref err, true);
            Console.WriteLine(err);
            OrdersActions.AddOrder(3, 4, 1, 250, ref err, true);
            Console.WriteLine(err);
            OrdersActions.AddOrder(3, 1, 2, 450, ref err, true);
            Console.WriteLine(err);
        }
    }
}
