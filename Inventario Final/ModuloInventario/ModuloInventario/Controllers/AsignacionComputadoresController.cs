using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ModuloInventario.Models;
using ModuloInventario.ViewModels;

namespace ModuloInventario.Controllers
{
    public class AsignacionComputadoresController : Controller
    {
        private InventarioContext db = new InventarioContext();

        // GET: AsignacionComputadores
        public ActionResult Index(int pagina = 1)
        {

            var aSIGNACIONCOMPUTADORES = db.ASIGNACIONCOMPUTADORES.Include(a => a.INGRESOCOMPUTADORES).Include(a => a.PERSONA).Include(a => a.SEDE);
            var cantidadRegistrosPorPagina = 10;
            using (var db = new InventarioContext())
            {

                var AsignacionComputador = aSIGNACIONCOMPUTADORES.OrderBy(x => x.SECUENCIAL)
                    .Skip((pagina - 1) * cantidadRegistrosPorPagina)
                    .Take(cantidadRegistrosPorPagina).ToList();
                var totalDeRegistros = aSIGNACIONCOMPUTADORES.Count();

                var modelo = new IndexViewModel();
                modelo.asignacionComputador = AsignacionComputador;
                modelo.PaginaActual = pagina;
                modelo.TotalDeRegistros = totalDeRegistros;
                modelo.RegistrosPorPagina = cantidadRegistrosPorPagina;

                return View(modelo);
            }
            //return View(aSIGNACIONCOMPUTADORES.ToList());
        }

        // GET: AsignacionComputadores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ASIGNACIONCOMPUTADORES aSIGNACIONCOMPUTADORES = db.ASIGNACIONCOMPUTADORES.Find(id);
            if (aSIGNACIONCOMPUTADORES == null)
            {
                return HttpNotFound();
            }
            return View(aSIGNACIONCOMPUTADORES);
        }

        // GET: AsignacionComputadores/Create
        public ActionResult Create()
        {
            ViewBag.SECUENCIALCOMPUTADOR = new SelectList(db.INGRESOCOMPUTADORES, "SECUENCIAL", "CODIGOINTERNO");
            ViewBag.SECUENCIALRESPONSABLE = new SelectList(db.PERSONA, "SECUENCIAL", "NOMBRE1");
            ViewBag.UBICACION = new SelectList(db.SEDE, "SECUENCIAL", "DESCRIPCION");
            return View();
        }

        // POST: AsignacionComputadores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SECUENCIAL,SECUENCIALRESPONSABLE,SECUENCIALCOMPUTADOR,UBICACION,TIEMPOINICIO,TIEMPOFIN,ESTADOENTREGA")] ASIGNACIONCOMPUTADORES aSIGNACIONCOMPUTADORES)
        {
            if (ModelState.IsValid)
            {
                db.ASIGNACIONCOMPUTADORES.Add(aSIGNACIONCOMPUTADORES);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SECUENCIALCOMPUTADOR = new SelectList(db.INGRESOCOMPUTADORES, "SECUENCIAL", "CODIGOINTERNO", aSIGNACIONCOMPUTADORES.SECUENCIALCOMPUTADOR);
            ViewBag.SECUENCIALRESPONSABLE = new SelectList(db.PERSONA, "SECUENCIAL", "NOMBRE1", aSIGNACIONCOMPUTADORES.SECUENCIALRESPONSABLE);
            ViewBag.UBICACION = new SelectList(db.SEDE, "SECUENCIAL", "CODIGO", aSIGNACIONCOMPUTADORES.UBICACION);
            return View(aSIGNACIONCOMPUTADORES);
        }

        // GET: AsignacionComputadores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ASIGNACIONCOMPUTADORES aSIGNACIONCOMPUTADORES = db.ASIGNACIONCOMPUTADORES.Find(id);
            if (aSIGNACIONCOMPUTADORES == null)
            {
                return HttpNotFound();
            }
            ViewBag.SECUENCIALCOMPUTADOR = new SelectList(db.INGRESOCOMPUTADORES, "SECUENCIAL", "CODIGOINTERNO", aSIGNACIONCOMPUTADORES.SECUENCIALCOMPUTADOR);
            ViewBag.SECUENCIALRESPONSABLE = new SelectList(db.PERSONA, "SECUENCIAL", "NOMBRE1", aSIGNACIONCOMPUTADORES.SECUENCIALRESPONSABLE);
            ViewBag.UBICACION = new SelectList(db.SEDE, "SECUENCIAL", "CODIGO", aSIGNACIONCOMPUTADORES.UBICACION);
            return View(aSIGNACIONCOMPUTADORES);
        }

        // POST: AsignacionComputadores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SECUENCIAL,SECUENCIALRESPONSABLE,SECUENCIALCOMPUTADOR,UBICACION,TIEMPOINICIO,TIEMPOFIN,ESTADOENTREGA")] ASIGNACIONCOMPUTADORES aSIGNACIONCOMPUTADORES)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aSIGNACIONCOMPUTADORES).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SECUENCIALCOMPUTADOR = new SelectList(db.INGRESOCOMPUTADORES, "SECUENCIAL", "CODIGOINTERNO", aSIGNACIONCOMPUTADORES.SECUENCIALCOMPUTADOR);
            ViewBag.SECUENCIALRESPONSABLE = new SelectList(db.PERSONA, "SECUENCIAL", "NOMBRE1", aSIGNACIONCOMPUTADORES.SECUENCIALRESPONSABLE);
            ViewBag.UBICACION = new SelectList(db.SEDE, "SECUENCIAL", "CODIGO", aSIGNACIONCOMPUTADORES.UBICACION);
            return View(aSIGNACIONCOMPUTADORES);
        }

        // GET: AsignacionComputadores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ASIGNACIONCOMPUTADORES aSIGNACIONCOMPUTADORES = db.ASIGNACIONCOMPUTADORES.Find(id);
            if (aSIGNACIONCOMPUTADORES == null)
            {
                return HttpNotFound();
            }
            return View(aSIGNACIONCOMPUTADORES);
        }

        // POST: AsignacionComputadores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ASIGNACIONCOMPUTADORES aSIGNACIONCOMPUTADORES = db.ASIGNACIONCOMPUTADORES.Find(id);
            db.ASIGNACIONCOMPUTADORES.Remove(aSIGNACIONCOMPUTADORES);
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
