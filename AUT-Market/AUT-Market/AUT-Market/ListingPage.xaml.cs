using AUT_Market.Service;
using AUT_Market.ViewModel;
using System;
using Xamarin.Forms;

namespace AUT_Market
{

    public partial class ListingPage : ContentPage
    {
        ListingPageViewModel vm;
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
            vm = new ListingPageViewModel(Navigation);
            BindingContext = vm;
        }
        private void bookRefresh_Refreshing(object sender, System.EventArgs e)
        {
            vm = new ListingPageViewModel(Navigation);
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

            if (conditionSelection.SelectedIndex > 0)
            {
                vm = new ListingPageViewModel(Navigation);

                string userSelect = conditionSelection.SelectedItem.ToString();

                vm.getShortLiistOfCondition(userSelect);

                BindingContext = vm;

            }
            else
            {
                vm = new ListingPageViewModel(Navigation);
                BindingContext = vm;
            }

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
            filter.IsVisible = false;
        }

        private void clearBtn_Clicked(object sender, EventArgs e)
        {
            vm = new ListingPageViewModel(Navigation);
            BindingContext = vm;

        }
    }
}

