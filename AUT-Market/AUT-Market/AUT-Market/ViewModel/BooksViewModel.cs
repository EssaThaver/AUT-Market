using AUT_Market.Service;
using AUT_Market.View;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace AUT_Market.ViewModel
{
    class BooksViewModel
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

        INavigation Navigation;
        public BooksViewModel(INavigation Navigation)
        {
            this.Navigation = Navigation;
            getBooks = BooksDb.GetBooks();
        }

        public void getShortLiistOfCondition(string condition)
        {
            ObservableCollection<Book> books = BooksDb.GetBooks();
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

        public ICommand ListViewCommand => new Command<Book>(async(value)=> {
            await Navigation.PushAsync(new WishlistDetail(null));
        });

    }


}
