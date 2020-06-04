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
    public partial class RemoveBook : ContentPage
    {
        TestBooksViewModel vm;
        public RemoveBook()
        {
            InitializeComponent();

            vm = new TestBooksViewModel(Navigation);
            vm.getUserBook();
            BindingContext = vm;
        }

        private async void Remove_Clicked(object sender, EventArgs e)
        {
            var check = await DisplayAlert("Warning", "Are you Sure? ", "Yes", "No");

            if (check)
            {
                var removeBtn = sender as ImageButton;

                var book = removeBtn?.BindingContext as Book;

                int result= BooksDb.RemoveBook(book);
                if (result > 0) {
                    vm?.RemoveBook.Execute(book);
                }
            }
        }
    }
}