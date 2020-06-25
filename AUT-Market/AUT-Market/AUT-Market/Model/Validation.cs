using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;
/**
 * This is validation class and there many different type validation to valid to make sure everything correct. 
 * @author Karan Patel 15900950
 */
namespace AUT_Market.Model
{
    public class Validation
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
            if (this.CheckStringToFloat(price))
            {
                if(this.CheckStringToFloat(edition))
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

        //This is check if user input is number.
        public Boolean CheckStringToFloat(string num)
        {
            Double doublePrice;
            try
            {
                doublePrice = float.Parse(num);
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
