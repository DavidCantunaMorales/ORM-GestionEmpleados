using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BDOO.Migrations
{
    /// <inheritdoc />
    public partial class validacionProyecto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "NombreProyecto",
                table: "Proyecto",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Proyecto_NombreProyecto",
                table: "Proyecto",
                column: "NombreProyecto",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Proyecto_NombreProyecto",
                table: "Proyecto");

            migrationBuilder.AlterColumn<string>(
                name: "NombreProyecto",
                table: "Proyecto",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
