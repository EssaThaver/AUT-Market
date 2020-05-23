using System;
using System.Collections.Generic;
using System.Text;

namespace AUT_Market.Model
{
    class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Edition { get; set; }
        public string CourseCode { get; set; }
        public string Faculty { get; set; }
        public string Condition { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public string Campus { get; set; }
        public DateTime Posted { get; set; }
        //public System.Drawing.Image Photo { get; set; }
        public Guid ListingNumber { get; set; }
        public Book()
        {
            Posted = DateTime.Now;
        }

        public Book(string Title, string Author, string Edition, string CourseCode, string Faculty, string Condition, string Description, float Price, string Campus, DateTime Posted)
        {
            this.Title = Title;
            this.Author = Author;
            this.Edition = Edition;
            this.CourseCode = CourseCode;
            this.Faculty = Faculty;
            this.Condition = Condition;
            this.Description = Description;
            this.Price = Price;
            this.Campus = Campus;
            this.Posted = Posted;
        }
    }
}
