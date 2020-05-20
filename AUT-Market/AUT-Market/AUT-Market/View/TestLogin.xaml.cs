using System;
<<<<<<< HEAD
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

=======
>>>>>>> Oliver
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AUT_Market.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TestLogin : ContentPage
    {
        public TestLogin()
        {
            InitializeComponent();
        }

        protected async void Button_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new HomePage();
            await Shell.Current.GoToAsync("//main");
        }
    }
}