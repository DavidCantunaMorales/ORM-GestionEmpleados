using Microsoft.EntityFrameworkCore;

namespace BDOO
{
    public class BDContext : DbContext
    {
        public BDContext(DbContextOptions<BDContext> options) : base(options) { }

        public DbSet<Supervisor> Supervisores { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Horario> Horarios { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Proyecto> Proyectos { get; set; }
        public DbSet<ProyectoEmpleado> ProyectosEmpleados { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Supervisor>().ToTable("Supervisor");
            modelBuilder.Entity<Departamento>().ToTable("Departamento");
            modelBuilder.Entity<Horario>().ToTable("Horario");
            modelBuilder.Entity<Empleado>().ToTable("Empleado");
            modelBuilder.Entity<Proyecto>().ToTable("Proyecto");
            modelBuilder.Entity<ProyectoEmpleado>().ToTable("ProyectoEmpleado");

            // RELACION DE MUCHOS A MUCHOS DE EMPLEADO Y PROYECTOS
            modelBuilder.Entity<ProyectoEmpleado>()
            .HasKey(ec => new { ec.IdProyectoEmp });

            modelBuilder.Entity<ProyectoEmpleado>()
                .HasOne(ec => ec.Empleado)
                .WithMany(e => e.ProyectoEmpleados)
                .HasForeignKey(ec => ec.IdEmpleado);

            modelBuilder.Entity<ProyectoEmpleado>()
                .HasOne(ec => ec.Proyecto)
                .WithMany(c => c.ProyectoEmpleados)
                .HasForeignKey(ec => ec.IdProyecto);

            // VALIDACION DEPARTAMENTO
            modelBuilder.Entity<Departamento>()
                .HasIndex(d => d.NombreDep)
                .IsUnique();

            // VALIDACION DEL EMPLEADO
            modelBuilder.Entity<Empleado>()
                .HasIndex(d => d.Telefono)
                .IsUnique();
            modelBuilder.Entity<Empleado>()
                .HasIndex(d => d.Correo)
                .IsUnique();

            // VALIDACION DEL SUPERVISOR
            modelBuilder.Entity<Supervisor>()
                .HasIndex(d => d.IdProyecto)
                .IsUnique();
            modelBuilder.Entity<Supervisor>()
                .HasIndex(d => d.Telefono)
                .IsUnique();
            modelBuilder.Entity<Supervisor>()
                .HasIndex(d => d.Correo)
                .IsUnique();

            // VALIDACIONES DEL PROYECTO
            modelBuilder.Entity<Proyecto>()
                .HasIndex(d => d.NombreProyecto)
                .IsUnique();

            // VALIDACION DEL PROYECTO EMPLEADO
            modelBuilder.Entity<ProyectoEmpleado>()
                .HasIndex(pe => new { pe.IdEmpleado, pe.IdProyecto })
                .IsUnique();

            // ELIMINACION EN CASCADA DEPARTAMENTO
            modelBuilder.Entity<Departamento>()
                .HasMany(d => d.Empleados)
                .WithOne(e => e.Departamento)
                .HasForeignKey(e => e.IdDep)
                .OnDelete(DeleteBehavior.Restrict); // Restringe la eliminación en cascada

            modelBuilder.Entity<Departamento>()
                .HasMany(d => d.Supervisores)
                .WithOne(e => e.Departamento)
                .HasForeignKey(e => e.IdDep)
                .OnDelete(DeleteBehavior.Restrict); // Restringe la eliminación en cascada

            // ELIMINACION EN CASCADA HORARIO
            modelBuilder.Entity<Horario>()
                .HasMany(d => d.Empleados)
                .WithOne(e => e.Horario)
                .HasForeignKey(e => e.IdHorario)
                .OnDelete(DeleteBehavior.Restrict); // Restringe la eliminación en cascada

            modelBuilder.Entity<Horario>()
                .HasMany(d => d.Supervisores)
                .WithOne(e => e.Horario)
                .HasForeignKey(e => e.IdHorario)
                .OnDelete(DeleteBehavior.Restrict); // Restringe la eliminación en cascada

            // ELIMINACION EN CASCADA PROYECTO
            modelBuilder.Entity<Proyecto>()
                .HasMany(d => d.Supervisores)
                .WithOne(e => e.Proyecto)
                .HasForeignKey(e => e.IdProyecto)
                .OnDelete(DeleteBehavior.Restrict); // Restringe la eliminación en cascada
        }
    }
}
