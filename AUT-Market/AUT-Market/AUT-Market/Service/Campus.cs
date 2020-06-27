using System;
using System.Collections.Generic;
using System.Text;

namespace AUT_Market.Service
{
    /*
     * The main Campus class
     * Contains a list of all AUT Campuses and the options for the Campus filter
     * @author Georgia Thomson 1391057
     */

    class Campus
    {
        //Returns a list of all AUT campuses
        public List<String> getlistOfCampus()
        {
            List<string> listCampus = new List<string>();

            listCampus.Add("North");
            listCampus.Add("City");
            listCampus.Add("South");

            return listCampus;
        }

        //Returns a list of all AUT Campuses for the campus picker including an "All" option
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