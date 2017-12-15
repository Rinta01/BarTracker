using BarTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BarTracker.Controllers
{
    public class MyAccountController : Controller
    {
        // GET: MyAccount
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LogIn(Models.User user)
        {
            return View();
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Register(Models.User user)
        {
            if(ModelState.IsValid)
            { using(BarTrackerDBEntities db = new BarTrackerDBEntities())
                {

                }        
            }
            return View(user);

        }
        [HttpPost]
        public ActionResult SignOut(Models.User user)
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }

    }
}