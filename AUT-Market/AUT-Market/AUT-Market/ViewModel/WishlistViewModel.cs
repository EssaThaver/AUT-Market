using AUT_Market.Model;
using AUT_Market.Service;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace AUT_Market.ViewModel
{
    class WishlistViewModel
    {
        public ObservableCollection<TestBooks> Items { get; set; }= new ObservableCollection<TestBooks>();

        public WishlistViewModel()
        {
            
        }
        public async void getChildData() {
            Items.Clear();
            var list = await BaseDatabase.Current.GetBooks(true);
            foreach (var item in list)
            {
                Items.Add(item);
            }
            Debug.WriteLine(JsonConvert.SerializeObject(Items));
        }
        public Command<TestBooks> RemoveBook
        {
            get
            {
                return new Command<TestBooks>(async(book) =>
                {
                    int result=await BaseDatabase.Current.RemoveBook(book);
                    if(result>0)
                        Items.Remove(book);
                });
            }
        }
        public Command<TestBooks> UpdateBooksZan
        {
            get
            {
                return new Command<TestBooks>(async (book) =>{
                    int index = Items.IndexOf(book);
                    book.Islike = !book.Islike;
                    int result= await BaseDatabase.Current.UpdateBook(book);
                    if (result > 0)
                        Items[index] = book;
                    Items.RemoveAt(index);
                    Debug.WriteLine(JsonConvert.SerializeObject(book));
                });
            }
        }
    }
}
