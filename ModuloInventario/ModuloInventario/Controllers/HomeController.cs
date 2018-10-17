using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ModuloInventario.Controllers
{
    public class HomeController : Controller
    {
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
    }
}