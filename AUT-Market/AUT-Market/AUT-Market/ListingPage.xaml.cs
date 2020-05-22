using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Xamarin.Forms;

namespace AUT_Market
{

    public partial class ListingPage : ContentPage
    {
        public IList<BookData> Books { get; private set; }

        public ListingPage()
        {
            InitializeComponent();

            Books = new List<BookData>
            {
                new BookData
                {
                    Title = "Information Technology Project Management",
                    Author = "Kathy Schwalbe",
                    Edition = 8,
                    Course_Code = "Comp600",
                    Faculty = "Engineering, Computer and Mathematical Sciences",
                    Description = "A description will go here",
                    Publication_Date = 2016,
                    Product_Image = "https://images.thenile.io/r1000/9781285452340.jpg",
                    Price = 40.0f,
                    Campus = "Wellesley"
                },

                new BookData
                {
                    Title = "Physiology",
                    Author = "Berne, Levy",
                    Edition = 2,
                    Course_Code = "Comp719",
                    Faculty = "Engineering, Computer and Mathematical Sciences",
                    Description = "A description will go here",
                    Publication_Date = 1988,
                    Product_Image = "https://images-na.ssl-images-amazon.com/images/I/41HVQQKkouL._SY334_BO1,204,203,200_.jpg",
                    Price = 100.0f,
                    Campus = "South"
                },

                new BookData
                {
                    Title = "The economic naturalist: in search of answers to everyday enigmas",
                    Author = "Robert H. Frank",
                    Edition = 1,
                    Course_Code = "Mars704",
                    Faculty = "Marketing and Advertising",
                    Description = "A description will go here",
                    Publication_Date = 2007,
                    Product_Image = "https://jackets.talis.com/manifestations/9780465002177/jackets/400.jpg",
                    Price = 50.50f,
                    Campus = "Wellesley"
                },

                new BookData
                {
                    Title = "The anatomy of corporate law: a comparative and functional approach",
                    Author = "Reinier H. Kraakman",
                    Edition = 3,
                    Course_Code = "Laws918",
                    Faculty = "Undergraduate Law",
                    Description = "A description will go here",
                    Publication_Date = 2017,
                    Product_Image = "https://global.oup.com/academic/covers/pop-up/9780198724315",
                    Price = 70.0f,
                    Campus = "North"
                },

                new BookData
                {
                    Title = "An interactive approach to writing essays and research reports in psychology",
                    Author = "Lorelle Burton",
                    Edition = 2,
                    Course_Code = "PSYC783",
                    Faculty = "Faculty of Culture and Society",
                    Description = "A description will go here",
                    Publication_Date = 2007,
                    Product_Image = "https://i.gr-assets.com/images/S/compressed.photo.goodreads.com/books/1258007674l/6588048.jpg",
                    Price = 70.0f,
                    Campus = "North"
                }
            };

            BindingContext = this;
        }


        void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            BookData selectedItem = e.SelectedItem as BookData;
        }

        void OnListViewItemTapped(object sender, ItemTappedEventArgs e)
        {
            BookData tappedItem = e.Item as BookData;
        }

        
    }
}