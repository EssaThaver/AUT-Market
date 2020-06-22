using AUT_Market.View;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace AUT_Market.ViewModel
{
    public class BookSellerViewModel: INotifyPropertyChanged
    {
        #region
        string _ShopUserName;
        public string ShopUserName { get => _ShopUserName;set { _ShopUserName = value;OnPropertyChaned(); } }

        string _ShopEmailAddress;
        public string ShopEmailAddress { get => _ShopEmailAddress; set { _ShopEmailAddress = value; OnPropertyChaned(); } }

        
        int _SaleTotal;
        public int SaleTotal { get => _SaleTotal; set { _SaleTotal = value; OnPropertyChaned(); } }

        #endregion
        public ObservableCollection<Book> Items { get; set; } = new ObservableCollection<Book>();
        INavigation Navigation;

        //------------------------------------------------------------------------------------------------------------------------------------//
        public BookSellerViewModel(INavigation Navigation) {
            this.Navigation = Navigation;
        }
        //------------------------------------------------------------------------------------------------------------------------------------//
        public Command getChildData => new Command<string>((value)=> {
            Items.Clear();
            SaleTotal = BooksDb.getTotalSale(value);
            var list = BooksDb.GetBooksByShoper(value);
            foreach (var item in list){
                Items.Add(item);
            }
            ShopUserName = list[0].ShopUserName;
            ShopEmailAddress = list[0].ShopEmailAddress;
        });

        //------------------------------------------------------------------------------------------------------------------------------------//
        public Command ListViewCommand => new Command<Book>(async (value) => {
            await Navigation.PushAsync(new WishlistDetail(value,false));
        });



        //------------------------------------------------------------------------------------------------------------------------------------//
        public event PropertyChangedEventHandler PropertyChanged;

        //------------------------------------------------------------------------------------------------------------------------------------//
        public void OnPropertyChaned([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
