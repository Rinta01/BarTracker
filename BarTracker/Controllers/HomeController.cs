using BarTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Data.Entity;

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
                listBarsCurrentCity = db.Bar.Include(x=>x.Rating).Where(x => x.City.ToLower().Equals(SearchCity.ToLower())).ToList();
                if (listBarsCurrentCity.Count() == 0)
                {
                    return View("Index");
                }
            }
            return View(listBarsCurrentCity);
        }
        public ActionResult BarDetails(Bar bar)
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddBar(Bar bar)
        {
            if (bar.BarName != "" && bar.Category != "" && bar.City != "")
            {
                using (BarTrackerDBEntities db = new BarTrackerDBEntities())
                {
                    db.Bar.Add(bar);
                    db.SaveChanges();
                }
            }
              return View("Index");
        }
        [HttpGet]
        public ActionResult AddBar()
        {
            return View();
        }


        public ActionResult EditBar(Bar bar)
        {
            using (BarTrackerDBEntities db = new BarTrackerDBEntities())
            {

            }
            return View();
        }
        public ActionResult DeleteBar(Bar bar)
        {
            using (BarTrackerDBEntities db = new BarTrackerDBEntities())
            {
                db.Bar.Remove(bar);
                db.SaveChanges();
            }
            return View();
        }
    }
}