using System;
using System.Collections.Generic;
using System.Text;

namespace AUT_Market.Service
{
    class Price
    {
        public List<String> getPrices()
        {
            List<string> listPrices = new List<string>();

            listPrices.Add("Less than $50");
            listPrices.Add("Less than $100");
            listPrices.Add("Less than $150");
            listPrices.Add("Less than $200");

            return listPrices;
        }

        public List<string> getOptionPrice()
        {
            List<string> listPrices = new List<string>();

            listPrices.Add("Less than $50");
            listPrices.Add("Less than $100");
            listPrices.Add("Less than $150");
            listPrices.Add("Less than $200");
            listPrices.Add("All");

            return listPrices;
        }
    }
}
