using FrondEndXamarin.Services;
using System;
using System.Collections.Generic;
using System.Text;
using FrondEndXamarin.Model;
using System.Windows.Input;
using Xamarin.Forms;
using FrondEndXamarin.Views;

namespace FrondEndXamarin.ViewModels
{
    
    public class Register
    {
        private RegisterBindingModel registerBindingModel = new RegisterBindingModel();
        ApiService apiService = new ApiService();

       
        public string EmailAddress { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
        public string MobileNO { get; set; }

        public string Message { get; set; }

        public ICommand RegisterCommand
        {
            get
            {
                return new Command(async() =>
                {
                   var isSuccess = await apiService.RegisterAsync(Title, FirstName, Surname, EmailAddress, Password,MobileNO);
                    
                    if(isSuccess)
                    {
                        await App.Current.MainPage.DisplayAlert("You have successfully registered.", "", "ok");
                        await Application.Current.MainPage.Navigation.PushAsync(new HomePage());
                    }
                    else
                    {
                        await App.Current.MainPage.DisplayAlert("Registration failed.", "", "ok");
                    }
                });
            }
        }
    }
}
