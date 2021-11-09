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
    /// Interaction logic for ComponentDisplay.xaml
    /// </summary>
    public partial class ComponentDisplay : UserControl
    {
        //public ComponentDisplay()
        //{
        //    InitializeComponent();
        //}
        public ComponentDisplay(Product prd)
        {
            char c = '₪';
            InitializeComponent();
            Component PdlPrd = (Component)prd;
            ComponentTitle.Content = PdlPrd.ProductName;
            Availability.Content = "Currently Available : " + InventoryItemActions.GetProductInventoryStatus(PdlPrd.ProductId).ToString();
            ComponentImage.Source = new BitmapImage(new Uri("/images/Products/" + PdlPrd.ProductId + ".jpg", UriKind.Relative));
            ComponentDescription.Text = "Quantity per Lot : " + PdlPrd.QuantityPerLot + "/Lot";
            ComponentPrice.Text = PdlPrd.ProductPrice.ToString() + c.ToString();
        }

    }
}
