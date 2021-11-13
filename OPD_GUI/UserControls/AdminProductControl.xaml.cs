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
using DataControl.Model;
using DataControl.Utils;

namespace OPD_GUI.UserControls
{
    /// <summary>
    /// Interaction logic for AdminProductControl.xaml
    /// </summary>
    public partial class AdminProductControl : UserControl
    {
        public AdminProductControl()
        {
            InitializeComponent();
            AllProductsBtn.IsChecked = true;

        }
        private List<Product> RetrieveProducts()
        {
            List<Product> lst = ProductActions.GetProducts();
            return lst;
        }   

        private List<Product> RetrieveProducts(ProductTypes pt)
        {
            List<Product> lst = ProductActions.GetProducts();
            return lst;
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton button = sender as RadioButton;

            if (button.Content.ToString() == "All Products")
                ProductsDG.ItemsSource = ProductActions.GetProducts();
            else
            {
                ProductTypes pt = (ProductTypes)Enum.Parse(typeof(ProductTypes), button.Content.ToString());
                ProductsDG.ItemsSource = ProductActions.GetProducts(pt);
            }
        }
    }
}
