using AUT_Market.Model;
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
        public WishlistDetail(Book model)
        {
            InitializeComponent();
            vm = new WishlistDetailViewModel(model);
            BindingContext = vm;
            vm.getChildData();
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e){
            vm?.UpdateZan.Execute(null);
        }
    }
}