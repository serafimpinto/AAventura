using AAventura.DAL;
using AAventura.Filters;
using AAventura.Models;
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
            /*if(User.Identity.IsAuthenticated) {
            Utilizador user = db.Utilizadores.Find(id);
            if (user.Estado != 0)
                return View();
            else
                return RedirectToAction("Index", "DashBoard");
            }
            else*/
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

        public ActionResult Pesquisa(string searchString)
        {
            var users = from m in db.Utilizadores
                        select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                users = users.Where(s => s.UserName.Contains(searchString));
                /*ViewBag.Results = new List<Utilizador>();
                for (int i = 0; (i < users.ToList().Count); i++)
                {
                    ViewBag.Results.Add(users.ElementAt(i));
                }*/
            }
            return View(users.ToList());
        }
    }
}
