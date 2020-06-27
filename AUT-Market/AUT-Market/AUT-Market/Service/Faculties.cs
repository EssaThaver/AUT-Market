using System;
using System.Collections.Generic;
using System.Text;

namespace AUT_Market.Service
{
    /*
     * The main Faculties class
     * Contains a list of all AUT faculties and the options for the Faculty filter
     * @author Georgia Thomson 1391057
     */

    public class Faculties
    {
        //Returns a list of all AUT faculties
        public List<String> getListOfFaculty()
        {
            var listFaculties = new List<String>();

            listFaculties.Add("Business, Economics and Law");
            listFaculties.Add("Culture and Society");
            listFaculties.Add("Design and Creative Technologies");
            listFaculties.Add("Health and Environmental Sciences");
            listFaculties.Add("Māori and Indigenous Development");

            return listFaculties;
        }

        //Returns a list of all AUT faculties for the faculty picker including an "All" option
        public List<String> getOptionFaculty()
        {
            List<string> listFaculties = new List<string>();

            listFaculties.Add("All");
            listFaculties.Add("Business, Economics and Law");
            listFaculties.Add("Culture and Society");
            listFaculties.Add("Design and Creative Technologies");
            listFaculties.Add("Health and Environmental Sciences");
            listFaculties.Add("Māori and Indigenous Development");

            return listFaculties;
        }
    }
}