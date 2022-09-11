using AspPhoneBuying.Context;
using AspPhoneBuying.Filters;
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
        [PhonesFilter]
        public ActionResult Index()
        {
            return View(phoneDb.Phones.ToList());
        }
    }
}