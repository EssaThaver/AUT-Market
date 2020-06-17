using AUT_Market.Service;
using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AUT_Market
{
    public class Book: INotifyPropertyChanged
    {
       
        public string Title { get; set; }
        public string Author { get; set; }
        public string Edition { get; set; }
        public string CourseCode { get; set; }
        public string Faculty { get; set; }
        public string Condition { get; set; }
        public string Description { get; set; }
        public string Price { get; set; } 
        public string Campus { get; set; }
        public string  Reason { get; set; }
        public DateTime Posted { get; set; }
        public string Photo { get; set; }
        public int IsDel { get; set; }
        [JsonIgnore]
        public string PhotoUrl {
            get {
                if (string.IsNullOrEmpty(Photo)) return "";
                return BaseServer.baseurl + Photo;
            }
        }
        public Guid ListingNumber { get; set; }
        [JsonIgnore]
        public string IslikeImg { get; set; }
        public string BooksImgs { get; set; } = "[]";
        /// <summary>
        /// Seller
        /// </summary>
        [JsonIgnore]
        public string ShopUserName { get; set; }

        /// <summary>
        /// User
        /// </summary>
        [JsonIgnore]
        public string ShopEmailAddress { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChaned([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}