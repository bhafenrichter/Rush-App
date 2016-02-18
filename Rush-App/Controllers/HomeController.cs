using Rush_App.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rush_App.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var users = HomeService.getUniversities();
            return View();
        }
    }
}