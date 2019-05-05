using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using M0v1n.Models;
using M0v1n.Repositories;

namespace M0v1n.Controllers
{
    public class AnunciosController : Controller
    {
        private Context db = new Context();

        // GET: Anuncios
        public ActionResult Index()
        {
            var anuncios = db.Anuncios.Include(a => a.Locador);
            return View(anuncios.ToList());
        }

        // GET: Anuncios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Anuncio anuncio = db.Anuncios.Find(id);
            if (anuncio == null)
            {
                return HttpNotFound();
            }
            return View(anuncio);
        }

        // GET: Anuncios/Create
        public ActionResult Create()
        {
            ViewBag.LocadorID = new SelectList(db.Locadores, "LocadorID", "NomeLocador");
            return View();
        }

        // POST: Anuncios/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AnuncioID,Descricao,QuartoSolteiro,QuartoCasal,QuartoComunitario,QtdCama,QtdBanheiro,NumHospedes,ValorDiaria,Rua,Bairro,Complemento,Numero,Cidade,UF,Cep,Foto1,Foto2,ArCondicionado,Ventilador,Banheira,Internet,TvCabo,Animais,Fumante,Ativo,ProblemasLocadorID")] Anuncio anuncio)
        {
            if (ModelState.IsValid)
            {
                db.Anuncios.Add(anuncio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LocadorID = new SelectList(db.Locadores, "LocadorID", "NomeLocador", anuncio.LocadorID);
            return View(anuncio);
        }

        // GET: Anuncios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Anuncio anuncio = db.Anuncios.Find(id);
            if (anuncio == null)
            {
                return HttpNotFound();
            }
            ViewBag.LocadorID = new SelectList(db.Locadores, "LocadorID", "NomeLocador", anuncio.LocadorID);
            return View(anuncio);
        }

        // POST: Anuncios/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AnuncioID,Descricao,QuartoSolteiro,QuartoCasal,QuartoComunitario,QtdCama,QtdBanheiro,NumHospedes,ValorDiaria,Rua,Bairro,Complemento,Numero,Cidade,UF,Cep,Foto1,Foto2,ArCondicionado,Ventilador,Banheira,Internet,TvCabo,Animais,Fumante,Ativo,Problemas,LocadorID")] Anuncio anuncio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(anuncio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LocadorID = new SelectList(db.Locadores, "LocadorID", "NomeLocador", anuncio.LocadorID);
            return View(anuncio);
        }

        // GET: Anuncios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Anuncio anuncio = db.Anuncios.Find(id);
            if (anuncio == null)
            {
                return HttpNotFound();
            }
            return View(anuncio);
        }

        // POST: Anuncios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Anuncio anuncio = db.Anuncios.Find(id);
            Locador locador = db.Locadores.Find(anuncio.LocadorID);
            //Inserir envio de email de aviso ao locador
            GmailEmailService gmail = new GmailEmailService();
            EmailMessage msg = new EmailMessage();
            msg.Body = "<!DOCTYPE HTML><html><body><p>Caro(a) " + locador.NomeLocador + ",</p><p>Seu anúncio " + anuncio.Descricao + " foi deletado da platafoma Movin!</p><p>Caso essa ação tenha sido feita por você desconsidere o e-mail, caso não, entre em contado com a Administração da Movin poís seu anúncio pode ter sido deletado por alguma infração as normas de uso da plataforma.<p>Atenciosamente,<br/>Administração Movin.</p></body></html>";
            msg.IsHtml = true;
            msg.Subject = "Anúncio Deletado - MOVIN";
            msg.ToEmail = locador.EmailLocador;
            gmail.SendEmailMessage(msg);
            db.Anuncios.Remove(anuncio);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult ReportarProblemas(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Anuncio anuncio = db.Anuncios.Find(id);
            Locador locador = db.Locadores.Find(anuncio.LocadorID);
            if (anuncio == null)
            {
                return HttpNotFound();
            }
            ViewBag.LocadorID = new SelectList(db.Locadores, "LocadorID", "NomeLocador", anuncio.LocadorID);
            return View(anuncio);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ReportarProblemas([Bind(Include = "AnuncioID,Descricao,QuartoSolteiro,QuartoCasal,QuartoComunitario,QtdCama,QtdBanheiro,NumHospedes,ValorDiaria,Rua,Bairro,Complemento,Numero,Cidade,UF,Cep,Foto1,Foto2,ArCondicionado,Ventilador,Banheira,Internet,TvCabo,Animais,Fumante,Ativo,Problemas,LocadorID")] Anuncio anuncio)
        {
            if (ModelState.IsValid)
            {
                Locador locador = db.Locadores.Find(anuncio.LocadorID);

                GmailEmailService gmail = new GmailEmailService();
                EmailMessage msg = new EmailMessage();
                msg.Body = "<!DOCTYPE HTML><html><body><p>Foi identificado um reporte de problema por um usuário.</p><p>O anúncio reportado foi " + anuncio.Descricao + ". O mesmo recebeu a seguinte mensagem: </p><p><strong>" + anuncio.Problemas + "</strong></p><p>Entre em contato com o locador para possivel aviso. <strong>" + locador.NomeLocador + "</strong> / <strong>" + locador.EmailLocador + "</strong></p><br/>Administração Movin.</p></body></html>";
                msg.IsHtml = true;
                msg.Subject = "REPORTE DE PROBLEMA - MOVIN";
                msg.ToEmail = "startoupcontact@gmail.com";
                gmail.SendEmailMessage(msg);

                anuncio.Problemas = "";

                db.Entry(anuncio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LocadorID = new SelectList(db.Locadores, "LocadorID", "NomeLocador", anuncio.LocadorID);
            return View(anuncio);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
