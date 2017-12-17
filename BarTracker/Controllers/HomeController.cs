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
    }
}