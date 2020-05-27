﻿using AUT_Market.Service;
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
        // List<Book> Books { get; set; }
        TestBooksViewModel vm;

        public ListingPage()
        {
            InitializeComponent();           
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            conditionSelection.ItemsSource = new Conditions().getOptionCondition();
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

        private void conditionSelection_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if(conditionSelection.SelectedIndex != 0)
            {
                vm = new TestBooksViewModel(Navigation); 
                
                string userSelect = conditionSelection.SelectedItem.ToString();

                vm.getShortLiistOfCondition(userSelect);

                BindingContext = vm;

            }
            else
            {
                vm = new TestBooksViewModel(Navigation);
                BindingContext = vm;
            }
            
        }
    }
}

