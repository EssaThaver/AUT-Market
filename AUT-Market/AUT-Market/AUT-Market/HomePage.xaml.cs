using AUT_Market.Service;
using AUT_Market.View;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AUT_Market
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : Shell
    {
        public HomePage()
        {
            InitializeComponent();
            DisplayAlert("Hello", "Hello, " + User.Name, "OK");
        }

        private void logout_Clicked(object sender, System.EventArgs e)
        {
            Application.Current.Properties["IsLoggedIn"] = Boolean.FalseString;
            SecureStorage.RemoveAll();
            Application.Current.MainPage = new Login();
        }


    }
}