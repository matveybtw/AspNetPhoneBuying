using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspPhoneBuying.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int PhoneId { get; set; }
        public Phone Phone { get; set; }
    }
}