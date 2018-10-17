namespace ModuloInventario.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class InventarioContext : DbContext
    {
        public InventarioContext()
            : base("name=InventarioContext")
        {
        }

        public virtual DbSet<ARTICULO> ARTICULO { get; set; }
        public virtual DbSet<ASIGNACIONCOMPUTADORES> ASIGNACIONCOMPUTADORES { get; set; }
        public virtual DbSet<ASIGNACIONVARIOS> ASIGNACIONVARIOS { get; set; }
        public virtual DbSet<INGRESOCOMPUTADORES> INGRESOCOMPUTADORES { get; set; }
        public virtual DbSet<INGRESOVARIOS> INGRESOVARIOS { get; set; }
        public virtual DbSet<PERSONA> PERSONA { get; set; }
        public virtual DbSet<SEDE> SEDE { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ARTICULO>()
                .Property(e => e.ARTICULO1)
                .IsUnicode(false);

            modelBuilder.Entity<ARTICULO>()
                .Property(e => e.CATEGORIAARTICULO)
                .IsUnicode(false);

            modelBuilder.Entity<ARTICULO>()
                .HasMany(e => e.INGRESOVARIOS)
                .WithRequired(e => e.ARTICULO)
                .HasForeignKey(e => e.SECUENCIALARTICULO)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ASIGNACIONCOMPUTADORES>()
                .Property(e => e.OBSERVACIONES)
                .IsUnicode(false);

            modelBuilder.Entity<ASIGNACIONVARIOS>()
                .Property(e => e.OBSERVACIONES)
                .IsUnicode(false);

            modelBuilder.Entity<INGRESOCOMPUTADORES>()
                .Property(e => e.CODIGOINTERNO)
                .IsUnicode(false);

            modelBuilder.Entity<INGRESOCOMPUTADORES>()
                .Property(e => e.ARTICULO)
                .IsUnicode(false);

            modelBuilder.Entity<INGRESOCOMPUTADORES>()
                .Property(e => e.PROCESADOR)
                .IsUnicode(false);

            modelBuilder.Entity<INGRESOCOMPUTADORES>()
                .Property(e => e.MARCA)
                .IsUnicode(false);

            modelBuilder.Entity<INGRESOCOMPUTADORES>()
                .Property(e => e.MODELO)
                .IsUnicode(false);

            modelBuilder.Entity<INGRESOCOMPUTADORES>()
                .Property(e => e.SERIE)
                .IsUnicode(false);

            modelBuilder.Entity<INGRESOCOMPUTADORES>()
                .Property(e => e.PARTICULARIDAD)
                .IsUnicode(false);

            modelBuilder.Entity<INGRESOCOMPUTADORES>()
                .Property(e => e.OBSERVACIONES)
                .IsUnicode(false);

            modelBuilder.Entity<INGRESOCOMPUTADORES>()
                .HasMany(e => e.ASIGNACIONCOMPUTADORES)
                .WithRequired(e => e.INGRESOCOMPUTADORES)
                .HasForeignKey(e => e.SECUENCIALCOMPUTADOR)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<INGRESOVARIOS>()
                .Property(e => e.CODIGOINTERNO)
                .IsUnicode(false);

            modelBuilder.Entity<INGRESOVARIOS>()
                .Property(e => e.MARCA)
                .IsUnicode(false);

            modelBuilder.Entity<INGRESOVARIOS>()
                .Property(e => e.MODELO)
                .IsUnicode(false);

            modelBuilder.Entity<INGRESOVARIOS>()
                .Property(e => e.SERIE)
                .IsUnicode(false);

            modelBuilder.Entity<INGRESOVARIOS>()
                .Property(e => e.PARTICULARIDAD)
                .IsUnicode(false);

            modelBuilder.Entity<INGRESOVARIOS>()
                .Property(e => e.OBSERVACIONES)
                .IsUnicode(false);

            modelBuilder.Entity<INGRESOVARIOS>()
                .HasMany(e => e.ASIGNACIONVARIOS)
                .WithRequired(e => e.INGRESOVARIOS)
                .HasForeignKey(e => e.SECUENCIALVARIOS)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PERSONA>()
                .Property(e => e.NOMBRE1)
                .IsUnicode(false);

            modelBuilder.Entity<PERSONA>()
                .Property(e => e.NOMBRE2)
                .IsUnicode(false);

            modelBuilder.Entity<PERSONA>()
                .Property(e => e.APELLIDO1)
                .IsUnicode(false);

            modelBuilder.Entity<PERSONA>()
                .Property(e => e.APELLIDO2)
                .IsUnicode(false);

            modelBuilder.Entity<PERSONA>()
                .Property(e => e.SEXO)
                .IsUnicode(false);

            modelBuilder.Entity<PERSONA>()
                .HasMany(e => e.ASIGNACIONCOMPUTADORES)
                .WithRequired(e => e.PERSONA)
                .HasForeignKey(e => e.SECUENCIALRESPONSABLE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PERSONA>()
                .HasMany(e => e.ASIGNACIONVARIOS)
                .WithRequired(e => e.PERSONA)
                .HasForeignKey(e => e.SECUENCIALRESPONSABLE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PERSONA>()
                .HasMany(e => e.INGRESOCOMPUTADORES)
                .WithRequired(e => e.PERSONA)
                .HasForeignKey(e => e.SECUENCIALRESPONSABLE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PERSONA>()
                .HasMany(e => e.INGRESOVARIOS)
                .WithRequired(e => e.PERSONA)
                .HasForeignKey(e => e.SECUENCIALRESPONSABLE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SEDE>()
                .Property(e => e.CODIGO)
                .IsUnicode(false);

            modelBuilder.Entity<SEDE>()
                .Property(e => e.DESCRIPCION)
                .IsUnicode(false);

            modelBuilder.Entity<SEDE>()
                .Property(e => e.ESTAACTIVO)
                .HasPrecision(1, 0);

            modelBuilder.Entity<SEDE>()
                .HasMany(e => e.ASIGNACIONCOMPUTADORES)
                .WithRequired(e => e.SEDE)
                .HasForeignKey(e => e.UBICACION)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SEDE>()
                .HasMany(e => e.ASIGNACIONVARIOS)
                .WithRequired(e => e.SEDE)
                .HasForeignKey(e => e.UBICACION)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SEDE>()
                .HasMany(e => e.INGRESOCOMPUTADORES)
                .WithRequired(e => e.SEDE)
                .HasForeignKey(e => e.UBICACION)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SEDE>()
                .HasMany(e => e.INGRESOVARIOS)
                .WithRequired(e => e.SEDE)
                .HasForeignKey(e => e.UBICACION)
                .WillCascadeOnDelete(false);
        }
    }
}
