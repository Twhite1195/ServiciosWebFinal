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
    public class LibroController : Controller
    {
        private ServiciosWebEntities db = new ServiciosWebEntities();

        // GET: Libro
        public ActionResult Index()
        {
            var libros = db.Libros.Include(l => l.Autor).Include(l => l.Editorial).Include(l => l.Genero).Include(l => l.Idioma);
            return View(libros.ToList());
        }

        // GET: Libro/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Libro libro = db.Libros.Find(id);
            if (libro == null)
            {
                return HttpNotFound();
            }
            return View(libro);
        }

        // GET: Libro/Create
        public ActionResult Create()
        {
            ViewBag.Autor_Libro = new SelectList(db.Autors, "ID_Autor", "Nombre_Autor");
            ViewBag.Editorial_Libro = new SelectList(db.Editorials, "ID_Editorial", "Nombre_Editorial");
            ViewBag.Genero_Libro = new SelectList(db.Generoes, "ID_Genero", "Nombre_Genero");
            ViewBag.Idioma_Libro = new SelectList(db.Idiomas, "ID_Idioma", "Nombre_Idioma");
            return View();
        }

        // POST: Libro/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Libro,Genero_Libro,Nombre_Libro,Autor_Libro,Idioma_Libro,Editorial_Libro,Ano_Libro,Archivo_Descarga_Libros,Archivo_Previsualizacion_Libro")] Libro libro)
        {
            if (ModelState.IsValid)
            {
                //db.Libros.Add(libro);
                db.InsertLibro(libro.Genero_Libro, libro.Nombre_Libro, libro.Autor_Libro, libro.Idioma_Libro, libro.Editorial_Libro, libro.Ano_Libro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Autor_Libro = new SelectList(db.Autors, "ID_Autor", "Nombre_Autor", libro.Autor_Libro);
            ViewBag.Editorial_Libro = new SelectList(db.Editorials, "ID_Editorial", "Nombre_Editorial", libro.Editorial_Libro);
            ViewBag.Genero_Libro = new SelectList(db.Generoes, "ID_Genero", "Nombre_Genero", libro.Genero_Libro);
            ViewBag.Idioma_Libro = new SelectList(db.Idiomas, "ID_Idioma", "Nombre_Idioma", libro.Idioma_Libro);
            return View(libro);
        }

        // GET: Libro/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Libro libro = db.Libros.Find(id);
            if (libro == null)
            {
                return HttpNotFound();
            }
            ViewBag.Autor_Libro = new SelectList(db.Autors, "ID_Autor", "Nombre_Autor", libro.Autor_Libro);
            ViewBag.Editorial_Libro = new SelectList(db.Editorials, "ID_Editorial", "Nombre_Editorial", libro.Editorial_Libro);
            ViewBag.Genero_Libro = new SelectList(db.Generoes, "ID_Genero", "Nombre_Genero", libro.Genero_Libro);
            ViewBag.Idioma_Libro = new SelectList(db.Idiomas, "ID_Idioma", "Nombre_Idioma", libro.Idioma_Libro);
            return View(libro);
        }

        // POST: Libro/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Libro,Genero_Libro,Nombre_Libro,Autor_Libro,Idioma_Libro,Editorial_Libro,Ano_Libro,Archivo_Descarga_Libros,Archivo_Previsualizacion_Libro")] Libro libro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(libro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Autor_Libro = new SelectList(db.Autors, "ID_Autor", "Nombre_Autor", libro.Autor_Libro);
            ViewBag.Editorial_Libro = new SelectList(db.Editorials, "ID_Editorial", "Nombre_Editorial", libro.Editorial_Libro);
            ViewBag.Genero_Libro = new SelectList(db.Generoes, "ID_Genero", "Nombre_Genero", libro.Genero_Libro);
            ViewBag.Idioma_Libro = new SelectList(db.Idiomas, "ID_Idioma", "Nombre_Idioma", libro.Idioma_Libro);
            return View(libro);
        }

        // GET: Libro/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Libro libro = db.Libros.Find(id);
            if (libro == null)
            {
                return HttpNotFound();
            }
            return View(libro);
        }

        // POST: Libro/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Libro libro = db.Libros.Find(id);
            db.Libros.Remove(libro);
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
