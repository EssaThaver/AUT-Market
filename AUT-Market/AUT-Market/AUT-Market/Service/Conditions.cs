using System;
using System.Collections.Generic;
using System.Text;

namespace AUT_Market.Service
{

    //------------------------------------------------------------------------------------------------------------------------------------//
    public class Conditions
    {
        public List<String> getlistOfCondition()
        {
            List<string> listCondition = new List<string>();

            listCondition.Add("Brand New");
            listCondition.Add("Nearly New");
            listCondition.Add("Average");
            listCondition.Add("Slightly Damaged");

            return listCondition;
        }

        //------------------------------------------------------------------------------------------------------------------------------------//
        public List<string> getOptionCondition()
        {
            List<string> listCondition = new List<string>();

            listCondition.Add("All");
            listCondition.Add("Brand New");
            listCondition.Add("Nearly New");
            listCondition.Add("Average");
            listCondition.Add("Slightly Damaged");

            return listCondition;
        }
    }
}
