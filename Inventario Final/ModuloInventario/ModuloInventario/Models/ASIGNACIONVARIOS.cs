namespace ModuloInventario.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("INVENTARIO.ASIGNACIONVARIOS")]
    public partial class ASIGNACIONVARIOS
    {
        [Key]
        public int SECUENCIAL { get; set; }

        public int SECUENCIALRESPONSABLE { get; set; }

        public int SECUENCIALVARIOS { get; set; }

        public int UBICACION { get; set; }

        [Column(TypeName = "date")]
        public DateTime TIEMPOINICIO { get; set; }

        [Column(TypeName = "date")]
        public DateTime TIEMPOFIN { get; set; }

        public bool ESTADOENTREGA { get; set; }

        public virtual PERSONA PERSONA { get; set; }

        public virtual INGRESOVARIOS INGRESOVARIOS { get; set; }

        public virtual SEDE SEDE { get; set; }
    }
}
