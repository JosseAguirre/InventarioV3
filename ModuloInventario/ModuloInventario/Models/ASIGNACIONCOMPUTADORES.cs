namespace ModuloInventario.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("INVENTARIO.ASIGNACIONCOMPUTADORES")]
    public partial class ASIGNACIONCOMPUTADORES
    {
        [Key]
        public int SECUENCIAL { get; set; }

        public int SECUENCIALRESPONSABLE { get; set; }

        public int SECUENCIALCOMPUTADOR { get; set; }

        public int UBICACION { get; set; }

        [Column(TypeName = "date")]
        public DateTime FECHAASIGNACION { get; set; }

        [Column(TypeName = "date")]
        public DateTime FECHAENTREGA { get; set; }

        public bool ESTADOENTREGA { get; set; }

        [Column(TypeName = "text")]
        public string OBSERVACIONES { get; set; }

        public virtual PERSONA PERSONA { get; set; }

        public virtual INGRESOCOMPUTADORES INGRESOCOMPUTADORES { get; set; }

        public virtual SEDE SEDE { get; set; }
    }
}
