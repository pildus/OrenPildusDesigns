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
    /// Interaction logic for AdminZone.xaml
    /// </summary>
    public partial class AdminZone : UserControl
    {
        public AdminZone()
        {
            InitializeComponent();

            TabItem ProductsTab = new TabItem()
            {
                Header = "Products",
                Width = 200,
                Margin = new Thickness(10, 0, 10, 0),
                Content = new AdminProductControl()
            };
            TabItem OrdersTab = new TabItem()
            {
                Header = "Orders",
                Width = 200,
                Margin = new Thickness(10, 0, 10, 0)
            };
            TabItem InventoryTab = new TabItem()
            {
                Header = "Inventory",
                Width = 200,
                Margin = new Thickness(10, 0, 10, 0)
            };
            TabItem UsersTab = new TabItem()
            {
                Header = "Users",
                Width = 200,
                Margin = new Thickness(10, 0, 10, 0)
            };

            AdminTabControl.Items.Add(ProductsTab);
            AdminTabControl.Items.Add(OrdersTab);
            AdminTabControl.Items.Add(InventoryTab);
            AdminTabControl.Items.Add(UsersTab);
        }


    }
}
