using ModuloInventario.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ModuloInventario.Controllers
{
    public class HomeController : Controller
    {
        InventarioContext db = new InventarioContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SeleccionIngreso()
        {
            return View();
        }

        public ActionResult SeleccionAsignacion()
        {
            return View();
        }
        public ActionResult Disponibilidad()
        {
            return View();
        }

        public ActionResult GetData()
        {
            int totalComputadores = db.INGRESOCOMPUTADORES.Count();
            int computadoresAsignados = db.ASIGNACIONCOMPUTADORES.Count();
            int totalVarios = db.INGRESOVARIOS.Count();
            int variosAsignados = db.ASIGNACIONVARIOS.Count();
            Grafica obj = new Grafica();
            obj.TotalComputadores = totalComputadores;
            obj.ComputadoresAsignados = computadoresAsignados;
            obj.TotalVarios = totalVarios;
            obj.VariosAsignados = variosAsignados;
            return Json(obj,JsonRequestBehavior.AllowGet);
        }

        public class Grafica
        {
            public int TotalComputadores { get; set; }
            public int ComputadoresAsignados { get; set; }
            public int TotalVarios { get; set; }
            public int VariosAsignados { get; set; }
        }
    }
}