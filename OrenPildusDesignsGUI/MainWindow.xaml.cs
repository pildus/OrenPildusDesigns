using System;
using DataControl.Utils;
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

namespace OrenPildusDesignsGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            this.Background = new ImageBrush(new BitmapImage(new Uri(@"H:\לימודים\קורס מורחב\פרוייקט אמצע\LoginBackground.jpg")));

            

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string err = "";

            if (ValidationControl.Validate_Password_Params(Text_Password.Password) && ValidationControl.EmailValidation(Text_Email.Text))
            {
                var encPass = Text_Password.Password;
                var userEmail = Text_Email.Text; 

                 if (UserActions.UserLogin(userEmail, encPass,ref err))
                {
                    MessageBox.Show("Successfull Login");
                    Window parentWindow = Window.GetWindow(this);
                    parentWindow.Hide();
                    StoreWindow store = new StoreWindow();
                    store.ShowDialog();

                    
                }

                else
                    MessageBox.Show("Invalid Password / Email");
            }

            else
                MessageBox.Show ("Invalid Password or Email");


        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e) 
        {
            RegisterWindow RegWnd = new RegisterWindow();
            this.Hide();
            RegWnd.ShowDialog();
        //{
        //    RegisterW form2 = new Window2();
        //    form2.Show();
        }


    }
}
