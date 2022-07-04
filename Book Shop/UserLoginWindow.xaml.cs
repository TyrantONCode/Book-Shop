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
    /// Interaction logic for UserLogin.xaml
    /// </summary>
    public partial class UserLoginWindow : Window
    {
        public UserLoginWindow()
        {
            InitializeComponent();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            string email = this.EmailTextbox.Text;
            string password= this.PasswordTextbox.Text;
            if (UserDbManager.ValidLoginEmail(email))
            {
                if(UserDbManager.UserLogin(email, password))
                {

                }
                else
                {
                    Global.MessageError("invalid password!");
                }
                
            }
            else
            {
                Global.MessageError("invalid email!");
            }
        }
    }
}
