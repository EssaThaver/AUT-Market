using AUT_Market.Model;
using AUT_Market.Service;
using Newtonsoft.Json;
using Plugin.Media;
using Plugin.Permissions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

/**
 * This is class of the sell the book form where user can fill the form to sell their book.
 * Also this class can edit and update seller's book detail. 
 * @author Karan Patel 15900950
 */

namespace AUT_Market.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SellProductFormView : ContentPage
    {
        Validation valid = new Validation();
        List<string> imagePaths = new List<string>();
        private Book updateBook;

        //-------------------------------------------------------------------------------------------------------------------------------------------------------//
        
        //This construction is initial to display the form that user able to fill it and sell thier book.
        public SellProductFormView()
        {
            InitializeComponent();

            UpdateBtn.IsVisible = false;
            doneBtn.IsVisible = true;

            facultySelection.ItemsSource = new Faculties().getListOfFaculty();
            conditionSelection.ItemsSource = new Conditions().getlistOfCondition();
            campusSelection.ItemsSource = new Campus().getlistOfCampus();
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------//

        //This construction is seller select the book from the mybook page adn edit and modify in this page. Initialise to display the current book detail.
        public SellProductFormView(Book Book)
        {
            InitializeComponent();

            updateBook = Book;

            UpdateBtn.IsVisible = true;
            doneBtn.IsVisible = false;

            facultySelection.ItemsSource = new Faculties().getListOfFaculty();
            conditionSelection.ItemsSource = new Conditions().getlistOfCondition();
            campusSelection.ItemsSource = new Campus().getlistOfCampus();

            titleInput.Text = updateBook.Title;
            authorInput.Text = updateBook.Author;
            editionInput.Text = updateBook.Edition;
            facultySelection.SelectedItem = updateBook.Faculty;
            campusSelection.SelectedItem = updateBook.Campus;
            courseCodeInput.Text = updateBook.CourseCode;
            priceInput.Text = updateBook.Price.ToString();
            conditionSelection.SelectedItem = updateBook.Condition;
            descInput.Text = updateBook.Description;
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------//

        //This is cancel function is when user click cancel button then book won't sell or update the detail. 
        protected async void cancelBtn_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new HomePage();
            await Shell.Current.GoToAsync("//main");
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------//

       // This is done function is when user complete fill the form for user want sell their book then click done button to sell their book
       //Before sell the book system need to valid check to make sure there are no null and empty input.
        private void doneBtn_Clicked(object sender, EventArgs e)
        {
            Boolean check = validCheck();

            if (check)
            {
                this.completeForm();
            }
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------//
        
        //This valid method to check all the and image to make sure there are no null and emtpy
        //Also, this pop up display to tell user which input is missing.
        private Boolean validCheck()
        {
            int IsValidInput = valid.CheckValidInput(titleInput.Text, authorInput.Text, editionInput.Text, courseCodeInput.Text, priceInput.Text, descInput.Text);
            if (IsValidInput == -1)
            {
                if (facultySelection.SelectedItem != null)
                {
                    if (campusSelection.SelectedItem != null)
                    {
                        if (conditionSelection.SelectedItem != null)
                        {
                            if (imagePaths.Count > 0)
                            {
                                return true;
                            }
                            else
                            {
                                DisplayAlert("Image is missing", "Please add the Image", "OK");
                            }
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
                        DisplayAlert("Campus is Missing", "Please select the Campus", "OK");
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
                //This method will pop up display of invalid input.
                invalidMsgDisplayAlert(IsValidInput);
            }

            return false;
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------//

        //This is display pop up method to pop up display on user screen to tell user which input is missing. 
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

        //-------------------------------------------------------------------------------------------------------------------------------------------------------//

        // This is complete form method. When valid check is comfirm then book detail will add the database and post in the list and anyone can see your book. 
        private async void completeForm()
        {
            var newBook = new Book {
                Edition = editionInput.Text,
                Title = titleInput.Text,
                Author = authorInput.Text,
                Faculty = facultySelection.SelectedItem.ToString(),
                CourseCode = courseCodeInput.Text,
                Price = priceInput.Text,
                Condition = conditionSelection.SelectedItem.ToString(),
                Description = descInput.Text.Trim(),
                Campus = campusSelection.SelectedItem.ToString()
            };
            newBook.Photo = "";
            newBook.BooksImgs = JsonConvert.SerializeObject(imagePaths);
            if (imagePaths.Count > 0) {
                newBook.Photo = imagePaths[0];
            }

            UsersDb.AddUser(new User());
            BooksDb.AddBook(newBook);
            await DisplayAlert("Complate", "Your Book will post on the list soon", "OK");

            Application.Current.MainPage = new HomePage();
            await Shell.Current.GoToAsync("//main");
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------//

        //This update function is when complete edit and click update button to update a new detail. 
        //before update system need to valid to check to make sure there no null and empty input.
        private void UpdateBtn_Clicked(object sender, EventArgs e)
        {
            Boolean check = validCheck();

            if (check)
            {
                this.completeUpdateForm();
            }
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------//

        // valid check comfirm then new update detail will update the list and database
        private async void completeUpdateForm()
        {

            updateBook.Title = titleInput.Text.Trim();
            titleInput.Text = null;

            updateBook.Author = authorInput.Text.Trim();
            authorInput.Text = null;

            updateBook.Edition = editionInput.Text.Trim();
            editionInput.Text = null;

            updateBook.CourseCode = courseCodeInput.Text.Trim();
            courseCodeInput.Text = null;

            updateBook.Faculty = facultySelection.SelectedItem.ToString();
            facultySelection.SelectedIndex = 0;

            updateBook.Condition = conditionSelection.SelectedItem.ToString();
            conditionSelection.SelectedIndex = 0;

            updateBook.Description = descInput.Text.Trim();
            descInput.Text = null;

            updateBook.Price = priceInput.Text.Trim();
            priceInput.Text = null;

            updateBook.Campus = campusSelection.SelectedItem.ToString();

            updateBook.BooksImgs = JsonConvert.SerializeObject(imagePaths);

            BooksDb.UpdateBookDetail(updateBook);

            await DisplayAlert("Complate Update", "Your Book will be update and post on the list soon", "OK");

            Application.Current.MainPage = new HomePage();
            await Shell.Current.GoToAsync("//main");

        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------//

        private async void BtnAddImageAsync(object sender,EventArgs e){
            var path = await getphoto();
            if (!string.IsNullOrEmpty(path)) {
                var dic=await BaseServer.UpdateImage(path);
                if (dic["code"] == "1000")
                {
                    Debug.WriteLine(dic["hash"]+","+ dic["key"]);
                    imagePaths.Add(dic["key"]);
                    loadGridData(path);
                }
                else {
                    Debug.WriteLine(dic["message"]);
                }
            }
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------//

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

        //-------------------------------------------------------------------------------------------------------------------------------------------------------//

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
    }
}