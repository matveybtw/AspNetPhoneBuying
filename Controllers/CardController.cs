using AspPhoneBuying.Context;
using AspPhoneBuying.Filters;
using AspPhoneBuying.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspPhoneBuying.Controllers
{
    [PhonesFilter]
    public class CardController : Controller
    {
        private PhoneDbContext phoneDb = new PhoneDbContext("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MyPhonesDB1;Integrated Security=True;");
        // GET: Card
        
        public ActionResult Index()
        {
            var id = ViewBag.UserId;
            var tempCardPhones = new List<Phone>();
            var carts = new List<Cart>();
            foreach (var item in phoneDb.Carts)
            {
                if (item.UserId == id)
                {
                    carts.Add(item);
                }
            }
            //var carts = phoneDb.Carts.Where(x => x.UserId == id).Include("Phone").ToList();
            foreach (var cart in carts)
            {
                tempCardPhones.Add(cart.Phone);
            }
            return View(tempCardPhones);
        }
        
        public ActionResult Add(int phoneId)
        {
            var id = (int)ViewBag.UserId;
            var user = phoneDb.Users.FirstOrDefault(x => x.Id==id);
            if (user != null)
            {
                var phone = phoneDb.Phones.FirstOrDefault(x => x.Id == phoneId);

                phoneDb.Carts.Add(new Cart() { PhoneId = phoneId, UserId = id, Phone = phone, User = user });
                phoneDb.SaveChanges();
            }

            return RedirectToAction("Index", "Home");

        }
        public ActionResult RemoveCard(int phoneId)
        {

            var id = (int)ViewBag.UserId;
            var user = phoneDb.Users.FirstOrDefault(x => x.Id == id);
            if (user != null)
            {
                var phone = phoneDb.Phones.FirstOrDefault(x => x.Id == phoneId);
                phoneDb.Carts.Remove(phoneDb.Carts.FirstOrDefault(o => o.PhoneId == phoneId));
                phoneDb.SaveChanges();
            }

            return RedirectToAction("Index", "Card");

        }
    }
}