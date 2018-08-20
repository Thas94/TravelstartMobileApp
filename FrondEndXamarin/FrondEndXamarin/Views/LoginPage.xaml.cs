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
    public partial class LoginPage : ContentPage
    {
        ApiService service = new ApiService();
        List<RegisterBindingModel> cities;
        public LoginPage()
        {
            InitializeComponent();
            //USname.Text = Settings.GeneralSettings;



        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            cities = await service.GetUsers();
        
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            for (int i = 0; i < cities.Count; i++)
            {
                if (cities[i].Password == Password.Text && cities[i].EmailAddress == email.Text)
                {
                    await DisplayAlert("You have successfully logged in as ", cities[i].FirstName + " " + cities[i].Surname, "ok");
                    Settings.UserID = Convert.ToString(i);
                    Settings.confirm = "logged";
                    await Navigation.PushAsync(new HomePage());
                    break;
                }
                /*else if (cities[i].Password != Password.Text && cities[i].EmailAddress != email.Text && i == cities.Count)
                {
                    await DisplayAlert("Wrong EmailAddress or Password, please try again", "", "ok");
                }*/
            }
        }
    }
}