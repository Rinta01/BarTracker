﻿using System;
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
        public ActionResult Login()
        {
            return View();
        }

    }
}