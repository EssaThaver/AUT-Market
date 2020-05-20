using AUT_Market.Model;
using AUT_Market.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AUT_Market.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SellProductFormView : ContentPage
    {
        SellProductValidation valid = new SellProductValidation();

        public SellProductFormView()
        {
            InitializeComponent();

            facultySelection.ItemsSource = new Faculties().getListOfFaculty();
            conditionSelection.ItemsSource = new Conditions().getlistOfCondition();
        }

        //-------------------------------------------------------------------------------------------------------------------------------------//

        // This when user complete the form the this method to proccess to check aall input to validation to make sure there are no dumb/ invalid input.
        private void doneBtn_Clicked(object sender, EventArgs e)
        {
            // This fuction to check all input are not null and white. Also, some input have number input then this fuction will check number is double.. 
            int IsValidInput = valid.CheckValidInput(titleInput.Text, authorInput.Text, editionInput.Text,courseCodeInput.Text, priceInput.Text, descInput.Text);

            //-------------------------------------------------------------------------------------------------------------------------------------//

            
            if (IsValidInput == -1)
            {
                //This method is check to make the input date is before today.
                if (valid.CheckSelectDateIsBeforeToday(publicationDateInput.Date))
                {
                    //This valid to check make sure user have select it.
                    if (facultySelection.SelectedItem != null)
                    {
                        //This valid to check make sure user have select it.
                        if (conditionSelection.SelectedItem != null)
                        {
                            this.completeForm();
                        }
                        else
                        {
                            // if not select then will pop up display of msg.
                            DisplayAlert("Condition is Missing", "Please select the condition", "OK");
                        }

                    }
                    else
                    {
                        // if not select then will pop up display of msg.
                        DisplayAlert("Faculty is missing", "Please select the Faculty", "OK");
                    }
                }
                else
                {
                    // if user input future date then this will pop up display of msg.
                    DisplayAlert("Publication Date Invalid", "Publication Date cannot been in the future. Please selection Date", "OK");
                }
            }
            else
            {
                //This method will pop up display of invalid input.
                invalidMsgDisplayAlert(IsValidInput);
            }


        }

        //-------------------------------------------------------------------------------------------------------------------------------------//

        //This is when valid check is invalid then function pass the num of type which is invliad will pop up display invalid input. 
        private void invalidMsgDisplayAlert(int InvalidType)
        {
            switch (InvalidType)
            {
                case 0:
                    DisplayAlert("Title missing", "Please Input the Title", "OK");
                    break;

                case 1:
                    DisplayAlert("Author missing", "Please Input the Author", "OK");
                    break;

                case 2:
                    DisplayAlert("Edition mission", "Please Input number the Edition", "OK");
                    break;

                case 3:
                    DisplayAlert("Course Code missing", "Please Input the Course Code", "OK");
                    break;

                case 4:
                    DisplayAlert("Price missing", "Please Input number the Price", "OK");
                    break;

                case 5:
                    DisplayAlert("description mission", "Please Input the Description", "OK");
                    break;

                default:
                    break;
            }
        }

        //-------------------------------------------------------------------------------------------------------------------------------------//

        //This method will save the detail and store in database
        // This method is waiting when the database is complete set then will start store in it.
        private void completeForm()
        {
            DisplayAlert("Complate", "Your Book will post on the list soon", "OK");
        }

        //-------------------------------------------------------------------------------------------------------------------------------------//
    }
}