﻿using BarTracker.Models;
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
        [HttpGet]
        public ActionResult Authorization()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Authorization(Models.User user)
        {
            using (BarTrackerDBEntities db = new BarTrackerDBEntities())
            {
                var CurrentUser = db.User.Where(u => u.Username.Equals(user.Username) && u.Password.Equals(user.Password)).FirstOrDefault();
                if(CurrentUser!=null)
                {
                    Membership.ValidateUser(CurrentUser.Username,CurrentUser.Password);
                }
            }
                return View();
        }
        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Registration(string LoginName, string PasswordBox)
        {
            if(ModelState.IsValid)
            { using(BarTrackerDBEntities db = new BarTrackerDBEntities())
                {
                    db.User.Add(new User { Username = LoginName, Password = PasswordBox });
                    db.SaveChanges();
                }        
            }
            return Redirect("/Home/Index");

        }
        [HttpPost]
        public ActionResult SignOut(Models.User user)
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
        [Authorize]
        public ActionResult MyProfile()
        {
            return View();
        }
    }
}