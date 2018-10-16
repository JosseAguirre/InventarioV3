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
    public class AsignacionVariosController : Controller
    {
        private InventarioContext db = new InventarioContext();

        // GET: AsignacionVarios
        public ActionResult Index(string currentFilter, string searchString, int pagina = 1)
        {
            ViewBag.SearchString = searchString;

            if (searchString != null)
            {
                pagina = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var aSIGNACIONVARIOS = db.ASIGNACIONVARIOS.Include(a => a.INGRESOVARIOS).Include(a => a.PERSONA).Include(a => a.SEDE);

            if (!String.IsNullOrEmpty(searchString))
            {
                aSIGNACIONVARIOS = aSIGNACIONVARIOS.Where(s => s.INGRESOVARIOS.CODIGOINTERNO.ToUpper().Contains(searchString.ToUpper()) ||
                s.PERSONA.NOMBRE1.ToUpper().Contains(searchString.ToUpper()) || s.PERSONA.APELLIDO1.ToUpper().Contains(searchString.ToUpper()) ||
                s.SEDE.DESCRIPCION.ToUpper().Contains(searchString.ToUpper()));

            }

            var cantidadRegistrosPorPagina = 10;
            using (var db = new InventarioContext())
            {

                var AsignacionVarios = aSIGNACIONVARIOS.OrderBy(x => x.SECUENCIAL)
                    .Skip((pagina - 1) * cantidadRegistrosPorPagina)
                    .Take(cantidadRegistrosPorPagina).ToList();
                var totalDeRegistros = aSIGNACIONVARIOS.Count();

                var modelo = new IndexViewModel();
                modelo.asignacionVarios = AsignacionVarios;
                modelo.PaginaActual = pagina;
                modelo.TotalDeRegistros = totalDeRegistros;
                modelo.RegistrosPorPagina = cantidadRegistrosPorPagina;

                return View(modelo);
            }

            return View(aSIGNACIONVARIOS.ToList());
        }

        // GET: AsignacionVarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ASIGNACIONVARIOS aSIGNACIONVARIOS = db.ASIGNACIONVARIOS.Find(id);
            if (aSIGNACIONVARIOS == null)
            {
                return HttpNotFound();
            }
            return View(aSIGNACIONVARIOS);
        }

        // GET: AsignacionVarios/Create
        public ActionResult Create()
        {
            ViewBag.SECUENCIALVARIOS = new SelectList(db.INGRESOVARIOS, "SECUENCIAL", "CODIGOINTERNO");
            ViewBag.SECUENCIALRESPONSABLE = new SelectList(db.PERSONA, "SECUENCIAL", "NOMBREUNIDO");
            ViewBag.UBICACION = new SelectList(db.SEDE, "SECUENCIAL", "DESCRIPCION");
            return View();
        }

        // POST: AsignacionVarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SECUENCIAL,SECUENCIALRESPONSABLE,SECUENCIALVARIOS,UBICACION,TIEMPOINICIO,TIEMPOFIN,ESTADOENTREGA")] ASIGNACIONVARIOS aSIGNACIONVARIOS)
        {
            if (ModelState.IsValid)
            {
                db.ASIGNACIONVARIOS.Add(aSIGNACIONVARIOS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SECUENCIALVARIOS = new SelectList(db.INGRESOVARIOS, "SECUENCIAL", "CODIGOINTERNO", aSIGNACIONVARIOS.SECUENCIALVARIOS);
            ViewBag.SECUENCIALRESPONSABLE = new SelectList(db.PERSONA, "SECUENCIAL", "NOMBRE1", aSIGNACIONVARIOS.SECUENCIALRESPONSABLE);
            ViewBag.UBICACION = new SelectList(db.SEDE, "SECUENCIAL", "CODIGO", aSIGNACIONVARIOS.UBICACION);
            return View(aSIGNACIONVARIOS);
        }

        // GET: AsignacionVarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ASIGNACIONVARIOS aSIGNACIONVARIOS = db.ASIGNACIONVARIOS.Find(id);
            if (aSIGNACIONVARIOS == null)
            {
                return HttpNotFound();
            }
            ViewBag.SECUENCIALVARIOS = new SelectList(db.INGRESOVARIOS, "SECUENCIAL", "CODIGOINTERNO", aSIGNACIONVARIOS.SECUENCIALVARIOS);
            ViewBag.SECUENCIALRESPONSABLE = new SelectList(db.PERSONA, "SECUENCIAL", "NOMBRE1", aSIGNACIONVARIOS.SECUENCIALRESPONSABLE);
            ViewBag.UBICACION = new SelectList(db.SEDE, "SECUENCIAL", "CODIGO", aSIGNACIONVARIOS.UBICACION);
            return View(aSIGNACIONVARIOS);
        }

        // POST: AsignacionVarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SECUENCIAL,SECUENCIALRESPONSABLE,SECUENCIALVARIOS,UBICACION,TIEMPOINICIO,TIEMPOFIN,ESTADOENTREGA")] ASIGNACIONVARIOS aSIGNACIONVARIOS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aSIGNACIONVARIOS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SECUENCIALVARIOS = new SelectList(db.INGRESOVARIOS, "SECUENCIAL", "CODIGOINTERNO", aSIGNACIONVARIOS.SECUENCIALVARIOS);
            ViewBag.SECUENCIALRESPONSABLE = new SelectList(db.PERSONA, "SECUENCIAL", "NOMBRE1", aSIGNACIONVARIOS.SECUENCIALRESPONSABLE);
            ViewBag.UBICACION = new SelectList(db.SEDE, "SECUENCIAL", "CODIGO", aSIGNACIONVARIOS.UBICACION);
            return View(aSIGNACIONVARIOS);
        }

        // GET: AsignacionVarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ASIGNACIONVARIOS aSIGNACIONVARIOS = db.ASIGNACIONVARIOS.Find(id);
            if (aSIGNACIONVARIOS == null)
            {
                return HttpNotFound();
            }
            return View(aSIGNACIONVARIOS);
        }

        // POST: AsignacionVarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ASIGNACIONVARIOS aSIGNACIONVARIOS = db.ASIGNACIONVARIOS.Find(id);
            db.ASIGNACIONVARIOS.Remove(aSIGNACIONVARIOS);
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
