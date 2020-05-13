using System;
using System.Collections.Generic;
using System.Text;

namespace AUT_Market.Model
{
    public class SellProductValidation
    {
        public Boolean CheckStringIsNotNullOrWhitespace(string title, string author, string courseCode, string price)
        {
            if((!String.IsNullOrWhiteSpace(title)) && (!String.IsNullOrWhiteSpace(author)) && (!String.IsNullOrWhiteSpace(courseCode)) && (!String.IsNullOrWhiteSpace(price)))
            {
                return true;   
            }
            else
            {
                return false;
            }
        }

        public Boolean CheckSelectDateIsBeforeToday(DateTime date)
        {
            return false;
        }
        
    }
}
