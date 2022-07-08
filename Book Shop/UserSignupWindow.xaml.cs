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

namespace Book_Shop
{
    /// <summary>
    /// Interaction logic for UserSignup.xaml
    /// </summary>
    public partial class UserSignupWindow : Window
    {
        public UserSignupWindow()
        {
            InitializeComponent();
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            string firstName = this.FirstNameTextbox.Text;
            string lastName = this.LastNameTextbox.Text;
            string email = this.EmailTextbox.Text;
            string password = this.Passwrod_PasswordBox.Password;
            string confirmation = this.Confrimation_PasswordBox.Password;
            string phoneNumber=this.PhoneNumberTextbox.Text;

            string error = "Error: ";
            if (!firstName.ValidName())
            {
                error += $"\n-Invalid First Name";
            }
            if (!lastName.ValidName())
            {
                error += "\n-Invalid Last Name!";
            }
            if (!email.ValidEmail())
            {
                error += "\n-Email must be in the format of : x@y.z";
            }
            if (!phoneNumber.ValidPhoneNumber())
            {
                error += "\n-Phone Number must be in the format of: 09xxxxxxxxx";
            }
            if (!password.ValidPassword())
            {
                error += "\n-Password must contain upper case and lower case and a number!";
            }
            if (password != confirmation)
            {
                error += "\n-Password and Confrimation don't match!!!";
            }
            if (!UserDbManager.ValidSignupEmail(email))
            {
                error += "\n-This email already exits!!";
            }
            if (error != "Error: ")
            {
                Global.MessageError(error);
                return;
            }
            UserDbManager.AddData(firstName, lastName, password, email,phoneNumber,0);
            Global.MessageInfo("Sign Up Successful");
            
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void PasswordTextbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Passwrod_PasswordBox.PasswordChar = '*';
            Confrimation_PasswordBox.PasswordChar = '*';
        }
    }
}
