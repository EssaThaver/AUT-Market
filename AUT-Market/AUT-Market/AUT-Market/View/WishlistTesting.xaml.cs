using AUT_Market.Model;
using AUT_Market.ViewModel;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
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
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            BindingContext = vm;
            vm.getChildData.Execute(null);
        }

        private void BtnZanClicked(object sender, EventArgs e)
        {
            var removeBtn = sender as ImageButton;
            var model = removeBtn?.BindingContext as Collects;
            vm?.UpdateBooksZan.Execute(model);
        }
        private async void BtnDetailClicked(object sender, EventArgs e)
        {
            var removeBtn = sender as ImageButton;
            var model = removeBtn?.BindingContext as Collects;
            var book = JsonConvert.DeserializeObject<Book>(JsonConvert.SerializeObject(model));
            await Navigation.PushAsync(new WishlistDetail(book));
        }
    }
}