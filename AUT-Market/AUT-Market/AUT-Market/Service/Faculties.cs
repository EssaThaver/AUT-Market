using System;
using System.Collections.Generic;
using System.Text;

namespace AUT_Market.Service
{
    public class Faculties
    {
        
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
