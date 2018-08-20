using FrondEndXamarin.Services;
using FrondEndXamarin.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace FrondEndXamarin.ViewModels
{
    public class TravellerViewModel : ContentPage
    {
        ApiService apiService = new ApiService();

        public string Title { get; set; }
        public string MiddleName { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string DOB { get; set; }
       

        public ICommand TravellerCommand
        {
            get
            {
                return new Command(async () =>
                {
        
                    var isSuccess = await apiService.InsertTraveller(Title, FirstName, MiddleName, Email, Surname, DOB);

                    if (isSuccess)
                    {
                        await App.Current.MainPage.DisplayAlert("You have successfully inserted traveller", FirstName  +" " + Surname, "ok");
                    }
                    else
                    {
                        await App.Current.MainPage.DisplayAlert("Failed.", "", "ok");
                    }
                });
            }
        }
    }
}
