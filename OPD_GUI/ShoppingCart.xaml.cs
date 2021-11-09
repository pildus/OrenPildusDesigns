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
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }       

        private void PopulateCart()
        {
            ShoppingCartItem item;
            Order o;
            foreach (Order p in Constants.SessionUser.ShoppingCart)
            {
            }
        }
        private void Checkout_Click(object sender, RoutedEventArgs e)
        {
           // this.Close();
        }
    }
}
