using AUT_Market.Model;
using AUT_Market.Service;
using AUT_Market.View;
using FFImageLoading.Forms.Args;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace AUT_Market.ViewModel
{
    class BooksViewModel
    {
        public ObservableCollection<Book> getBooks { get; set; }
        
        //-------------------------------------------------------------------------------------------------------------------------------//

        INavigation Navigation;
        public BooksViewModel(INavigation Navigation)
        {
            this.Navigation = Navigation;
            getBooks = BooksDb.GetBookss();
        }

        //-------------------------------------------------------------------------------------------------------------------------------//

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

        //-------------------------------------------------------------------------------------------------------------------------------//

        public void getUserBook ()
        {
            getBooks = BooksDb.GetBookByUser(new User());
        }

        //-------------------------------------------------------------------------------------------------------------------------------//

        public ICommand ListViewCommand => new Command<Book>(async(value)=> {
            await Navigation.PushAsync(new WishlistDetail(value));
        });

        //-------------------------------------------------------------------------------------------------------------------------------//

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

        public void searchBook(string userInput)
        {
            ObservableCollection<Book> books = BooksDb.GetBookss();
            ObservableCollection<Book> resultBook = new ObservableCollection<Book>();

            foreach (Book book in books)
            {
                if(book.Title.ToLower().Contains(userInput.Trim().ToLower()) || book.CourseCode.ToLower().Contains(userInput.Trim().ToLower()))
                {
                    resultBook.Add(book);
                }
            }

            getBooks = resultBook;
        }


    }


}
