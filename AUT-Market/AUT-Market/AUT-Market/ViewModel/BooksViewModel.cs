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
        
        //------------------------------------------------------------------------------------------------------------------//

        // This method is when user select the book to remove from the list. 
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

        //------------------------------------------------------------------------------------------------------------------//
        
        //This construction is to set up list of the book by seller.

        INavigation Navigation;
        public BooksViewModel(INavigation Navigation)
        {
            this.Navigation = Navigation;
            getBooks = BooksDb.GetBookByUser();
        }

        //------------------------------------------------------------------------------------------------------------------//

        //This method is get book by seller.
        public void getUserBook ()
        {
            getBooks = BooksDb.GetBookByUser();
        }

        //------------------------------------------------------------------------------------------------------------------//

        public ICommand ListViewCommand => new Command<Book>(async(value)=> {
            await Navigation.PushAsync(new WishlistDetail(null));
        });

    }


}
