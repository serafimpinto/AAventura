using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AAventura.Models;
using AAventura.DAL;
using WebMatrix.WebData;

namespace AAventura.Controllers
{
    public class JogarController : Controller
    {
        private AAventuraDB db = new AAventuraDB();

        //
        // GET: /Jogar/

        public ActionResult Aventura()
        {
            int id = WebSecurity.GetUserId(User.Identity.Name);
            ViewBag.UserId = id;
            if (User.Identity.IsAuthenticated)
                return View();
            else
                return RedirectToAction("Login", "Account");
        }

        public ActionResult Arcade()
        {
            int id = WebSecurity.GetUserId(User.Identity.Name);
            ViewBag.UserId = id;
            if (User.Identity.IsAuthenticated)
                return View();
            else
                return RedirectToAction("Login", "Account");
        }

        public ActionResult Jogo()
        {
            return View();
        }

        public ActionResult CriarAventura(Aventura aventura)
        {
            int id = WebSecurity.GetUserId(User.Identity.Name);
            ViewBag.UserId = id;
            aventura.Exploradores = 100;
            aventura.Moedas = 0;
            aventura.Utilizador = db.Utilizadores.Find(id);

            db.Aventuras.Add(aventura);
            db.SaveChanges();
            TempData["message"] = "Inserida com sucesso";

            return RedirectToAction("Jogo","Jogar");
        }
    }
}