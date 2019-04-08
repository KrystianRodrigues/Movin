using M0v1n.Models;
using M0v1n.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace M0v1n.Controllers
{
    public class PublicoController : Controller
    {
        // GET: Publico
        public ActionResult Logar()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Logar(string email, string senha)
        {
            if (Funcoes.AutenticarUsuario(email, senha) == false)
            {
                ViewBag.Error = "Nome de usuário e/ou senha inválida";
                return View();
            }
            return RedirectToAction("Index", "Home");
        }
        public ActionResult AcessoNegado()
        {
            using (Context c = new Context())
            {
                return View();
            }
        }
        public ActionResult Logoff()
        {
            M0v1n.Repositories.Funcoes.Deslogar();
            return RedirectToAction("Logar", "Publico");
        }

    }
}