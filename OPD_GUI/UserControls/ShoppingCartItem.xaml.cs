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
using System.Windows.Navigation;
using System.Windows.Shapes;
using DataControl.Utils;
using DataControl.Model;
using DataControl.DataAccess;


namespace OPD_GUI.UserControls
{
    /// <summary>
    /// Interaction logic for ShoppingCartItem.xaml
    /// </summary>
    public partial class ShoppingCartItem : UserControl
    {
        public ShoppingCartItem(Order o)
        {
            char c = '₪';
            InitializeComponent();
            Product p = ProductActions.GetProducts(o);

            ProductImage.Tag = o.OrderID.ToString();
            //ProductImage.Source = new BitmapImage(new Uri("/images/Products/" + p.ProductId + ".jpg", UriKind.Relative));
            ProductImage.Source = new BitmapImage(new Uri("http://pildus-001-site1.gtempurl.com/images/Products/" + p.ProductId + ".jpg", UriKind.Absolute));
            ProductName.Text = p.ProductName;
            ProductPrice.Text = p.ProductPrice.ToString() + c.ToString();
            OrderQuantity.Text = o.OrderQuantity.ToString();
            OrderTotalAmount.Text = (p.ProductPrice * o.OrderQuantity).ToString() + c.ToString();
        }

        private void Click2DeleteOrder(object sender, MouseButtonEventArgs e)
        {
            MessageBoxResult del = MessageBox.Show("Are you sure you want to delete this order?","DElete Order",MessageBoxButton.OKCancel);

            if (del == MessageBoxResult.OK)
            {
                string err = "";

                var oID = int.Parse(ProductImage.Tag.ToString());
                OrdersActions.DeleteOrder(oID,false, ref err );

                MessageBoxWnd wnd = new MessageBoxWnd("Order deleted successfully !");
                wnd.ShowDialog();

                Constants.SessionUser.ShoppingCart = new List<Order>();
                OrdersActions.PopulateShoppingCart(Constants.SessionUser, ref err);

                ShoppingCart win = (ShoppingCart)Window.GetWindow(this);
                win.MainDisplay.Children.Clear();
                win.PopulateCart();

                
            }

        }
    }
}
