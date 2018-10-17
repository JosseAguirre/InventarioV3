namespace ModuloInventario.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("INVENTARIO.INGRESOCOMPUTADORES")]
    public partial class INGRESOCOMPUTADORES
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public INGRESOCOMPUTADORES()
        {
            ASIGNACIONCOMPUTADORES = new HashSet<ASIGNACIONCOMPUTADORES>();
        }

        [Key]
        public int SECUENCIAL { get; set; }

        public int SECUENCIALRESPONSABLE { get; set; }

        [Required]
        [StringLength(25)]
        public string CODIGOINTERNO { get; set; }

        public int UBICACION { get; set; }

        [Required]
        [StringLength(25)]
        public string ARTICULO { get; set; }

        public int MEMORIARAM { get; set; }

        [Required]
        [StringLength(50)]
        public string PROCESADOR { get; set; }

        public int DISCODURO { get; set; }

        public bool LICENCIADO { get; set; }

        public bool OFFICE { get; set; }

        [Required]
        [StringLength(50)]
        public string MARCA { get; set; }

        [Required]
        [StringLength(50)]
        public string MODELO { get; set; }

        [Required]
        [StringLength(50)]
        public string SERIE { get; set; }

        [Required]
        [StringLength(70)]
        public string PARTICULARIDAD { get; set; }

        public bool ESTADO { get; set; }

        public long? NODEFACTURA { get; set; }

        public int? VALORFACTURA { get; set; }

        [Column(TypeName = "date")]
        public DateTime FECHAADQUISICION { get; set; }

        [Column(TypeName = "text")]
        public string OBSERVACIONES { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ASIGNACIONCOMPUTADORES> ASIGNACIONCOMPUTADORES { get; set; }

        public virtual PERSONA PERSONA { get; set; }

        public virtual SEDE SEDE { get; set; }
    }
}
