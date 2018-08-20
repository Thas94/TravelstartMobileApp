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
    public class BookSeatModelView
    {
        ApiService apiService = new ApiService();
        public int userID { get; set; }
        public int seatNO { get; set; }

        public TravellerModel traveller { get; set; }

        public ICommand BookSeatCoomand
        {
        
        get
            {
                return new Command(async () =>
                {
                    
                    /*\var isSuccess = await apiService.InsertSeatNO(Int32.Parse(Settings.bookSeatID), Settings.seatNO);
                    try
                    {
                        if (isSuccess)
                        {
                            await App.Current.MainPage.DisplayAlert("You have successfully inserted traveller", "", "OK");
                            await Application.Current.MainPage.Navigation.PushAsync(new PaymentPage());
                        }
                    }
                    catch(Exception ex)
                    {
                        await App.Current.MainPage.DisplayAlert("Failed." + ex, "", "ok");
                    }*/
                });
            }
        }
   
    }
}
