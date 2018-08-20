using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace FrondEndXamarin.Helpers
{
    public static class Settings
    {
        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }
        #region
        private const string SettingsKey = "settings_key";
        private static readonly string SettingsDefault = string.Empty;
        #endregion

        public static string GeneralSettings
        {
            get
            {
                return AppSettings.GetValueOrDefault(SettingsKey, SettingsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(SettingsKey, value);
            }
        }

        public static string accessToken
        {
            get
            {
                return AppSettings.GetValueOrDefault("accessToken","");
            }
            set
            {
                AppSettings.AddOrUpdateValue("accessToken",value);
            }
        }

        public static string username
        {
            get
            {
                return AppSettings.GetValueOrDefault("username","");
            }
            set
            {
                AppSettings.AddOrUpdateValue("username",value);
            }
        }

        public static string password
        {
            get
            {
                return AppSettings.GetValueOrDefault("password", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("password", value);
            }
        }

        public static string deptCity
        {
            get
            {
                return AppSettings.GetValueOrDefault("deptCity", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("deptCity", value);
            }
        }

        public static string arrCity
        {
            get
            {
                return AppSettings.GetValueOrDefault("arrCity", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("arrCity", value);
            }
        }

        public static string date
        {
            get
            {
                return AppSettings.GetValueOrDefault("date", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("date", value);
            }
        }

        public static string noTravellers
        {
            get
            {
                return AppSettings.GetValueOrDefault("noTravellers", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("noTravellers", value);
            }
        }

        public static string FlightResults
        {
            get
            {
                return AppSettings.GetValueOrDefault("FlightResults", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("FlightResults", value);
            }
        }

        public static string deptC
        {
            get
            {
                return AppSettings.GetValueOrDefault("deptC", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("deptC", value);
            }
        }

        public static string deptD
        {
            get
            {
                return AppSettings.GetValueOrDefault("deptD", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("deptD", value);
            }
        }

        public static string deptT
        {
            get
            {
                return AppSettings.GetValueOrDefault("deptT", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("deptT", value);
            }
        }

        public static string arrC
        {
            get
            {
                return AppSettings.GetValueOrDefault("arrC", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("arrC", value);
            }
        }

        public static string arrD
        {
            get
            {
                return AppSettings.GetValueOrDefault("arrD", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("arrD", value);
            }
        }

        public static string arrT
        {
            get
            {
                return AppSettings.GetValueOrDefault("arrT", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("arrT", value);
            }
        }

        public static string airline
        {
            get
            {
                return AppSettings.GetValueOrDefault("airline", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("airline", value);
            }
        }

        public static string airportN
        {
            get
            {
                return AppSettings.GetValueOrDefault("airportN", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("airportN", value);
            }
        }

        public static string price
        {
            get
            {
                return AppSettings.GetValueOrDefault("price", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("price", value);
            }
        }

        public static string cabin
        {
            get
            {
                return AppSettings.GetValueOrDefault("cabin", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("cabin", value);
            }
        }

        public static string stops
        {
            get
            {
                return AppSettings.GetValueOrDefault("stops", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("stops", value);
            }
        }

        public static string FlightID
        {
            get
            {
                return AppSettings.GetValueOrDefault("FlightID", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("FlightID", value);
            }
        }

        public static string airLpic
        {
            get
            {
                return AppSettings.GetValueOrDefault("airLpic", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("airLpic", value);
            }
        }

        public static string totTime
        {
            get
            {
                return AppSettings.GetValueOrDefault("totTime", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("totTime", value);
            }
        }



        public static List<string> nameTrav
        {
            get
            {
                string value = AppSettings.GetValueOrDefault("nameTrav", "");
                List<string> myList;
                if (string.IsNullOrEmpty(value))
                    myList = new List<string>();
                else
                    myList = JsonConvert.DeserializeObject<List<string>>(value);
                return myList;
            }
            set
            {
                string listValue = JsonConvert.SerializeObject(value);
                AppSettings.AddOrUpdateValue("nameTrav", listValue);
            }
        }

        public static List<string> surnTrav
        {
            get
            {
                string value = AppSettings.GetValueOrDefault("surnTrav", "");
                List<string> myList;
                if (string.IsNullOrEmpty(value))
                    myList = new List<string>();
                else
                    myList = JsonConvert.DeserializeObject<List<string>>(value);
                return myList;
            }
            set
            {
                string listValue = JsonConvert.SerializeObject(value);
                AppSettings.AddOrUpdateValue("surnTrav", listValue);
            }
        }

        public static string bookSeatID
        {
            get
            {
                return AppSettings.GetValueOrDefault("bookSeatID", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("bookSeatID", value);
            }
        }

        public static string seatNO
        {
            get
            {
                return AppSettings.GetValueOrDefault("seatNO", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("seatNO", value);
            }
        }

        public static string userEmail
        {
            get
            {
                return AppSettings.GetValueOrDefault("userEmail", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("userEmail", value);
            }
        }

        public static string UserPassword
        {
            get
            {
                return AppSettings.GetValueOrDefault("UserPassword", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("UserPassword", value);
            }
        }

        public static string UserID
        {
            get
            {
                return AppSettings.GetValueOrDefault("UserID", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("UserID", value);
            }
        }

        public static string confirm
        {
            get
            {
                return AppSettings.GetValueOrDefault("confirm", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("confirm", value);
            }
        }
    }
}
