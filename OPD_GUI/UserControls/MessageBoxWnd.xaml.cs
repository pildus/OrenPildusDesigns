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

namespace OPD_GUI.UserControls
{
    /// <summary>
    /// Interaction logic for MessageBoxWnd.xaml
    /// </summary>
    public partial class MessageBoxWnd : Window
    {
        public MessageBoxWnd(string msg)
        {
            InitializeComponent();
            MessageText.Text = msg;
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
