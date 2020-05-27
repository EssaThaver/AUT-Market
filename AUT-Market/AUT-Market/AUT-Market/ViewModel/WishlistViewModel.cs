using AUT_Market.Model;
using AUT_Market.Service;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace AUT_Market.ViewModel
{
    class WishlistViewModel
    {
        public ObservableCollection<Book> Items { get; set; }= new ObservableCollection<Book>();

        public void getChildData()
        {
            Items.Clear();
            var list = BooksDb.GetBooks(1);
            foreach (var item in list)
            {
                Items.Add(item);
            }
            Debug.WriteLine(JsonConvert.SerializeObject(Items));
        }
        public Command<Book> UpdateBooksZan
        {
            get
            {
                return new Command<Book>((book) =>{
                    book.Islike = book.Islike == 0 ? 1 : 0;
                    BooksDb.UpdateBook(book);
                    getChildData();
                });
            }
        }
    }
}
