using AUT_Market.Model;
using AUT_Market.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

/** This is my books page and this is display is my book that is very current selling. User able to control 
 *  their book by using edit the book detail, price change, or remove the book from the list. 
 *  @author by Karan Patel 15900950
 */


namespace AUT_Market.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyBooks : ContentPage
    {
        BooksViewModel vm;
        Validation valid;

        //----------------------------------------------------------------------------------------------------------------------------------------------------//

        // This is inital to setup the list of the books to display it.
        public MyBooks()
        {
            InitializeComponent();

            vm = new BooksViewModel(Navigation);

            vm.getUserBook();

            BindingContext = vm;


        }

        //----------------------------------------------------------------------------------------------------------------------------------------------------//

        //This remove function is when user click the remove button then the book will remove from the list and database. 
        private async void Remove_Clicked(object sender, EventArgs e)
        {
            var check = await DisplayAlert("Warning", "Are You Sure? ", "Yes", "No");

            if (check)
            {
                //This comment statement below that will hold to the next sprint becuase this feature not fully complete. That will add in new version in later
                //var reason = await DisplayActionSheet("Reason", null, null, "Sold", " I Changed My Mind"," No Buyers","Faulty");


                var removeBtn = sender as Button;

                var book = removeBtn?.BindingContext as Book;

                BooksDb.RemoveBook(book /*,reason*/);

                vm?.RemoveBook.Execute(book);
            }
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------------//

        //This edit function is when user click edit then book detail display and user edit and modify the detail of the book. 
        private void Edit_Clicked(object sender, EventArgs e)
        {
            var editBtn = sender as Button;

            var book = editBtn?.BindingContext as Book;

            Navigation.PushModalAsync(new SellProductFormView(book));
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------------//
         
        // This is price change fuction is when user click the price change then display will pop up and user will input new price value then display will change to new price.
        private async void priceChange_Clicked(object sender, EventArgs e)
        {
            var priceBtn = sender as Button;

            var book = priceBtn?.BindingContext as Book;

            string newPrice = await DisplayPromptAsync("Price Change", "New Price", keyboard: Keyboard.Numeric);

            if (!String.IsNullOrWhiteSpace(newPrice))
            {

                this.changePrice(newPrice, book);
            }
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------------//

        //This is price change method to display the new price and update the database too. 
        private void changePrice(string newPrice, Book book)
        {
            valid = new Validation();

            if (valid.CheckStringToFloat(newPrice) && !(String.IsNullOrWhiteSpace(newPrice)))
            {
                book.Price = newPrice;

                BooksDb.PriceChange(book);
            }

            vm = new BooksViewModel(Navigation);
            vm.getUserBook();
            BindingContext = vm;

        }

        //----------------------------------------------------------------------------------------------------------------------------------------------------//

    }
}