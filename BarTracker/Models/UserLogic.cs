using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace BarTracker.Models
{
    public class UserLogic
    {
        public void RegistrationLogic(string LoginReg,string PasswordReg, string EmailReg)
        {
            using (BarTrackerDBEntities db = new BarTrackerDBEntities())
            {
                db.User.Add(new User { Username = LoginReg, Password = PasswordReg, Email = EmailReg });
                db.SaveChanges();
            }
        }
        public bool RegistrationValid(string LoginReg, string PasswordReg, string EmailReg)
        {
            Regex reg = new Regex(@".+\@\w+\.\w+", RegexOptions.Compiled);
            if (reg.Match(EmailReg) != null && LoginReg != "" && PasswordReg != "" && EmailReg != "")
                return true;
            else
                return false;
        }

    }
}