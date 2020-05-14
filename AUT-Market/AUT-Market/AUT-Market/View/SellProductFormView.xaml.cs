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

        private void doneBtn_Clicked(object sender, EventArgs e)
        {
            int IsValidInput = valid.CheckValidInput(titleInput.Text, authorInput.Text, editionInput.Text,courseCodeInput.Text, priceInput.Text, descInput.Text);
            
            if(IsValidInput == -1)
            {
                if (valid.CheckSelectDateIsBeforeToday(publicationDateInput.Date))
                {
                    if (facultySelection.SelectedItem != null)
                    {
                        if(conditionSelection.SelectedItem != null)
                        {
                            this.completeForm();
                        }
                        else
                        {
                            DisplayAlert("Condition is Missing", "Please select the condition", "OK");
                        }

                    }
                    else
                    {
                        DisplayAlert("Faculty is missing", "Please select the Faculty", "OK");
                    }
                }
                else
                {
                    DisplayAlert("Publication Date Invalid", "Publication Date cannot been in the future. Please selection Date", "OK");
                }
            }
            else
            {
                invalidMsgDisplayAlert(IsValidInput);
            }

        }

        //-------------------------------------------------------------------------------------------------------------------------------------//



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

        private void completeForm()
        {
            DisplayAlert("Complate", "Your Book will post on the list soon", "OK");
        }

        //-------------------------------------------------------------------------------------------------------------------------------------//
    }
}