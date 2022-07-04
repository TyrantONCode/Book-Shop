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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Book_Shop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            //todo :
           /* if (Global.MessageConfirm("Are You Sure You Want To Exit ?"))
            {
                this.Close();
            }*/
        }

        private void UserButton_Click(object sender, RoutedEventArgs e)
        {
            //todo :
           /* UserSignupOrLoginWindow window = new UserSignupOrLoginWindow(this);
            this.IsEnabled = false;
            window.Show();*/
        }

        private void ManagerButton_Click(object sender, RoutedEventArgs e)
        {
            //todo : open manager ui window
        }
    }
}
