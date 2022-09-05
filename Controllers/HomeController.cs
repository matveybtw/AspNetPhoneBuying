using AspPhoneBuying.Context;
using System;
using System.Collections.Generic; 
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspPhoneBuying.Controllers
{
    public class HomeController : Controller
    {
        private PhoneDbContext phoneDb = new PhoneDbContext("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MyPhonesDB1;Integrated Security=True;");
        // GET: Home
        public ActionResult Index()
        {
            var res = Request.Cookies["id"];
            if(res != null)
            {
                var id = int.Parse(res.Value);
                ViewBag.UserId = id;
            }

            return View(phoneDb.Phones.ToList());
        }
    }
}