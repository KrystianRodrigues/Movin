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
    public class AdministradoresController : Controller
    {
        private Context db = new Context();

        // GET: Administradores
        public ActionResult Index()
        {
            IEnumerable<Anuncio> anuncios = db.Anuncios.ToList();
            IEnumerable<Locador> locadores = db.Locadores.ToList();
            ViewBag.Anuncios = anuncios;
            ViewBag.Locadores = locadores;
            return View();
            //return View(db.Administradores.ToList());
        }

        // GET: Administradores/Details/5
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
            IEnumerable<Anuncio> anuncios = db.Anuncios.ToList();
            IEnumerable<Locador> locadores = db.Locadores.ToList();
            ViewBag.Anuncios = anuncios;
            ViewBag.Locadores = locadores;
            return View();
        }

        // GET: Administradores/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Administradores/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AdministradorID,Nome,Email,Senha")] Administrador administrador)
        {
            if (ModelState.IsValid)
            {
                db.Administradores.Add(administrador);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(administrador);
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
        public ActionResult Edit([Bind(Include = "AnuncioID,Descricao,QuartoSolteiro,QuartoCasal,QuartoComunitario,QtdCama,QtdBanheiro,NumHospedes,ValorDiaria,Rua,Bairro,Complemento,Numero,Cidade,UF,Cep,Foto1,Foto2,ArCondicionado,Ventilador,Banheira,Internet,TvCabo,Animais,Fumante,Ativo,LocadorID")] Anuncio anuncio)
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
            db.Anuncios.Remove(anuncio);
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
