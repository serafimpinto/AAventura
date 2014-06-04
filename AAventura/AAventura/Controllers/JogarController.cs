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

        public ActionResult JogarAventura(Aventura aventura)
        {
            int id = WebSecurity.GetUserId(User.Identity.Name);
            ViewBag.UserId = id;
            Utilizador u = db.Utilizadores.Find(id);
            int idAventura = 0;
            foreach (Aventura a in db.Aventuras) {
                if (a.Utilizador.UserId == u.UserId)
                    idAventura = a.AventuraId;
            }
            if (idAventura != 0) {
                Aventura aa = db.Aventuras.Find(idAventura);
                return View(aa);
            }
            else {
                aventura.Exploradores = 100;
                aventura.Moedas = 0;
                aventura.Utilizador = db.Utilizadores.Find(id);

                db.Aventuras.Add(aventura);
                db.SaveChanges();

                return View(aventura);
            }  
        }
    }
}