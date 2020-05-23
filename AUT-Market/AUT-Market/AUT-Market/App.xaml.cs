using AUT_Market;
using AUT_Market.Service;
using AUT_Market.View;
using System;
using System.Threading;
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

            MainPage = new TestLogin();
           
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
