using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace BarTracker.Models
{
    public static class BarLogic
    {
        public static void AddBarLogic(Bar bar)
        {
            if (bar.BarName != "" && bar.Category != "" && bar.City != "")
            {
                using (BarTrackerDBEntities db = new BarTrackerDBEntities())
                {
                    db.Bar.Add(bar);
                    db.SaveChanges();
                }
            }
        }
        public static List<Bar> SearchBarByCityLogic(string SearchCity)
        {
            List<Bar> listBarsCurrentCity = new List<Bar>();
            using (BarTrackerDBEntities db = new BarTrackerDBEntities())
            {
                listBarsCurrentCity = db.Bar.Include(x => x.Rating).Where(x => x.City.ToLower().Equals(SearchCity.ToLower())).ToList();
            }
            return listBarsCurrentCity;
        }
        public static Bar SearchBarByItemLogic(string SearchBarByItem)
        {
            Bar SearchedBar = new Bar();
            using (BarTrackerDBEntities db = new BarTrackerDBEntities())
            {
                SearchedBar = db.Bar.SingleOrDefault(x => x.BarName == SearchBarByItem);
            }
            return SearchedBar;
        }
        public static void DeleteBarLogic(Bar bar)
        {
            using (BarTrackerDBEntities db = new BarTrackerDBEntities())
            {
                db.Bar.Remove(bar);
                db.SaveChanges();
            }
        }
        public static Bar EditBarLogic(Bar bar)
        {
            Bar Fullbar=new Bar();
            using (BarTrackerDBEntities db = new BarTrackerDBEntities())
            {
                Bar oldBar = db.Bar.SingleOrDefault(x => x.BarId == bar.BarId);
                oldBar.BarName = bar.BarName;
                oldBar.Category = bar.Category;
                oldBar.City = bar.City;
                db.SaveChanges();
                Fullbar = db.Bar.Include(x => x.Rating).FirstOrDefault(x=> x.BarId == bar.BarId);
            }
            return Fullbar;
        }
        public static Bar FindBarById(int BarId)
        {
            Bar thatbar = new Bar();
            using (BarTrackerDBEntities db = new BarTrackerDBEntities())
            {
                thatbar = db.Bar.SingleOrDefault(x => x.BarId == BarId);
            }
            return thatbar;
        }

    }
}