using FrondEndXamarin.Helpers;
using FrondEndXamarin.Model;
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
	public partial class TravellerPage : ContentPage
	{
        public int count = Int32.Parse(Settings.noTravellers);
     
        public List<string> name = new List<string>();
        public List<string> Sname = new List<string>();
        public string Trvlng { get; set; }
        int cou = 0;

        public TravellerPage ()
		{
			InitializeComponent ();
            Trvlng = "Traveller: ";
        }

       

        private void Button_Clicked(object sender, EventArgs e)
        {
            string n = Firstname.Text;
            string s = Surname.Text;

            name.Add(n);
            Sname.Add(s);
            cou++;
          

            if(name.Count == count && Sname.Count == count)
            {
                Settings.nameTrav = name;
                Settings.surnTrav = Sname;
                Navigation.PushAsync(new BookSeatPage());
            }

            Reset();

        }

        public void Reset()
        {
            Title.Text = string.Empty;
            Firstname.Text = string.Empty;
            Middlename.Text = string.Empty;
            Surname.Text = string.Empty;
            DOB.Text = string.Empty;
            Email.Text = string.Empty;
        }
       
    }
}