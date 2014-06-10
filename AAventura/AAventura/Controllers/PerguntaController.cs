using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AAventura.Models;
using AAventura.DAL;
using WebMatrix.WebData;

namespace AAventura.Controllers
{
    public class PerguntaController : Controller
    {

        private AAventuraDB db = new AAventuraDB();

        //
        // GET: /Pergunta/

        public JsonResult GetRandomByZona(float latitude, float longitude, int dificuldade)
        {
            int userID = WebSecurity.GetUserId(User.Identity.Name);
            Utilizador u = db.Utilizadores.Find(userID);
            Aventura a = db.Aventuras.ToList().LastOrDefault(x => x.Utilizador.UserId == userID);
            Zona z = db.Zonas.FirstOrDefault(x => x.Latitude == latitude && x.Longitude == longitude);
            
            List<Pergunta> filter = z.Perguntas.Where(x => x.Dificuldade == dificuldade).ToList();
            Random rnd = new Random();
            int r = rnd.Next(filter.Count);
            Pergunta p = filter[r];

            bool aventuras = z.Aventuras.Any(item => item.AventuraId == a.AventuraId);
            bool zonas = a.Zonas.Any(item => item.ZonaId == z.ZonaId);
            int conquistada = 0;
            if (aventuras && zonas)
                conquistada = 1;
            return Json(new PerguntaViewModel(p, z, conquistada), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Responder(int perguntaID, string resposta)
        {
            Pergunta p = db.Perguntas.Find(perguntaID);
            int acertou;
            if (p.Resposta == resposta)
                acertou = 1;
            else
                acertou = 0;
            int userID = WebSecurity.GetUserId(User.Identity.Name);
            Utilizador u = db.Utilizadores.Find(userID);
            Aventura a = db.Aventuras.ToList().LastOrDefault(x => x.Utilizador.UserId == userID);
            int n = a.Zonas.Count();
            if (acertou == 1)
            {
                if (p.Dificuldade == 1)
                    a.Moedas += 20;
                if (p.Dificuldade == 2)
                    a.Moedas += 15;
                if (p.Dificuldade == 3)
                    a.Moedas += 10;
                u.NrRespostasCertas++;
                Zona z = p.Zona;
                a.Zonas.Add(z);
                z.Aventuras.Add(a);
            }

            if (acertou == 0)
            {
                if (p.Dificuldade == 1)
                    a.Exploradores -= 5;
                if (p.Dificuldade == 2)
                    a.Exploradores -= 10;
                if (p.Dificuldade == 3)
                    a.Exploradores -= 15;
                u.NrRespostasErradas++;
            }
            db.SaveChanges();

            if (a.Exploradores <= 0)
            {
                acertou = -1;
                return Json(acertou, JsonRequestBehavior.AllowGet);
            }
            else
                return Json(acertou, JsonRequestBehavior.AllowGet);
        }

    }
}
