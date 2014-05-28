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
            
            return View();
        }

        public ActionResult BanirUtilizador(int id = 0)
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

        public ActionResult ActivarUtilizador(int id = 0)
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

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult AdicionarUtilizador(RegisterModel user)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    WebSecurity.CreateUserAndAccount(user.UserName, user.Password, new
                    {
                        Nome = user.Nome,
                        Email = user.Email,
                        Avatar = "~/images/default.jpg",
                        Estado = 1,
                        NrRespostasCertas = 0,
                        NrRespostasErradas = 0,
                        VoltasDadas = 0,
                        TempoTotal = 0,
                        HighScore = 0
                    });
                    TempData["message"] = "Inserido com sucesso";
                    return RedirectToAction("Utilizadores", "DashBoard");
                }
                catch (MembershipCreateUserException e)
                    {
                        ModelState.AddModelError("", ErrorCodeToString(e.StatusCode));
                    }
                }
                   
            return RedirectToAction("Utilizadores", "DashBoard");      
    }
    private static string ErrorCodeToString(MembershipCreateStatus createStatus)
        {
            // See http://go.microsoft.com/fwlink/?LinkID=177550 for
            // a full list of status codes.
            switch (createStatus)
            {
                case MembershipCreateStatus.DuplicateUserName:
                    return "User name already exists. Please enter a different user name.";

                case MembershipCreateStatus.DuplicateEmail:
                    return "A user name for that e-mail address already exists. Please enter a different e-mail address.";

                case MembershipCreateStatus.InvalidPassword:
                    return "The password provided is invalid. Please enter a valid password value.";

                case MembershipCreateStatus.InvalidEmail:
                    return "The e-mail address provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidAnswer:
                    return "The password retrieval answer provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidQuestion:
                    return "The password retrieval question provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidUserName:
                    return "The user name provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.ProviderError:
                    return "The authentication provider returned an error. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                case MembershipCreateStatus.UserRejected:
                    return "The user creation request has been canceled. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                default:
                    return "An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator.";
            }
        }

        public ActionResult Perguntas(int pag=0)
        {
            if (pag < 0)
            {
                pag = 0;
            }
            int nelem = 1;
            int id = WebSecurity.GetUserId(User.Identity.Name);
            ViewBag.UserId = id;
            ViewBag.Pag = pag;
            List<Pergunta> perguntas = db.Perguntas.ToList();
            ViewBag.Lista = new List<Pergunta>();
            for (int i = pag * nelem; (i < (pag + 1) * nelem) && (i < perguntas.Count); i++)
            {
                ViewBag.Lista.Add(perguntas.ElementAt(i));
            }
            int var = perguntas.Count / nelem;
            ViewBag.Elem = var;
            ViewBag.Size = perguntas.Count;

            //Zonas
            List<Zona> zonas = db.Zonas.ToList();
            ViewBag.Zonas = new List<Zona>();
            for (int i = 0; (i < zonas.Count); i++)
            {
                ViewBag.Zonas.Add(zonas.ElementAt(i));
            }

            return View();
        }

        [HttpPost]
        public ActionResult AdicionarPergunta(Pergunta pergunta)
        {

            if (ModelState.IsValid)
            {
                Hipotese A = new Hipotese();
                A.Resposta = "A";
                A.Descricao = pergunta.Ha;
                A.Pergunta = pergunta;
                
                Hipotese B = new Hipotese();
                B.Resposta = "B";
                B.Descricao = pergunta.Hb;
                B.Pergunta = pergunta;
                
                Hipotese C = new Hipotese();
                C.Resposta = "C";
                C.Descricao = pergunta.Hc;
                C.Pergunta = pergunta;
                
                Hipotese D = new Hipotese();
                D.Resposta = "D";
                D.Descricao = pergunta.Hd;
                D.Pergunta = pergunta;

                db.Hipoteses.Add(A);
                db.Hipoteses.Add(B);
                db.Hipoteses.Add(C);
                db.Hipoteses.Add(D);
                pergunta.Path = "/../images/" + pergunta.imagem;
                int x = pergunta.ZonaId;
                pergunta.Zona = db.Zonas.Find(x);
                pergunta.Zona.Perguntas.Add(pergunta);
                db.Perguntas.Add(pergunta);
                db.SaveChanges();
                TempData["message"] = "Inserida com sucesso";
                return RedirectToAction("Perguntas", "DashBoard");
            }
            else
            {
                return RedirectToAction("Perguntas","DashBoard");
            }
        }

        public ActionResult RemoverPergunta(int id = 0)
        {
            Pergunta pergunta = db.Perguntas.Find(id);
            if (pergunta == null)
            {
                return HttpNotFound();
            }
            db.Perguntas.Remove(pergunta);
            db.SaveChanges();

            return RedirectToAction("Perguntas", "DashBoard");
        }

        public ActionResult Itens(int pag=0)
        {
            if (pag < 0)
            {
                pag = 0;
            }
            int nelem = 1;
            int id = WebSecurity.GetUserId(User.Identity.Name);
            ViewBag.UserId = id;
            ViewBag.Pag = pag;
            
            List<Item> itens = db.Itens.ToList();
            ViewBag.Lista = new List<Item>();
            for (int i = pag * nelem; (i < (pag + 1) * nelem) && (i < itens.Count); i++)
            {
                ViewBag.Lista.Add(itens.ElementAt(i));
            }
            int var = itens.Count / nelem;
            ViewBag.Elem = var;
            ViewBag.Size = itens.Count;
         
            return View();
        }
        public ActionResult AdicionarItem(Item item)
        {
            if (ModelState.IsValid)
            {
                item.Path = "/../images/" + item.imagem;
                db.Itens.Add(item);
                db.SaveChanges();
                TempData["message"] = "Inserido com sucesso";

                return RedirectToAction("Itens", "DashBoard");
            }
            else
                return RedirectToAction("Itens","DashBoard");
        }

        public ActionResult RemoverItem(int id = 0)
        {
            Item item = db.Itens.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            db.Itens.Remove(item);
            db.SaveChanges();

            return RedirectToAction("Itens", "DashBoard");
        }
    }
}