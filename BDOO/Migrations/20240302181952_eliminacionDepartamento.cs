using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BDOO.Migrations
{
    /// <inheritdoc />
    public partial class eliminacionDepartamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empleado_Departamento_IdDep",
                table: "Empleado");

            migrationBuilder.AddForeignKey(
                name: "FK_Empleado_Departamento_IdDep",
                table: "Empleado",
                column: "IdDep",
                principalTable: "Departamento",
                principalColumn: "IdDep",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empleado_Departamento_IdDep",
                table: "Empleado");

            migrationBuilder.AddForeignKey(
                name: "FK_Empleado_Departamento_IdDep",
                table: "Empleado",
                column: "IdDep",
                principalTable: "Departamento",
                principalColumn: "IdDep",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
