using AUT_Market.Service;
using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace AUT_Market.Model
{
    /// <summary>
    /// Wishlist
    /// </summary>
    public class Collects
    {
        public int Id { get; set; }
        public string EmailAddress { get; set; }
        public string ListingNumber { get; set; }
        public DateTime addtime { get; set; }

        #region  books
        public string Title { get; set; }
        public string Author { get; set; }
        public string Edition { get; set; }
        public string CourseCode { get; set; }
        public string Faculty { get; set; }
        public string Condition { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public string Campus { get; set; }
        public DateTime Posted { get; set; }
        public string Photo { get; set; }
        [JsonIgnore]
        public string PhotoUrl
        {
            get
            {
                if (string.IsNullOrEmpty(Photo)) return "";
                return BaseServer.baseurl + Photo;
            }
        }
        [JsonIgnore]
        public string IslikeImg { get; set; }
        public string BooksImgs { get; set; } = "[]";
        /// <summary>
        /// Person who add books to the Wishlist
        /// </summary>
        public string UserEmailAddress { get; set; }
        /// <summary>
        /// Buyer
        /// </summary>
        public string ShopUserName { get; set; }
        /// <summary>
        /// Seller
        /// </summary>
        public string ShopEmailAddress { get; set; }
        #endregion


    }
}
