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

            #region CreateUsers
            string EmailAddress = "pildus@gmail.com";
            string Password = "Leviha2016!";
            string FirstName = "Oren";
            string LastName = "Pildus";
            string UserName = "Pildus";
            bool IsAdmin = true;
            UserActions.UserSignUp(UserName, FirstName, LastName, Password, EmailAddress, IsAdmin, ref err);
            Console.WriteLine(err);

            EmailAddress = "pildus@hotmail.com";
            Password = "Leviha2016!";
            FirstName = "Oren";
            LastName = "Pildus";
            UserName = "Pildus2";
            IsAdmin = false;
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
            #endregion

            #region CreatePedals
            PedalActions.AddPedal("Screaming Crow", 250, ProductTypes.Pedal, EffectTypes.Overdrive, "Tube Screamer Clone", ref err);
            Console.WriteLine(err);
            InventoryItemActions.AddInventoryItem(1, 3, ref err, 250);
            Console.WriteLine(err);
            PedalActions.AddPedal("The Bats Cave", 250, ProductTypes.Pedal, EffectTypes.Delay, "PT2399 Based Delay", ref err);
            Console.WriteLine(err);
            InventoryItemActions.AddInventoryItem(2, 2, ref err, 200);
            Console.WriteLine(err);
            PedalActions.AddPedal("The Parrot", 100, ProductTypes.Pedal, EffectTypes.Misc, "Marshall Amp simulator", ref err);
            Console.WriteLine(err);
            InventoryItemActions.AddInventoryItem(3, 1, ref err, 80);
            Console.WriteLine(err);
            PedalActions.AddPedal("The Girrafe", 150, ProductTypes.Pedal, EffectTypes.Boost, "Clean Boost (Jfet)", ref err);
            Console.WriteLine(err);
            InventoryItemActions.AddInventoryItem(4, 2, ref err, 150);
            Console.WriteLine(err);
            PedalActions.AddPedal("The Chameleon", 200, ProductTypes.Pedal, EffectTypes.Phaser, "Ross Phaser Clone", ref err);
            Console.WriteLine(err);
            InventoryItemActions.AddInventoryItem(5, 1, ref err, 180);
            Console.WriteLine(err);
            PedalActions.AddPedal("Cerberus", 150, ProductTypes.Pedal, EffectTypes.Distortion, "MXR Distortion+ Clone", ref err);
            Console.WriteLine(err);
            InventoryItemActions.AddInventoryItem(6, 1, ref err, 150);
            Console.WriteLine(err);
            PedalActions.AddPedal("Rattle Snake 2.0", 180, ProductTypes.Pedal, EffectTypes.Tremolo, "EHX Pulsar Tremolo Clone", ref err);
            Console.WriteLine(err);
            InventoryItemActions.AddInventoryItem(7, 2, ref err, 180);
            Console.WriteLine(err);
            PedalActions.AddPedal("The Catterpillar 2.0", 220, ProductTypes.Pedal, EffectTypes.Overdrive, "Fulltone OCD Clone", ref err);
            Console.WriteLine(err);
            InventoryItemActions.AddInventoryItem(8, 2, ref err, 220);
            Console.WriteLine(err); 
            PedalActions.AddPedal("Amelia", 250, ProductTypes.Pedal, EffectTypes.Chorus, "BOSS CE2 Clone", ref err);
            Console.WriteLine(err);
            InventoryItemActions.AddInventoryItem(9, 1, ref err, 250);
            Console.WriteLine(err);
            PedalActions.AddPedal("Centaur", 150, ProductTypes.Pedal, EffectTypes.Misc, "Splitter/Blender Unit", ref err);
            Console.WriteLine(err);
            InventoryItemActions.AddInventoryItem(10, 2, ref err, 120);
            Console.WriteLine(err);
            PedalActions.AddPedal("Growling Bear 2.0", 200, ProductTypes.Pedal, EffectTypes.Overdrive, "JHS Morning Glory Clone", ref err);
            Console.WriteLine(err);
            InventoryItemActions.AddInventoryItem(11, 1, ref err, 200);
            Console.WriteLine(err);
            #endregion

            #region AddBoards
            BoardActions.AddBoard("Screaming Crow Board", 80, ProductTypes.Board, EffectTypes.Overdrive, 6.5, 6.5, ref err);
            Console.WriteLine(err);
            InventoryItemActions.AddInventoryItem(12, 5, ref err, 80);
            Console.WriteLine(err);
            BoardActions.AddBoard("Chameleon Board", 80, ProductTypes.Board, EffectTypes.Phaser, 3.5, 4.5, ref err);
            Console.WriteLine(err);
            InventoryItemActions.AddInventoryItem(13, 5, ref err, 80);
            Console.WriteLine(err);
            BoardActions.AddBoard("3PDT Board", 60, ProductTypes.Board, EffectTypes.Misc, 2.8, 2.8, ref err);
            Console.WriteLine(err);
            InventoryItemActions.AddInventoryItem(14, 8, ref err, 50);
            Console.WriteLine(err);
            BoardActions.AddBoard("Amelia Board", 120, ProductTypes.Board, EffectTypes.Chorus, 7.5, 7.5, ref err);
            Console.WriteLine(err);
            InventoryItemActions.AddInventoryItem(15, 4, ref err, 120);
            Console.WriteLine(err);
            BoardActions.AddBoard("African Gray Board", 80, ProductTypes.Board, EffectTypes.Fuzz, 2.8, 3.2, ref err);
            Console.WriteLine(err);
            InventoryItemActions.AddInventoryItem(16, 8, ref err, 80);
            Console.WriteLine(err);
            BoardActions.AddBoard("Girrafe Board", 80, ProductTypes.Board, EffectTypes.Boost, 3.5, 4.5, ref err);
            Console.WriteLine(err);
            InventoryItemActions.AddInventoryItem(17, 10, ref err, 80);
            Console.WriteLine(err);
            BoardActions.AddBoard("Rattle Snake 2.0", 100, ProductTypes.Board, EffectTypes.Tremolo,4.2,4.5, ref err);
            Console.WriteLine(err);
            InventoryItemActions.AddInventoryItem(18, 6, ref err, 90);
            Console.WriteLine(err);
            BoardActions.AddBoard("Centaur Board", 80, ProductTypes.Board, EffectTypes.Misc, 4.2, 4.5, ref err);
            Console.WriteLine(err);
            InventoryItemActions.AddInventoryItem(19, 6, ref err, 80);
            Console.WriteLine(err);
            BoardActions.AddBoard("Soaring Eagle Board", 80, ProductTypes.Board, EffectTypes.Fuzz, 3, 3, ref err);
            Console.WriteLine(err);
            InventoryItemActions.AddInventoryItem(20, 9, ref err, 80);
            Console.WriteLine(err);

            #endregion

            #region AddComponents
            ComponentActions.AddComponent("TL072", 40, ProductTypes.Component, ComponentTypes.IC, 2, ref err);
            Console.WriteLine(err);
            InventoryItemActions.AddInventoryItem(21, 10, ref err, 40);
            Console.WriteLine(err);
            ComponentActions.AddComponent("LM13600", 50, ProductTypes.Component, ComponentTypes.IC, 3, ref err);
            Console.WriteLine(err);
            InventoryItemActions.AddInventoryItem(22, 4, ref err, 40);
            Console.WriteLine(err);
            ComponentActions.AddComponent("100nF Ceramic", 10, ProductTypes.Component, ComponentTypes.Capacitor, 10, ref err);
            Console.WriteLine(err);
            InventoryItemActions.AddInventoryItem(23, 50, ref err, 10);
            Console.WriteLine(err);
            ComponentActions.AddComponent("470k", 10, ProductTypes.Component, ComponentTypes.Resistor, 10, ref err);
            Console.WriteLine(err);
            InventoryItemActions.AddInventoryItem(24, 800, ref err, 10);
            Console.WriteLine(err);
            ComponentActions.AddComponent("10uF Polar", 10, ProductTypes.Component, ComponentTypes.PolCapacitor, 5, ref err);
            Console.WriteLine(err);
            InventoryItemActions.AddInventoryItem(25, 15, ref err, 10);
            Console.WriteLine(err);
            ComponentActions.AddComponent("3PDT FootSwitch", 30, ProductTypes.Component, ComponentTypes.Switch, 1, ref err);
            Console.WriteLine(err);
            InventoryItemActions.AddInventoryItem(26, 10, ref err, 30);
            Console.WriteLine(err);
            ComponentActions.AddComponent("3PDT Toggle Switch", 20, ProductTypes.Component, ComponentTypes.Switch, 2, ref err);
            Console.WriteLine(err);
            InventoryItemActions.AddInventoryItem(27, 15, ref err, 20);
            Console.WriteLine(err);
            ComponentActions.AddComponent("1N4001", 10, ProductTypes.Component, ComponentTypes.Diode, 5, ref err);
            Console.WriteLine(err);
            InventoryItemActions.AddInventoryItem(28, 40, ref err, 10);
            Console.WriteLine(err);
            #endregion

            #region AddOrders
            OrdersActions.AddOrder(2, 1, 1, 250, ref err, false);
            Console.WriteLine(err);
            OrdersActions.AddOrder(2, 4, 1, 250, ref err, false);
            Console.WriteLine(err);
            OrdersActions.AddOrder(2, 14, 2, 50, ref err, false);
            Console.WriteLine(err);
            OrdersActions.AddOrder(2, 26, 2, 30, ref err, false);
            Console.WriteLine(err);
            #endregion
        }
    }
}
