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
        [HttpGet]
        public ActionResult Authorization()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Authorization(string Username, string Password)
        {
            using (BarTrackerDBEntities db = new BarTrackerDBEntities())
            {
                var CurrentUser = db.User.Where(u => u.Username.Equals(Username) && u.Password.Equals(Password)).FirstOrDefault();
                if(CurrentUser!=null)
                {
                    FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(
                    10,
                    Username,
                    DateTime.Now,
                    DateTime.Now.AddMinutes(40),
                    true,
                    "user"
                    );


                    HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(authTicket))
                    {
                        Expires = authTicket.Expiration
                    };
                    Response.Cookies.Add(cookie);
                }
            }
                return RedirectToAction("Index","Home");
        }
        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Registration(string LoginReg, string PasswordReg, string EmailReg)
        {
            if (Factory.GetUserLogic().RegistrationValid(LoginReg,PasswordReg,EmailReg) && ModelState.IsValid)
            {
                Factory.GetUserLogic().RegistrationLogic(LoginReg, PasswordReg, EmailReg);

                return RedirectToAction("Authorization", new { user = new User { Username = LoginReg, Password = PasswordReg, Email = EmailReg } });
            }
            else
            {
                return View();
            }
        }
        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index","Home");
        }
        [Authorize]
        public ActionResult MyProfile()
        {
            return View();
        }
    }
}