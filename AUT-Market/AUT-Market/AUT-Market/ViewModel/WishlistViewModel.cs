using AUT_Market.Model;
using AUT_Market.Service;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Xamarin.Forms;

namespace AUT_Market.ViewModel
{
    public class WishlistViewModel
    {
        public ObservableCollection<Collects> Items { get; set; }= new ObservableCollection<Collects>();

        public Command getChildData => new Command(()=> {
            Items.Clear();
            var list = CollectsServer.getCollects(User.Email);
            foreach (var item in list)
            {
                Items.Add(item);
            }
            Debug.WriteLine(JsonConvert.SerializeObject(Items));
        });
        public Command UpdateBooksZan => new Command<Collects>((model) => {
            CollectsServer.RemoveCollcet(model.ListingNumber.ToString(),User.Email);
            getChildData.Execute(null);
        });
    }
}
