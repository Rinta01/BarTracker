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
        public ActionResult BarListByCity(string SearchCity)
        {
            if (SearchCity != "")
            {
                var CurrentCityList = BarLogic.SearchBarByCityLogic(SearchCity);
                if (CurrentCityList.Count() == 0)
                {
                    return View("Index");
                }
                else
                {
                    return View("BarList",CurrentCityList);
                }
            }
            else
                return View("Index");
        }
        public ActionResult BarListByItem(string SearchBar)
        {
            if (SearchBar != "")
            {
                var CurrentBar = BarLogic.SearchBarByItemLogic(SearchBar);
                if (CurrentBar != null)
                    return View("BarDetails", CurrentBar);
                else
                    return View("Index");
            }
            else
                return View("Index");
        }
        
        public ActionResult BarDetails(Bar bar)
        {
            Bar newbar = new Bar();
            using (BarTrackerDBEntities db = new BarTrackerDBEntities())
            {
                newbar = db.Bar.Include(x => x.Rating).Include(y => y.Review).SingleOrDefault(z => z.BarName == bar.BarName);
            }
                return View(newbar);
        }
        [HttpGet]
        public ActionResult AddBar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddBar(Bar bar)
        {
            BarLogic.AddBarLogic(bar);
            return View("Index");
        }

        [HttpGet]
        public ActionResult EditBar(int? id)
        {
           Bar b = BarLogic.FindBarById(id);
            return View(b);
        }
        [HttpPost]
        public ActionResult EditBar(Bar bar)
        {
            BarLogic.EditBarLogic(bar);
            return View("BarDetails",bar);
        }

        public ActionResult DeleteBar(Bar bar)
        {
            BarLogic.DeleteBarLogic(bar);
            return View();
        }
    }
}