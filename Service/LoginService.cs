using AspPhoneBuying.Context;
using AspPhoneBuying.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspPhoneBuying.Service
{
    public class LoginService
    {
        private PhoneDbContext phoneDb = new PhoneDbContext("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MyPhonesDB1;Integrated Security=True;");

        public int Login(string login, string pass)
        {
            var user = phoneDb.Users.FirstOrDefault(x => x.Login == login && x.Pass == pass);
            return user == null ?-1 : user.Id;
        }

        public bool Register(User user)
        {
            var count = phoneDb.Users.Count(x => x.Login == user.Login);
            if(count >0) return false;
            phoneDb.Users.Add(user);
            phoneDb.SaveChanges();
            return true;

        }
    }
}