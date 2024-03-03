using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BDOO.Migrations
{
    /// <inheritdoc />
    public partial class eliminacionHorario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empleado_Horario_IdHorario",
                table: "Empleado");

            migrationBuilder.DropForeignKey(
                name: "FK_Supervisor_Departamento_IdDep",
                table: "Supervisor");

            migrationBuilder.DropForeignKey(
                name: "FK_Supervisor_Horario_IdHorario",
                table: "Supervisor");

            migrationBuilder.AddForeignKey(
                name: "FK_Empleado_Horario_IdHorario",
                table: "Empleado",
                column: "IdHorario",
                principalTable: "Horario",
                principalColumn: "IdHorario",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Supervisor_Departamento_IdDep",
                table: "Supervisor",
                column: "IdDep",
                principalTable: "Departamento",
                principalColumn: "IdDep",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Supervisor_Horario_IdHorario",
                table: "Supervisor",
                column: "IdHorario",
                principalTable: "Horario",
                principalColumn: "IdHorario",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empleado_Horario_IdHorario",
                table: "Empleado");

            migrationBuilder.DropForeignKey(
                name: "FK_Supervisor_Departamento_IdDep",
                table: "Supervisor");

            migrationBuilder.DropForeignKey(
                name: "FK_Supervisor_Horario_IdHorario",
                table: "Supervisor");

            migrationBuilder.AddForeignKey(
                name: "FK_Empleado_Horario_IdHorario",
                table: "Empleado",
                column: "IdHorario",
                principalTable: "Horario",
                principalColumn: "IdHorario",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Supervisor_Departamento_IdDep",
                table: "Supervisor",
                column: "IdDep",
                principalTable: "Departamento",
                principalColumn: "IdDep",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Supervisor_Horario_IdHorario",
                table: "Supervisor",
                column: "IdHorario",
                principalTable: "Horario",
                principalColumn: "IdHorario",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
