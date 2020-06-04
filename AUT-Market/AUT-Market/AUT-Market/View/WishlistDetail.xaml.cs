using AUT_Market.Model;
using AUT_Market.Service;
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
    public partial class WishlistDetail : ContentPage
    {
        WishlistDetailViewModel vm;
        public WishlistDetail(Book model,bool ShowShoper=true)
        {
            InitializeComponent();
            vm = new WishlistDetailViewModel(model,Navigation);
            BindingContext = vm;
            if (!ShowShoper) {
                StackShoper.IsVisible = false;
            }
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            
            vm.getChildData();
        }
        private void TapGestureRecognizer_Tapped(object sender, EventArgs e){
            vm?.UpdateZan.Execute(null);
        }

        private void NavToShoperPage(object sender, EventArgs e) {
            vm?.NavToShoperPage.Execute(null);
        }

        private async void interesting_Clicked(object sender, EventArgs e)
        {
            var confrim = await DisplayAlert("Permission", "We need get your email to pass to " + vm.currentBook.ShopEmailAddress + " to contact", "ACCPET", "DECLINE");

            if (confrim)
            {
                bool validSend = new Email().sendMesseage(vm.currentBook);

                if(validSend)
                {
                    DisplayAlert("Complete Send", "Seller will contact you soon", "OK");
                }
                else
                {
                    DisplayAlert("Send Failed", "Try Again later", "OK");
                }
            }

        }


    }
}