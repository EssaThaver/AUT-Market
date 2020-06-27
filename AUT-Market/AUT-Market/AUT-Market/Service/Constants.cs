using System;
using System.Collections.Generic;
using System.Text;

namespace AUT_Market.Service
{
    public class Constants
    {
        public static string AppName = "Constants";

        //For Google login confiugre at https://console.developers.google.com/
        public static string iOSClientId = "<insert IOS client ID here>";
        public static string AndroidClientId = "1089706656019-q0dgfmlvl5trfdto620ttai38thjljr4.apps.googleusercontent.com";

        public static string Scope = "https://www.googleapis.com/auth/userinfo.email https://www.googleapis.com/auth/userinfo.profile";
        public static string AuthorizeUrl = "https://accounts.google.com/o/oauth2/auth"; //Google Authoriztion Link
        public static string AccessTokenUrl = "https://www.googleapis.com/oauth2/v4/token"; // Access Token for the Auth 
        public static string UserInfoUrl = "https://www.googleapis.com/oauth2/v2/userinfo"; // Gets the user info from google once user is logged in

        public static string iOSRedirectUrl = "<insert IOS redirect URL here>:/oauth2redirect";
        public static string AndroidRedirectUrl = "com.googleusercontent.apps.1089706656019-q0dgfmlvl5trfdto620ttai38thjljr4:/oauth2redirect"; 
    }
}
