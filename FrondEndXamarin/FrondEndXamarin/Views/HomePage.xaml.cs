using FrondEndXamarin.Helpers;
using FrondEndXamarin.Model;
using FrondEndXamarin.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FrondEndXamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {

        private ApiService apiService = new ApiService();

     
        public HomePage ()
		{
			InitializeComponent ();

        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            List<Cities> cities = await apiService.GetCities();
            List<Cities> citye = new List<Cities>();
            Cities city;
            for(int i = 0;i < cities.Count;i++)
            {
                city = new Cities
                {  
                    DeptCity = cities[i].DeptCity,
                    ArrCity = cities[i].ArrCity,
                };

                DepartCity.Items.Add(cities[i].DeptCity);
                ArrCity.Items.Add(cities[i].ArrCity);
                citye.Add(city);

            }

        }

        private void DepartCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            var departC = DepartCity.Items[DepartCity.SelectedIndex];
            Settings.deptCity = departC;
        }

        private void ArrCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            var arrC = ArrCity.Items[ArrCity.SelectedIndex];
            Settings.arrCity = arrC;
        }
    

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            var t = Travellers.Text;
            
            Settings.noTravellers = t;
        }

        private void DeptDate_DateSelected(object sender, DateChangedEventArgs e)
        {
            string date = e.NewDate.ToString();

            var newDate = date.Remove(8);

            var sp = newDate.Split('/');
            string dDate = sp[2] +"-" + sp[0] + "-" + sp[1];
            Settings.date = dDate;
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegisterPage());
        }

        private void ToolbarItem_Clicked_1(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LoginPage());
        }
    }
}