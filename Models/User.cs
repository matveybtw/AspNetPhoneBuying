using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspPhoneBuying.Models
{
    public class User
    {
        public User()
        {
            Phones = new List<Phone>();
        }

        public int Id { get; set; }
        public string Login { get; set; }
        public string Pass { get; set; }
        public string Name { get; set; }
        public virtual List<Phone> Phones { get; set; }
    }
}