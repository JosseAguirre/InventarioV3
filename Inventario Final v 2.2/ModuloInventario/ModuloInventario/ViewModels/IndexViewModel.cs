using ModuloInventario.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ModuloInventario.ViewModels
{
    public class IndexViewModel : BaseModelo
    {
        public List<ASIGNACIONCOMPUTADORES> asignacionComputador { get; set; }
        public List<ASIGNACIONVARIOS> asignacionVarios { get; set; }
        public List<INGRESOCOMPUTADORES> ingresoComputador { get; set; }
        public List<INGRESOVARIOS> ingresoVarios { get; set; }
    }
}