using Microsoft.EntityFrameworkCore.Migrations;

namespace MCN.ServiceRep.BAL.Migrations
{
    public partial class appintmentsyste : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Latitude",
                table: "Users",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Longitude",
                table: "Users",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Users");
        }
    }
}
