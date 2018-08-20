using FrondEndXamarin.Helpers;
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
	public partial class TicketPage : ContentPage
	{
        List<string> name;
        List<string> Sname;
        public TicketPage ()
		{
			InitializeComponent ();

            name = Settings.nameTrav;
            Sname = Settings.surnTrav;


            for (int i = 0; i < name.Count; i++)
            {
                TravellerName.Text = ("Traveller Name: "+ " " +name[i] + " " + Sname[i]);
                dCity.Text = "Departure City: " + Settings.deptC;
                aCity.Text = "Arrival City: " + Settings.arrC;
                aDate.Text = "Arrival Date: " + Settings.arrD;
                aTime.Text = "Arrival Time: " + Settings.arrT;
                dDate.Text = "Departure Date: " + Settings.deptD;
                dTime.Text = "Departure Time: " + Settings.deptT;
                time.Text = "Total Travel Time: " + Settings.totTime;
                cabin.Text = "Cabin: " + Settings.cabin;
                seatNO.Text = "seat Number: " + Settings.seatNO;
            }

        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new HomePage());
        }
    }
}