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
using System.Windows.Media.Animation;

namespace OPD_GUI.UserControls
{
    /// <summary>
    /// Interaction logic for HomePageContent.xaml
    /// </summary>
    public partial class HomePageContent : UserControl
    {


        public HomePageContent(int count = 3)
        {
            InitializeComponent();


            Random random = new Random();
            List<Product> lst = ProductActions.GetProducts(random, 4);
             
            int col = 0; int row = 0;

            foreach (Product p in lst)
            {
                ProductDisplay Pdis = new ProductDisplay(p,false);
                Pdis.Name = $"PDisplay{col}";
                this.RegisterName(Pdis.Name, Pdis);

                Grid.SetRow(Pdis, row);
                Grid.SetColumn(Pdis, col);
                HomepageProductDisplay.Children.Add(Pdis);

                if (col < count)
                {
                    col++;
                }
            }
        }


    }
}
