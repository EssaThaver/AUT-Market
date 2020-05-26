using AUT_Market.Model;
using AUT_Market.ViewModel;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AUT_Market.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WishlistTesting : ContentPage
    {
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
            var book = removeBtn?.BindingContext as Book;
            vm?.UpdateBooksZan.Execute(book);
        }
        private async void BtnDeleteClicked(object sender, EventArgs e)
        {
            var removeBtn = sender as ImageButton;
            var book = removeBtn?.BindingContext as Book;
            //vm?.RemoveBook.Execute(book);
            await Navigation.PushAsync(new WishlistDetail(book));
        }
    }
}