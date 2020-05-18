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
    public class AsignaturasController : Controller
    {
        private LaSalleModelContainer db = new LaSalleModelContainer();

        // GET: Asignaturas
        public ActionResult Index()
        {
            var asignaturas = db.Asignaturas.Include(a => a.Docente);
            return View(asignaturas.ToList());
        }

        // GET: Asignaturas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asignatura asignatura = db.Asignaturas.Find(id);
            if (asignatura == null)
            {
                return HttpNotFound();
            }
            return View(asignatura);
        }

        // GET: Asignaturas/Create
        public ActionResult Create()
        {
            ViewBag.DocenteId = new SelectList(db.Docentes, "Id", "NombreCompleto");
            return View();
        }

        // POST: Asignaturas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Codigo,Nombre,Creditos,DocenteId")] Asignatura asignatura)
        {
            if (ModelState.IsValid)
            {
                db.Asignaturas.Add(asignatura);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DocenteId = new SelectList(db.Docentes, "Id", "NombreCompleto", asignatura.DocenteId);
            return View(asignatura);
        }

        // GET: Asignaturas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asignatura asignatura = db.Asignaturas.Find(id);
            if (asignatura == null)
            {
                return HttpNotFound();
            }
            ViewBag.DocenteId = new SelectList(db.Docentes, "Id", "NombreCompleto", asignatura.DocenteId);
            return View(asignatura);
        }

        // POST: Asignaturas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Codigo,Nombre,Creditos,DocenteId")] Asignatura asignatura)
        {
            if (ModelState.IsValid)
            {
                db.Entry(asignatura).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DocenteId = new SelectList(db.Docentes, "Id", "NombreCompleto", asignatura.DocenteId);
            return View(asignatura);
        }

        // GET: Asignaturas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asignatura asignatura = db.Asignaturas.Find(id);
            if (asignatura == null)
            {
                return HttpNotFound();
            }
            return View(asignatura);
        }

        // POST: Asignaturas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Asignatura asignatura = db.Asignaturas.Find(id);
            db.Asignaturas.Remove(asignatura);
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
