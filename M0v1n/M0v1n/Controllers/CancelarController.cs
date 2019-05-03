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
    public class CancelarController : Controller
    {
        private Context db = new Context();

        // GET: Cancelar
        public ActionResult Index()
        {
            return View(db.Cancelacao.ToList());
        }

        // GET: Cancelar/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cancelar cancelar = db.Cancelacao.Find(id);
            if (cancelar == null)
            {
                return HttpNotFound();
            }
            return View(cancelar);
        }

        // GET: Cancelar/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cancelar/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CancelarID,From,To,Subject,Body")] Cancelar cancelar)
        {
            if (ModelState.IsValid)
            {
                db.Cancelacao.Add(cancelar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cancelar);
        }

        // GET: Cancelar/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cancelar cancelar = db.Cancelacao.Find(id);
            if (cancelar == null)
            {
                return HttpNotFound();
            }
            return View(cancelar);
        }

        // POST: Cancelar/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CancelarID,From,To,Subject,Body")] Cancelar cancelar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cancelar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cancelar);
        }

        // GET: Cancelar/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cancelar cancelar = db.Cancelacao.Find(id);
            if (cancelar == null)
            {
                return HttpNotFound();
            }
            return View(cancelar);
        }

        // POST: Cancelar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cancelar cancelar = db.Cancelacao.Find(id);
            db.Cancelacao.Remove(cancelar);
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
