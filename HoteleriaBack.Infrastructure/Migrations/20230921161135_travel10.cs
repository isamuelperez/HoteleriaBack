using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HoteleriaBack.Infrastructure.Migrations
{
    public partial class travel10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "EmergencyContactId",
                table: "Reservations",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_EmergencyContactId",
                table: "Reservations",
                column: "EmergencyContactId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_EmergencyContacts_EmergencyContactId",
                table: "Reservations",
                column: "EmergencyContactId",
                principalTable: "EmergencyContacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_EmergencyContacts_EmergencyContactId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_EmergencyContactId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "EmergencyContactId",
                table: "Reservations");
        }
    }
}
