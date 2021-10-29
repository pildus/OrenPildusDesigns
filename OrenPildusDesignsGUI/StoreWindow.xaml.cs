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
using System.Windows.Shapes;

using DataControl.Utils;

namespace OrenPildusDesignsGUI
{
    /// <summary>
    /// Interaction logic for StoreWindow.xaml
    /// </summary>
    public partial class StoreWindow : Window
    {
        public StoreWindow()
        {
            InitializeComponent();
            Test_Text.Text = $"User ID: {Constants.SessionUser.UserID} , Name = {Constants.SessionUser.FirstName + " " + Constants.SessionUser.LastName}";
        }
    }
}
