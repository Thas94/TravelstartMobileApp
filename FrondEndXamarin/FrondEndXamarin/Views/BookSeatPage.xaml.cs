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
	public partial class BookSeatPage : ContentPage
	{
        ApiService apiService = new ApiService();
        List<TravellerModel> travellers;

        List<SeatsModel> seats = new List<SeatsModel>()
        {
            new SeatsModel(){seatA="01A",seatB="01B",seatC="01C"},
            new SeatsModel(){seatA="02A",seatB="02B",seatC="02C"},
            new SeatsModel(){seatA="03A",seatB="03B",seatC="03C"},
            new SeatsModel(){seatA="04A",seatB="04B",seatC="04C"},
            new SeatsModel(){seatA="05A",seatB="05B",seatC="05C"},
            new SeatsModel(){seatA="06A",seatB="06B",seatC="05C"},
            new SeatsModel(){seatA="07A",seatB="07B",seatC="07C"},
            new SeatsModel(){seatA="08A",seatB="08B",seatC="08C"},
            new SeatsModel(){seatA="09A",seatB="09B",seatC="09C"},
            new SeatsModel(){seatA="10A",seatB="10B",seatC="10C"}
        };
        List<string> name;
        List<string> Sname;
        int index;
        int nameIndex;
        int count = 0;
        string searchN;
        string searchS;
        int travellerID;
        string seat;

        public BookSeatPage ()
		{
			InitializeComponent ();

            name = Settings.nameTrav;
            Sname = Settings.surnTrav;


            for(int i = 0; i < name.Count;i++)
            {
                details.Items.Add(name[i] + " " + Sname[i]);
            }
            


            for(int i = 0;i < seats.Count;i++)
            {
                seatA.Items.Add(seats[i].seatA);
          
            }

          
    }

        private async void details_SelectedIndexChanged(object sender, EventArgs e)
        {
            index = 0;
            if (index == 0)
            {
                nameIndex = details.SelectedIndex;
            }
          
            searchN = name[details.SelectedIndex];
            searchS = Sname[details.SelectedIndex];

            travellers = await apiService.GetTravellers(searchN, searchS);
          
            travellerID = travellers[details.SelectedIndex].userID;
          
        }

        private void seatA_SelectedIndexChanged(object sender, EventArgs e)
        {

            seat = seatA.Items[seatA.SelectedIndex];
            nameIndex = 0;
            if(nameIndex == 0)
            {
                index = seatA.SelectedIndex;
            }
            
        }


        private async void Button_Clicked(object sender, EventArgs e)
        {
            Settings.bookSeatID = travellerID.ToString();
            Settings.seatNO = seat;
            //seats.RemoveAt(index);
            //seatA.Items.RemoveAt(index);
            //seatA.SelectedIndex = -1;

            //details.Items.RemoveAt(details.SelectedIndex);
            //details.SelectedItem = string.Empty;

            //await apiService.InsertSeatNO(travellerID,seat);
            count++;

            PutSeat();

            if (count == name.Count)
            {
               await Navigation.PushAsync(new PaymentPage());
            }

        
        }

        public async void PutSeat()
        {

            TravellerModel travellerModel;

            travellerModel = new TravellerModel
            {
                userID = Convert.ToInt32(Settings.bookSeatID),
                seatNO = Settings.seatNO,
                FirstName = travellers[details.SelectedIndex].FirstName,
                Surname = travellers[details.SelectedIndex].Surname,
                DOB = travellers[details.SelectedIndex].DOB,
                Title = travellers[details.SelectedIndex].Title,
                MiddleName = travellers[details.SelectedIndex].MiddleName,
                payID = null
            };

            var res = await apiService.PutSeatNO(travellerModel.userID, travellerModel);
            try
            {
                if (count == name.Count)
                {
                    await App.Current.MainPage.DisplayAlert("You have successfully inserted traveller", "", "OK");
                    await Application.Current.MainPage.Navigation.PushAsync(new PaymentPage());
                }
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Failed." + ex, "", "ok");
            }

        }
    }
}