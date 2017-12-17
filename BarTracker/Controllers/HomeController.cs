using BarTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BarTracker.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult BarList(string SearchCity)
        {
            List<Bar> listBarsCurrentCity = new List<Bar>();
            using (BarTrackerDBEntities db = new BarTrackerDBEntities())
            {
                listBarsCurrentCity = db.Bar.Where(x => x.City.ToLower().Equals(SearchCity.ToLower())).ToList();
                if (listBarsCurrentCity.Count()==0)
                {
                    return View("Index");
                }
            }
            return View(listBarsCurrentCity);
        }
        [Authorize]
        public ActionResult MyProfile()
        {
            return View();
        }
        public ActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogIn(Models.User user)
        {
            using (BarTrackerDBEntities db = new BarTrackerDBEntities())
            {
                var CurrentUser = db.User.Where(u => u.Username.Equals(user.Username) && u.Password.Equals(user.Password)).FirstOrDefault();
                if (CurrentUser != null)
                {
                    Membership.ValidateUser(CurrentUser.Username, CurrentUser.Password);
                }
                else
                    return View();
            }
            return View();
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View("Lol");
        }
        [HttpPost]
        public ActionResult Register(string LoginName, string PasswordBox)
        {
            if (ModelState.IsValid)
            {
                using (BarTrackerDBEntities db = new BarTrackerDBEntities())
                {
                    db.User.Add(new User { Username = LoginName, Password = PasswordBox });
                    db.SaveChangesAsync();
                }
            }
            return Redirect("/Home/List");

        }

    }
}