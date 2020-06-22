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
        public WishlistDetail(Book model, bool ShowShoper = true)
        {
            InitializeComponent();
            vm = new WishlistDetailViewModel(model, Navigation);
            BindingContext = vm;
            vm.getChildData();
            if (!ShowShoper)
            {
                StackShoper.IsVisible = false;
            }
            checkBookIsOwnByUser();
          
        }
        //------------------------------------------------------------------------------------------------------------------------------------//
        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            vm?.UpdateZan.Execute(null);
        }

        //------------------------------------------------------------------------------------------------------------------------------------//
        private void NavToShoperPage(object sender, EventArgs e)
        {
            vm?.NavToShoperPage.Execute(null);
            checkBookIsOwnByUser();
        }

        //------------------------------------------------------------------------------------------------------------------------------------//
        private async void interesting_Clicked(object sender, EventArgs e)
        {
            var confrim = await DisplayAlert("Permission", "Do we have your permission to send your email address to " + vm.currentBook.ShopUserName + " and she/he will contact you soon?", "ACCPET", "DECLINE");
            bool validSend = false;

            if (confrim)
            {

                validSend = new Email().sendMesseage(vm.currentBook);


                if (validSend)
                {
                  await  DisplayAlert("Sent", "Seller will contact you soon", "OK");
                }
                else
                {
                    await DisplayAlert("Send Failed", "Try Again later", "OK");
                }
            }

        }

        //------------------------------------------------------------------------------------------------------------------------------------//
        public void checkBookIsOwnByUser()
        {
            if (vm.currentBook.ShopEmailAddress == User.Email)
            {
                interestingTop.IsEnabled = false;
                interestingTop.Text = "My Book";
                interestingTop.BackgroundColor = Color.FromHex("#DADADA");
                interestingTop.TextColor = Color.Black;

                interestingBottom.IsVisible = false;
            }
        }
    }
}