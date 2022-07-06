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
            //todo: check :
            string firstName = this.FirstNameTextbox.Text;
            string lastName = this.LastNameTextbox.Text;
            string email = this.EmailTextbox.Text;
            string password = this.PasswordTextbox.Text;
            string phoneNumber=this.PhoneNumberTextbox.Text;

            if (!firstName.ValidName())
            {
                Global.MessageError("invalid first name!");
            }
            else if (!lastName.ValidName())
            {
                Global.MessageError("invalid last name!");
            }
            else if (!email.ValidEmail())
            {
                Global.MessageError("invalid email!");
            }
            else if (!phoneNumber.ValidPhoneNumber())
            {
                Global.MessageError("invalid phone number!");
            }
            else if (!password.ValidPassword())
            {
                Global.MessageError("invalid password!");
            }
            else
            {
                User user = new User(firstName, lastName, password, email, phoneNumber);
                //todo :add to data base
                Global.MessageInfo("new user added!");
            }
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
