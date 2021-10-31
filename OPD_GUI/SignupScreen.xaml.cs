using System;
using System.Collections.Generic;
using System.ComponentModel;
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

using DataControl.DataAccess;
using DataControl.Utils;

namespace OPD_GUI
{
    /// <summary>
    /// Interaction logic for SignupScreen.xaml
    /// </summary>
    public partial class SignupScreen : Window
    {
        public SignupScreen()
        {
            InitializeComponent();
        }

        private void btnSignup_Click(object sender, RoutedEventArgs e)
        {
            string err = "";

            if (ValidateFormFields())
            {
                bool b = UserActions.UserSignUp(txtUsername.Text, txtFName.Text, txtLName.Text, txtPassword.Password, txtEmail.Text, false, ref err);
                MessageBox.Show(err);

                if (b)
                {
                    LoginScreen logsc = new LoginScreen();
                    logsc.Show();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Invalid Data");
            }
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            LoginScreen logsc = new LoginScreen();
            logsc.Show();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
          //  MessageBox.Show("d");
        }
        private bool ValidateFormFields()
        {
            if (txtFName.Text != "" &&
                txtLName.Text != "" &&
                txtUsername.Text != "" &&
                txtPassword.Password == txtVerPassword.Password &&
                ValidationControl.Validate_Password_Params(txtPassword.Password) &&
                ValidationControl.EmailValidation(txtEmail.Text)
                )
                return true;
            else
                return false;

        }
    }
}
