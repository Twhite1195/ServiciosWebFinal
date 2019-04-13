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
    public class UsuariosController : Controller
    {
        private ServiciosWebEntities db = new ServiciosWebEntities();

        // GET: Usuarios
        public ActionResult Index()
        {
            var usuarios = db.Usuarios.Include(u => u.Tipo_Usuario1);
            return View(usuarios.ToList());
        }

        internal List<Usuario> ListUsuarios()
        {
            List<Usuario> ListaUsuarios = new List<Usuario>();
            var Usuarios = from s in db.Usuarios
                           select s;
            foreach (Usuario element in Usuarios)
            {

                ListaUsuarios.Add(element);

            }
            return ListaUsuarios;
        }

        // GET: Usuarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuarios.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // GET: Usuarios/Create
        public ActionResult Create()
        {
            ViewBag.Tipo_Usuario = new SelectList(db.Tipo_Usuario, "Cod_Tipo_Usuario", "Nombre_Tipo_Usuario");
            return View();
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Cod_Usuario,Nombre_Usuario,Pri_Ape_Usuario,Seg_Ape_Usuario,Email_Usuario,Pass_Usuario,Tipo_Usuario")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Usuarios.Add(usuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Tipo_Usuario = new SelectList(db.Tipo_Usuario, "Cod_Tipo_Usuario", "Nombre_Tipo_Usuario", usuario.Tipo_Usuario);
            return View(usuario);
        }

        // GET: Usuarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuarios.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            ViewBag.Tipo_Usuario = new SelectList(db.Tipo_Usuario, "Cod_Tipo_Usuario", "Nombre_Tipo_Usuario", usuario.Tipo_Usuario);
            return View(usuario);
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Cod_Usuario,Nombre_Usuario,Pri_Ape_Usuario,Seg_Ape_Usuario,Email_Usuario,Pass_Usuario,Tipo_Usuario")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Tipo_Usuario = new SelectList(db.Tipo_Usuario, "Cod_Tipo_Usuario", "Nombre_Tipo_Usuario", usuario.Tipo_Usuario);
            return View(usuario);
        }

        // GET: Usuarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuarios.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Usuario usuario = db.Usuarios.Find(id);
            db.Usuarios.Remove(usuario);
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
