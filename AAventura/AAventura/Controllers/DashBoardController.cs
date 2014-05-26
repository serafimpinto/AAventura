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
using System.Web.Security;

namespace AAventura.Controllers
{
    public class DashBoardController : Controller
    {
        private AAventuraDB db = new AAventuraDB();

        //
        // GET: /DashBoard/

        public ActionResult Index()
        {
            int id = WebSecurity.GetUserId(User.Identity.Name);
            ViewBag.UserId = id;

            return View();
        }

        public ActionResult Utilizadores(int pag=0)
        {
            if (pag < 0)
            {
                pag = 0;
            }
            int nelem = 2;
            int id = WebSecurity.GetUserId(User.Identity.Name);
            ViewBag.UserId = id;
            ViewBag.Pag = pag;

            List<Utilizador> users = db.Utilizadores.ToList();
            ViewBag.Lista = new List<Utilizador>();
            for (int i = pag*nelem; (i < (pag+1)*nelem) && (i<users.Count); i++)
            {
                ViewBag.Lista.Add(users.ElementAt(i));
            }
            int var = users.Count / nelem;
            ViewBag.Elem = var;
            ViewBag.Size = users.Count;
            
            return View(users);
        }

        public ActionResult Banir(int id = 0)
        {
            Utilizador utilizador = db.Utilizadores.Find(id);
            if (utilizador == null)
            {
                return HttpNotFound();
            }
            utilizador.Estado = 2;
            db.SaveChanges();

            return RedirectToAction("Utilizadores","DashBoard");
        }

        public ActionResult Activar(int id = 0)
        {
            Utilizador utilizador = db.Utilizadores.Find(id);
            if (utilizador == null)
            {
                return HttpNotFound();
            }
            utilizador.Estado = 1;
            db.SaveChanges();

            return RedirectToAction("Utilizadores", "DashBoard");
        }

        // GET: /DashBoard/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Aventura aventura = db.Aventuras.Find(id);
            if (aventura == null)
            {
                return HttpNotFound();
            }
            return View(aventura);
        }

        //
        // POST: /DashBoard/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Aventura aventura)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aventura).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aventura);
        }

        //
        // GET: /DashBoard/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Aventura aventura = db.Aventuras.Find(id);
            if (aventura == null)
            {
                return HttpNotFound();
            }
            return View(aventura);
        }

        //
        // POST: /DashBoard/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Aventura aventura = db.Aventuras.Find(id);
            db.Aventuras.Remove(aventura);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}