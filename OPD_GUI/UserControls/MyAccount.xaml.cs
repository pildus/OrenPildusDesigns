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
using DataControl.Model;
using DataControl.Utils;

namespace OPD_GUI.UserControls
{
    /// <summary>
    /// Interaction logic for MyAccount.xaml
    /// </summary>
    public partial class MyAccount : UserControl
    {
        string err = "";
        public MyAccount()
        {
            InitializeComponent();

            // Populate Details Textboxes
            fName.Text = Constants.SessionUser.FirstName;
            lName.Text = Constants.SessionUser.LastName;
            UserName.Text = Constants.SessionUser.UserName;
            email.Text = Constants.SessionUser.EmailAddress;

            // Retrieve all confirmed orders for this user
            List<ComplexOrder> OrdersLst = OrdersActions.GetOrders(Constants.SessionUser.UserName);
            
            OrderDG.ItemsSource = ExtractOrdersList(OrdersLst);

        }

        private void UpdateDetailsBtn_Click(object sender, RoutedEventArgs e)
        {
            
            UserActions.EditUser(Constants.SessionUser.UserID, fName.Text, lName.Text, (bool)Constants.SessionUser.IsAdmin, ref err);

            MessageBoxWnd wnd = new MessageBoxWnd(err);
            wnd.ShowDialog();
        }

        private void UpdatePasswordBtn_Click(object sender, RoutedEventArgs e)
        {
            if (
               ValidationControl.Encrypt_Password(CurPass.Password) == Constants.SessionUser.Password &&
                ValidationControl.Validate_Password_Params(NewPass.Password) && VerPass.Password == NewPass.Password)
            {
                string pass = ValidationControl.Encrypt_Password(NewPass.Password);
                UserActions.EditUser(Constants.SessionUser.UserID, pass, ref err);
                MessageBoxWnd wnd = new MessageBoxWnd(err);
                wnd.ShowDialog();
            }
        }

        private List<OrderDisplay> ExtractOrdersList ( List<ComplexOrder> lst)
        {
            OrderDisplay ord;
            List<OrderDisplay> newLst = new List<OrderDisplay>(); 

            foreach (ComplexOrder comp in lst)
            {
                ord = new OrderDisplay
                {
                    Order_Date = comp.cOrder.OrderDate.Date,
                    Product_Name = comp.cProduct.ProductName,
                    Item_Price = comp.cinventoryItem.InventoryItemSpecialPrice,
                    Order_Quantity = comp.cOrder.OrderQuantity,
                    Order_Amount = comp.cOrder.OrderTotalAmount,
                };

                newLst.Add(ord);
            }
            return newLst;
        }

        private void resetFilter_Click(object sender, RoutedEventArgs e)
        {
            // Retrieve all confirmed orders for this user
            List<ComplexOrder> OrdersLst = OrdersActions.GetOrders(Constants.SessionUser.UserName);

            OrderDG.ItemsSource = ExtractOrdersList(OrdersLst);
        }
        private void filterByDates_Click(object sender, RoutedEventArgs e)
        {
            if (startDate != null && endDate != null & endDate.SelectedDate >= startDate.SelectedDate)
            {
                List<ComplexOrder> OrdersLst = OrdersActions.GetOrders((DateTime)startDate.SelectedDate, (DateTime)endDate.SelectedDate, Constants.SessionUser.UserID);
                OrderDG.ItemsSource = ExtractOrdersList(OrdersLst);
            }
            else
            {
                MessageBoxWnd wnd = new MessageBoxWnd("Invalid Dates");
                wnd.ShowDialog();
            }
        }
    }

    class OrderDisplay
    {
        public DateTime Order_Date { get; set; }
        public string Product_Name { get; set; }
        public int Order_Quantity { get; set; }
        public double Item_Price { get; set; }
        public double Order_Amount { get; set; }
    }
}
