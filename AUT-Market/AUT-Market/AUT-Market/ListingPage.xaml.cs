﻿using AUT_Market.Service;
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
        private void bookRefresh_Refreshing(object sender, System.EventArgs e)
        {
            vm = new ListingPageViewModel(Navigation);
            BindingContext = vm;
            bookRefresh.IsRefreshing = false;
            filter.IsVisible = false;
            sort.IsVisible = false;
            NoBookResult.IsVisible = false;
        }


        private void filterBtn_Clicked(object sender, EventArgs e)
        {
            filter.IsVisible = true;
            sort.IsVisible = false;
        }

        private void applyBtn_Clicked(object sender, EventArgs e)
        {
            vm = new ListingPageViewModel(Navigation);

            if (conditionSelection.SelectedIndex > 0)
            {
                string userSelect = conditionSelection.SelectedItem.ToString();

                vm.getShortLiistOfCondition(userSelect);

                //BindingContext = vm;
            }
            if (campusSelection.SelectedIndex > 0)
            {
                string userSelect = campusSelection.SelectedItem.ToString();

                vm.getShortLiistOfCampus(userSelect);

                //BindingContext = vm;
            }
            if (facultySelection.SelectedIndex > 0)
            {
                string userSelect = facultySelection.SelectedItem.ToString();

                vm.getShortLiistOfFaculty(userSelect);

                //BindingContext = vm;
            }


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
            filter.IsVisible = false;
            //vm = new ListingPageViewModel(Navigation);
        }

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

        private void clearBtn_Clicked(object sender, EventArgs e)
        {
            vm = new ListingPageViewModel(Navigation);
            BindingContext = vm;

            filter.IsVisible = false;
            sort.IsVisible = false;
            NoBookResult.IsVisible = false;
        }

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