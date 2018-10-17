namespace ModuloInventario.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("INVENTARIO.ARTICULO")]
    public partial class ARTICULO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ARTICULO()
        {
            INGRESOVARIOS = new HashSet<INGRESOVARIOS>();
        }

        [Key]
        public int SECUENCIAL { get; set; }

        [Column("ARTICULO")]
        [Required]
        [StringLength(50)]
        public string ARTICULO1 { get; set; }

        [Required]
        [StringLength(50)]
        public string CATEGORIAARTICULO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INGRESOVARIOS> INGRESOVARIOS { get; set; }
    }
}
