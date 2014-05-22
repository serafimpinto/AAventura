﻿using AAventura.DAL;
using AAventura.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;

namespace AAventura.Controllers
{
    public class HomeController : Controller
    {
        private AAventuraDB db = new AAventuraDB();

        [InitializeSimpleMembership]
        public ActionResult Index()
        {
            int id = WebSecurity.GetUserId(User.Identity.Name);
            ViewBag.UserId = id;

            return View();
        }

        public ActionResult About()
        {
            int id = WebSecurity.GetUserId(User.Identity.Name);
            ViewBag.UserId = id;

            return View();
        }
        public ActionResult Team()
        {
            int id = WebSecurity.GetUserId(User.Identity.Name);
            ViewBag.UserId = id;

            return View();
        }

        public ActionResult Contact()
        {
            int id = WebSecurity.GetUserId(User.Identity.Name);
            ViewBag.UserId = id;

            return View();
        }

        public ActionResult Ranking()
        {
            int id = WebSecurity.GetUserId(User.Identity.Name);
            ViewBag.UserId = id;

            return View(db.Utilizadores.ToList());

        }
    }
}
