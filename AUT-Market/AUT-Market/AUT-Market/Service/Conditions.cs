using System;
using System.Collections.Generic;
using System.Text;

namespace AUT_Market.Service
{
    public class Conditions
    {
        public List<String> getlistOfCondition()
        {
            List<string> listCondition = new List<string>();

            listCondition.Add("Brand New");
            listCondition.Add("Nearly New");
            listCondition.Add("Noraml");
            listCondition.Add("Old");
            listCondition.Add("Slightly Damage");

            return listCondition;
        }
    }
}
