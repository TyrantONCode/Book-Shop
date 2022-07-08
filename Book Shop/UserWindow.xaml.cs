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
            if (!EMethods.ValidExpirationDate(year, month))
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

        private void EditInfoConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            string firstName=this.NewFirstNameTextbox.Text;
            string lastName=this.NewLastNameTextbox.Text;
            string email=this.NewEmailTextbox.Text;
            string phone = this.NewPhoneNumberTextbox.Text;
            string password = this.NewPasswrod_PasswordBox.Password;
            string confirmation = this.NewConfrimation_PasswordBox.Password;
            string error = "Error: ";
            if (!EMethods.ValidName(firstName) && firstName != "")
            {
                error += "\n-Invalid fitsname!!!";
            }
            if (!EMethods.ValidName(lastName) && lastName != "")
            {
                error += "\n-Invalid lastname!!!";
            }
            if (!EMethods.ValidEmail(email) && email != "")
            {
                error += "\n-Invalid email format.Email must be in the format of x@y.z";
            }
            if (!EMethods.ValidPhoneNumber(phone) && phone != "")
            {
                error += "\n-Invalid phone number. Phone number must be in the format of 09xxxxxxxxx";
            }
            if (!EMethods.ValidPassword(password) && password != "")
            {
                error += "\n-Password must contain at least one lower case, one upper case and a nubmer";
            }
            if (password != confirmation && confirmation != "")
            {
                error += "\n-Password and Confrimation does not match";
            }
            if (error == "Error: ")
            {
                UserDbManager.EditProfile(UserLoginWindow.ID, firstName, lastName, email, phone, password);
                Global.MessageInfo("Profile editted successfully.");
                return;
            }
            Global.MessageError(error);
           //todo :
            //string password = this.NewPasswrod_PasswordBox.Text;
            //string confirmPassword = this.NewPassowrd_confirmation_textblock.Text;
        }
    }
}
