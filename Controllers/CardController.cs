using AspPhoneBuying.Context;
using AspPhoneBuying.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspPhoneBuying.Controllers
{
    public class CardController : Controller
    {
        private PhoneDbContext phoneDb = new PhoneDbContext("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MyPhonesDB1;Integrated Security=True;");
        // GET: Card
        public ActionResult Index()
        {
            var cookies = Request.Cookies["id"];
            if (cookies != null)
            {
                var id = int.Parse(cookies.Value);
                var tempCardPhones = new List<Phone>();

                var carts = phoneDb.Carts.Where(x => x.UserId == id).Include("Phone").ToList();
                foreach (var cart in carts)
                {
                    tempCardPhones.Add(cart.Phone);
                }
                ViewBag.UserId = id;
                return View(tempCardPhones);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        public ActionResult Add(int phoneId)
        {
            var cookies = Request.Cookies["id"];
            if (cookies != null)
            {
                var id = int.Parse(cookies.Value);
                var user = phoneDb.Users.FirstOrDefault(x => x.Id == id);
                if(user!= null)
                {
                    var phone = phoneDb.Phones.FirstOrDefault(x => x.Id == phoneId);

                    phoneDb.Carts.Add(new Cart() { PhoneId = phoneId, UserId = id, Phone = phone, User = user });
                    phoneDb.SaveChanges();
                }

                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        public ActionResult RemoveCard(int phoneId)
        {
            var cookies = Request.Cookies["id"];
            if (cookies != null)
            {
                var id = int.Parse(cookies.Value);
                var user = phoneDb.Users.FirstOrDefault(x => x.Id == id);
                if (user != null)
                {
                    var phone = phoneDb.Phones.FirstOrDefault(x => x.Id == phoneId);
                    phoneDb.Carts.Remove(phoneDb.Carts.FirstOrDefault(o => o.PhoneId == phoneId));
                    phoneDb.SaveChanges();
                }

                return RedirectToAction("Index", "Card");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}