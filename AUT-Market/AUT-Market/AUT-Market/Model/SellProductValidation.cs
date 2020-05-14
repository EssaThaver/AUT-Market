using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace AUT_Market.Model
{
    public class SellProductValidation
    {
        public int CheckValidInput(string title, string author, string edition, string courseCode, string price, string desc)
        {
            string[] userInput = { title, author, edition, courseCode, price, desc };

            for (int i = 0; i < userInput.Length; i++)
            {
                if (String.IsNullOrWhiteSpace(userInput[i]))
                {
                    return i;
                }
                
            }

            if(this.CheckStringToDouble(price))
            {
                if(this.CheckStringToDouble(edition))
                {
                    return -1;
                }
                else
                {
                    return 2;
                }
            }
            else
            {
                return 4;
            }
               
        }
               
        public Boolean CheckSelectDateIsBeforeToday(DateTime date)
        {
            if(date < DateTime.Now.Date)
            {
                return true;
            }
            else
            {
                return false;
            }            
        }

        public Boolean CheckMinWordCount(String desc)
        {
            desc.Trim();

            String[] words = desc.Split(' ');

            if (words.Length > 20)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean CheckStringToDouble(string num)
        {
            Double doublePrice;
            try
            {
                doublePrice = Double.Parse(num);
            }
            catch(FormatException )
            {
                return false;
            }


            return true;
        }


        
    }
}
