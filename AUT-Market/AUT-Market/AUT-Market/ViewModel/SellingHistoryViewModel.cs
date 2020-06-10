using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace AUT_Market.ViewModel
{
    class SellingHistoryViewModel
    {
        public ObservableCollection<Book> getSellerHistoryBooks { get; set; }

        public SellingHistoryViewModel()
        {
            getSellerHistoryBooks = BooksDb.GetSellerHistoryBook();
        }
    }
}
