using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BDOO.Migrations
{
    /// <inheritdoc />
    public partial class validacionPE : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ProyectoEmpleado_IdEmpleado",
                table: "ProyectoEmpleado");

            migrationBuilder.CreateIndex(
                name: "IX_ProyectoEmpleado_IdEmpleado_IdProyecto",
                table: "ProyectoEmpleado",
                columns: new[] { "IdEmpleado", "IdProyecto" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ProyectoEmpleado_IdEmpleado_IdProyecto",
                table: "ProyectoEmpleado");

            migrationBuilder.CreateIndex(
                name: "IX_ProyectoEmpleado_IdEmpleado",
                table: "ProyectoEmpleado",
                column: "IdEmpleado");
        }
    }
}
