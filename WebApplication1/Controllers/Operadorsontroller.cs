using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1;

namespace WebApplication1.Controllers
{
    public class Operadorsontroller : Controller
    {
        private BD db = new BD();

        // GET: Operadorsontroller
        public ActionResult Index()
        {
            var operador = db.Operador.Include(o => o.Rol).Include(o => o.Turno);
            return View(operador.ToList());
        }

        // GET: Operadorsontroller/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Operador operador = db.Operador.Find(id);
            if (operador == null)
            {
                return HttpNotFound();
            }
            return View(operador);
        }

        // GET: Operadorsontroller/Create
        public ActionResult Create()
        {
            ViewBag.RolId = new SelectList(db.Rol, "Id", "Nombre");
            ViewBag.TurnoId = new SelectList(db.Turno, "Id", "Nombre");
            return View();
        }

        // POST: Operadorsontroller/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Rut,Nombre,Contrasena,TurnoId,RolId")] Operador operador)
        {
            if (ModelState.IsValid)
            {
                db.Operador.Add(operador);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RolId = new SelectList(db.Rol, "Id", "Nombre", operador.RolId);
            ViewBag.TurnoId = new SelectList(db.Turno, "Id", "Nombre", operador.TurnoId);
            return View(operador);
        }

        // GET: Operadorsontroller/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Operador operador = db.Operador.Find(id);
            if (operador == null)
            {
                return HttpNotFound();
            }
            ViewBag.RolId = new SelectList(db.Rol, "Id", "Nombre", operador.RolId);
            ViewBag.TurnoId = new SelectList(db.Turno, "Id", "Nombre", operador.TurnoId);
            return View(operador);
        }

        // POST: Operadorsontroller/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Rut,Nombre,Contrasena,TurnoId,RolId")] Operador operador)
        {
            if (ModelState.IsValid)
            {
                db.Entry(operador).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RolId = new SelectList(db.Rol, "Id", "Nombre", operador.RolId);
            ViewBag.TurnoId = new SelectList(db.Turno, "Id", "Nombre", operador.TurnoId);
            return View(operador);
        }

        // GET: Operadorsontroller/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Operador operador = db.Operador.Find(id);
            if (operador == null)
            {
                return HttpNotFound();
            }
            return View(operador);
        }

        // POST: Operadorsontroller/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Operador operador = db.Operador.Find(id);
            db.Operador.Remove(operador);
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
