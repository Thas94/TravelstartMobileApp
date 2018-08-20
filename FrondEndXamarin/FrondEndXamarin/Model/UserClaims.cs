using System;
using System.Collections.Generic;
using System.Text;

namespace FrondEndXamarin.Model
{
    public class UserClaims
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string LoggedOn { get; set; }
    }
}
