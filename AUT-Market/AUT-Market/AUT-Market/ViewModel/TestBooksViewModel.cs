using AUT_Market.Model;
using AUT_Market.Service;
using FFImageLoading.Forms.Args;
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
            getBooks = BooksDb.GetBookss();
        }

        public void getShortLiistOfCondition(string condition)
        {
            ObservableCollection<Book> books = BooksDb.GetBookss();
            ObservableCollection<Book> resultBook = new ObservableCollection<Book>();

            foreach(Book book in books)
            {
                if(book.Condition.Equals(condition))
                {
                    resultBook.Add(book);
                }
            }

            getBooks = resultBook;
        }

        public void getUserBook ()
        {
            getBooks = BooksDb.GetBookByUser(new User());
        }

    }


}
