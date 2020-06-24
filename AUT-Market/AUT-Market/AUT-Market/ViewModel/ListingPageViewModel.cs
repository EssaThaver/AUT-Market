using AUT_Market.Service;
using AUT_Market.View;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace AUT_Market.ViewModel
{
    public class ListingPageViewModel
    {
        public ObservableCollection<Book> getBooks { get; set; }

        INavigation Navigation;
        public ListingPageViewModel(INavigation Navigation)
        {
            this.Navigation = Navigation;
            getBooks = BooksDb.GetBooks();
        }

        public ICommand ListViewCommand => new Command<Book>(async (value) => {
            await Navigation.PushAsync(new WishlistDetail(value));
        });

        public void getShortLiistOfCondition(string condition)
        {
            ObservableCollection<Book> books = BooksDb.GetBooks();
            ObservableCollection<Book> resultBook = new ObservableCollection<Book>();

            foreach (Book book in books)
            {
                if (book.Condition.Equals(condition))
                {
                    resultBook.Add(book);
                }
            }

            getBooks = resultBook;
        }

        public void getShortLiistOfCampus(string campus)
        {
            ObservableCollection<Book> books = BooksDb.GetBooks();
            ObservableCollection<Book> resultBook = new ObservableCollection<Book>();

            foreach (Book book in books)
            {
                if (book.Campus.Equals(campus))
                {
                    resultBook.Add(book);
                }
            }

            getBooks = resultBook;
        }

        public void getShortLiistOfFaculty(string faculty)
        {
            ObservableCollection<Book> books = BooksDb.GetBooks();
            ObservableCollection<Book> resultBook = new ObservableCollection<Book>();

            foreach (Book book in books)
            {
                if (book.Faculty.Equals(faculty))
                {
                    resultBook.Add(book);
                }
            }

            getBooks = resultBook;
        }

        public void getOrder(string orderChoice)
        {
            ObservableCollection<Book> books = BooksDb.GetBooks();
           // ObservableCollection<Book> resultBook = new ObservableCollection<Book>();

            foreach (Book book in books)
            {
                books.OrderBy(price => book.Price);
            }

            getBooks = books;
        }

        public void searchBook(string userInput)
        {
            ObservableCollection<Book> books = BooksDb.GetBooks();
            ObservableCollection<Book> resultBook = new ObservableCollection<Book>();

            foreach (Book book in books)
            {
                if (book.Title.ToLower().Contains(userInput.Trim().ToLower()) || book.CourseCode.ToLower().Contains(userInput.Trim().ToLower()))
                {
                    resultBook.Add(book);
                }
            }

            getBooks = resultBook;
        }
    }
}
