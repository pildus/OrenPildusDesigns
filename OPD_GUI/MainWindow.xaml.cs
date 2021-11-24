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
using DataControl.DataAccess;
using DataControl.Model;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using OPD_GUI.UserControls;

namespace OPD_GUI
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Application.Current.MainWindow = this;

            //Setting welcome user name and shopping cart items.
            lblHello.Content = "Hello " + Constants.SessionUser.FirstName;

            //Creating Shopping Cart
            RefreshShoppingCartCount();

            //Creating Main Navigation functionality and screens
            CreateMainNavigation();
        }

        public int RefreshShoppingCartCount()
        {
            int count = Constants.SessionUser.ShoppingCart.Count();
            ShoppingCartCount.Text = "(" + count + ")";
            return count;
        }

        // Generate products display in the Tab Content Page
        private void CreateMainNavigation()
        {
            #region CreatingMainTabsNavigation
            // Creating Homw Tab
            TabItem prdTab = new TabItem();

            prdTab.Name = "Home";
            //prdTab.Header = "Home";
            prdTab.Header = new Image() { Source = new BitmapImage(new Uri("/images/home.png", UriKind.Relative)) , Width=70 , Height = 70 };
            prdTab.Content = new HomePageContent(4);
            ProductStackPanel.Items.Add(prdTab);


            //Setting Products tabs and page content
            ScrollViewer scrl;

            //Going through te Product Types Enum to generate tabs automatically.
            foreach (ProductTypes item in Enum.GetValues(typeof(ProductTypes)))
            {
                scrl = new ScrollViewer()
                {
                    Width = 1180,
                    Height = 730,
                    VerticalScrollBarVisibility = ScrollBarVisibility.Auto,
                    VerticalAlignment = VerticalAlignment.Top
                };

                scrl.Content = DisplayProducts(ProductActions.GetProducts(item));
                
                StackPanel stc = new StackPanel() { HorizontalAlignment = HorizontalAlignment.Center };
                Image img = new Image() { Source = new BitmapImage(new Uri($"/images/{item.ToString().ToLower()}.png", UriKind.Relative)), Width = 70, Height = 70 };
                stc.Children.Add(img);
                stc.Children.Add(new Label { Content = item.ToString() + "s" , FontSize=14,HorizontalAlignment = HorizontalAlignment.Center});


                prdTab = new TabItem();
                prdTab.Name = item.ToString();
                prdTab.Header = stc;
                prdTab.Content = scrl;
                ProductStackPanel.Items.Add(prdTab);
            }
            //Creatin My Account Tab
            prdTab = new TabItem();
            prdTab.Name = "MyAccount";
            prdTab.Header = "My Account";
            prdTab.Content = new MyAccount();
            ProductStackPanel.Items.Add(prdTab);

            // Creating Admin Zone tab - Available to admins only
            if (Constants.SessionUser.IsAdmin == true)
            {
                prdTab = new TabItem();
                prdTab.Name = "Admin";
                prdTab.Header = "Admin Zone";
                prdTab.Content = new AdminZone();
                ProductStackPanel.Items.Add(prdTab);
            }
            #endregion
        }


        //Creating Scrollviewer and grid to display products
        private Grid DisplayProducts(List<Product> lst)
        {
            #region GridInit
            Grid myGrid = new Grid();
            myGrid.HorizontalAlignment = HorizontalAlignment.Center;
            myGrid.VerticalAlignment = VerticalAlignment.Top;
            myGrid.Margin = new Thickness(10, 10, 10, 10);
            myGrid.ShowGridLines = false;
            // Define the Columns
            ColumnDefinition colDef1 = new ColumnDefinition();
            ColumnDefinition colDef2 = new ColumnDefinition();
            ColumnDefinition colDef3 = new ColumnDefinition();
            ColumnDefinition colDef4 = new ColumnDefinition();
            myGrid.ColumnDefinitions.Add(colDef1);
            myGrid.ColumnDefinitions.Add(colDef2);
            myGrid.ColumnDefinitions.Add(colDef3);
            myGrid.ColumnDefinitions.Add(colDef4);
            // Define the Rows
            RowDefinition rowDef1 = new RowDefinition();
            myGrid.RowDefinitions.Add(rowDef1);
            #endregion

            int col = 0; int row = 0; int count = 3;

            foreach (Product p in lst)
            {
                ProductDisplay pd = new ProductDisplay(p);
                Grid.SetRow(pd, row);
                Grid.SetColumn(pd, col);
                myGrid.Children.Add(pd);


                if (col == count)
                {
                    col = 0;
                    RowDefinition rowDef = new RowDefinition();
                    myGrid.RowDefinitions.Add(rowDef);
                    row++;
                }
                else
                {
                    col++;
                }
            }

            return myGrid;
        }

        //Exit button
        private void ExitBtn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
        private void LogoutBtn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MessageBoxWnd msgWnd = new MessageBoxWnd("Logging Off\nHope you had a great time\nCome again soon !");
            msgWnd.ShowDialog();

            Constants.SessionUser = new User();

            LoginScreen logScr = new LoginScreen();
            logScr.Show();
            this.Close();
        }

        //Detecting tab selection in main navigation
        // ** Changing effect filter menu accordingly
        // ** Changing main content page
        private void OnSelectionChanged(Object sender, SelectionChangedEventArgs args)
        {
            TabControl tc = (TabControl)sender;
            TabItem item = (TabItem)tc.SelectedItem;
            StackPanel es = EffectStackPanel;

            es.Children.Clear();

            if (tc != null)
            {
                switch (item.Name)
                {
                    case "Pedal":
                    case "Board":
                        foreach (EffectTypes et in Enum.GetValues(typeof(EffectTypes)))
                        {
                            Label effPTab = new Label();
                            effPTab = new Label();
                            effPTab.PreviewMouseDown += EffectType_PreviewMouseDown;
                            effPTab.Name = et.ToString();
                            effPTab.Content = et.ToString();
                            effPTab.MinWidth = 80;
                            effPTab.FontSize = 18;
                            es.Children.Add(effPTab);
                        }
                        var effTab = new Label();
                        effTab.PreviewMouseDown += EffectType_PreviewMouseDown;
                        effTab.PreviewMouseDown += ComponentType_PreviewMouseDown;
                        effTab.Name = "Clr";
                        effTab.Content = "Clear Filters";
                        effTab.Foreground = Brushes.Green;
                        effTab.MinWidth = 80;
                        effTab.FontSize = 18;
                        es.Children.Add(effTab);
                        break;
                    case "Component":
                        foreach (ComponentTypes et in Enum.GetValues(typeof(ComponentTypes)))
                        {
                            var effCTab = new Label();
                            effCTab.HorizontalContentAlignment = HorizontalAlignment.Center;
                            effCTab.PreviewMouseDown += ComponentType_PreviewMouseDown;
                            effCTab.Name = et.ToString();
                            effCTab.Content = et.ToString();
                            effCTab.MinWidth = 80;
                            effCTab.FontSize = 18;
                            es.Children.Add(effCTab);
                        }
                        effTab = new Label();
                        effTab.PreviewMouseDown += EffectType_PreviewMouseDown;
                        effTab.PreviewMouseDown += ComponentType_PreviewMouseDown;
                        effTab.Name = "Clr";
                        effTab.Content = "Clear Filters";
                        effTab.Foreground = Brushes.Green;
                        effTab.MinWidth = 80;
                        effTab.FontSize = 18;
                        es.Children.Add(effTab);
                        break;
                    case "Home":
                        item.Content = new HomePageContent();
                        break;
                    default:
                        break;
                }

            }
        }

        private void EffectType_PreviewMouseDown(Object sender, MouseButtonEventArgs e)
        {
            TabControl tc = ProductStackPanel;
            TabItem item = (TabItem)tc.SelectedItem;
            Label lbl = (Label)sender;
            List<Product> lst;

            if (lbl.Name != "Clr")
            {
                ProductTypes pt = (ProductTypes)Enum.Parse(typeof(ProductTypes), item.Name);
                EffectTypes et = (EffectTypes)Enum.Parse(typeof(EffectTypes), lbl.Name);
                lst = ProductActions.GetProducts(pt, et);
            }
            else
            {
                ProductTypes pt = (ProductTypes)Enum.Parse(typeof(ProductTypes), item.Name);
                lst = ProductActions.GetProducts(pt);
            }

            ScrollViewer scrl;
            scrl = new ScrollViewer()
            {
                Width = 1180,
                Height = 730,
                VerticalScrollBarVisibility = ScrollBarVisibility.Auto,
                VerticalAlignment = VerticalAlignment.Top
            };

            scrl.Content = DisplayProducts(lst);
            item.Content = scrl;
        }

        private void ComponentType_PreviewMouseDown(Object sender, MouseButtonEventArgs e)
        {
            TabControl tc = ProductStackPanel;
            TabItem item = (TabItem)tc.SelectedItem;
            Label lbl = (Label)sender;
            List<Product> lst;

            if (lbl.Name != "Clr")
            {
                ProductTypes pt = (ProductTypes)Enum.Parse(typeof(ProductTypes), item.Name);
                ComponentTypes ct = (ComponentTypes)Enum.Parse(typeof(ComponentTypes), lbl.Name);
                lst = ProductActions.GetProducts(pt, ct);
            }
            else
            {
                ProductTypes pt = (ProductTypes)Enum.Parse(typeof(ProductTypes), item.Name);
                lst = ProductActions.GetProducts(pt);
            }

            ScrollViewer scrl;
            scrl = new ScrollViewer()
            {
                Width = 1180,
                Height = 730,
                VerticalScrollBarVisibility = ScrollBarVisibility.Auto,
                VerticalAlignment = VerticalAlignment.Top
            };

            scrl.Content = DisplayProducts(lst);
            item.Content = scrl;
        }

        private void ShoppingCart_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ShoppingCart SCWnd = new ShoppingCart();
            SCWnd.Owner = this;
            SCWnd.ShowDialog();

        }


    }
}








