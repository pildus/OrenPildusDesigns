using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using DataControl.Utils;
using DataControl.Model;
using DataControl.DataAccess;
using OPD_GUI.UserControls;

namespace OPD_GUI
{
    /// <summary>
    /// Interaction logic for ShoppingCart.xaml
    /// </summary>
    public partial class ShoppingCart : Window
    {
        
        public ShoppingCart()
        {
            InitializeComponent();
            PopulateCart();
        }

        private void ContinueShopping_Click(object sender, RoutedEventArgs e)
        {
            var myObject = this.Owner as MainWindow;
            myObject.ProductStackPanel.Items.Refresh();

            this.Close();
        }       

        public void PopulateCart()
        {
            ShoppingCartItem item;
           // Label lbl = new Label() { HorizontalAlignment = HorizontalAlignment.Center, Content = "Shopping Cart", Height = 70 };
            //MainDisplay.Children.Add(lbl);

            foreach (Order o in Constants.SessionUser.ShoppingCart)
            {
                item = new ShoppingCartItem(o);
                MainDisplay.Children.Add(item);
            }
        }
        private void Checkout_Click(object sender, RoutedEventArgs e)
        {
            var myObject = this.Owner as MainWindow;
            List<Order> tmpLst = new List<Order>();
            int orderID;
            

            foreach (ShoppingCartItem sci in MainDisplay.Children )
            {
                if (sci.chkConfirm.IsChecked == true)
                {
                    orderID = int.Parse(sci.ProductImage.Tag.ToString());
                    Order ord = Constants.SessionUser.ShoppingCart.Find(o => o.OrderID == orderID);
                    tmpLst.Add(ord);
                    Constants.SessionUser.ShoppingCart.Remove(ord);
                }
                    
            }

            if (tmpLst.Count() > 0)
            {
                OrdersActions.ProcessShoppingCart(tmpLst);
                MessageBoxWnd wnd = new MessageBoxWnd("Congrats !!! Your order in on the way !");
                wnd.ShowDialog();


                MainDisplay.Children.Clear();
                PopulateCart();

                //Code on the modal window
                
                myObject.RefreshShoppingCartCount(); // Call your method here
            }
            else
            {
                MessageBoxWnd wnd = new MessageBoxWnd("Congrats !!! Your order in on the way !");
                wnd.ShowDialog();
            }

            myObject.ProductStackPanel.Items.Refresh();
        }

    }
}
