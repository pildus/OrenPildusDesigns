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


namespace OPD_GUI.UserControls
{
    /// <summary>
    /// Interaction logic for ShoppingCartItem.xaml
    /// </summary>
    public partial class ShoppingCartItem : UserControl
    {
        public ShoppingCartItem(ComplexOrder co)
        {
            char c = '₪';
            InitializeComponent();

            ProductImage.Source = new BitmapImage(new Uri("/images/Products/" + co.cProduct.ProductId + ".jpg", UriKind.Relative));
            ProductName.Text = co.cProduct.ProductName;
            ProductPrice.Text = co.cProduct.ProductPrice + c.ToString();
            OrderQuantity.Text = co.cOrder.OrderQuantity.ToString();
            OrderTotalAmount.Text = (co.cProduct.ProductPrice * co.cOrder.OrderQuantity).ToString() + c.ToString();
        }
    }
}
