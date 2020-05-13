using AUT_Market.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AUT_Market.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SellProductFormView : ContentPage
    {
        

        public SellProductFormView()
        {
            InitializeComponent();

            facultySelection.ItemsSource = new Faculties().getListOfFaculty();
            conditionSelection.ItemsSource = new Conditions().getlistOfCondition();
        }

        //-------------------------------------------------------------------------------------------------------------------------------------//

        //This picker box (combobox) function
        private void form_Completed(object sender, EventArgs e)
        {
            this.validationCheckInput();
        }

        //-------------------------------------------------------------------------------------------------------------------------------------//

        //This entry box (inputbox) function 
        private void entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.validationCheckInput();
        }

        //-------------------------------------------------------------------------------------------------------------------------------------//

        //This is date picker function 
        private void DatePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            this.validationCheckInput();
        }

        //-------------------------------------------------------------------------------------------------------------------------------------//

        //This validation check to make sure all the input are filled. if not fill in some input then sell buttion will disable.
        private void validationCheckInput()
        {
            //-------------------------------------------------------------------------------------------------------------------------------------//

            // This is validation check input make sure there no null and no whitespace.
            if (!(String.IsNullOrWhiteSpace(titleInput.Text)) && !(String.IsNullOrWhiteSpace(authorInput.Text)) && !(String.IsNullOrWhiteSpace(descInput.Text))
                && !(String.IsNullOrWhiteSpace(editionInput.Text)) && !(String.IsNullOrWhiteSpace(priceInput.Text)))
            {
                //-------------------------------------------------------------------------------------------------------------------------------------//

                //This is validation to check the date to make sure select date is befoe today. 
                if (publicationDateInput.Date < DateTime.Now.Date)
                {
                    sellBtn.IsEnabled = true;
                }

                //-------------------------------------------------------------------------------------------------------------------------------------//
            }
            else
            {
                sellBtn.IsEnabled = false;
            }
        }

        //-------------------------------------------------------------------------------------------------------------------------------------//
    }
}