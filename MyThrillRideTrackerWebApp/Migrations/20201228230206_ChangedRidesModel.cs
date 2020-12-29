using Microsoft.EntityFrameworkCore.Migrations;

namespace MyThrillRideTrackerWebApp.Migrations
{
    public partial class ChangedRidesModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rides_Parks_ParkId",
                table: "Rides");

            migrationBuilder.DropForeignKey(
                name: "FK_Rides_Visits_VisitId",
                table: "Rides");

            migrationBuilder.DropForeignKey(
                name: "FK_Visits_Parks_ParkId",
                table: "Visits");

            migrationBuilder.DropIndex(
                name: "IX_Rides_VisitId",
                table: "Rides");

            migrationBuilder.DropColumn(
                name: "VisitId",
                table: "Rides");

            migrationBuilder.AlterColumn<int>(
                name: "ParkId",
                table: "Visits",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ParkId",
                table: "Rides",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Rides_Parks_ParkId",
                table: "Rides",
                column: "ParkId",
                principalTable: "Parks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Visits_Parks_ParkId",
                table: "Visits",
                column: "ParkId",
                principalTable: "Parks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rides_Parks_ParkId",
                table: "Rides");

            migrationBuilder.DropForeignKey(
                name: "FK_Visits_Parks_ParkId",
                table: "Visits");

            migrationBuilder.AlterColumn<int>(
                name: "ParkId",
                table: "Visits",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "ParkId",
                table: "Rides",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "VisitId",
                table: "Rides",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rides_VisitId",
                table: "Rides",
                column: "VisitId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rides_Parks_ParkId",
                table: "Rides",
                column: "ParkId",
                principalTable: "Parks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Rides_Visits_VisitId",
                table: "Rides",
                column: "VisitId",
                principalTable: "Visits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Visits_Parks_ParkId",
                table: "Visits",
                column: "ParkId",
                principalTable: "Parks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
