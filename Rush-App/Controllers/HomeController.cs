using Rush_App.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Rush_App.Models.db;
namespace Rush_App.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Create()
        {
            var vm = HomeControllerService.getCreateViewModel();
            return View(vm);
        }

        [HttpPost]
        public ActionResult Create(User user)
        {
            AccountService.createUser(user);
            return RedirectToAction("Login");
        }

        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            User user = AccountService.Login(email, password);
            //user exists 
            if (user != null)
            {
                var userCookie = new HttpCookie("UserId", user.ID.ToString());
                userCookie.Expires.AddDays(1);
                HttpContext.Response.Cookies.Add(userCookie);
                return RedirectToAction("User");
            }
            else
            {
                ViewBag.ErrorMessage = "Invalid Credentials.  Please try again.";
                return View();
            }
        }

        public ActionResult Index()
        {
            if(Request.Cookies["User"] == null) { return View("Login"); }
            int userid = Int32.Parse(Request.Cookies["User"].Value);

            return View();
        }

        public ActionResult Profile()
        {
            if (Request.Cookies["User"] == null) { return View("Login"); }
            int userid = Int32.Parse(Request.Cookies["User"].Value);
            var vm = HomeControllerService.getProfileViewModel(userid);
            
            return View(vm);
        }
    }
}