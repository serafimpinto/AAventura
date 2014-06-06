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
            Zona z = db.Zonas.FirstOrDefault(x => x.Latitude == latitude && x.Longitude == longitude);
            Pergunta p = z.Perguntas.FirstOrDefault(x => x.Dificuldade == dificuldade);
            return Json(new PerguntaViewModel(p, z), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Responder(int perguntaID, string resposta)
        {
            Pergunta p = db.Perguntas.Find(perguntaID);
            bool acertou = p.Resposta == resposta;
            int userID = WebSecurity.GetUserId(User.Identity.Name);
            Utilizador u = db.Utilizadores.Find(userID);
            if (acertou)
            {
                u.NrRespostasCertas++;
            }
            else
            {
                u.NrRespostasErradas++;
            }
            db.SaveChanges();
            return Json(acertou, JsonRequestBehavior.AllowGet);
        }

    }
}
