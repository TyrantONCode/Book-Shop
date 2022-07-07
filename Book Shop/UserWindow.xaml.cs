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
    /// Interaction logic for UserWindow.xaml
    /// </summary>
    

    public partial class UserWindow : Window
    {
        public UserWindow()
        {
            InitializeComponent();
        }

        private void ChargeConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            string cardNum = this.CardNumberTextbox1.Text+ this.CardNumberTextbox2.Text+ this.CardNumberTextbox3.Text+ this.CardNumberTextbox4.Text;
            string ccv = this.CVV2Textbox.Text;
            string year = this.ExpirationYearTextbox.Text;
            string month = this.ExpirationMonthTextbox.Text;
        }
    }
}
