using AAventura.DAL;
using AAventura.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;

namespace AAventura.Controllers
{
    public class ItemController : Controller
    {
        //
        // GET: /Item/
        private AAventuraDB db = new AAventuraDB();

        public ActionResult Comprar1()
        {
            //id 3
            int userID = WebSecurity.GetUserId(User.Identity.Name);
            Utilizador u = db.Utilizadores.Find(userID);
            Aventura a = db.Aventuras.ToList().LastOrDefault(x => x.Utilizador.UserId == userID);
            
            Item item = db.Itens.Find(3);
            a.Itens.Add(item);
            item.Aventuras.Add(a);

            db.SaveChanges();

            return RedirectToAction("JogarAventura", "Jogar", new { aventuraID = a.AventuraId });
        }

        public ActionResult Comprar2()
        {
            //id 4
            int userID = WebSecurity.GetUserId(User.Identity.Name);
            Utilizador u = db.Utilizadores.Find(userID);
            Aventura a = db.Aventuras.ToList().LastOrDefault(x => x.Utilizador.UserId == userID);
            if(a.Moedas >=30) {
                Item item = db.Itens.Find(4);
                a.Itens.Add(item);
                item.Aventuras.Add(a);

                a.Exploradores += 20;
                TempData["message"] = "Acabaste de ganhar 20 Exploradores";
                db.SaveChanges(); 
            }
            return RedirectToAction("JogarAventura", "Jogar", new { aventuraID = a.AventuraId });
        }

        public ActionResult Comprar3()
        {
            //id 5
            int userID = WebSecurity.GetUserId(User.Identity.Name);
            Utilizador u = db.Utilizadores.Find(userID);
            Aventura a = db.Aventuras.ToList().LastOrDefault(x => x.Utilizador.UserId == userID);

            Item item = db.Itens.Find(5);
            a.Itens.Add(item);
            item.Aventuras.Add(a);

            db.SaveChanges();

            return RedirectToAction("JogarAventura", "Jogar", new { aventuraID = a.AventuraId });
        }

        public ActionResult Comprar4()
        {
            //id 6
            int userID = WebSecurity.GetUserId(User.Identity.Name);
            Utilizador u = db.Utilizadores.Find(userID);
            Aventura a = db.Aventuras.ToList().LastOrDefault(x => x.Utilizador.UserId == userID);

            Item item = db.Itens.Find(6);
            a.Itens.Add(item);
            item.Aventuras.Add(a);

            db.SaveChanges();

            return RedirectToAction("JogarAventura", "Jogar", new { aventuraID = a.AventuraId });
        }

        public ActionResult Comprar5()
        {
            //id 7
            int userID = WebSecurity.GetUserId(User.Identity.Name);
            Utilizador u = db.Utilizadores.Find(userID);
            Aventura a = db.Aventuras.ToList().LastOrDefault(x => x.Utilizador.UserId == userID);

            Item item = db.Itens.Find(7);
            a.Itens.Add(item);
            item.Aventuras.Add(a);

            db.SaveChanges();

            return RedirectToAction("JogarAventura", "Jogar", new { aventuraID = a.AventuraId });
        }

        public ActionResult Comprar6()
        {
            //id 8
            int userID = WebSecurity.GetUserId(User.Identity.Name);
            Utilizador u = db.Utilizadores.Find(userID);
            Aventura a = db.Aventuras.ToList().LastOrDefault(x => x.Utilizador.UserId == userID);

            Item item = db.Itens.Find(8);
            a.Itens.Add(item);
            item.Aventuras.Add(a);

            db.SaveChanges();

            return RedirectToAction("JogarAventura", "Jogar", new { aventuraID = a.AventuraId });
        }

        public ActionResult Comprar7()
        {
            //id 9
            int userID = WebSecurity.GetUserId(User.Identity.Name);
            Utilizador u = db.Utilizadores.Find(userID);
            Aventura a = db.Aventuras.ToList().LastOrDefault(x => x.Utilizador.UserId == userID);

            Item item = db.Itens.Find(9);
            a.Itens.Add(item);
            item.Aventuras.Add(a);

            db.SaveChanges();

            return RedirectToAction("JogarAventura", "Jogar", new { aventuraID = a.AventuraId });
        }

        public ActionResult Comprar8()
        {
            //id 10
            int userID = WebSecurity.GetUserId(User.Identity.Name);
            Utilizador u = db.Utilizadores.Find(userID);
            Aventura a = db.Aventuras.ToList().LastOrDefault(x => x.Utilizador.UserId == userID);

            Item item = db.Itens.Find(10);
            a.Itens.Add(item);
            item.Aventuras.Add(a);

            db.SaveChanges();

            return RedirectToAction("JogarAventura", "Jogar", new { aventuraID = a.AventuraId });
        }

        public ActionResult Comprar9()
        {
            //id 11
            int userID = WebSecurity.GetUserId(User.Identity.Name);
            Utilizador u = db.Utilizadores.Find(userID);
            Aventura a = db.Aventuras.ToList().LastOrDefault(x => x.Utilizador.UserId == userID);

            Item item = db.Itens.Find(11);
            a.Itens.Add(item);
            item.Aventuras.Add(a);

            db.SaveChanges();

            return RedirectToAction("JogarAventura", "Jogar", new { aventuraID = a.AventuraId });
        }

        public ActionResult Comprar10()
        {
            //id 12
            int userID = WebSecurity.GetUserId(User.Identity.Name);
            Utilizador u = db.Utilizadores.Find(userID);
            Aventura a = db.Aventuras.ToList().LastOrDefault(x => x.Utilizador.UserId == userID);

            Item item = db.Itens.Find(12);
            a.Itens.Add(item);
            item.Aventuras.Add(a);

            db.SaveChanges();

            return RedirectToAction("JogarAventura", "Jogar", new { aventuraID = a.AventuraId });
        }

        public ActionResult Comprar11()
        {
            //id 13
            int userID = WebSecurity.GetUserId(User.Identity.Name);
            Utilizador u = db.Utilizadores.Find(userID);
            Aventura a = db.Aventuras.ToList().LastOrDefault(x => x.Utilizador.UserId == userID);

            Item item = db.Itens.Find(13);
            a.Itens.Add(item);
            item.Aventuras.Add(a);

            db.SaveChanges();

            return RedirectToAction("JogarAventura", "Jogar", new { aventuraID = a.AventuraId });
        }

        public ActionResult Comprar12()
        {
            //id 14
            int userID = WebSecurity.GetUserId(User.Identity.Name);
            Utilizador u = db.Utilizadores.Find(userID);
            Aventura a = db.Aventuras.ToList().LastOrDefault(x => x.Utilizador.UserId == userID);

            Item item = db.Itens.Find(14);
            a.Itens.Add(item);
            item.Aventuras.Add(a);

            db.SaveChanges();

            return RedirectToAction("JogarAventura", "Jogar", new { aventuraID = a.AventuraId });
        }


    }
}
