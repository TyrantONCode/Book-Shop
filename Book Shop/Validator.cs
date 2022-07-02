using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Book_Shop
{
    static internal class Validator
    {
        public static bool ValidEmail(this string email)
        {
            Regex validateEmailRegex = new Regex("^[a-zA-Z]{1,32}@[a-zA-Z]{1,32}[.][a-zA-Z]{1,32}$");
            return validateEmailRegex.IsMatch(email);
        }

        public static bool ValidName(this string name)
        {
            Regex ValidNameRegex = new Regex("^[a - zA - Z]{ 3, 32 }$");
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

        public static bool ValidExpirationDate(string year,string month)
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

        public static bool ValidCreditCardNumber(this string number)
        {
            // Luhn Algorithm
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

}

