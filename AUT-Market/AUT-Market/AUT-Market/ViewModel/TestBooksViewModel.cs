using AUT_Market.Model;
using AUT_Market.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace AUT_Market.ViewModel
{
    class TestBooksViewModel
    {
        public ObservableCollection<Book> getBooks { get; set; }

        public Command<Book> RemoveBook
        {
            get
            {
                return new Command<Book>((book) =>
                {
                    getBooks.Remove(book);
                });
            }
        }

        public TestBooksViewModel()
        {
            getBooks = BooksDb.GetBookss(); ;
        }
    }
}
