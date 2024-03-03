using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BDOO.Migrations
{
    /// <inheritdoc />
    public partial class validacionSupervisor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Supervisor_IdProyecto",
                table: "Supervisor");

            migrationBuilder.AlterColumn<string>(
                name: "Telefono",
                table: "Supervisor",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Correo",
                table: "Supervisor",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Supervisor_Correo",
                table: "Supervisor",
                column: "Correo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Supervisor_IdProyecto",
                table: "Supervisor",
                column: "IdProyecto",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Supervisor_Telefono",
                table: "Supervisor",
                column: "Telefono",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Supervisor_Correo",
                table: "Supervisor");

            migrationBuilder.DropIndex(
                name: "IX_Supervisor_IdProyecto",
                table: "Supervisor");

            migrationBuilder.DropIndex(
                name: "IX_Supervisor_Telefono",
                table: "Supervisor");

            migrationBuilder.AlterColumn<string>(
                name: "Telefono",
                table: "Supervisor",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Correo",
                table: "Supervisor",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateIndex(
                name: "IX_Supervisor_IdProyecto",
                table: "Supervisor",
                column: "IdProyecto");
        }
    }
}
