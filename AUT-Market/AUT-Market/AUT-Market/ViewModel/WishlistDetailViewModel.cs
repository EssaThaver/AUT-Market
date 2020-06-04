using AUT_Market.Model;
using AUT_Market.Service;
using AUT_Market.View;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace AUT_Market.ViewModel
{
    public class WishlistDetailViewModel: INotifyPropertyChanged
    {
        #region
        string _BookTitle;
        public string BookTitle { get => _BookTitle;set { _BookTitle = value;OnPropertyChaned(); } }
        string _IslikeImg;
        public string IslikeImg { get => _IslikeImg; set { _IslikeImg = value; OnPropertyChaned(); } }
        string _author;
        public string author { get => _author; set { _author = value; OnPropertyChaned(); } }
        string _publicationDateStr;
        public string publicationDateStr { get => _publicationDateStr; set { _publicationDateStr = value; OnPropertyChaned(); } }
        string _faculty;
        public string faculty { get => _faculty; set { _faculty = value; OnPropertyChaned(); } }
        string _courseCode;
        public string courseCode { get => _courseCode; set { _courseCode = value; OnPropertyChaned(); } }
        string _Campus;
        public string Campus { get => _Campus; set { _Campus = value; OnPropertyChaned(); } }

        string _price;
        public string price { get => _price; set { _price = value; OnPropertyChaned(); } }
        string _bookCondition;
        public string bookCondition { get => _bookCondition; set { _bookCondition = value; OnPropertyChaned(); } }
        string _BookDesc;
        public string BookDesc { get => _BookDesc; set { _BookDesc = value; OnPropertyChaned(); } }

        string _ShopUserName;
        public string ShopUserName { get => _ShopUserName; set { _ShopUserName = value; OnPropertyChaned(); } }

        #endregion
        public ObservableCollection<string> BookImages { get; set; }= new ObservableCollection<string>();
        public Book currentBook { get; set; }
        Book model;
        INavigation Navigation;

        public WishlistDetailViewModel(Book model, INavigation Navigation) {
            this.Navigation = Navigation;
            this.model = BooksDb.GetBooks(model.ListingNumber.ToString());
            this.currentBook = model;
        }

        public void getChildData() {
            var list = JsonConvert.DeserializeObject<List<string>>(model.BooksImgs);
            foreach (var item in list){
                BookImages.Add(BaseServer.baseurl+item);
            }
            BookTitle = model.Title;
            BookDesc = model.Description;
            bookCondition = model.Condition;
            price = model.Price.ToString();
            courseCode = model.CourseCode;
            faculty = model.Faculty;
            publicationDateStr = model.Posted.ToString("yyyy-MM-dd HH:mm:ss:fff");
            author = model.Author;
            Campus = model.Campus;
            ShopUserName = model.ShopUserName;


            int result = CollectsServer.getQueryZan(model.ListingNumber.ToString(), User.Email);
            IslikeImg = result > 0 ? "zan_on" : "zan_off";
        }
        public Command UpdateZan => new Command(()=> {
            int result = 0;
            if (IslikeImg == "zan_on")
            {
                //Remove books from wishlist
                result = CollectsServer.RemoveCollcet(model.ListingNumber.ToString(),User.Email);
                if (result > 0) {
                    IslikeImg = "zan_off";
                }
            }
            else if (IslikeImg == "zan_off")
            {
                //Add books to wishlist
                result = CollectsServer.AddCollect(new Collects { EmailAddress = User.Email, ListingNumber = model.ListingNumber.ToString() });
                if (result > 0){
                    IslikeImg = "zan_on";
                }
            }
        });

        public Command NavToShoperPage => new Command(async()=>{
            await Navigation.PushAsync(new BookSeller(model.ShopEmailAddress));
        });



        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChaned([CallerMemberName] string  name="") {
            PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(name));
        }

    }
}
