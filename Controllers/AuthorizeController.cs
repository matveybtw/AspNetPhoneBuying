using AspPhoneBuying.Models;
using AspPhoneBuying.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspPhoneBuying.Controllers
{
    public class AuthorizeController : Controller
    {
        private LoginService _loginService = new LoginService();
        // GET: Authorize
        public ActionResult Login(string login, string pass)
        {
            var res = _loginService.Login(login, pass);
            if (res == -1) RedirectToAction("Error", "Authorize");

            Response.Cookies.Add(new HttpCookie("id") { Expires = DateTime.Now.AddDays(1), Value = res.ToString() });

           return RedirectToAction("Index", "Home");
        
        }
        public ActionResult SignUp()
        {
           
            return View();
        }
        public ActionResult SignIn()
        {

            return View();
        }
        public ActionResult Register(User  user)
        {
            if (_loginService.Register(user)) return RedirectToAction("Index", "Home");
            return View("Error");
        }

        public ActionResult LogOut()
        {
            Response.Cookies.Add(new HttpCookie("id") { Expires = DateTime.Now.AddDays(-1), Value = "-1"});
            return RedirectToAction("Index", "Home");
        }

    }
}