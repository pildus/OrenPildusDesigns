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
    /// Interaction logic for HomePageContent.xaml
    /// </summary>
    public partial class HomePageContent : UserControl
    {
        public HomePageContent()
        {
            InitializeComponent();

            Random random = new Random();
            List<Product> lst = ProductActions.GetProducts(random, 3);

            int col = 0; int row = 0; int count = 3;

            foreach (Product p in lst)
            {
                ProductDisplay pd = new ProductDisplay(p);
                Grid.SetRow(pd, row);
                Grid.SetColumn(pd, col);
                HomepageProductDisplay.Children.Add(pd);

                if (col < count)
                {
                    col++;
                }
            }
        }
    }
}
