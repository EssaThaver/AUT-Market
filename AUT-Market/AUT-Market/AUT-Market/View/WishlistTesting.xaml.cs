<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
=======
﻿using AUT_Market.Model;
using AUT_Market.ViewModel;
using System;
>>>>>>> Oliver

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AUT_Market.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WishlistTesting : ContentPage
    {
<<<<<<< HEAD
        public WishlistTesting()
        {
            InitializeComponent();
=======
        WishlistViewModel vm;
        public WishlistTesting()
        {
            InitializeComponent();
            vm = new WishlistViewModel();
            BindingContext = vm;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            vm.getChildData();
        }

        private void BtnZanClicked(object sender, EventArgs e)
        {
            var removeBtn = sender as ImageButton;
            var book = removeBtn?.BindingContext as TestBooks;
            vm?.UpdateBooksZan.Execute(book);
        }
        private async void BtnDeleteClicked(object sender, EventArgs e)
        {
            var removeBtn = sender as ImageButton;
            var book = removeBtn?.BindingContext as TestBooks;
            //vm?.RemoveBook.Execute(book);
            await Navigation.PushAsync(new WishlistDetail(book));
>>>>>>> Oliver
        }
    }
}