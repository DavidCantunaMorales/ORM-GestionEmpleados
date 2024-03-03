using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BDOO.Migrations
{
    /// <inheritdoc />
    public partial class eliminacionProyecto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Supervisor_Proyecto_IdProyecto",
                table: "Supervisor");

            migrationBuilder.AddForeignKey(
                name: "FK_Supervisor_Proyecto_IdProyecto",
                table: "Supervisor",
                column: "IdProyecto",
                principalTable: "Proyecto",
                principalColumn: "IdProyecto",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Supervisor_Proyecto_IdProyecto",
                table: "Supervisor");

            migrationBuilder.AddForeignKey(
                name: "FK_Supervisor_Proyecto_IdProyecto",
                table: "Supervisor",
                column: "IdProyecto",
                principalTable: "Proyecto",
                principalColumn: "IdProyecto",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
