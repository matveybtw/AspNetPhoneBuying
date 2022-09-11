using AspPhoneBuying.Context;
using AspPhoneBuying.Filters;
using AspPhoneBuying.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspPhoneBuying.Controllers
{
    public class PhoneController : Controller
    {
        private PhoneDbContext phoneDb = new PhoneDbContext("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MyPhonesDB1;Integrated Security=True;");
        [PhonesFilter]
        public ActionResult Index()
        {
            int id = ViewBag.UserId;
            var user = phoneDb.Users.FirstOrDefault(x => x.Id == id);
            return View(user.Phones);
        }
        public ActionResult NewPhone()
        {
            return View();
        }
        public ActionResult Add(Phone phone)
        {

            var id = (int)ViewBag.UserId;
            ViewBag.UserId = id;
            phoneDb.Users.First(x => x.Id == id).Phones.Add(phone);
            phoneDb.SaveChanges();
            return View("Index", phoneDb.Users.Find(id).Phones);

        }
    }
}