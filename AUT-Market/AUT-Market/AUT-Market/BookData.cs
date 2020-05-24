using System;
using System.Collections.Generic;
using System.Text;

namespace AUT_Market
{
    public class BookData
{
        public string Title { get; set; }
        public string Author { get; set; }
        public int Edition { get; set; }
        public string Course_Code { get; set; }
        public string Faculty { get; set; }
        public string Condition { get; set; }
        public string Description { get; set; }
        public int Publication_Date { get; set; }
        public string Product_Image { get; set; }
        public float Price { get; set; }
        public string Campus { get; set; }

        public BookData()
         {
         }
    }
}