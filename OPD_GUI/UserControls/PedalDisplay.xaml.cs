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
using OPD_GUI;
using DataControl.Model;
using DataControl.Utils;

namespace OPD_GUI.UserControls
{
    /// <summary>
    /// Interaction logic for PedalDisplay.xaml
    /// </summary>
    public partial class PedalDisplay : UserControl
    {
        //public PedalDisplay()
        //{
        //    InitializeComponent();
        //}
        public PedalDisplay(Product prd)
        {
            char c = '₪';
            InitializeComponent();
            Pedal PdlPrd = (Pedal)prd;
            PedalTitle.Content = PdlPrd.ProductName;
            Availability.Content = "Currently Available : " + InventoryItemActions.GetProductInventoryStatus(PdlPrd.ProductId).ToString();
            PedalImage.Source = new BitmapImage(new Uri("/images/Products/" + PdlPrd.ProductId + ".jpg", UriKind.Relative));
            PedalDescription.Text = PdlPrd.PedalDescription;
            PedalPrice.Text = PdlPrd.ProductPrice.ToString() + c.ToString();
            PedalProductID.Content = PdlPrd.ProductId;

        }

        private void AddToSC_Click(object sender, RoutedEventArgs e)
        {
            string s = "";
            int ProductID = int.Parse(PedalProductID.Content.ToString());
            Product p = ProductActions.GetProducts(ProductID);

            if (OrdersActions.AddOrder(Constants.SessionUser.UserID, p.ProductId, 1, p.ProductPrice, ref s, false))
            {
                MessageBox.Show("Successfully added to Shopping Cart");
                MainWindow win = (MainWindow)Window.GetWindow(this);
                win.RefreshShoppingCartCount();
            }
            
        }
    }
}
