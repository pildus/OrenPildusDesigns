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
using OPD_GUI.UserControls;
using DataControl.DataAccess;
using DataControl.Utils;

namespace OPD_GUI
{
    /// <summary>
    /// Interaction logic for LoginScreen.xaml
    /// </summary>
    public partial class LoginScreen : Window
    {
        public LoginScreen()
        {
            InitializeComponent();
            PopulateDB.CheckDBExist();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            string err = "";

            if (ValidationControl.Validate_Password_Params(txtPassword.Password) && ValidationControl.EmailValidation(txtEmail.Text))
            {
                var encPass = txtPassword.Password;
                var userEmail = txtEmail.Text;

                if (UserActions.UserLogin(userEmail, encPass, ref err))
                {
                    MessageBoxWnd msgWnd = new MessageBoxWnd("Login Successfull !\nWelcome To Oren Pildus Designs");
                    msgWnd.ShowDialog();

                    MainWindow mainWnd = new MainWindow();
                    mainWnd.Show();
                    this.Close();


                }

                else
                {
                    MessageBox.Show("Invalid Password / Email","Login Error",MessageBoxButton.OK );
                }
            }

            else
                MessageBox.Show("Invalid Password or Email");
        }
        //private void Hyperlink_Click(object sender, RoutedEventArgs e)
        //{
        //}

        private void btnSignup_Click(object sender, RoutedEventArgs e)
        {
            SignupScreen SignUp = new SignupScreen();
            SignUp.Show();
            this.Close();

        }
    }
}
