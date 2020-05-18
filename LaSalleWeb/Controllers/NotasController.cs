using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LaSalleWeb.Models;

namespace LaSalleWeb.Controllers
{
    [Authorize]
    public class NotasController : Controller
    {
        private LaSalleModelContainer db = new LaSalleModelContainer();

        // GET: Notas
        public ActionResult Index()
        {
            var notas = db.Notas.Include(n => n.Alumno).Include(n => n.Asignatura);
            return View(notas.ToList());
        }

        // GET: Notas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nota nota = db.Notas.Find(id);
            if (nota == null)
            {
                return HttpNotFound();
            }
            return View(nota);
        }

        // GET: Notas/Create
        public ActionResult Create()
        {
            ViewBag.AlumnoId = new SelectList(db.Alumnos, "Id", "Carnet");
            ViewBag.AsignaturaId = new SelectList(db.Asignaturas, "Id", "Codigo");
            return View();
        }

        // POST: Notas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Acumulado,Examen,AlumnoId,AsignaturaId")] Nota nota)
        {
            if (ModelState.IsValid)
            {
                db.Notas.Add(nota);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AlumnoId = new SelectList(db.Alumnos, "Id", "Carnet", nota.AlumnoId);
            ViewBag.AsignaturaId = new SelectList(db.Asignaturas, "Id", "Codigo", nota.AsignaturaId);
            return View(nota);
        }

        // GET: Notas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nota nota = db.Notas.Find(id);
            if (nota == null)
            {
                return HttpNotFound();
            }
            ViewBag.AlumnoId = new SelectList(db.Alumnos, "Id", "Carnet", nota.AlumnoId);
            ViewBag.AsignaturaId = new SelectList(db.Asignaturas, "Id", "Codigo", nota.AsignaturaId);
            return View(nota);
        }

        // POST: Notas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Acumulado,Examen,AlumnoId,AsignaturaId")] Nota nota)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nota).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AlumnoId = new SelectList(db.Alumnos, "Id", "Carnet", nota.AlumnoId);
            ViewBag.AsignaturaId = new SelectList(db.Asignaturas, "Id", "Codigo", nota.AsignaturaId);
            return View(nota);
        }

        // GET: Notas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nota nota = db.Notas.Find(id);
            if (nota == null)
            {
                return HttpNotFound();
            }
            return View(nota);
        }

        // POST: Notas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Nota nota = db.Notas.Find(id);
            db.Notas.Remove(nota);
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
