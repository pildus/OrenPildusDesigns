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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new OPDdbContext();

            lblHello.Content = "Hello " + Constants.SessionUser.FirstName;
            ShoppingCartCount.Text = "(" + Constants.SessionUser.ShoppingCart.Count() + ")"; 

            TabItem prdTab = new TabItem();

            foreach (ProductTypes item in Enum.GetValues(typeof(ProductTypes)))
            {
                prdTab = new TabItem();
                prdTab.Name = item.ToString();
                prdTab.Header = item.ToString() + "s";
                prdTab.Content = DisplayProducts(item);
                ProductStackPanel.Items.Add(prdTab);
                InitializeComponent();
            }
        }
        private Grid DisplayProducts(ProductTypes pt)
        {
            Grid myGrid = new Grid();
            myGrid.Width = 1280;
            myGrid.Height = 730;
            myGrid.HorizontalAlignment = HorizontalAlignment.Center;
            myGrid.VerticalAlignment = VerticalAlignment.Center;
            myGrid.ShowGridLines = false;
            // Define the Columns
            ColumnDefinition colDef1 = new ColumnDefinition();
            ColumnDefinition colDef2 = new ColumnDefinition();
            ColumnDefinition colDef3 = new ColumnDefinition();
            myGrid.ColumnDefinitions.Add(colDef1);
            myGrid.ColumnDefinitions.Add(colDef2);
            myGrid.ColumnDefinitions.Add(colDef3);
            // Define the Rows
            RowDefinition rowDef1 = new RowDefinition();
            myGrid.RowDefinitions.Add(rowDef1);


            List<Product> lst = ProductActions.GetProducts(pt);
            int col = 0; int row = 0;
            foreach (Product p in lst)
            {
                switch (pt)
                {
                    case ProductTypes.Pedal:
                        PedalDisplay pd = new PedalDisplay(p);
                        Grid.SetRow(pd, row);
                        Grid.SetColumn(pd, col);
                        myGrid.Children.Add(pd);
                        break;
                    case ProductTypes.Board:
                        BoardDisplay bd = new BoardDisplay(p);
                        Grid.SetRow(bd, row);
                        Grid.SetColumn(bd, col);
                        myGrid.Children.Add(bd);
                        break;
                    default:
 
                        break;

                }

                


                if (col == 2)
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

        private void ExitBtn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void OnSelectionChanged(Object sender, SelectionChangedEventArgs args)
        {
            TabControl tc = (TabControl)sender;

            if (tc != null)
            {
                TabItem item = (TabItem)tc.SelectedItem;
                StackPanel es = EffectStackPanel;
                es.Children.Clear();

                if (item.Name == "Pedal" || item.Name == "Board")
                {
                    foreach (EffectTypes et in Enum.GetValues(typeof(EffectTypes)))
                    {
                        var effTab = new Label();
                        effTab.Name = et.ToString();
                        effTab.Content = et.ToString();
                        effTab.MinWidth = 80;
                        effTab.FontSize = 20;
                        es.Children.Add(effTab);
                    }
                }
                else
                {
                    foreach (ComponentTypes et in Enum.GetValues(typeof(ComponentTypes)))
                    {
                        var effTab = new Label() ;
                        effTab.HorizontalContentAlignment = HorizontalAlignment.Center;
                        effTab.Name = et.ToString();
                        effTab.Content = et.ToString();
                        effTab.MinWidth = 120;
                        effTab.FontSize = 20;
                        es.Children.Add(effTab);
                    }
                }
            }
        }


    }
}


//TextBlock printTextBlock = new TextBlock();

//foreach (var item in Enum.GetValues(typeof(ProductTypes)))
//{
//    printTextBlock = new TextBlock();
//    printTextBlock.Text = item.ToString();
//    ProductStackPanel.Children.Add(printTextBlock);

//}          

//Button printTextBlock;

//foreach (var item in Enum.GetValues(typeof(ProductTypes)))
//{
//    printTextBlock = new Button();
//    printTextBlock.Content = item.ToString();
//    ProductStackPanel.Children.Add(printTextBlock);

//}




