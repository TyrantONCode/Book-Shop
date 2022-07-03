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
    /// Interaction logic for UserSignupOrLoginWindow.xaml
    /// </summary>
    public partial class UserSignupOrLoginWindow : Window
    {
        MainWindow mainWindow;
        public UserSignupOrLoginWindow()
        {
            InitializeComponent();
        }
        public UserSignupOrLoginWindow(MainWindow mainWindow)
        {
            this.mainWindow=mainWindow;
            InitializeComponent();
        }
        private void UserLoginSelectButton_Click(object sender, RoutedEventArgs e)
        {
           /* UserLoginWindow window = new UserLoginWindow();
            window.Show();
            this.mainWindow.Close();
            this.Close();*/
        }

        private void UserSignupSelectButton_Click(object sender, RoutedEventArgs e)
        {
           /* UserSignupWindow userSignupWindow = new UserSignupWindow();
            userSignupWindow.Show();    
            this.mainWindow.Close();
            this.Close();*/
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.mainWindow.IsEnabled = true;
            this.Close();
        }
    }
}
