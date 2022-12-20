using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ovning12.Migrations
{
    public partial class UniqueRegistrationConstraint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ParkedVehicle_RegistrationNumber",
                table: "ParkedVehicle",
                column: "RegistrationNumber",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ParkedVehicle_RegistrationNumber",
                table: "ParkedVehicle");
        }
    }
}
