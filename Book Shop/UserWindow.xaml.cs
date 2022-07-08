﻿using System;
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
            int[] bookIds=UserDbManager.FavBookIdList(UserLoginWindow.ID);
            List<Book> books = new List<Book>();
            BookmarksControl.ItemsSource = books;

            for (int i = 0; i < bookIds.Length; i++)
            {
                string name;
                string writer;
                int publishYear;
                string description;
                float price;
                string imagePath;
                //todo: fix it :
                BookDbManager.ShowData(bookIds[i],out name,out writer,out publishYear,out description,out price,out imagePath);
                books.Add(new Book() { name = name, writer = writer, publishYear = publishYear, info = description });
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

        private void EditInfoConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            string firstName=this.NewFirstNameTextbox.Text;
            string lastName=this.NewLastNameTextbox.Text;
            string email=this.NewEmailTextbox.Text;
           //todo :
            //string password = this.NewPasswrod_PasswordBox.Text;
            string confirmPassword = this.NewPassowrd_confirmation_textblock.Text;
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

        private void TabItem_MouseEnter(object sender, MouseEventArgs e)
        {
         // UserDbManager.FavBookIdList(UserLoginWindow.ID);

        }
    }
}
