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
            campusSelection.ItemsSource = new Campus().getlistOfCampus();
        }

        protected async void cancelBtn_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new HomePage();
            await Shell.Current.GoToAsync("//main");
        }

        private void doneBtn_Clicked(object sender, EventArgs e)
        {
            int IsValidInput = valid.CheckValidInput(titleInput.Text, authorInput.Text, editionInput.Text,courseCodeInput.Text, priceInput.Text, descInput.Text);
            if (IsValidInput == -1)
            {
                if (facultySelection.SelectedItem != null)
                {
                    if (campusSelection.SelectedItem != null)
                    {
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
        }
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

        private async void completeForm()
        {
            var model = new Book {
                Edition = editionInput.Text,
                Title = titleInput.Text,
                Author = authorInput.Text,
                Faculty = facultySelection.SelectedItem.ToString(),
                CourseCode = courseCodeInput.Text,
                Price = float.Parse(priceInput.Text),
                Condition = conditionSelection.SelectedItem.ToString(),
                Description = descInput.Text.Trim(),
                Campus = campusSelection.SelectedItem.ToString()
            };
            model.BooksImgs = JsonConvert.SerializeObject(imagePaths);
            if (imagePaths.Count > 0) {
                model.Photo = imagePaths[0];
            }
            //UsersDb.AddUser(new User());
            BooksDb.AddBook(model);
            await DisplayAlert("Complate", "Your Book will post on the list soon", "OK");

            Application.Current.MainPage = new HomePage();
            await Shell.Current.GoToAsync("//main");
        }
        List<string> imagePaths = new List<string>();
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
    }
}