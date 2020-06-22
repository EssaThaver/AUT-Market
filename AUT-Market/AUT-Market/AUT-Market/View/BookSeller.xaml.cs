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

    //------------------------------------------------------------------------------------------------------------------------------------//
    public partial class BookSeller : ContentPage
    {
        BookSellerViewModel vm;
        string EmailAddress;

        //------------------------------------------------------------------------------------------------------------------------------------//
        public BookSeller(string emailaddress)
        {
            InitializeComponent();
            EmailAddress = emailaddress;
            vm = new BookSellerViewModel(Navigation);
            BindingContext = vm;
        }
        //------------------------------------------------------------------------------------------------------------------------------------//
        protected override void OnAppearing()
        {
            base.OnAppearing();
            vm?.getChildData.Execute(EmailAddress);
        }
    }
}