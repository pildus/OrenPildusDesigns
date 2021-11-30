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
using System.Text.RegularExpressions;
using System.Data;
using System.Net;

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
            EffectTypeCmb.ItemsSource = Enum.GetValues(typeof(EffectTypes)); EffectTypeCmb.SelectedIndex = 7;
            ComponentTypeCmb.ItemsSource = Enum.GetValues(typeof(ComponentTypes)); ComponentTypeCmb.SelectedIndex = 0;
            EditEffectTypeCmb.ItemsSource = Enum.GetValues(typeof(EffectTypes));
            EditComponentTypeCmb.ItemsSource = Enum.GetValues(typeof(ComponentTypes));

        }

        private void dataGrid_MouseDownClick(object sender, RoutedEventArgs e)
        {
            DataGrid dg = sender as DataGrid;

            switch (dg.SelectedItem.GetType().Name)
            {
                case "Pedal":
                    Pedal p = (Pedal)dg.SelectedItem;

                    EditProductStck.Tag = p.ProductId.ToString();

                    EditProductName.Text = p.ProductName;
                    EditProducPrice.Text = p.ProductPrice.ToString();
                    EditPedalDescription.IsEnabled = true; EditPedalDescription.Text = p.PedalDescription;
                    EditEffectTypeCmb.IsEnabled = true; EditEffectTypeCmb.SelectedItem = p.EffectType;

                    EditDimensionBlck.IsEnabled = false; EditBoardWidth.Text = ""; EditBoardHeight.Text = "";
                    EditQuantity.IsEnabled = false; EditQuantity.Text = "";
                    ComponentTypeCmb.IsEnabled = false;
                    break;
                case "Board":
                    Board b = (Board)dg.SelectedItem;

                    EditProductStck.Tag = b.ProductId.ToString();

                    EditProductName.Text = b.ProductName;
                    EditProducPrice.Text = b.ProductPrice.ToString();
                    EditDimensionBlck.IsEnabled = true;
                    EditBoardWidth.Text = b.BoardWidth.ToString();
                    EditBoardHeight.Text = b.BoardHeight.ToString();
                    EditEffectTypeCmb.IsEnabled = true; EditEffectTypeCmb.SelectedItem = b.EffectType;

                    EditPedalDescription.IsEnabled = false; EditPedalDescription.Text = "";
                    EditQuantity.IsEnabled = false; EditQuantity.Text = "";
                    ComponentTypeCmb.IsEnabled = false;
                    break;
                case "Component":
                    Component c = (Component)dg.SelectedItem;

                    EditProductStck.Tag = c.ProductId.ToString();

                    EditProductName.Text = c.ProductName;
                    EditProducPrice.Text = c.ProductPrice.ToString();
                    EditQuantity.IsEnabled = true; EditQuantity.Text = c.QuantityPerLot.ToString();
                    EditComponentTypeCmb.IsEnabled = true; EditComponentTypeCmb.SelectedItem = c.ComponentType;
                    EditEffectTypeCmb.IsEnabled = true; EditEffectTypeCmb.SelectedItem = c.EffectType;

                    EditDimensionBlck.IsEnabled = false; EditBoardWidth.Text = ""; EditBoardHeight.Text = "";
                    EditPedalDescription.IsEnabled = false; EditPedalDescription.Text = "";
                    break;

            }

            //var p = dg.SelectedItem.GetType();
            //EditProductNameTxt.Text = p.Name;

        }
        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton button = sender as RadioButton;

            if (button.Content.ToString() == "All Products")
            {
                ProductsDG.ItemsSource = ProductActions.GetProducts();
                ProductsDG.SelectedIndex = 0;
            }
            else
            {
                ProductTypes pt = (ProductTypes)Enum.Parse(typeof(ProductTypes), button.Content.ToString());
                ProductsDG.ItemsSource = ProductActions.GetProducts(pt);
                ProductsDG.SelectedIndex = 0;
            }

            var p = ProductsDG.SelectedItem.GetType();
        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex(@"[^0-9.]+");
            e.Handled = regex.IsMatch(e.Text);
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
                ProductImg.Width = 100;
                ProductImg.Height = 150;
                ProductImg.ClipToBounds = true;
            }

        }
        private void EditProductBtn_Click(object sender, RoutedEventArgs e)
        {
            string err = "";

            if (EditProductName.Text != "" && EditProducPrice.Text != "")
            {
                int pId = int.Parse(EditProductStck.Tag.ToString());
                string pName = EditProductName.Text;
                float pPrice = float.Parse(EditProducPrice.Text);

                if (EditPedalDescription.IsEnabled == true)
                    ProductActions.EditProduct( pId,pName,pPrice,(EffectTypes)EditEffectTypeCmb.SelectedItem,EditPedalDescription.Text,ref err );
                if (EditDimensionBlck.IsEnabled == true)
                    ProductActions.EditProduct(pId, pName, pPrice, (EffectTypes)EditEffectTypeCmb.SelectedItem, float.Parse(EditBoardWidth.Text),float.Parse(EditBoardHeight.Text), ref err);
                if (EditQuantity.IsEnabled == true)
                    ProductActions.EditProduct(pId, pName, pPrice, (ComponentTypes)EditComponentTypeCmb.SelectedItem , int.Parse(EditQuantity.Text), ref err, (EffectTypes)EditEffectTypeCmb.SelectedItem);



                ProductsDG.Items.Refresh();

                MessageBoxWnd wnd = new MessageBoxWnd("Product was updated successfully");
                wnd.ShowDialog();

            }
            else
            {
                MessageBoxWnd wnd = new MessageBoxWnd("Invalid Data! \n Please check data and try again");
                wnd.ShowDialog();

            }
        }
        private void AddProductBtn_Click(object sender, RoutedEventArgs e)
        {
            if (AddProductName.Text != "" & AddProducPrice.Text != "" && int.Parse(AddProducPrice.Text) > 0)
            {
                int pId = 0;
                string err = "";

                if (PedalPTRadio.IsChecked == true)
                {
                    pId = ProductActions.AddProduct(AddProductName.Text, double.Parse(AddProducPrice.Text), ProductTypes.Pedal,
    (EffectTypes)Enum.Parse(typeof(EffectTypes), EffectTypeCmb.SelectedItem.ToString()), AddPedalDescription.Text, ref err);
                }
                else if (BoardPTRadio.IsChecked == true)
                {
                    pId = ProductActions.AddProduct(AddProductName.Text, double.Parse(AddProducPrice.Text), ProductTypes.Board, (EffectTypes)Enum.Parse(typeof(EffectTypes), EffectTypeCmb.SelectedItem.ToString()),
                      float.Parse(AddBoardWidth.Text), float.Parse(AddBoardHeight.Text), ref err);
                }
                else
                {
                    pId = ProductActions.AddProduct(AddProductName.Text, double.Parse(AddProducPrice.Text), ProductTypes.Component,
                        (ComponentTypes)Enum.Parse(typeof(ComponentTypes), ComponentTypeCmb.SelectedItem.ToString()), int.Parse(AddQuantity.Text), ref err,
                        (EffectTypes)Enum.Parse(typeof(EffectTypes), EffectTypeCmb.SelectedItem.ToString()));
                }

                InventoryItemActions.AddInventoryItem(pId, int.Parse(AddInventoryTxt.Text), ref err, double.Parse(AddProducPrice.Text));

                WebClient client = new WebClient();
                client.Credentials = new NetworkCredential("pildus", "Leviha2016!");
                client.UploadFile(
                    "ftp://win5239.site4now.net" + $"/{pId}.jpg", ProductImg.Tag.ToString());

                MessageBoxWnd wnd = new MessageBoxWnd("A new product was successfully added !");
                wnd.ShowDialog();

                foreach (var ctl in AddProductGrid.Children)
                {
                    if (ctl.GetType() == typeof(RadioButton))
                        ((RadioButton)ctl).IsChecked = false;
                    else if (ctl.GetType() == typeof(TextBox))
                        ((TextBox)ctl).Text = String.Empty;

                }
            }
            else
            {
                MessageBoxWnd wnd = new MessageBoxWnd("Invalid Data! \n Please check data and try again");
                wnd.ShowDialog();
            }

        }

    }
}
