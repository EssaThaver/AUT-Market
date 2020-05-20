using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace AUT_Market.Model
{
    public class SellProductValidation
    {
        //-------------------------------------------------------------------------------------------------------------------------------------//\
        
        //This method to check make sure all input are not null or whitespace.
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

            //-------------------------------------------------------------------------------------------------------------------------------------//

            // Those fucntion to call method to valid user input are number.
            if (this.CheckStringToDouble(price))
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

        //-------------------------------------------------------------------------------------------------------------------------------------//

        //This method to check if the input date is before today. 
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

        //-------------------------------------------------------------------------------------------------------------------------------------//

        //This mehtod to check description word count is below min word count.
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

        //-------------------------------------------------------------------------------------------------------------------------------------//

        //This is check if user input is number.
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

        //-------------------------------------------------------------------------------------------------------------------------------------//

    }
}
