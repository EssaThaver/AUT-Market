﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Auth;
using Newtonsoft.Json;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using AUT_Market.Service;
using AUT_Market.View;
using System.Data.SqlClient;
using Xamarin.Essentials;

namespace AUT_Market.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        Account account;
        AccountStore store;

        public Login()
        {
            InitializeComponent();
            store = AccountStore.Create();
        }
        //When user clicks the googel sign in button
        private async void signinGoogle_Clicked(System.Object sender, System.EventArgs e)
        {
            string clientId = null;
            string redirectUrl = null;

            switch (Device.RuntimePlatform)
            {
                case Device.Android:
                    clientId = Constants.AndroidClientId;
                    redirectUrl = Constants.AndroidRedirectUrl;
                    break;
            }

            account = store.FindAccountsForService(Constants.AppName).FirstOrDefault();

            var authenticator = new OAuth2Authenticator(
                clientId,
                null,
                Constants.Scope,
                new Uri(Constants.AuthorizeUrl),
                new Uri(redirectUrl),
                new Uri(Constants.AccessTokenUrl),
                null,
                true);

            authenticator.Completed += OnAuthCompleted;
            authenticator.Error += OnAuthError;

            AuthenticationState.Authenticator = authenticator;

            var presenter = new Xamarin.Auth.Presenters.OAuthLoginPresenter();
            presenter.Login(authenticator);

        }
        //When Auth is completed
        async void OnAuthCompleted(object sender, AuthenticatorCompletedEventArgs e)
        {
            var authenticator = sender as OAuth2Authenticator;
            if (authenticator != null)
            {
                authenticator.Completed -= OnAuthCompleted;
                authenticator.Error -= OnAuthError;
            }

            User user = null;
            if (e.IsAuthenticated)
            {
                var request = new OAuth2Request("GET", new Uri(Constants.UserInfoUrl), null, e.Account);
                var response = await request.GetResponseAsync();
                if (response != null)
                {
                    string userJson = await response.GetResponseTextAsync();
                    user = JsonConvert.DeserializeObject<User>(userJson);
                }
                if (account != null)
                {
                    store.Delete(account, Constants.AppName);
                }
                await store.SaveAsync(account = e.Account, Constants.AppName);
                try
                {
                    UsersDb.AddUser(user);
                }
                catch (SqlException ex)
                { }
                App.CurrentUser = user;
            }

            // Information of the user we get and use
            Application.Current.Properties["IsLoggedIn"] = Boolean.TrueString;
            await SecureStorage.SetAsync("userID", User.Id);
            await SecureStorage.SetAsync("userName", User.Name);
            await SecureStorage.SetAsync("userEmail", User.Email);
            await SecureStorage.SetAsync("userPicture", User.Picture);


            Application.Current.MainPage = new HomePage();
            await Shell.Current.GoToAsync("//main");
        }




         // Error message if we get an Anthentication Error
        void OnAuthError(object sender, AuthenticatorErrorEventArgs e)
        {
            var authenticator = sender as OAuth2Authenticator;
            if (authenticator != null)
            {
                authenticator.Completed -= OnAuthCompleted;
                authenticator.Error -= OnAuthError;
            }

            Debug.WriteLine("Authenticaion Error: " + e.Message);

        }

    }

}
