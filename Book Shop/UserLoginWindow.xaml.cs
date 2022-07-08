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
        public static int User_Id = -1;
        public static int ID
        {
            get { return User_Id; }
        }
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
            if (UserDbManager.UserLogin(email, password, out User_Id))
            {
                // to do: user page open
                UserWindow userWindow = new UserWindow();
                userWindow.Show();      
                Global.MessageInfo("Logged in successfully!");
                //return;
            }
            else
            {
                Global.MessageError("Invalid email or password!!");
            }
        }
    }
}
