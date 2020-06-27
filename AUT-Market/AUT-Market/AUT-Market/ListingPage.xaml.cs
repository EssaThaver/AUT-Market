using AUT_Market.Service;
using AUT_Market.ViewModel;
using System;
using Xamarin.Forms;

namespace AUT_Market
{
    /*
     * This is the main Listing Page which displays the books and also updates as the user makes different selections.
     * @author Georgia Thomson 1391057
     */

    public partial class ListingPage : ContentPage
    {
        ListingPageViewModel vm;
        public ListingPage()
        {
            InitializeComponent();

            conditionSelection.ItemsSource = new Conditions().getOptionCondition();
            campusSelection.ItemsSource = new Campus().getOptionCampus();
            facultySelection.ItemsSource = new Faculties().getOptionFaculty();

            filter.IsVisible = false;
            sort.IsVisible = false;
            NoBookResult.IsVisible = false;
            vm = new ListingPageViewModel(Navigation);

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            BindingContext = vm;

            filter.IsVisible = false;
            sort.IsVisible = false;
            NoBookResult.IsVisible = false;
        }

        //This refreshes the list of books being displayed when the user pulls the page down
        private void bookRefresh_Refreshing(object sender, System.EventArgs e)
        {
            vm = new ListingPageViewModel(Navigation);
            BindingContext = vm;
            bookRefresh.IsRefreshing = false;
            filter.IsVisible = false;
            sort.IsVisible = false;
            NoBookResult.IsVisible = false;
        }

        //This displays the filter options when the user presses the "Filter" button
        private void filterBtn_Clicked(object sender, EventArgs e)
        {
            filter.IsVisible = true;
            sort.IsVisible = false;
        }

        //This calls the functions to change the ObservableCollection being displayed based on user filter choices.
        private void applyBtn_Clicked(object sender, EventArgs e)
        {
            vm = new ListingPageViewModel(Navigation);

            //If the user chose a specific condition in the Condition picker
            if (conditionSelection.SelectedIndex > 0)
            {
                string userSelect = conditionSelection.SelectedItem.ToString();

                vm.getShortLiistOfCondition(userSelect);
            }
            //If the user chose a specific campus in the Campus picker
            if (campusSelection.SelectedIndex > 0)
            {
                string userSelect = campusSelection.SelectedItem.ToString();

                vm.getShortLiistOfCampus(userSelect);
            }
            //If the user chose a specific faculty in the Faculty picker
            if (facultySelection.SelectedIndex > 0)
            {
                string userSelect = facultySelection.SelectedItem.ToString();

                vm.getShortLiistOfFaculty(userSelect);
            }

            BindingContext = vm;

            filter.IsVisible = false;
        }

        //This closes the filter picker section
        private void closeFilter_Clicked(object sender, EventArgs e)
        {
            filter.IsVisible = false;
        }

        //This closes the sorting picker section
        private void closeStoring_Clicked(object sender, EventArgs e)
        {
            sort.IsVisible = false;
        }

        //This displays the sorting section on the screen
        private void sortBtn_Clicked(object sender, EventArgs e)
        {
            sort.IsVisible = true;
            filter.IsVisible = false;
        }

        //This calls the required functions to change the books to the user's chosen order if necessary
        private void applySortBtn_Clicked(object sender, EventArgs e)
        {
            vm = new ListingPageViewModel(Navigation);

            if (orderSelection.SelectedIndex == 1)
            {
                string userSelect = orderSelection.SelectedItem.ToString();
                vm.getAscendOrder(userSelect);
            }
            else if (orderSelection.SelectedIndex == 2)
            {
                string userSelect = orderSelection.SelectedItem.ToString();
                vm.getDescendOrder(userSelect);
            }

            BindingContext = vm;
            sort.IsVisible = false;
        }

        //Reverts the list of books being displayed to its original state before filters or sorting were applied
        private void clearBtn_Clicked(object sender, EventArgs e)
        {
            vm = new ListingPageViewModel(Navigation);
            BindingContext = vm;

            filter.IsVisible = false;
            sort.IsVisible = false;
            NoBookResult.IsVisible = false;
        }

        //This calls the function to search through the database for a book based on user input
        private void searchBook_SearchButtonPressed(object sender, EventArgs e)
        {
            vm = new ListingPageViewModel(Navigation);

            vm.searchBook(searchBook.Text);

            if (vm.getBooks.Count == 0)
            {
                BindingContext = vm;
                NoBookResult.IsVisible = true;
            }
            else
            {
                BindingContext = vm;
                NoBookResult.IsVisible = false;
            }

        }
    }
}