using FrondEndXamarin.Helpers;
using FrondEndXamarin.Model;
using FrondEndXamarin.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FrondEndXamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UpdateUserPage : ContentPage
    {
        ApiService service = new ApiService();
        List<RegisterBindingModel> cities;
        int index = Convert.ToInt32(Settings.UserID);   
        public UpdateUserPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            cities = await service.GetUsers();

            Title.Text = cities[index - 1].Title;
            Firstname.Text = cities[index - 1].FirstName;
            Surname.Text = cities[index - 1].Surname;
            Email.Text = cities[index - 1].EmailAddress;
            Password.Text = cities[index - 1].Password;
            MobileNo.Text = cities[index - 1].MobileNO;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            updateUser();
        }

        public async void updateUser()
        {
            RegisterBindingModel register;

            register = new RegisterBindingModel
            {
                UserID = index,
                Title = Title.Text,
                FirstName = Firstname.Text,
                Surname = Surname.Text,
                EmailAddress = Email.Text,
                Password = Password.Text,
                MobileNO = MobileNo.Text
            };

            var res = await service.UpdateUser(index, register);
            if (res)
            {

                await App.Current.MainPage.DisplayAlert("You have successfully updated user", "", "OK");
                // await Application.Current.MainPage.Navigation.PushAsync(new PaymentPage());

            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Failed.", "", "ok");
            }
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new HomePage());
        }
    }
}