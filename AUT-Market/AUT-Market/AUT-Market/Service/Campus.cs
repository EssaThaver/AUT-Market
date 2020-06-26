using System;
using System.Collections.Generic;
using System.Text;

namespace AUT_Market.Service
{
    class Campus
    {
        public List<String> getlistOfCampus()
        {
            List<string> listCampus = new List<string>();

            listCampus.Add("North");
            listCampus.Add("City");
            listCampus.Add("South");

            return listCampus;
        }

        public List<string> getOptionCampus()
        {
            List<string> listCampus = new List<string>();

            listCampus.Add("All");
            listCampus.Add("North");
            listCampus.Add("City");
            listCampus.Add("South");

            return listCampus;
        }
    }
}