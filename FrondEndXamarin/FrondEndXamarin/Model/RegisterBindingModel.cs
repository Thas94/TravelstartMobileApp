using System;
using System.Collections.Generic;
using System.Text;

namespace FrondEndXamarin.Model
{
    public class RegisterBindingModel
    {
        public int UserID { get; set; }
        public string EmailAddress { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
        public string MobileNO { get; set; }
    }
}
