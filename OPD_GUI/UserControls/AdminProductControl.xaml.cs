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
using Microsoft.Win32;
using DataControl.Model;
using DataControl.Utils;
using System.IO;

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

        private void saveChangesBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Pedal p = (Pedal)ProductsDG.SelectedItem;
                Product getP = ProductActions.GetProducts(p.ProductId);
                //List<Product> lst = (List<Product>)ProductsDG.ItemsSource;

            }
            catch 
            {
                MessageBox.Show("No product was selected");
            }
        }

        private void ProductImg_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                ProductImg.Source = new BitmapImage(new Uri(op.FileName));
                ProductImg.Tag = op.FileName;
                ProductImg.Width = 200;
                ProductImg.Height = 250;
            }

        }
        private void AddProductBtn_Click(object sender, RoutedEventArgs e)
        {
            Grid r = new Grid();
            r.Background = new ImageBrush(ProductImg.Source);


            System.Windows.Size sz = new System.Windows.Size(ProductImg.Source.Width, ProductImg.Source.Height);
            r.Measure(sz);
            r.Arrange(new Rect(sz));

            RenderTargetBitmap rtb = new RenderTargetBitmap((int)ProductImg.Source.Width, (int)ProductImg.Source.Height, 96d, 96d, PixelFormats.Default);
            rtb.Render(r);

            BmpBitmapEncoder encoder = new BmpBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(rtb));

            FileStream fs = File.Create(@"C:\lol.png");
            encoder.Save(fs);
            fs.Close();
        }

    }
}
