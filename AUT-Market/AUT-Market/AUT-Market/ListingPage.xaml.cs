using AUT_Market.Service;
using AUT_Market.View;
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
        TestBooksViewModel vm;

        public ListingPage()
        {
            InitializeComponent();
            filter.IsVisible = false;
            sort.IsVisible = false;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            conditionSelection.ItemsSource = new Conditions().getOptionCondition();
            campusSelection.ItemsSource = new Campus().getOptionCampus();
            //           priceSelection.ItemsSource = new Price().getOptionPrice();
            facultySelection.ItemsSource = new Faculty().getOptionFaculty();
            orderSelection.ItemsSource = new Order().getListOfOrder();
            vm = new TestBooksViewModel(Navigation);
            BindingContext = vm;
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
            vm = new TestBooksViewModel(Navigation);
            BindingContext = vm;
            bookRefresh.IsRefreshing = false;
        }


        private void filterBtn_Clicked(object sender, EventArgs e)
        {
            filter.IsVisible = true;
            sort.IsVisible = false;
        }

        private void applyBtn_Clicked(object sender, EventArgs e)
        {
            vm = new TestBooksViewModel(Navigation);

            if (conditionSelection.SelectedIndex > 0)
            {
                string userSelect = conditionSelection.SelectedItem.ToString();

                vm.getShortLiistOfCondition(userSelect);
            }
            if (campusSelection.SelectedIndex > 0)
            {
                string userSelect = campusSelection.SelectedItem.ToString();

                vm.getShortLiistOfCampus(userSelect);
            }
            if (facultySelection.SelectedIndex > 0)
            {
                string userSelect = facultySelection.SelectedItem.ToString();

                vm.getShortLiistOfFaculty(userSelect);
            }
            /*            if (priceSelection.SelectedIndex > 0)
                        {
                            string UserSelect = priceSelection.SelectedItem.ToString();
                            vm.getShortLiistOfPrice(UserSelect);
                        }
              */
            BindingContext = vm;
            filter.IsVisible = false;
        }

        private void closeFilter_Clicked(object sender, EventArgs e)
        {
            filter.IsVisible = false;
        }

        private void closeStoring_Clicked(object sender, EventArgs e)
        {
            sort.IsVisible = false;
        }

        private void sortBtn_Clicked(object sender, EventArgs e)
        {
            sort.IsVisible = true;

            if(facultySelection.SelectedIndex > 0)
            {
                string userSelect = orderSelection.SelectedItem.ToString();

            }

            vm = new TestBooksViewModel(Navigation);
            BindingContext = vm;


            filter.IsVisible = false;
        }

        private void clearBtn_Clicked(object sender, EventArgs e)
        {
            vm = new TestBooksViewModel(Navigation);
            BindingContext = vm;

        }


    }
}

