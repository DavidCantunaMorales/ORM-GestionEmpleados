﻿// <auto-generated />
using BDOO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BDOO.Migrations
{
    [DbContext(typeof(BDContext))]
    [Migration("20240302180627_validacionPE")]
    partial class validacionPE
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BDOO.Departamento", b =>
                {
                    b.Property<int>("IdDep")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdDep"));

                    b.Property<string>("DescripcionDep")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreDep")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("IdDep");

                    b.HasIndex("NombreDep")
                        .IsUnique();

                    b.ToTable("Departamento", (string)null);
                });

            modelBuilder.Entity("BDOO.Empleado", b =>
                {
                    b.Property<int>("IdEmp")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdEmp"));

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdDep")
                        .HasColumnType("int");

                    b.Property<int>("IdHorario")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("IdEmp");

                    b.HasIndex("Correo")
                        .IsUnique();

                    b.HasIndex("IdDep");

                    b.HasIndex("IdHorario");

                    b.HasIndex("Telefono")
                        .IsUnique();

                    b.ToTable("Empleado", (string)null);
                });

            modelBuilder.Entity("BDOO.Horario", b =>
                {
                    b.Property<int>("IdHorario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdHorario"));

                    b.Property<string>("HoraEntrada")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HoraSalida")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdHorario");

                    b.ToTable("Horario", (string)null);
                });

            modelBuilder.Entity("BDOO.Proyecto", b =>
                {
                    b.Property<int>("IdProyecto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdProyecto"));

                    b.Property<string>("DescripcionProyecto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FechaFin")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FechaInicio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreProyecto")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("IdProyecto");

                    b.HasIndex("NombreProyecto")
                        .IsUnique();

                    b.ToTable("Proyecto", (string)null);
                });

            modelBuilder.Entity("BDOO.ProyectoEmpleado", b =>
                {
                    b.Property<int>("IdProyectoEmp")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdProyectoEmp"));

                    b.Property<int>("IdEmpleado")
                        .HasColumnType("int");

                    b.Property<int>("IdProyecto")
                        .HasColumnType("int");

                    b.HasKey("IdProyectoEmp");

                    b.HasIndex("IdProyecto");

                    b.HasIndex("IdEmpleado", "IdProyecto")
                        .IsUnique();

                    b.ToTable("ProyectoEmpleado", (string)null);
                });

            modelBuilder.Entity("BDOO.Supervisor", b =>
                {
                    b.Property<int>("IdSup")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdSup"));

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdDep")
                        .HasColumnType("int");

                    b.Property<int>("IdHorario")
                        .HasColumnType("int");

                    b.Property<int>("IdProyecto")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("IdSup");

                    b.HasIndex("Correo")
                        .IsUnique();

                    b.HasIndex("IdDep");

                    b.HasIndex("IdHorario");

                    b.HasIndex("IdProyecto")
                        .IsUnique();

                    b.HasIndex("Telefono")
                        .IsUnique();

                    b.ToTable("Supervisor", (string)null);
                });

            modelBuilder.Entity("BDOO.Empleado", b =>
                {
                    b.HasOne("BDOO.Departamento", "Departamento")
                        .WithMany()
                        .HasForeignKey("IdDep")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BDOO.Horario", "Horario")
                        .WithMany()
                        .HasForeignKey("IdHorario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Departamento");

                    b.Navigation("Horario");
                });

            modelBuilder.Entity("BDOO.ProyectoEmpleado", b =>
                {
                    b.HasOne("BDOO.Empleado", "Empleado")
                        .WithMany("ProyectoEmpleados")
                        .HasForeignKey("IdEmpleado")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BDOO.Proyecto", "Proyecto")
                        .WithMany("ProyectoEmpleados")
                        .HasForeignKey("IdProyecto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Empleado");

                    b.Navigation("Proyecto");
                });

            modelBuilder.Entity("BDOO.Supervisor", b =>
                {
                    b.HasOne("BDOO.Departamento", "Departamento")
                        .WithMany()
                        .HasForeignKey("IdDep")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BDOO.Horario", "Horario")
                        .WithMany()
                        .HasForeignKey("IdHorario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BDOO.Proyecto", "Proyecto")
                        .WithMany()
                        .HasForeignKey("IdProyecto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Departamento");

                    b.Navigation("Horario");

                    b.Navigation("Proyecto");
                });

            modelBuilder.Entity("BDOO.Empleado", b =>
                {
                    b.Navigation("ProyectoEmpleados");
                });

            modelBuilder.Entity("BDOO.Proyecto", b =>
                {
                    b.Navigation("ProyectoEmpleados");
                });
#pragma warning restore 612, 618
        }
    }
}
