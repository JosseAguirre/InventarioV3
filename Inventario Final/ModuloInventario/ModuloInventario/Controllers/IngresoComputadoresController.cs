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
    public class IngresoComputadoresController : Controller
    {
        private InventarioContext db = new InventarioContext();

        // GET: IngresoComputadores
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

            var iNGRESOCOMPUTADORES = db.INGRESOCOMPUTADORES.Include(i => i.PERSONA).Include(i => i.SEDE);

            if (!String.IsNullOrEmpty(searchString))
            {
                iNGRESOCOMPUTADORES = iNGRESOCOMPUTADORES.Where(s => s.CODIGOINTERNO.ToUpper().Contains(searchString.ToUpper()) ||
                s.ARTICULO.ToUpper().Contains(searchString.ToUpper()) || s.PROCESADOR.ToUpper().Contains(searchString.ToUpper()) ||
                s.MARCA.ToUpper().Contains(searchString.ToUpper()) || s.MODELO.ToUpper().Contains(searchString.ToUpper()) ||
                s.PERSONA.NOMBRE1.ToUpper().Contains(searchString.ToUpper()) || s.PERSONA.APELLIDO1.ToUpper().Contains(searchString.ToUpper()) ||
                s.SEDE.DESCRIPCION.ToUpper().Contains(searchString.ToUpper()));

            }
            var cantidadRegistrosPorPagina = 10;
            using (var db = new InventarioContext())
            {

                var IngresoComputador = iNGRESOCOMPUTADORES.OrderBy(x => x.SECUENCIAL)
                    .Skip((pagina - 1) * cantidadRegistrosPorPagina)
                    .Take(cantidadRegistrosPorPagina).ToList();
                var totalDeRegistros = iNGRESOCOMPUTADORES.Count();

                var modelo = new IndexViewModel();
                modelo.ingresoComputador = IngresoComputador;
                modelo.PaginaActual = pagina;
                modelo.TotalDeRegistros = totalDeRegistros;
                modelo.RegistrosPorPagina = cantidadRegistrosPorPagina;

                return View(modelo);
            }

            //return View(iNGRESOCOMPUTADORES.ToList());
        }

        // GET: IngresoComputadores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            INGRESOCOMPUTADORES iNGRESOCOMPUTADORES = db.INGRESOCOMPUTADORES.Find(id);
            if (iNGRESOCOMPUTADORES == null)
            {
                return HttpNotFound();
            }
            return View(iNGRESOCOMPUTADORES);
        }

        // GET: IngresoComputadores/Create
        public ActionResult Create()
        {
            ViewBag.SECUENCIALRESPONSABLE = new SelectList(db.PERSONA, "SECUENCIAL", "NOMBRE1");
            ViewBag.UBICACIONDEORIGEN = new SelectList(db.SEDE, "SECUENCIAL", "DESCRIPCION");
            return View();
        }

        // POST: IngresoComputadores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SECUENCIAL,SECUENCIALRESPONSABLE,CODIGOINTERNO,UBICACIONDEORIGEN,ARTICULO,MEMORIARAM,PROCESADOR,DISCODURO,LICENCIADO,OFFICE,MARCA,MODELO,SERIE,PARTICULARIDAD,ESTADO,NODEFACTURA,VALORFACTURA,FECHAADQUISICION,OBSERVACIONES")] INGRESOCOMPUTADORES iNGRESOCOMPUTADORES)
        {
            if (ModelState.IsValid)
            {
                db.INGRESOCOMPUTADORES.Add(iNGRESOCOMPUTADORES);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SECUENCIALRESPONSABLE = new SelectList(db.PERSONA, "SECUENCIAL", "NOMBRE1", iNGRESOCOMPUTADORES.SECUENCIALRESPONSABLE);
            ViewBag.UBICACIONDEORIGEN = new SelectList(db.SEDE, "SECUENCIAL", "CODIGO", iNGRESOCOMPUTADORES.UBICACIONDEORIGEN);
            return View(iNGRESOCOMPUTADORES);
        }

        // GET: IngresoComputadores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            INGRESOCOMPUTADORES iNGRESOCOMPUTADORES = db.INGRESOCOMPUTADORES.Find(id);
            if (iNGRESOCOMPUTADORES == null)
            {
                return HttpNotFound();
            }
            ViewBag.SECUENCIALRESPONSABLE = new SelectList(db.PERSONA, "SECUENCIAL", "NOMBRE1", iNGRESOCOMPUTADORES.SECUENCIALRESPONSABLE);
            ViewBag.UBICACIONDEORIGEN = new SelectList(db.SEDE, "SECUENCIAL", "CODIGO", iNGRESOCOMPUTADORES.UBICACIONDEORIGEN);
            return View(iNGRESOCOMPUTADORES);
        }

        // POST: IngresoComputadores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SECUENCIAL,SECUENCIALRESPONSABLE,CODIGOINTERNO,UBICACIONDEORIGEN,ARTICULO,MEMORIARAM,PROCESADOR,DISCODURO,LICENCIADO,OFFICE,MARCA,MODELO,SERIE,PARTICULARIDAD,ESTADO,NODEFACTURA,VALORFACTURA,FECHAADQUISICION,OBSERVACIONES")] INGRESOCOMPUTADORES iNGRESOCOMPUTADORES)
        {
            if (ModelState.IsValid)
            {
                db.Entry(iNGRESOCOMPUTADORES).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SECUENCIALRESPONSABLE = new SelectList(db.PERSONA, "SECUENCIAL", "NOMBRE1", iNGRESOCOMPUTADORES.SECUENCIALRESPONSABLE);
            ViewBag.UBICACIONDEORIGEN = new SelectList(db.SEDE, "SECUENCIAL", "CODIGO", iNGRESOCOMPUTADORES.UBICACIONDEORIGEN);
            return View(iNGRESOCOMPUTADORES);
        }

        // GET: IngresoComputadores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            INGRESOCOMPUTADORES iNGRESOCOMPUTADORES = db.INGRESOCOMPUTADORES.Find(id);
            if (iNGRESOCOMPUTADORES == null)
            {
                return HttpNotFound();
            }
            return View(iNGRESOCOMPUTADORES);
        }

        // POST: IngresoComputadores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            INGRESOCOMPUTADORES iNGRESOCOMPUTADORES = db.INGRESOCOMPUTADORES.Find(id);
            db.INGRESOCOMPUTADORES.Remove(iNGRESOCOMPUTADORES);
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
