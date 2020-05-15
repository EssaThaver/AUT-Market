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
    public partial class RemoveBook : ContentPage
    {
        TestBooksViewModel vm;
        public RemoveBook()
        {
            InitializeComponent();

            vm = new TestBooksViewModel();
            BindingContext = vm;


        }
    }
}