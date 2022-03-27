using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MCN.ServiceRep.BAL.Migrations
{
    public partial class timesloth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Slot1",
                table: "TimeSlot");

            migrationBuilder.DropColumn(
                name: "Slot10",
                table: "TimeSlot");

            migrationBuilder.DropColumn(
                name: "Slot11",
                table: "TimeSlot");

            migrationBuilder.DropColumn(
                name: "Slot12",
                table: "TimeSlot");

            migrationBuilder.DropColumn(
                name: "Slot2",
                table: "TimeSlot");

            migrationBuilder.DropColumn(
                name: "Slot3",
                table: "TimeSlot");

            migrationBuilder.DropColumn(
                name: "Slot4",
                table: "TimeSlot");

            migrationBuilder.DropColumn(
                name: "Slot5",
                table: "TimeSlot");

            migrationBuilder.DropColumn(
                name: "Slot6",
                table: "TimeSlot");

            migrationBuilder.DropColumn(
                name: "Slot7",
                table: "TimeSlot");

            migrationBuilder.DropColumn(
                name: "Slot8",
                table: "TimeSlot");

            migrationBuilder.DropColumn(
                name: "Slot9",
                table: "TimeSlot");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "TimeSlot",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<int>(
                name: "TimeSlots",
                table: "TimeSlot",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TimeSlot_AppointmentId",
                table: "TimeSlot",
                column: "AppointmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_TimeSlot_Appointment_AppointmentId",
                table: "TimeSlot",
                column: "AppointmentId",
                principalTable: "Appointment",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TimeSlot_Appointment_AppointmentId",
                table: "TimeSlot");

            migrationBuilder.DropIndex(
                name: "IX_TimeSlot_AppointmentId",
                table: "TimeSlot");

            migrationBuilder.DropColumn(
                name: "TimeSlots",
                table: "TimeSlot");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "TimeSlot",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Slot1",
                table: "TimeSlot",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Slot10",
                table: "TimeSlot",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Slot11",
                table: "TimeSlot",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Slot12",
                table: "TimeSlot",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Slot2",
                table: "TimeSlot",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Slot3",
                table: "TimeSlot",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Slot4",
                table: "TimeSlot",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Slot5",
                table: "TimeSlot",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Slot6",
                table: "TimeSlot",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Slot7",
                table: "TimeSlot",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Slot8",
                table: "TimeSlot",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Slot9",
                table: "TimeSlot",
                type: "bit",
                nullable: true);
        }
    }
}
