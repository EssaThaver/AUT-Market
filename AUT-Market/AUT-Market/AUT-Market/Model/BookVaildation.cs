using System;
using System.Collections.Generic;
using System.Text;

namespace AUT_Market.Model
{
    public class BookVaildation
    {
        public bool AddBook(Book model) {
            if (model == null) return false;
            if (string.IsNullOrEmpty(model.Title) || string.IsNullOrEmpty(model.Author) || model.ListingNumber==null) return false;
            return true;
        }

    }
}
