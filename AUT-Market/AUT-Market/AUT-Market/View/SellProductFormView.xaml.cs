using AUT_Market.Model;
using AUT_Market.Service;
<<<<<<< HEAD
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
=======
using Newtonsoft.Json;
using Plugin.Media;
using Plugin.Permissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
>>>>>>> Oliver
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

<<<<<<< HEAD
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

=======
        private void doneBtn_Clicked(object sender, EventArgs e)
        {
            int IsValidInput = valid.CheckValidInput(titleInput.Text, authorInput.Text, editionInput.Text,courseCodeInput.Text, priceInput.Text, descInput.Text);
            if (IsValidInput == -1)
            {
                if (valid.CheckSelectDateIsBeforeToday(publicationDateInput.Date))
                {
                    if (facultySelection.SelectedItem != null)
                    {
                        if (conditionSelection.SelectedItem != null){
                            this.completeForm();
                        }
                        else{
                            // if not select then will pop up display of msg.
                            DisplayAlert("Condition is Missing", "Please select the condition", "OK");
                        }
>>>>>>> Oliver
                    }
                    else
                    {
                        // if not select then will pop up display of msg.
                        DisplayAlert("Faculty is missing", "Please select the Faculty", "OK");
                    }
                }
                else
                {
<<<<<<< HEAD
                    // if user input future date then this will pop up display of msg.
=======
>>>>>>> Oliver
                    DisplayAlert("Publication Date Invalid", "Publication Date cannot been in the future. Please selection Date", "OK");
                }
            }
            else
            {
                //This method will pop up display of invalid input.
                invalidMsgDisplayAlert(IsValidInput);
            }
<<<<<<< HEAD


        }

        //-------------------------------------------------------------------------------------------------------------------------------------//

        //This is when valid check is invalid then function pass the num of type which is invliad will pop up display invalid input. 
=======
        }
>>>>>>> Oliver
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
<<<<<<< HEAD

=======
>>>>>>> Oliver
                default:
                    break;
            }
        }

<<<<<<< HEAD
        //-------------------------------------------------------------------------------------------------------------------------------------//

        //This method will save the detail and store in database
        // This method is waiting when the database is complete set then will start store in it.
        private void completeForm()
        {
            DisplayAlert("Complate", "Your Book will post on the list soon", "OK");
        }

        //-------------------------------------------------------------------------------------------------------------------------------------//
=======
        private async void completeForm()
        {
            var model = new TestBooks {
                imageUrl = "https://d1w7fb2mkkr3kw.cloudfront.net/assets/images/book/lrg/9781/1188/9781118881170.jpg",
                title = titleInput.Text,
                author = authorInput.Text,
                publicationDateStr= DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                faculty = facultySelection.SelectedItem.ToString(),
                courseCode = courseCodeInput.Text,
                price = Convert.ToDouble(priceInput.Text),
                bookCondition = conditionSelection.SelectedItem.ToString(),
                BookDesc = descInput.Text.Trim()
            };
            model.BooksImgs = JsonConvert.SerializeObject(imagePaths);
            System.Diagnostics.Debug.WriteLine(JsonConvert.SerializeObject(model));
            var result= await BaseDatabase.Current.UpdateBook(model);
            await DisplayAlert("Complate", "Your Book will post on the list soon"+ result, "OK");
        }
        List<string> imagePaths = new List<string>();
        private async void BtnAddImageAsync(object sender,EventArgs e){
            var path = await getphoto();
            if (!string.IsNullOrEmpty(path)) {
                imagePaths.Add(path);
                loadGridData(path);
            }
        }
        void loadGridData(string item){
            AbsoluteLayout absoluteLayout = new AbsoluteLayout { HeightRequest = 100, WidthRequest = 100, Margin = new Thickness(0, 0, 5, 5) };
            absoluteLayout.BindingContext = imagePaths.Where(a => a== item).ToList().FirstOrDefault();

            Image image1 = new Image { Aspect = Aspect.AspectFill, HeightRequest = 100, WidthRequest = 100 };
            image1.Source = ImageSource.FromFile(item);
            absoluteLayout.Children.Add(image1);

            ImageButton image2 = new ImageButton { Source = "iconclose", HeightRequest = 20, WidthRequest = 20, Margin = new Thickness(85, -8, 0, 0) };
            image2.BindingContext = absoluteLayout;
            image2.Clicked+=delegate {
                imagePaths.Remove(item);
                var abs = (AbsoluteLayout)image2.BindingContext;
                flexlay.Children.Remove(abs);
            };
            absoluteLayout.Children.Add(image2);
            flexlay.Children.Add(absoluteLayout);
        }
        async Task<string> getphoto() {

            await CrossMedia.Current.Initialize();
            if (!CrossMedia.Current.IsPickPhotoSupported) return null;
            var photosStatus = await CrossPermissions.Current.CheckPermissionStatusAsync(Plugin.Permissions.Abstractions.Permission.Photos);
            if (photosStatus != Plugin.Permissions.Abstractions.PermissionStatus.Granted)
            {
                
                var results = await CrossPermissions.Current.RequestPermissionsAsync(Plugin.Permissions.Abstractions.Permission.Photos);
                photosStatus = results[Plugin.Permissions.Abstractions.Permission.Photos];
            }
            if (photosStatus == Plugin.Permissions.Abstractions.PermissionStatus.Granted)
            {
                var file = await CrossMedia.Current.PickPhotoAsync();
                if (file != null)
                {
                    string path = file.Path;
                    file.Dispose();
                    return path;
                }
            }
            return null;
        }
>>>>>>> Oliver
    }
}