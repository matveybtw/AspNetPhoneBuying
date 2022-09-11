using AspPhoneBuying.Context;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace AspPhoneBuying.Filters
{
    public class PhonesFilter : FilterAttribute, IAuthorizationFilter
    {
        private PhoneDbContext phoneDb = new PhoneDbContext("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MyPhonesDB1;Integrated Security=True;");
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            var cookies = filterContext.HttpContext.Request.Cookies["id"];
            if (cookies != null)
            {
                var id = int.Parse(cookies.Value);
                var user = phoneDb.Users.FirstOrDefault(x => x.Id == id);
                filterContext.Controller.ViewBag.UserId = (user !=null) ? id : -1;
            }
        }
    }
}