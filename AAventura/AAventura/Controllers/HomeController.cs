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
        [InitializeSimpleMembership]
        public ActionResult Index()
        {
            int id = WebSecurity.GetUserId(User.Identity.Name);
            ViewBag.UserId = id;

            return View();
        }

        public ActionResult About()
        {

            return View();
        }
        public ActionResult Team()
        {

            return View();
        }

        public ActionResult Contact()
        {

            return View();
        }
    }
}
