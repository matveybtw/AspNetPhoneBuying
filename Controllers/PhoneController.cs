using AspPhoneBuying.Context;
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
        public ActionResult Index()
        {
            var cookies = Request.Cookies["id"];
            if (cookies != null)
            {
                var id = int.Parse(cookies.Value);
                var user = phoneDb.Users.FirstOrDefault(x => x.Id == id);
                if (user != null)
                {
                    ViewBag.UserId = id;
                    return View(user.Phones);
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
               
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        public ActionResult NewPhone()
        {
            return View();
        }

        public ActionResult Add(Phone phone)
        {

            var cookies = Request.Cookies["id"];
            if (cookies != null)
            {
                var id = int.Parse(cookies.Value);
                ViewBag.UserId = id;

                phoneDb.Users.First(x => x.Id == id).Phones.Add(phone);
                phoneDb.SaveChanges();
                return View("Index", phoneDb.Users.Find(id).Phones);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
          
        }
    }
}