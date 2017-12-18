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
                    return View(CurrentCityList);
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
                return View("BarDetails", CurrentBar);
            }
            else
                return View("Index");
        }
        
        public ActionResult BarDetails(Bar bar)
        {
            return View(bar);
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
        public ActionResult EditBar(int BarId)
        {
            BarLogic.FindBarById(BarId);
            return View();
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