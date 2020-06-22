using AUT_Market;
using AUT_Market.Service;
using AUT_Market.View;
using System;
using System.Threading;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AUT_Market
{
    public partial class App : Application
    {
        public static User CurrentUser;

        public App()
        {
            InitializeComponent();


            //BaseDatabase.Current.CreateTableAsync();
            Device.SetFlags(new[] {
                "IndicatorView_Experimental"
            });

            bool isLoggedIn = Current.Properties.ContainsKey("IsLoggedIn") ? Convert.ToBoolean(Current.Properties["IsLoggedIn"]) : false;

            if (!isLoggedIn)
            {
                //Load if Not Logged In
                MainPage = new Login();
            }
            else
            {
                //Load if Logged In
                getUserDetail();
                MainPage = new HomePage();
            }

            // MainPage = new Login();

        }

        private async void getUserDetail()
        {
            User.Id = await SecureStorage.GetAsync("userID");
            User.Name = await SecureStorage.GetAsync("userName");
            User.Email = await SecureStorage.GetAsync("userEmail");
            User.Picture = await SecureStorage.GetAsync("userPicture");
        }


        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
