using System;
using System.IO;
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

        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            //UserDbManager.AddData(id_textbox.Text.ToString(), firstname_textbox.Text.ToString(),
            //    lastname_textbox.Text.ToString(), password_textbox.Text.ToString(),
            //    email_textbox.Text.ToString(), phone_textbox.Text.ToString(),
            //    float.Parse(money_textbox.Text.ToString()));
            //textblockshit.Text = UserDbManager.ValidUsername(id_textbox.Text.ToString()).ToString();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
           if (Global.MessageConfirm("Are You Sure You Want To Exit ?"))
           {
                this.Close();
           }
        }

        private void UserButton_Click(object sender, RoutedEventArgs e)
        {
            UserSignupOrLoginWindow window = new UserSignupOrLoginWindow(this);
            this.IsEnabled = false;
            window.Show();
        }

        private void ManagerButton_Click(object sender, RoutedEventArgs e)
        {
            AdminLogin adminLogin = new AdminLogin();
            adminLogin.Show();
            this.Close();
        }

        private void B_Click(object sender, RoutedEventArgs e)
        {
            // Create OpenFileDialog
            Microsoft.Win32.OpenFileDialog openFileDlg = new Microsoft.Win32.OpenFileDialog();

            // Launch OpenFileDialog by calling ShowDialog method
            Nullable<bool> result = openFileDlg.ShowDialog();
            // Get the selected file name and display in a TextBox.
            // Load content of file in a TextBlock
            //if (result == true)
            //{
            //    textblock.Text = openFileDlg.FileName;
            //    Uri uri = new Uri(openFileDlg.FileName);
            //    image.Source = new BitmapImage(uri);
            //}
            //FileStream fileStream = new FileStream($@"{F:\Elmos\AP\AP1}", FileMode.Open);

        }
    }
}

