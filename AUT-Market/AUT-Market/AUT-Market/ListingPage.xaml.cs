using AUT_Market.Service;
using AUT_Market.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace AUT_Market
{

    public partial class ListingPage : ContentPage
    {
        // List<Book> Books { get; set; }
        TestBooksViewModel vm;

        public ListingPage()
        {
            InitializeComponent();

            conditionSelection.ItemsSource = new Conditions().getOptionCondition();
            vm = new TestBooksViewModel();
            BindingContext = vm;

            ////Books = new List<Book>(); //Creates a new List of book objects called Books 
            ////Books = BooksDb.GetBooks(); //Populates the Books List with data from the database
            ////BindingContext = Books; //Binds the Books List

            /* { Test data used to show if the listing page would operate correctly. No longer needed.
                 new Book
                 {
                     Title = "Information Technology Project Management",
                     Author = "Kathy Schwalbe",
                     Edition = "8th",
                     CourseCode = "Comp600",
                     Faculty = "Engineering, Computer and Mathematical Sciences",
                     Description = "A description will go here",
                     Publication_Date = 2016,
                     Product_Image = "https://images.thenile.io/r1000/9781285452340.jpg",
                     Price = 40.0f,
                     Campus = "Wellesley"
                 },

                 new Book
                 {
                     Title = "Physiology",
                     Author = "Berne, Levy",
                     Edition = "2nd",
                     CourseCode = "Comp719",
                     Faculty = "Engineering, Computer and Mathematical Sciences",
                     Description = "A description will go here",
                     Publication_Date = 1988,
                     Product_Image = "https://images-na.ssl-images-amazon.com/images/I/41HVQQKkouL._SY334_BO1,204,203,200_.jpg",
                     Price = 100.0f,
                     Campus = "South"
                 },

                 new Book
                 {
                     Title = "The economic naturalist: in search of answers to everyday enigmas",
                     Author = "Robert H. Frank",
                     Edition = "1st",
                     CourseCode = "Mars704",
                     Faculty = "Marketing and Advertising",
                     Description = "A description will go here",
                     Publication_Date = 2007,
                     Product_Image = "https://jackets.talis.com/manifestations/9780465002177/jackets/400.jpg",
                     Price = 50.50f,
                     Campus = "Wellesley"
                 },

                 new Book
                 {
                     Title = "The anatomy of corporate law: a comparative and functional approach",
                     Author = "Reinier H. Kraakman",
                     Edition = "3rd",
                     CourseCode = "Laws918",
                     Faculty = "Undergraduate Law",
                     Description = "A description will go here",
                     Publication_Date = 2017,
                     Product_Image = "https://global.oup.com/academic/covers/pop-up/9780198724315",
                     Price = 70.0f,
                     Campus = "North"
                 },

                 new Book
                 {
                     Title = "An interactive approach to writing essays and research reports in psychology",
                     Author = "Lorelle Burton",
                     Edition = "2nd",
                     CourseCode = "PSYC783",
                     Faculty = "Faculty of Culture and Society",
                     Description = "A description will go here",
                     Publication_Date = 2007,
                     Product_Image = "https://i.gr-assets.com/images/S/compressed.photo.goodreads.com/books/1258007674l/6588048.jpg",
                     Price = 70.0f,
                     Campus = "North"
                 }
             };
             */
        }



        void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Book selectedItem = e.SelectedItem as Book;
        }

        void OnListViewItemTapped(object sender, ItemTappedEventArgs e)
        {
            Book tappedItem = e.Item as Book;
        }

        private void bookRefresh_Refreshing(object sender, System.EventArgs e)
        {
            vm = new TestBooksViewModel();
            BindingContext = vm;
            bookRefresh.IsRefreshing = false;
        }

        private void conditionSelection_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if(conditionSelection.SelectedIndex != 0)
            {
                vm = new TestBooksViewModel(); 
                
                string userSelect = conditionSelection.SelectedItem.ToString();

                vm.getShortLiistOfCondition(userSelect);

                BindingContext = vm;

            }
            else
            {
                vm = new TestBooksViewModel();
                BindingContext = vm;
            }
            
        }
    }
}

