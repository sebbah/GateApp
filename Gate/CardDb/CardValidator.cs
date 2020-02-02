using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace GateApp.CardDb
{
    class CardValidator
    {
        //public static bool IsCreditCardInfoValid(string cardNo, string expiryDate, string cvv)
        //{
        //    //example from: stackoverflow.com/questions/32959273/c-sharp-validating-user-input-like-a-credit-card-number
        //    var cardCheck = new Regex(@"^(1298|1267|4512|4567|8901|8933)([\-\s]?[0-9]{4}){3}$");
        //    var monthCheck = new Regex(@"^(0[1-9]|1[0-2])$");
        //    var yearCheck = new Regex(@"^20[0-9]{2}$");
        //    var cvvCheck = new Regex(@"^\d{3}$");

        //    if (!cardCheck.IsMatch(cardNo)) // <1>check card number is valid
        //        return false;
        //    if (!cvvCheck.IsMatch(cvv)) // <2>check cvv is valid as "999"
        //        return false;

        //    var dateParts = expiryDate.Split('/'); //expiry date in from MM/yyyy            
        //    if (!monthCheck.IsMatch(dateParts[0]) || !yearCheck.IsMatch(dateParts[1])) // <3 - 6>
        //        return false; // ^ check date format is valid as "MM/yyyy"

        //    var year = int.Parse(dateParts[1]);
        //    var month = int.Parse(dateParts[0]);
        //    var lastDateOfExpiryMonth = DateTime.DaysInMonth(year, month); //get actual expiry date
        //    var cardExpiry = new DateTime(year, month, lastDateOfExpiryMonth, 23, 59, 59);

        //    //check expiry greater than today & within next 6 years <7, 8>>
        //    return (cardExpiry > DateTime.Now && cardExpiry < DateTime.Now.AddYears(6));
        //}

        public static bool CheckCardNumber(string cardNo)
        {
            if (cardNo.Length != 16)
                return false;

            int value, sum = 0, it = 1;
            foreach (char c in cardNo)
            {
                value = Convert.ToInt32(c) - 48;
                if (value < 0 || value > 9) return false;

                if (it % 2 != 0)
                {
                    if (value * 2 > 9)
                    {
                        value *= 2;
                        string st = value.ToString();
                        sum += Convert.ToInt32(st[1]) - 48;
                        value /= 10;
                    }
                    else value *= 2;
                }
                sum += value;
                it++;
            }

            if (sum % 10 == 0)
                return true;
            else
                return false;
        }
    }
}
