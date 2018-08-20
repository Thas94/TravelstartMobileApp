using FrondEndXamarin.Helpers;
using FrondEndXamarin.Model;
using FrondEndXamarin.Services;
using FrondEndXamarin.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace FrondEndXamarin.ViewModels
{
    class HomeViewModel
    {
        private ApiService apiService = new ApiService();

        public List<Cities> cities { get; set; }

        public ICommand SearchCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var results = await apiService.GetFlightDetails(Settings.deptCity,Settings.arrCity,Settings.date);

                    if (results.Count > 0)
                    {
                        await App.Current.MainPage.DisplayAlert("You are being directed to the next page", "", "ok");
                        await Application.Current.MainPage.Navigation.PushAsync(new FlightResultsView());
                    }
                    else
                    {
                        await App.Current.MainPage.DisplayAlert("No flights from " +Settings.deptCity+" to " + Settings.arrCity+ ", please try again", "", "ok");
                    }
                });
            }
        }
    }
}
