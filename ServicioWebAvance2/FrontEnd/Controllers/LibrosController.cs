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
    public class LibrosController : Controller
    {
        Libro libro = new Libro();
        Pelicula pelicula = new Pelicula();

        private ServiciosWebEntities db = new ServiciosWebEntities();

        // GET: Libroes
        public ViewResult Index(string sortOrder, string searchString)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "Nombre" : "";

            ViewBag.CurrentSort = sortOrder;

            

            var libros = db.Libros.Include(l => l.Autor).Include(l => l.Editorial).Include(l => l.Genero).Include(l => l.Idioma);

            if (!String.IsNullOrEmpty(searchString))
            {

                libros = libros.Where(s => s.Nombre_Libro.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "Nombre_Libro":
                    libros = libros.OrderByDescending(s => s.Nombre_Libro);
                    break;
            }

            return View(libros.ToList());
        }
        public ActionResult Search(string Searching)
        {
            List<Libro> Libros = db.Libros.ToList();

            return View(db.Libros.Where(x => x.Nombre_Libro.Contains(Searching) || Searching == null).ToList());
        }

        // GET: Libroes/Details/5
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

        // GET: Libroes/Create
        public ActionResult Create()
        {
            ViewBag.Autor_Libro = new SelectList(db.Autors, "ID_Autor", "Nombre_Autor");
            ViewBag.Editorial_Libro = new SelectList(db.Editorials, "ID_Editorial", "Nombre_Editorial");
            ViewBag.Genero_Libro = new SelectList(db.Generoes, "ID_Genero", "Nombre_Genero");
            ViewBag.Idioma_Libro = new SelectList(db.Idiomas, "ID_Idioma", "Nombre_Idioma");
            return View();
        }

        // POST: Libroes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Libro,Genero_Libro,Nombre_Libro,Autor_Libro,Idioma_Libro,Editorial_Libro,Ano_Libro,Archivo_Descarga_Libros,Archivo_Previsualizacion_Libro")] Libro libro)
        {
            if (ModelState.IsValid)
            {
                db.InsertLibro(libro.Genero_Libro, libro.Nombre_Libro, libro.Autor_Libro, libro.Idioma_Libro, libro.Editorial_Libro, libro.Ano_Libro,libro.Archivo_Previsualizacion_Libro,libro.Archivo_Descarga_Libros);
                //db.Libros.Add(libro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Autor_Libro = new SelectList(db.Autors, "ID_Autor", "Nombre_Autor", libro.Autor_Libro);
            ViewBag.Editorial_Libro = new SelectList(db.Editorials, "ID_Editorial", "Nombre_Editorial", libro.Editorial_Libro);
            ViewBag.Genero_Libro = new SelectList(db.Generoes, "ID_Genero", "Nombre_Genero", libro.Genero_Libro);
            ViewBag.Idioma_Libro = new SelectList(db.Idiomas, "ID_Idioma", "Nombre_Idioma", libro.Idioma_Libro);
            return View(libro);
        }

        // GET: Libroes/Edit/5
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

        // POST: Libroes/Edit/5
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

        // GET: Libroes/Delete/5
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

        // POST: Libroes/Delete/5
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

        //public ActionResult Search(string Searching)
        //{
        //    return View(db.Libros.Where(x => x.Nombre_Libro.Contains(Searching) || Searching == null).ToList());
        //}
    }
}
