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
    public class IngresoVariosController : Controller
    {
        private InventarioContext db = new InventarioContext();

        // GET: IngresoVarios
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

            var iNGRESOVARIOS = db.INGRESOVARIOS.Include(i => i.ARTICULO).Include(i => i.PERSONA).Include(i => i.SEDE);

            if (!String.IsNullOrEmpty(searchString))
            {
                iNGRESOVARIOS = iNGRESOVARIOS.Where(s => s.CODIGOINTERNO.ToUpper().Contains(searchString.ToUpper()) ||
                s.ARTICULO.ARTICULO1.ToUpper().Contains(searchString.ToUpper()) ||
                s.MARCA.ToUpper().Contains(searchString.ToUpper()) || s.MODELO.ToUpper().Contains(searchString.ToUpper()) ||
                s.PERSONA.NOMBRE1.ToUpper().Contains(searchString.ToUpper()) || s.PERSONA.APELLIDO1.ToUpper().Contains(searchString.ToUpper()) ||
                s.SEDE.DESCRIPCION.ToUpper().Contains(searchString.ToUpper()));

            }

            var cantidadRegistrosPorPagina = 10;
            using (var db = new InventarioContext())
            {

                var IngresoVarios = iNGRESOVARIOS.OrderBy(x => x.SECUENCIAL)
                    .Skip((pagina - 1) * cantidadRegistrosPorPagina)
                    .Take(cantidadRegistrosPorPagina).ToList();
                var totalDeRegistros = iNGRESOVARIOS.Count();

                var modelo = new IndexViewModel();
                modelo.ingresoVarios = IngresoVarios;
                modelo.PaginaActual = pagina;
                modelo.TotalDeRegistros = totalDeRegistros;
                modelo.RegistrosPorPagina = cantidadRegistrosPorPagina;

                return View(modelo);
            }

            //return View(iNGRESOVARIOS.ToList());
        }

        // GET: IngresoVarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            INGRESOVARIOS iNGRESOVARIOS = db.INGRESOVARIOS.Find(id);
            if (iNGRESOVARIOS == null)
            {
                return HttpNotFound();
            }
            return View(iNGRESOVARIOS);
        }

        // GET: IngresoVarios/Create
        public ActionResult Create()
        {
            ViewBag.SECUENCIALARTICULO = new SelectList(db.ARTICULO, "SECUENCIAL", "ARTICULO1");
            ViewBag.SECUENCIALRESPONSABLE = new SelectList(db.PERSONA, "SECUENCIAL", "NOMBRE1");
            ViewBag.CUADADDEUBICACION = new SelectList(db.SEDE, "SECUENCIAL", "DESCRIPCION");
            return View();
        }

        // POST: IngresoVarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SECUENCIAL,SECUENCIALRESPONSABLE,CODIGOINTERNO,CUADADDEUBICACION,SECUENCIALARTICULO,MARCA,MODELO,SERIE,PARTICULARIDAD,ESTADO,NODEFACTURA,VALORFACTURA,FECHAADQUISICION,OBSERVACIONES")] INGRESOVARIOS iNGRESOVARIOS)
        {
            if (ModelState.IsValid)
            {
                db.INGRESOVARIOS.Add(iNGRESOVARIOS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SECUENCIALARTICULO = new SelectList(db.ARTICULO, "SECUENCIAL", "ARTICULO1", iNGRESOVARIOS.SECUENCIALARTICULO);
            ViewBag.SECUENCIALRESPONSABLE = new SelectList(db.PERSONA, "SECUENCIAL", "NOMBRE1", iNGRESOVARIOS.SECUENCIALRESPONSABLE);
            ViewBag.CUADADDEUBICACION = new SelectList(db.SEDE, "SECUENCIAL", "CODIGO", iNGRESOVARIOS.CUADADDEUBICACION);
            return View(iNGRESOVARIOS);
        }

        // GET: IngresoVarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            INGRESOVARIOS iNGRESOVARIOS = db.INGRESOVARIOS.Find(id);
            if (iNGRESOVARIOS == null)
            {
                return HttpNotFound();
            }
            ViewBag.SECUENCIALARTICULO = new SelectList(db.ARTICULO, "SECUENCIAL", "ARTICULO1", iNGRESOVARIOS.SECUENCIALARTICULO);
            ViewBag.SECUENCIALRESPONSABLE = new SelectList(db.PERSONA, "SECUENCIAL", "NOMBRE1", iNGRESOVARIOS.SECUENCIALRESPONSABLE);
            ViewBag.CUADADDEUBICACION = new SelectList(db.SEDE, "SECUENCIAL", "CODIGO", iNGRESOVARIOS.CUADADDEUBICACION);
            return View(iNGRESOVARIOS);
        }

        // POST: IngresoVarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SECUENCIAL,SECUENCIALRESPONSABLE,CODIGOINTERNO,CUADADDEUBICACION,SECUENCIALARTICULO,MARCA,MODELO,SERIE,PARTICULARIDAD,ESTADO,NODEFACTURA,VALORFACTURA,FECHAADQUISICION,OBSERVACIONES")] INGRESOVARIOS iNGRESOVARIOS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(iNGRESOVARIOS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SECUENCIALARTICULO = new SelectList(db.ARTICULO, "SECUENCIAL", "ARTICULO1", iNGRESOVARIOS.SECUENCIALARTICULO);
            ViewBag.SECUENCIALRESPONSABLE = new SelectList(db.PERSONA, "SECUENCIAL", "NOMBRE1", iNGRESOVARIOS.SECUENCIALRESPONSABLE);
            ViewBag.CUADADDEUBICACION = new SelectList(db.SEDE, "SECUENCIAL", "CODIGO", iNGRESOVARIOS.CUADADDEUBICACION);
            return View(iNGRESOVARIOS);
        }

        // GET: IngresoVarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            INGRESOVARIOS iNGRESOVARIOS = db.INGRESOVARIOS.Find(id);
            if (iNGRESOVARIOS == null)
            {
                return HttpNotFound();
            }
            return View(iNGRESOVARIOS);
        }

        // POST: IngresoVarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            INGRESOVARIOS iNGRESOVARIOS = db.INGRESOVARIOS.Find(id);
            db.INGRESOVARIOS.Remove(iNGRESOVARIOS);
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
