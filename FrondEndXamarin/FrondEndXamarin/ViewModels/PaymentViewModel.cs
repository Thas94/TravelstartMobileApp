using FrondEndXamarin.Services;
using FrondEndXamarin.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace FrondEndXamarin.ViewModels
{
    public class PaymentViewModel : ContentPage
    {
        private ApiService apiService = new ApiService();

        public int bookID { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string SecurityCode { get; set; }
        public string Price { get; set; }
        public string CardType { get; set; }
        public string CardNumber { get; set; }
        public string Date { get; set; }

        public ICommand PaymentCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await Application.Current.MainPage.Navigation.PushAsync(new TicketPage());

                     /*var isSuccess = await apiService.Payment(FirstName, Surname, CardType, CardNumber, SecurityCode);

                     if (isSuccess)
                     {
                         await App.Current.MainPage.DisplayAlert("You have successfully payed", "", "ok");
                         await Application.Current.MainPage.Navigation.PushAsync(new TicketPage());

                     }
                     else
                     {
                         await App.Current.MainPage.DisplayAlert("Failed.", "", "ok");
                     }*/
                });
            }
        }
    }
}
