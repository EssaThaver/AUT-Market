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
        public ObservableCollection<TestBooks> getBooks { get; set; }

        public Command<TestBooks> RemoveBook
        {
            get
            {
                return new Command<TestBooks>((book) =>
                {
                    getBooks.Remove(book);    
                });
            }
        }

        public TestBooksViewModel()
        {
            getBooks = new BooksTempDB().GetBooks();
        }
    }
}
