﻿using AUT_Market.Model;
using AUT_Market.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AUT_Market.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyBooks : ContentPage
    {
        BooksViewModel vm;
        Validation valid;

        //----------------------------------------------------------------------------------------------------------------------------------------------------//

        public MyBooks()
        {
            InitializeComponent();

            vm = new BooksViewModel(Navigation);

            vm.getUserBook();

            BindingContext = vm;


        }

        //----------------------------------------------------------------------------------------------------------------------------------------------------//

        private async void Remove_Clicked(object sender, EventArgs e)
        {
            var check = await DisplayAlert("Warning", "Are You Sure? ", "Yes", "No");

            if (check)
            {
                var reason = await DisplayActionSheet("Reason", null, null, "Sold", " I Changed My Mind"," No Buyers","Faulty");


                var removeBtn = sender as Button;

                var book = removeBtn?.BindingContext as Book;

                BooksDb.RemoveBook(book,reason);

                vm?.RemoveBook.Execute(book);
            }
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------------//

        private void Edit_Clicked(object sender, EventArgs e)
        {
            var editBtn = sender as Button;

            var book = editBtn?.BindingContext as Book;

            Navigation.PushModalAsync(new SellProductFormView(book));
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------------//

        private async void priceChange_Clicked(object sender, EventArgs e)
        {
            var priceBtn = sender as Button;

            var book = priceBtn?.BindingContext as Book;

            string newPrice = await DisplayPromptAsync("Price Change", "New Price", keyboard: Keyboard.Numeric);

            if (!String.IsNullOrWhiteSpace(newPrice))
            {

                this.changePrice(newPrice, book);
            }
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------------//

        private void changePrice(string newPrice, Book book)
        {
            valid = new Validation();

            if (valid.CheckStringToDouble(newPrice) && !(String.IsNullOrWhiteSpace(newPrice)))
            {
                book.Price = float.Parse(newPrice);

                BooksDb.PriceChange(book);
            }

            vm = new BooksViewModel(Navigation);
            vm.getUserBook();
            BindingContext = vm;

        }
    }
}