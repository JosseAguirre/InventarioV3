namespace ModuloInventario.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TAREAS.PERSONA")]
    public partial class PERSONA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PERSONA()
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
        public string NOMBRE1 { get; set; }

        [Required]
        [StringLength(30)]
        public string NOMBRE2 { get; set; }

        [Required]
        [StringLength(30)]
        public string APELLIDO1 { get; set; }

        [Required]
        [StringLength(30)]
        public string APELLIDO2 { get; set; }

        [Required]
        [StringLength(1)]
        public string SEXO { get; set; }

        [Column(TypeName = "date")]
        public DateTime FECHANAC { get; set; }

        public int SECUENCIALPAIS { get; set; }

        public int NUMEROVERIFICADOR { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ASIGNACIONCOMPUTADORES> ASIGNACIONCOMPUTADORES { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ASIGNACIONVARIOS> ASIGNACIONVARIOS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INGRESOCOMPUTADORES> INGRESOCOMPUTADORES { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INGRESOVARIOS> INGRESOVARIOS { get; set; }
        public string NOMBREUNIDO { get { return NOMBRE1 + " " + APELLIDO1; } }
    }
}
