using FrondEndXamarin.Helpers;
using Plugin.Messaging;
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
           /* var smsMessenger = CrossMessaging.Current.SmsMessenger;
            if (smsMessenger.CanSendSms)
                smsMessenger.SendSms("+27749324728", "Well hello there from Xam.Messaging.Plugin");*/


           /* var emailMessenger = CrossMessaging.Current.EmailMessenger;
            if (emailMessenger.CanSendEmail)
            {
                // Send simple e-mail to single receiver without attachments, bcc, cc etc.
                emailMessenger.SendEmail("to.plugins@xamarin.com", "Xamarin Messaging Plugin", "Well hello there from Xam.Messaging.Plugin");

                // Alternatively use EmailBuilder fluent interface to construct more complex e-mail with multiple recipients, bcc, attachments etc.
                var email = new EmailMessageBuilder()
                  .To("to.plugins@xamarin.com")
                  .Cc("cc.plugins@xamarin.com")
                  .Bcc(new[] { "bcc1.plugins@xamarin.com", "bcc2.plugins@xamarin.com" })
                  .Subject("Xamarin Messaging Plugin")
                  .Body("Well hello there from Xam.Messaging.Plugin")
                  .Build();

                emailMessenger.SendEmail(email);
            }*/
        }
    }
}