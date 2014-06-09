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

        public ActionResult JogarAventura(Aventura aventura, int aventuraID = -1)
        {
            if (aventuraID == -1)
            {
                int id = WebSecurity.GetUserId(User.Identity.Name);
                ViewBag.UserId = id;
                Utilizador u = db.Utilizadores.Find(id);

                aventura.Exploradores = 100;
                aventura.Moedas = 0;
                aventura.Utilizador = db.Utilizadores.Find(id);

                db.Aventuras.Add(aventura);
                db.SaveChanges();

                return RedirectToAction("JogarAventura", "Jogar", new { aventuraID = aventura.AventuraId });
            }
            else {
                Aventura a = db.Aventuras.Find(aventuraID);
                return View(a);
            }

        }

        public ActionResult ContinuarAventura()
        {
            int id = WebSecurity.GetUserId(User.Identity.Name);
            ViewBag.UserId = id;
            Utilizador u = db.Utilizadores.Find(id);

            Aventura a = db.Aventuras.ToList().LastOrDefault(x => x.Utilizador.UserId == id);
            //Aventura aa = db.Aventuras.ElementAt(0);
            if ( (a == null) || (a.Exploradores <= 0))
            {
                TempData["message"] = "Nenhuma aventura por terminar. Inicie uma agora";
                return RedirectToAction("Aventura", "Jogar");

            }
            else
            {
                return RedirectToAction("JogarAventura","Jogar",new {aventuraID = a.AventuraId});
            }
        }

        public ActionResult GameOver()
        {
            int id = WebSecurity.GetUserId(User.Identity.Name);
            ViewBag.UserId = id;
            return View();
        }


    }
}