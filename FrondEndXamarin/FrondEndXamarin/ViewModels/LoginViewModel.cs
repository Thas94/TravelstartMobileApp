using FrondEndXamarin.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Net.Http;
using System.Windows.Input;
using Xamarin.Forms;
using FrondEndXamarin.Helpers;
using FrondEndXamarin.Views;

namespace FrondEndXamarin.ViewModels
{
    class LoginViewModel : ContentPage
    {
        private ApiService apiService = new ApiService();
        //private INavigation Navigation;

        public string Username { get; set; }
        public string Password { get; set; }
        

        public ICommand LoginCommand
        {
            get
            {
                return new Command(async() =>
                {
                    
                   /*var accessToken =  await apiService.LoginAsync(Username, Password);
                    
                    //UserClaimsViewModel  userClaimsViewModel = 

                    Settings.accessToken = accessToken;
                    Settings.username = Username;
                    Settings.password = Password;
                 
                    if (accessToken != null)
                    {
                        //var UserClaims = await apiService.GetCities();
                        await App.Current.MainPage.DisplayAlert("You have successfully logged in as ", Username, "ok");
                        //await Navigation.PushAsync(new HomePage());
                        Application.Current.MainPage = new HomePage();
                        //await App.Page.Navigation.PushAsync(new MapAndContacts());
                    }
                    else
                    {
                        await App.Current.MainPage.DisplayAlert("Wrong Username or Password, please try again", "", "ok");
                    }*/
                });
            }
        }
    }
}
