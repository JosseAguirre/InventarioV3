namespace ModuloInventario.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("INVENTARIO.INGRESOVARIOS")]
    public partial class INGRESOVARIOS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public INGRESOVARIOS()
        {
            ASIGNACIONVARIOS = new HashSet<ASIGNACIONVARIOS>();
        }

        [Key]
        public int SECUENCIAL { get; set; }

        public int SECUENCIALRESPONSABLE { get; set; }

        [Required]
        [StringLength(25)]
        public string CODIGOINTERNO { get; set; }

        public int UBICACION { get; set; }

        public int SECUENCIALARTICULO { get; set; }

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
        [StringLength(50)]
        public string PARTICULARIDAD { get; set; }

        public bool ESTADO { get; set; }

        public long? NODEFACTURA { get; set; }

        public int? VALORFACTURA { get; set; }

        [Column(TypeName = "date")]
        public DateTime FECHAADQUISICION { get; set; }

        [Column(TypeName = "text")]
        public string OBSERVACIONES { get; set; }

        public virtual ARTICULO ARTICULO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ASIGNACIONVARIOS> ASIGNACIONVARIOS { get; set; }

        public virtual PERSONA PERSONA { get; set; }

        public virtual SEDE SEDE { get; set; }
    }
}
