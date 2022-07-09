﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
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
    public static class EMethods
    {
        public static bool ValidEmail(this string email)
        {
            Regex validateEmailRegex = new Regex("^[a-zA-Z]{1,32}@[a-zA-Z]{1,32}[.][a-zA-Z]{1,32}$");
            return validateEmailRegex.IsMatch(email);
        }
        public static bool ValidName(this string name)
        {
            Regex ValidNameRegex = new Regex("^[a-zA-Z]{3,32}$");
            return ValidNameRegex.IsMatch(name);
        }
        public static bool ValidPhoneNumber(this string number)
        {
            Regex PhoneNumberRegex = new Regex("^09[0-9]{9}$");
            return PhoneNumberRegex.IsMatch(number);

        }
        public static bool ValidPassword(this string password)
        {
            Regex PasswordRegex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])[a-zA-Z\d]{8,40}$");
            return PasswordRegex.IsMatch(password);
        }
        public static bool ValidCVV(this string cvv)
        {
            Regex CVVRegex = new Regex("^[0-9]{3,4}$");
            return CVVRegex.IsMatch(cvv);
        }

        public static bool ValidExpirationDate(string year, string month)
        {
            DateTime now = DateTime.Now;
            try
            {
                int yearInt = int.Parse(year);
                int monthInt = int.Parse(month);
                if (yearInt < now.Year)
                {
                    return false;
                }
                else if (yearInt == now.Year)
                {
                    if (monthInt > now.Month)
                    {
                        return true;
                    }
                    return false;
                }
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        public static bool ValidCreditCardNumber(string number)
        {
            if (number.Length != 16)
            {
                return false;
            }
            int counter = 0;
            int digit = 0;
            for (int i = 0; i < 16; i++)
            {
                digit = int.Parse(number[i].ToString());
                if (i % 2 == 1)
                {
                    counter += digit;
                    continue;
                }

                if (digit >= 5)
                {
                    counter += 2 * (digit - 4) - 1;
                }
                else
                {
                    counter += 2 * digit;
                }
            }

            return counter % 10 == 0;
        }

    }
    public class User
    {
        public string firstName;
        public string lastName;
        public string password;
        public string email;
        public string phone;
        public float money;
        public List<Book> bag;
        public List<Book> bought;
        public List<Book> bookmarks;
        public User(string firstName, string lastName, string password, string email, string phone)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.password = password;
            this.email = email;
            this.phone = phone;
            this.money = 0;
            this.bag = new List<Book>();
            this.bought = new List<Book>();
            this.bookmarks = new List<Book>();
        }
    }
    public class Book
    {
        public int id { get; set; } 
        public string name { get; set; }
        public string writer { get; set; }
        public float price { get; set; }
        public int publishYear { get; set; }
        public double score { get; set; }
        public string info { get; set; }
        public int numOfVotes { get; set; }
        public string imagPath { get; set; }
        public string pdfPath { get; set; }
        public Book()
        {

        }
        public Book(string name, float price, double score, string info)
        {
            this.name = name;
            this.price = price;
            this.score = score;
            this.info = info;
            this.numOfVotes = 0;
        }
        public void AddScore(double score)
        {
            double sum = score * numOfVotes + score;
            numOfVotes++;
            this.score = sum / numOfVotes;
        }
    }
    public abstract class Global
    {
        public static void MessageInfo(string text)
        {
            MessageBox.Show(text, "Info", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        public static void MessageError(string text)
        {
            MessageBox.Show(text, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        public static bool MessageConfirm(string text)
        {
            return (MessageBox.Show(text, "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes);
        }
    }

}

