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
	public partial class RegisterPage : ContentPage
	{
		public RegisterPage ()
		{
			InitializeComponent ();
		}


        private void Button_Clicked_1(object sender, EventArgs e)
        {
            Settings.userEmail = Email.Text;
            Settings.UserPassword = Password.Text;
            Application.Current.MainPage = new LoginPage();
        }
    }
}