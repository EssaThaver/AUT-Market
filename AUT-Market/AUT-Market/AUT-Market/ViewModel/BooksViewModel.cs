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

        public void getUserBook ()
        {
            getBooks = BooksDb.GetBookByUser();
        }

        public ICommand ListViewCommand => new Command<Book>(async(value)=> {
            await Navigation.PushAsync(new WishlistDetail(null));
        });

    }


}
