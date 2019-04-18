using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using M0v1n.Models;

namespace M0v1n.Controllers
{
    public class LocadoresController : Controller
    {
        private Context db = new Context();

        // GET: Locadores
        public ActionResult Index()
        {
            return View(db.Locadores.ToList());
        }

        // GET: Locadores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Locador locador = db.Locadores.Find(id);
            if (locador == null)
            {
                return HttpNotFound();
            }
            return View(locador);
        }

        // GET: Locadores/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Locadores/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LocadorID,NomeLocador,DataNascimentoLocador,CpfLocador,EmailLocador,SenhaLocador")] Locador locador)
        {
            if (ModelState.IsValid)
            {
                db.Locadores.Add(locador);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(locador);
        }

        // GET: Locadores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Locador locador = db.Locadores.Find(id);
            if (locador == null)
            {
                return HttpNotFound();
            }
            return View(locador);
        }

        // POST: Locadores/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LocadorID,NomeLocador,DataNascimentoLocador,CpfLocador,EmailLocador,SenhaLocador")] Locador locador)
        {
            if (ModelState.IsValid)
            {
                db.Entry(locador).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(locador);
        }

        // GET: Locadores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Locador locador = db.Locadores.Find(id);
            if (locador == null)
            {
                return HttpNotFound();
            }
            return View(locador);
        }

        // POST: Locadores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Locador locador = db.Locadores.Find(id);
            db.Locadores.Remove(locador);
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
