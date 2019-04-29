using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using M0v1n.Models;

namespace M0v1n.Controllers
{
    public class AvaliacoesController : Controller
    {
        private Context db = new Context();

        // GET: Avaliacoes
        public ActionResult Index()
        {
            return View(db.Avaliacoes.ToList());
        }

        // GET: Avaliacoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Avaliar avaliar = db.Avaliacoes.Find(id);
            if (avaliar == null)
            {
                return HttpNotFound();
            }
            return View(avaliar);
        }

        public ActionResult Confirmacao()
        {
            return View();
        }

        // GET: Avaliacoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Avaliacoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AvaliarID,From,To,Subject,Body")] Avaliar avaliar)
        {
            if (ModelState.IsValid)
            {
                db.Avaliacoes.Add(avaliar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(avaliar);
        }

        // GET: Avaliacoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Avaliar avaliar = db.Avaliacoes.Find(id);
            if (avaliar == null)
            {
                return HttpNotFound();
            }
            return View(avaliar);
        }




        // POST: Avaliacoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AvaliarID,From,To,Subject,Body")] Avaliar avaliar, M0v1n.Models.Avaliar _objModelMail)
        {
            if (ModelState.IsValid)
            {
                db.Avaliacoes.Add(avaliar);
                db.SaveChanges();

                MailMessage mail = new MailMessage();
                mail.To.Add(_objModelMail.To);
                mail.From = new MailAddress(_objModelMail.From);
                mail.Subject = _objModelMail.Subject;
                string Body = _objModelMail.Body;
                mail.Body = Body;
                mail.IsBodyHtml = true;

                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential
                ("mandajudaservico@gmail.com", "Mand@judaPI");
                smtp.EnableSsl = true;
                smtp.Send(mail);

                return RedirectToAction("Confirmacao");
            }
            return View(avaliar);
        }

        // GET: Avaliacoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Avaliar avaliar = db.Avaliacoes.Find(id);
            if (avaliar == null)
            {
                return HttpNotFound();
            }
            return View(avaliar);
        }

        // POST: Avaliacoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Avaliar avaliar = db.Avaliacoes.Find(id);
            db.Avaliacoes.Remove(avaliar);
            db.SaveChanges();
            return RedirectToAction("Index");
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
