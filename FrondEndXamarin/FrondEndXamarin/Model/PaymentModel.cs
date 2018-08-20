using System;
using System.Collections.Generic;
using System.Text;

namespace FrondEndXamarin.Model
{
   public  class PaymentModel
    {
        public int bookID { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string SecurityCode { get; set; }
        public string Price { get; set; }
        public string CardType { get; set; }
        public string CardNumber { get; set; }
        public string Date { get; set; }
    }
}
