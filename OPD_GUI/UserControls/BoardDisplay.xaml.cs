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
    /// Interaction logic for BoardDisplay.xaml
    /// </summary>
    public partial class BoardDisplay : UserControl
    {
        //public BoardDisplay()
        //{
        //    InitializeComponent();
        //}
        public BoardDisplay(Product prd)
        {
            char c = '₪';
            InitializeComponent();
            Board PdlPrd = (Board)prd;
            BoardTitle.Content = PdlPrd.ProductName;
            Availability.Content = "Currently Available : " + InventoryItemActions.GetProductInventoryStatus(PdlPrd.ProductId).ToString();
            BoardImage.Source = new BitmapImage(new Uri("/images/Products/" + PdlPrd.ProductId + ".jpg", UriKind.Relative));
            BoardDescription.Text =  "Dimension : " + PdlPrd.BoardWidth + " X " + PdlPrd.BoardHeight;
            BoardPrice.Text = PdlPrd.ProductPrice.ToString() + c.ToString();
        }

    }
}
