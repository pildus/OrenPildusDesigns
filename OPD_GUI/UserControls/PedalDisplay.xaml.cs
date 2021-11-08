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
            InitializeComponent();
            Pedal PdlPrd = (Pedal)prd;
            PedalTitle.Content = PdlPrd.ProductName;
            PedalImage.Source = new BitmapImage(new Uri("/images/Products/" + PdlPrd.ProductId + ".jpg", UriKind.Relative));
            PedalDescription.Text = PdlPrd.PedalDescription;
        }

    }
}
