using AUT_Market.Model;
using AUT_Market.Service;
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
        string _price;
        public string price { get => _price; set { _price = value; OnPropertyChaned(); } }
        string _bookCondition;
        public string bookCondition { get => _bookCondition; set { _bookCondition = value; OnPropertyChaned(); } }
        string _BookDesc;
        public string BookDesc { get => _BookDesc; set { _BookDesc = value; OnPropertyChaned(); } }

        #endregion
        public ObservableCollection<string> BookImages { get; set; }
        TestBooks model;
        public WishlistDetailViewModel(TestBooks model) {
            this.model = model;
            BookImages = new ObservableCollection<string>();
           
        }
        public void getChildData() {
            var list = JsonConvert.DeserializeObject<List<string>>(model.BooksImgs);
            foreach (var item in list){
                BookImages.Add(item);
            }
            BookTitle = model.title;
            BookDesc = model.BookDesc;
            bookCondition = model.bookCondition;
            price = model.price.ToString();
            courseCode = model.courseCode;
            faculty = model.faculty;
            publicationDateStr = model.publicationDateStr;
            author = model.author;
            IslikeImg = model.IslikeImg;
        }
        public Command UpdateZan{
            get {
                return new Command(async()=> {
                    model.Islike = !model.Islike;
                    int result = await BaseDatabase.Current.UpdateBook(model);
                    if (result > 0)
                        IslikeImg = model.IslikeImg;
                });
            }
        }



        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChaned([CallerMemberName] string  name="") {
            PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(name));
        }

    }
}
