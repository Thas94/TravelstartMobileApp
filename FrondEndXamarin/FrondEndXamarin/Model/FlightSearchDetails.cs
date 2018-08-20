using System;
using System.Collections.Generic;
using System.Text;

namespace FrondEndXamarin.Model
{
    public class FlightSearchDetails
    {
        public int IdFlight { get; set; }
        public string DeptCity { get; set; }
        public string DeptDate { get; set; }
        public string DeptTime { get; set; }
        public string ArrCity { get; set; }
        public string ArrDate { get; set; }
        public string ArrTime { get; set; }
        public string Airline { get; set; }
        public string AirportName { get; set; }
        public string Price { get; set; }
        public string Cabin { get; set; }
        public string Stops { get; set; }
        public string FlightID { get; set; }
        public string AirlinePicName { get; set; }
        public string TotTime { get; set; }
    }
}
