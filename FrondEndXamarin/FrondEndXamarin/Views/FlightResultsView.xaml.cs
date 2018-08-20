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
    public partial class FlightResultsView : ContentPage
    {
        private ApiService apiService = new ApiService();
        public FlightResultsView()
        {
            InitializeComponent();
           
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var results = await apiService.GetFlightDetails(Settings.deptCity, Settings.arrCity,Settings.date);
            FlightView.ItemsSource = results;
        }

        private async void FlightView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var flight = e.Item as FlightSearchDetails;

            Settings.deptC = flight.DeptCity;
            Settings.deptD = flight.DeptDate;
            Settings.deptT = flight.DeptTime;

            Settings.arrC = flight.ArrCity;
            Settings.arrD = flight.ArrDate;
            Settings.arrT = flight.ArrTime;

            Settings.airline = flight.Airline;
            Settings.airportN = flight.AirportName;
            Settings.price = flight.Price;

            Settings.cabin = flight.Cabin;
            Settings.stops = flight.Stops;
            Settings.FlightID = flight.FlightID;

            Settings.airLpic = flight.AirlinePicName;
            Settings.totTime = flight.TotTime;

            if( await DisplayAlert("Flight Selected", "Price p.person R" + flight.Price 
                + ", Cabin: " + flight.Cabin 
                + ", Travel Time" + flight.TotTime, 
                "Continue","Cancel"))
            {
                await Navigation.PushAsync(new TravellerPage());
                //Application.Current.MainPage = new RegisterPage();
            }

            //await DisplayAlert()
        }
    }
}