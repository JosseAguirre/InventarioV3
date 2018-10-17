namespace ModuloInventario.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TAREAS.SEDE")]
    public partial class SEDE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SEDE()
        {
            ASIGNACIONCOMPUTADORES = new HashSet<ASIGNACIONCOMPUTADORES>();
            ASIGNACIONVARIOS = new HashSet<ASIGNACIONVARIOS>();
            INGRESOCOMPUTADORES = new HashSet<INGRESOCOMPUTADORES>();
            INGRESOVARIOS = new HashSet<INGRESOVARIOS>();
        }

        [Key]
        public int SECUENCIAL { get; set; }

        [Required]
        [StringLength(30)]
        public string CODIGO { get; set; }

        [Required]
        [StringLength(250)]
        public string DESCRIPCION { get; set; }

        [Column(TypeName = "numeric")]
        public decimal ESTAACTIVO { get; set; }

        public int NUMEROVERIFICADOR { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ASIGNACIONCOMPUTADORES> ASIGNACIONCOMPUTADORES { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ASIGNACIONVARIOS> ASIGNACIONVARIOS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INGRESOCOMPUTADORES> INGRESOCOMPUTADORES { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INGRESOVARIOS> INGRESOVARIOS { get; set; }
    }
}
