using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ServicioWebAvance2.Models;

namespace ServicioWebAvance2.Controllers
{
    public class AlmacenamientoController : Controller
    {
        private ServiciosWebEntities db = new ServiciosWebEntities();

        // GET: Almacenamiento
        public ActionResult Index()
        {
            return View(db.Almacenamientoes.ToList());
        }

        // GET: Almacenamiento/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Almacenamiento almacenamiento = db.Almacenamientoes.Find(id);
            if (almacenamiento == null)
            {
                return HttpNotFound();
            }
            return View(almacenamiento);
        }

        // GET: Almacenamiento/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Almacenamiento/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Almacenamiento,Nombre,Path_Almacenamiento")] Almacenamiento almacenamiento)
        {
            if (ModelState.IsValid)
            {
                db.Almacenamientoes.Add(almacenamiento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(almacenamiento);
        }

        // GET: Almacenamiento/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Almacenamiento almacenamiento = db.Almacenamientoes.Find(id);
            if (almacenamiento == null)
            {
                return HttpNotFound();
            }
            return View(almacenamiento);
        }

        // POST: Almacenamiento/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Almacenamiento,Nombre,Path_Almacenamiento")] Almacenamiento almacenamiento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(almacenamiento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(almacenamiento);
        }

        // GET: Almacenamiento/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Almacenamiento almacenamiento = db.Almacenamientoes.Find(id);
            if (almacenamiento == null)
            {
                return HttpNotFound();
            }
            return View(almacenamiento);
        }

        // POST: Almacenamiento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Almacenamiento almacenamiento = db.Almacenamientoes.Find(id);
            db.Almacenamientoes.Remove(almacenamiento);
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
