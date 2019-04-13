using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FrontEnd.Models;

namespace FrontEnd.Controllers
{
    public class PeliculasController : Controller
    {
        private ServiciosWebEntities db = new ServiciosWebEntities();

        // GET: Peliculas
        public ViewResult Index(string sortOrder, string searchString)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "Nombre" : "";

            ViewBag.CurrentSort = sortOrder;

            var peliculas = db.Peliculas.Include(p => p.Actor).Include(p => p.Actor1).Include(p => p.Actor2).Include(p => p.Actor3).Include(p => p.Genero).Include(p => p.Idioma);


            if (!String.IsNullOrEmpty(searchString))
            {

                peliculas = peliculas.Where(s => s.Nombre_Pelicula.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "Nombre_Pelicula":
                    peliculas = peliculas.OrderByDescending(s => s.Nombre_Pelicula);
                    break;
            }

            return View(peliculas.ToList());
        }

        public ActionResult Search(string Searching)
        {
            List<Pelicula> peliculas = db.Peliculas.ToList();

            return View(db.Peliculas.Where(x => x.Nombre_Pelicula.Contains(Searching) || Searching == null).ToList());
        }

        // GET: Peliculas/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pelicula pelicula = db.Peliculas.Find(id);
            if (pelicula == null)
            {
                return HttpNotFound();
            }
            return View(pelicula);
        }

        // GET: Peliculas/Create
        public ActionResult Create()
        {
            ViewBag.Actor1_Pelicula = new SelectList(db.Actors, "ID_Actor", "Nombre_Actor");
            ViewBag.Actor2_Pelicula = new SelectList(db.Actors, "ID_Actor", "Nombre_Actor");
            ViewBag.Actor3_Pelicula = new SelectList(db.Actors, "ID_Actor", "Nombre_Actor");
            ViewBag.Actor4_Pelicula = new SelectList(db.Actors, "ID_Actor", "Nombre_Actor");
            ViewBag.Genero_Pelicula = new SelectList(db.Generoes, "ID_Genero", "Nombre_Genero");
            ViewBag.Idioma_Pelicula = new SelectList(db.Idiomas, "ID_Idioma", "Nombre_Idioma");
            return View();
        }

        // POST: Peliculas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Pelicula,Genero_Pelicula,Nombre_Pelicula,Ano_Pelicula,Idioma_Pelicula,Actor1_Pelicula,Actor2_Pelicula,Actor3_Pelicula,Actor4_Pelicula,Archivo_Descarga_Pelicula,Archivo_Previsualizacion_Pelicula")] Pelicula pelicula)
        {
            if (ModelState.IsValid)
            {
                db.InsertPelicula(pelicula.Genero_Pelicula, pelicula.Nombre_Pelicula, pelicula.Ano_Pelicula, pelicula.Idioma_Pelicula, pelicula.Actor1_Pelicula, pelicula.Actor2_Pelicula, pelicula.Actor3_Pelicula, pelicula.Actor4_Pelicula, pelicula.Archivo_Previsualizacion_Pelicula, pelicula.Archivo_Descarga_Pelicula);
                //db.Peliculas.Add(pelicula);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Actor1_Pelicula = new SelectList(db.Actors, "ID_Actor", "Nombre_Actor", pelicula.Actor1_Pelicula);
            ViewBag.Actor2_Pelicula = new SelectList(db.Actors, "ID_Actor", "Nombre_Actor", pelicula.Actor2_Pelicula);
            ViewBag.Actor3_Pelicula = new SelectList(db.Actors, "ID_Actor", "Nombre_Actor", pelicula.Actor3_Pelicula);
            ViewBag.Actor4_Pelicula = new SelectList(db.Actors, "ID_Actor", "Nombre_Actor", pelicula.Actor4_Pelicula);
            ViewBag.Genero_Pelicula = new SelectList(db.Generoes, "ID_Genero", "Nombre_Genero", pelicula.Genero_Pelicula);
            ViewBag.Idioma_Pelicula = new SelectList(db.Idiomas, "ID_Idioma", "Nombre_Idioma", pelicula.Idioma_Pelicula);
            return View(pelicula);
        }

        // GET: Peliculas/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pelicula pelicula = db.Peliculas.Find(id);
            if (pelicula == null)
            {
                return HttpNotFound();
            }
            ViewBag.Actor1_Pelicula = new SelectList(db.Actors, "ID_Actor", "Nombre_Actor", pelicula.Actor1_Pelicula);
            ViewBag.Actor2_Pelicula = new SelectList(db.Actors, "ID_Actor", "Nombre_Actor", pelicula.Actor2_Pelicula);
            ViewBag.Actor3_Pelicula = new SelectList(db.Actors, "ID_Actor", "Nombre_Actor", pelicula.Actor3_Pelicula);
            ViewBag.Actor4_Pelicula = new SelectList(db.Actors, "ID_Actor", "Nombre_Actor", pelicula.Actor4_Pelicula);
            ViewBag.Genero_Pelicula = new SelectList(db.Generoes, "ID_Genero", "Nombre_Genero", pelicula.Genero_Pelicula);
            ViewBag.Idioma_Pelicula = new SelectList(db.Idiomas, "ID_Idioma", "Nombre_Idioma", pelicula.Idioma_Pelicula);
            return View(pelicula);
        }

        // POST: Peliculas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Pelicula,Genero_Pelicula,Nombre_Pelicula,Ano_Pelicula,Idioma_Pelicula,Actor1_Pelicula,Actor2_Pelicula,Actor3_Pelicula,Actor4_Pelicula,Archivo_Descarga_Pelicula,Archivo_Previsualizacion_Pelicula")] Pelicula pelicula)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pelicula).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Actor1_Pelicula = new SelectList(db.Actors, "ID_Actor", "Nombre_Actor", pelicula.Actor1_Pelicula);
            ViewBag.Actor2_Pelicula = new SelectList(db.Actors, "ID_Actor", "Nombre_Actor", pelicula.Actor2_Pelicula);
            ViewBag.Actor3_Pelicula = new SelectList(db.Actors, "ID_Actor", "Nombre_Actor", pelicula.Actor3_Pelicula);
            ViewBag.Actor4_Pelicula = new SelectList(db.Actors, "ID_Actor", "Nombre_Actor", pelicula.Actor4_Pelicula);
            ViewBag.Genero_Pelicula = new SelectList(db.Generoes, "ID_Genero", "Nombre_Genero", pelicula.Genero_Pelicula);
            ViewBag.Idioma_Pelicula = new SelectList(db.Idiomas, "ID_Idioma", "Nombre_Idioma", pelicula.Idioma_Pelicula);
            return View(pelicula);
        }

        // GET: Peliculas/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pelicula pelicula = db.Peliculas.Find(id);
            if (pelicula == null)
            {
                return HttpNotFound();
            }
            return View(pelicula);
        }

        // POST: Peliculas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Pelicula pelicula = db.Peliculas.Find(id);
            db.Peliculas.Remove(pelicula);
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
