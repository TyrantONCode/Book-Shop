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

        }

        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            //UserDbManager.AddData(id_textbox.Text.ToString(), firstname_textbox.Text.ToString(),
            //    lastname_textbox.Text.ToString(), password_textbox.Text.ToString(),
            //    email_textbox.Text.ToString(), phone_textbox.Text.ToString(),
            //    float.Parse(money_textbox.Text.ToString()));
            textblockshit.Text = UserDbManager.ValidUsername(id_textbox.Text.ToString()).ToString();
        }
    }
}
