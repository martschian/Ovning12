using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ovning12.Migrations
{
    public partial class AdditionalVehicleProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "ParkedVehicle",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "NumberOfWheels",
                table: "ParkedVehicle",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Color",
                table: "ParkedVehicle");

            migrationBuilder.DropColumn(
                name: "NumberOfWheels",
                table: "ParkedVehicle");
        }
    }
}
