using FrondEndXamarin.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using FrondEndXamarin.Helpers;
using System.Text;
using System.Threading.Tasks;

namespace FrondEndXamarin.Services
{
    public class ApiService
    {
        string url = "http://192.168.2.116:45455/";

        internal async Task <bool> RegisterAsync(string title, string lastname, string firstname, string email, string password, string mobileNo)
        {
            var client = new HttpClient();
            

            var model = new RegisterBindingModel()
            {
                Title = title,
                Surname = firstname,
                FirstName = lastname,
                MobileNO = mobileNo,
                EmailAddress = email,
                Password = password,
            };

            var json = JsonConvert.SerializeObject(model);

            HttpContent content = new StringContent(json);

            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

           var response = await client.PostAsync(url + "api/UserInfo", content);

            return response.IsSuccessStatusCode;
        }

        public async Task <String> LoginAsync(string username,string password)
        {
            var keyValues = new List<KeyValuePair<string, string >>
            {
                new KeyValuePair<string, string>("username",username),
                new KeyValuePair<string, string>("password",password),
                new KeyValuePair<string, string>("grant_type","password")
            };

            var request = new HttpRequestMessage(HttpMethod.Post, "http://192.168.2.116:45457/token");

            request.Content = new FormUrlEncodedContent(keyValues);

            var client = new HttpClient();
            var response = await client.SendAsync(request);

            var content = await response.Content.ReadAsStringAsync();
            var dyna = JObject.Parse(content);
            var accessToken = dyna.Value<string>("access_token");
            Debug.WriteLine(content);

            return accessToken;
        }

        public async Task<List<Cities>> GetUserClaims()
        {
            var client = new HttpClient();
            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Authorization","bearer "+ Settings.accessToken);

            var response = await client.GetStringAsync("http://192.168.2.116:45455/api/FlightServices");
            var cities = JsonConvert.DeserializeObject<List<Cities>>(response);
            Debug.WriteLine(cities);
            return cities;
        }

        public async Task<List<Cities>> GetCities()
        {
            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync(url + "api/FlightServices");
            var cities = JsonConvert.DeserializeObject<List<Cities>>(response);
            //CitiesView.ItemsSource = cities;
            return cities;
        }

        public async Task<List<FlightSearchDetails>> GetFlightDetails(string dp,string arr,string dd)
        {
            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync(url + "api/FlightDetails?dp=" + dp + "&ar=" + arr + "&dd=" + dd);
            var results = JsonConvert.DeserializeObject<List<FlightSearchDetails>>(response);
            //CitiesView.ItemsSource = cities;
            return results;
        }

        internal async Task<bool> InsertTraveller(string title, string firstname, string middlename,  string email, string surname,string DOB)
        {
          
            var client = new HttpClient();
            

            var model = new TravellerModel()
            {
                Title = title,
                Surname = surname,
                FirstName = firstname,
                MiddleName = middlename,
                Email = email,
                DOB = DOB,
            };

            var json = JsonConvert.SerializeObject(model);

            HttpContent content = new StringContent(json);

            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            var response = await client.PostAsync(url + "api/FlightUsers1", content);

            return response.IsSuccessStatusCode;
        }

        public async Task<List<TravellerModel>> GetTravellers(string dp, string arr)
        {
            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync(url + "api/FlightUsers1?fn=" + dp + "&sn=" + arr);
            var results = JsonConvert.DeserializeObject<List<TravellerModel>>(response);
            return results;
        }

        public async Task<bool> PutSeatNO(int id,TravellerModel traveller)
        {
            var client = new HttpClient();

            var json = JsonConvert.SerializeObject(traveller);

            HttpContent content = new StringContent(json);

            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await client.PutAsync(url + "api/FlightUsers1/" + id, content);

              return response.IsSuccessStatusCode;
        }

        internal async Task<bool> Payment(string firstname, string surname, string cardType, string cardNumber, string secuCode)
        {
            var client = new HttpClient();


            var model = new PaymentModel()
            {
                Surname = surname,
                FirstName = firstname,
                CardType = cardType,
                SecurityCode = secuCode,
                CardNumber = cardNumber,
                Date = Settings.date,
                Price = Settings.price
            };

            var json = JsonConvert.SerializeObject(model);

            HttpContent content = new StringContent(json);

            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            var response = await client.PostAsync(url + "api/Payments2", content);

            return response.IsSuccessStatusCode;
        }

        public async Task<List<RegisterBindingModel>> GetUsers()
        {
            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync(url + "api/UserInfo");
            var cities = JsonConvert.DeserializeObject<List<RegisterBindingModel>>(response);
            //CitiesView.ItemsSource = cities;
            return cities;
        }
    }
}
