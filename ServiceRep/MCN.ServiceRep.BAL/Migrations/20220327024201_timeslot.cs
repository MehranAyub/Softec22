using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MCN.ServiceRep.BAL.Migrations
{
    public partial class timeslot : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Appointment",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorId = table.Column<int>(nullable: true),
                    PatientId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointment", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TimeSlot",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorId = table.Column<int>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Slot1 = table.Column<bool>(nullable: true),
                    Slot2 = table.Column<bool>(nullable: true),
                    Slot3 = table.Column<bool>(nullable: true),
                    Slot4 = table.Column<bool>(nullable: true),
                    Slot5 = table.Column<bool>(nullable: true),
                    Slot6 = table.Column<bool>(nullable: true),
                    Slot7 = table.Column<bool>(nullable: true),
                    Slot8 = table.Column<bool>(nullable: true),
                    Slot9 = table.Column<bool>(nullable: true),
                    Slot10 = table.Column<bool>(nullable: true),
                    Slot11 = table.Column<bool>(nullable: true),
                    Slot12 = table.Column<bool>(nullable: true),
                    AppointmentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeSlot", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointment");

            migrationBuilder.DropTable(
                name: "TimeSlot");
        }
    }
}
