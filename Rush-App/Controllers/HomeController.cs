using Rush_App.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Rush_App.Models.db;
using Rush_App.Models;

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
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.ErrorMessage = "Invalid Credentials.  Please try again.";
                return View();
            }
        }

        public ActionResult Index()
        {
            if(Request.Cookies["UserId"] == null) { return View("Login"); }
            int userid = Int32.Parse(Request.Cookies["UserId"].Value);

            var vm = HomeControllerService.getHomeViewModel(userid);

            return View(vm);
        }

        public ActionResult Profile(int? userid)
        {
            if (Request.Cookies["UserId"] == null && userid == null) { return View("Login"); }
            var vm = new ProfileViewModel();
            if(userid != null)
            {
                //viewing someone elses profile
                vm = HomeControllerService.getProfileViewModel(userid ?? 0);
            }
            else
            {
                //viewing our own profile
                int currentUserId = Int32.Parse(Request.Cookies["UserId"].Value);
                vm = HomeControllerService.getProfileViewModel(currentUserId);
            }

            
            
            return View(vm);
        }

        public ActionResult House(int? houseId)
        {
            if (Request.Cookies["UserId"] == null) { return View("Login"); }

            int userId = Int32.Parse(Request.Cookies["UserId"].Value);
            
            var vm = new HouseViewModel();
            vm.User = AccountService.getUserById(userId);
            vm = HomeControllerService.getHouseViewModel(userId, houseId ?? vm.User.GreekID ?? 0);

            return View(vm);
        }

        [HttpPost]
        public ActionResult House(Event e)
        {
            int userId = Int32.Parse(Request.Cookies["UserId"].Value);

            HomeService.createEvent(e);

            return RedirectToAction("House", new { e.GreekId });
        }

        public ActionResult Logout()
        {
            if (Request.Cookies["UserId"] != null)
            {
                var c = new HttpCookie("UserId");
                c.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(c);
            }
            return RedirectToAction("Login");
        }

        public ActionResult Event(int ID)
        {
            int userId = Int32.Parse(Request.Cookies["UserId"].Value);
            var vm = HomeControllerService.getEventViewModel(userId, ID);
            return View(vm);
        }
    }
}