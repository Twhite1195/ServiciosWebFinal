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
    public class MusicaController : Controller
    {
        private ServiciosWebEntities db = new ServiciosWebEntities();

        // GET: Musicas
        public ViewResult Index(string sortOrder, string searchString)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "Nombre" : "";

            ViewBag.CurrentSort = sortOrder;

            var musicas = db.Musicas.Include(m => m.Disco).Include(m => m.Disquera).Include(m => m.Genero).Include(m => m.Idioma).Include(m => m.Pai);

            if (!String.IsNullOrEmpty(searchString))
            {

                musicas = musicas.Where(s => s.Nombre_Musica.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "Nombre_Libro":
                    musicas = musicas.OrderByDescending(s => s.Nombre_Musica);
                    break;
            }
            return View(musicas.ToList());
        }
        public ActionResult Search(string Searching)
        {
            List<Musica> Musicas = db.Musicas.ToList();

            return View(db.Musicas.Where(x => x.Nombre_Musica.Contains(Searching) || Searching == null).ToList());
        }

        // GET: Musicas/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Musica musica = db.Musicas.Find(id);
            if (musica == null)
            {
                return HttpNotFound();
            }
            return View(musica);
        }

        // GET: Musicas/Create
        public ActionResult Create()
        {
            ViewBag.Disco_Musica = new SelectList(db.Discoes, "ID_Disco", "Nombre_Disco");
            ViewBag.Disquera_Musica = new SelectList(db.Disqueras, "ID_Disquera", "Nombre_Disquera");
            ViewBag.Genero_Musica = new SelectList(db.Generoes, "ID_Genero", "Nombre_Genero");
            ViewBag.Idioma_Musica = new SelectList(db.Idiomas, "ID_Idioma", "Nombre_Idioma");
            ViewBag.Pais_Musica = new SelectList(db.Pais, "ID_Pais", "Nombre_Pais");
            return View();
        }

        // POST: Musicas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Musica,Genero_Musica,Nombre_Musica,Tipo_Inerpretacion_Musica,Idioma_Musica,Pais_Musica,Disquera_Musica,Disco_Musica,Ano_Musica,Archivo_Descarga_Musica,Archivo_Previsualizacion_Musica")] Musica musica)
        {
            if (ModelState.IsValid)
            {
                db.InsertMusica(musica.Genero_Musica, musica.Nombre_Musica, musica.Tipo_Inerpretacion_Musica, musica.Idioma_Musica, musica.Pais_Musica, musica.Disquera_Musica, musica.Disco_Musica, musica.Ano_Musica, musica.Archivo_Previsualizacion_Musica, musica.Archivo_Descarga_Musica);
                //db.Musicas.Add(musica);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Disco_Musica = new SelectList(db.Discoes, "ID_Disco", "Nombre_Disco", musica.Disco_Musica);
            ViewBag.Disquera_Musica = new SelectList(db.Disqueras, "ID_Disquera", "Nombre_Disquera", musica.Disquera_Musica);
            ViewBag.Genero_Musica = new SelectList(db.Generoes, "ID_Genero", "Nombre_Genero", musica.Genero_Musica);
            ViewBag.Idioma_Musica = new SelectList(db.Idiomas, "ID_Idioma", "Nombre_Idioma", musica.Idioma_Musica);
            ViewBag.Pais_Musica = new SelectList(db.Pais, "ID_Pais", "Nombre_Pais", musica.Pais_Musica);
            return View(musica);
        }

        // GET: Musicas/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Musica musica = db.Musicas.Find(id);
            if (musica == null)
            {
                return HttpNotFound();
            }
            ViewBag.Disco_Musica = new SelectList(db.Discoes, "ID_Disco", "Nombre_Disco", musica.Disco_Musica);
            ViewBag.Disquera_Musica = new SelectList(db.Disqueras, "ID_Disquera", "Nombre_Disquera", musica.Disquera_Musica);
            ViewBag.Genero_Musica = new SelectList(db.Generoes, "ID_Genero", "Nombre_Genero", musica.Genero_Musica);
            ViewBag.Idioma_Musica = new SelectList(db.Idiomas, "ID_Idioma", "Nombre_Idioma", musica.Idioma_Musica);
            ViewBag.Pais_Musica = new SelectList(db.Pais, "ID_Pais", "Nombre_Pais", musica.Pais_Musica);
            return View(musica);
        }

        // POST: Musicas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Musica,Genero_Musica,Nombre_Musica,Tipo_Inerpretacion_Musica,Idioma_Musica,Pais_Musica,Disquera_Musica,Disco_Musica,Ano_Musica,Archivo_Descarga_Musica,Archivo_Previsualizacion_Musica")] Musica musica)
        {
            if (ModelState.IsValid)
            {
                db.Entry(musica).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Disco_Musica = new SelectList(db.Discoes, "ID_Disco", "Nombre_Disco", musica.Disco_Musica);
            ViewBag.Disquera_Musica = new SelectList(db.Disqueras, "ID_Disquera", "Nombre_Disquera", musica.Disquera_Musica);
            ViewBag.Genero_Musica = new SelectList(db.Generoes, "ID_Genero", "Nombre_Genero", musica.Genero_Musica);
            ViewBag.Idioma_Musica = new SelectList(db.Idiomas, "ID_Idioma", "Nombre_Idioma", musica.Idioma_Musica);
            ViewBag.Pais_Musica = new SelectList(db.Pais, "ID_Pais", "Nombre_Pais", musica.Pais_Musica);
            return View(musica);
        }

        // GET: Musicas/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Musica musica = db.Musicas.Find(id);
            if (musica == null)
            {
                return HttpNotFound();
            }
            return View(musica);
        }

        // POST: Musicas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Musica musica = db.Musicas.Find(id);
            db.Musicas.Remove(musica);
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
