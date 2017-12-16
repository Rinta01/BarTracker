using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BarTracker.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login(string LoginBox, string PasswordBox)
        {
            return View();
        }
        public ActionResult list()
        {
            return View();
        }

        public ActionResult auth()
        {
            return View();
        }

    }
}