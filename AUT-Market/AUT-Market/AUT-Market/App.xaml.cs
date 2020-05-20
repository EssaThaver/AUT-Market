using AUT_Market;
<<<<<<< HEAD
=======
using AUT_Market.Service;
>>>>>>> Oliver
using AUT_Market.View;
using System;
using System.Threading;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AUT_Market
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

<<<<<<< HEAD
=======
            BaseDatabase.Current.CreateTableAsync();
            Device.SetFlags(new[] {
                "IndicatorView_Experimental"
            });

>>>>>>> Oliver
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
