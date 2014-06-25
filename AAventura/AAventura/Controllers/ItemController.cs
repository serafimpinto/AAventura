using AAventura.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AAventura.Controllers
{
    public class ItemController : Controller
    {
        //
        // GET: /Item/
        private AAventuraDB db = new AAventuraDB();

        public ActionResult ComprarItem(int id=0)
        {

            return RedirectToAction("JogarAventura","Jogar");
        }

    }
}
