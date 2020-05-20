using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
<<<<<<< HEAD

namespace AUT_Market.Model
{
    class TestBooks
    {
        //public Boolean WishList { get; set; }
        public string imageUrl { get; set; }
        public string title { get; set; }
        public string author { get; set; }
        public DateTime publicationDate { get; set; }
=======
using SQLite;
using Newtonsoft.Json;

namespace AUT_Market.Model
{
    public class TestBooks
    {
        //public Boolean WishList { get; set; }
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        public string imageUrl { get; set; }
        public string title { get; set; }
        public string author { get; set; }
        //public DateTime publicationDate { get; set; }
        public string publicationDateStr { get; set; }
>>>>>>> Oliver
        public string faculty { get; set; }
        public string courseCode { get; set; }
        public double price { get; set; }
        public string bookCondition { get; set; }
        public string BookDesc { get; set; }
<<<<<<< HEAD
        
=======

        public bool Islike { get; set; }
        [JsonIgnore]
        public string IslikeImg {
            get => Islike ? "zan_on" : "zan_off";
        }
        public string BooksImgs { get; set; } = "[]";



>>>>>>> Oliver
    }
}
