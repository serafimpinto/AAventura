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

        public ActionResult Comprar(int id=0)
        {
            int userID = WebSecurity.GetUserId(User.Identity.Name);
            Utilizador u = db.Utilizadores.Find(userID);
            Aventura a = db.Aventuras.ToList().LastOrDefault(x => x.Utilizador.UserId == userID);

            Item item = db.Itens.Find(id);
            a.Itens.Add(item);
            item.Aventuras.Add(a);

            a.Moedas -= (int)item.Custo;
            if (item.ItemId == 4)
            {
                a.Exploradores += 12;
            }
            if (item.ItemId == 8)
            {
                a.Exploradores += 40;

            }
            if (item.ItemId == 9)
            {
                a.Exploradores += 28;
            }
            db.SaveChanges();

            return RedirectToAction("JogarAventura", "Jogar", new { aventuraID = a.AventuraId });
        }
    }
}
