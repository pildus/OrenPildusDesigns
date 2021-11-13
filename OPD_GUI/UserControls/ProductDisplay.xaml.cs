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
using System.Windows.Media.Animation;

namespace OPD_GUI.UserControls
{
    /// <summary>
    /// Interaction logic for ProductDisplay.xaml
    /// </summary>
    public partial class ProductDisplay : UserControl
    {
        private Storyboard myStoryboard;
        private ProductDisplay Pdis;

        public ProductDisplay(Product prd, bool animated = false)
        {
            InitializeComponent();
            Pdis = this;
            Pdis.Name = $"ProductDisplay{prd.ProductId}";
            Pdis.RegisterName(Pdis.Name, Pdis);

            char c = '₪';



            Product PdlPrd = (Product)prd;
            ProductTitle.Content = PdlPrd.ProductName;
            Availability.Content = "Currently Available : " + InventoryItemActions.GetProductInventoryStatus(PdlPrd.ProductId).ToString();
            ProductImage.Source = new BitmapImage(new Uri("/images/Products/" + PdlPrd.ProductId + ".jpg", UriKind.Relative));
            ProductPrice.Text = PdlPrd.ProductPrice.ToString() + c.ToString();
            ProductProductID.Content = PdlPrd.ProductId;

            switch (prd.ProductType)
            {
                case ProductTypes.Pedal:
                    Pedal tmpP = (Pedal)PdlPrd;
                    ProductDescription.Text = tmpP.PedalDescription;
                    break;
                case ProductTypes.Board:
                    Board tmpB = (Board)PdlPrd;
                    ProductDescription.Text = $"Dimensions: {tmpB.BoardWidth}cm X {tmpB.BoardHeight}cm";
                    break;
                case ProductTypes.Component:
                    Component tmpC = (Component)PdlPrd;
                    ProductDescription.Text = $"Items/Lot : {tmpC.QuantityPerLot}";
                    break;
                default:
                    break;
            }

            if (animated)
            {
                DoubleAnimation myDoubleAnimation = new DoubleAnimation();
                myDoubleAnimation.From = 1.0;
                myDoubleAnimation.To = 0.0;
                myDoubleAnimation.Duration = new Duration(TimeSpan.FromSeconds(5));
                myDoubleAnimation.AutoReverse = true;
                myDoubleAnimation.RepeatBehavior = RepeatBehavior.Forever;


                myStoryboard = new Storyboard();
                myStoryboard.Children.Add(myDoubleAnimation);
                Storyboard.SetTargetName(myDoubleAnimation, Pdis.Name);
                Storyboard.SetTargetProperty(myDoubleAnimation, new PropertyPath(Rectangle.OpacityProperty));

                Pdis.Loaded += new RoutedEventHandler(Pdis_Loaded);
            }

        }
        private void Pdis_Loaded(object sender, RoutedEventArgs e)
        {
            myStoryboard.Begin(this);
        }
        private void AddToSC_Click(object sender, RoutedEventArgs e)
        {
            string s = "";
            int ProductID = int.Parse(ProductProductID.Content.ToString());
            Product p = ProductActions.GetProducts(ProductID);

            if (OrdersActions.AddOrder(Constants.SessionUser.UserID, p.ProductId, 1, p.ProductPrice, ref s, false))
            {
                MessageBoxWnd msgWnd = new MessageBoxWnd("Congratulations\nThis item was added to your shopping cart");
                msgWnd.ShowDialog();

                MainWindow win = (MainWindow)Window.GetWindow(this);

                win.RefreshShoppingCartCount();
                win.ProductStackPanel.Items.Refresh();
            }

        }
    }
}
