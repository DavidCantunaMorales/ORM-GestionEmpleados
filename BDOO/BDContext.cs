using Microsoft.EntityFrameworkCore;

namespace BDOO
{
    public class BDContext : DbContext
    {
        public BDContext(DbContextOptions<BDContext> options) : base(options) { }

        public DbSet<Cargo> Cargos { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Horario> Horarios { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Proyecto> Proyectos { get; set; }
        public DbSet<ProyectoEmpleado> ProyectosEmpleados { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cargo>().ToTable("Cargo");
            modelBuilder.Entity<Departamento>().ToTable("Departamento");
            modelBuilder.Entity<Horario>().ToTable("Horario");
            modelBuilder.Entity<Empleado>().ToTable("Empleado");
            modelBuilder.Entity<Proyecto>().ToTable("Proyecto");
            modelBuilder.Entity<ProyectoEmpleado>().ToTable("ProyectoEmpleado");

            // RELACION DE MUCHOS A MUCHOS DE EMPLEADO Y PROYECTOS
            modelBuilder.Entity<ProyectoEmpleado>()
            .HasKey(ec => new { ec.IdEmpleado, ec.IdProyecto });

            modelBuilder.Entity<ProyectoEmpleado>()
                .HasOne(ec => ec.Empleado)
                .WithMany(e => e.ProyectoEmpleados)
                .HasForeignKey(ec => ec.IdEmpleado);

            modelBuilder.Entity<ProyectoEmpleado>()
                .HasOne(ec => ec.Proyecto)
                .WithMany(c => c.ProyectoEmpleados)
                .HasForeignKey(ec => ec.IdProyecto);
        }
    }
}
