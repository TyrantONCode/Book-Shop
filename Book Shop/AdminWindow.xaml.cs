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
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            if (Global.MessageConfirm("Are you sure?"))
            {
                MainWindow mainWindow = new MainWindow();
                this.Close();
                mainWindow.Show();
            }
        }

        private void ChargeConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            string cardNum = this.CardNumberTextbox1.Text + this.CardNumberTextbox2.Text + this.CardNumberTextbox3.Text + this.CardNumberTextbox4.Text;
            string ccv2 = this.CVV2Textbox.Text;
            string year = this.ExpirationYearTextbox.Text;
            string month = this.ExpirationMonthTextbox.Text;
            double deposit = double.Parse(MoneyTextbox.Text);
            string error = "Error: ";
            if (!EMethods.ValidCreditCardNumber(cardNum))
            {
                error += "\n-Invalid credit card number!!!";
            }
            if (!EMethods.ValidCVV(ccv2))
            {
                error += "\n-CVV2 must be a 3 or 4 digit number!!!";
            }
            if (EMethods.ValidExpirationDate(year, month))
            {
                error += "\n-This credit card has been expired!!!";
            }
            if (deposit <= 0)
            {
                error += "\n-Deposite value must be a positive number.";
            }
            if (error == "Error: ")
            {
                UserDbManager.ChargeWallet(UserLoginWindow.ID, deposit);
                Global.MessageInfo($"{deposit}$ Successfully added to you wallet.");
                return;
            }
            Global.MessageError(error);
        }

        private void AddBookConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            string bookName = this.BookNameTextbox.Text;
            string author = this.AuthorNameTextbox.Text;
            string description = this.Descriptiontextbox.Text;
            int publishYear=0;
            float price = 0;
          // todo:   Point point =this.Descriptiontextbox.TransformToAncestor
            try
            {
                price = float.Parse(this.PriceTextbox.Text);
            }
            catch
            {
                Global.MessageError("invalid price!");
            }
            try
            {
                publishYear = int.Parse(this.PublishYearTextbox.Text);
            }
            catch
            {
                Global.MessageError("invalid publish year!");
            }
            if(publishYear <= 0)
            {
                Global.MessageError("invalid publish year!");
            }
            else if(price <= 0)
            {
                Global.MessageError("invalid price!");
            }
            else
            {
                //todo: add to db
            }
        }
    }
}
