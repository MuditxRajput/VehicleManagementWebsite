using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace vechicalManagement.Migrations
{
    /// <inheritdoc />
    public partial class updateVehicle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "workerId",
                table: "Vehicles",
                newName: "WorkerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "WorkerId",
                table: "Vehicles",
                newName: "workerId");
        }
    }
}
