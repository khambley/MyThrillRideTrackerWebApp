using Microsoft.EntityFrameworkCore.Migrations;

namespace MyThrillRideTrackerWebApp.Migrations
{
    public partial class AddedWebsiteLinkToModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImageFileNames_Parks_ParkId",
                table: "ImageFileNames");

            migrationBuilder.AlterColumn<decimal>(
                name: "Stars",
                table: "Ratings",
                type: "decimal(8, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(8,2)");

            migrationBuilder.AddColumn<string>(
                name: "ParkMapLink",
                table: "Parks",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WebsiteLink",
                table: "Parks",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ParkId",
                table: "ImageFileNames",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ImageFileNames_Parks_ParkId",
                table: "ImageFileNames",
                column: "ParkId",
                principalTable: "Parks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImageFileNames_Parks_ParkId",
                table: "ImageFileNames");

            migrationBuilder.DropColumn(
                name: "ParkMapLink",
                table: "Parks");

            migrationBuilder.DropColumn(
                name: "WebsiteLink",
                table: "Parks");

            migrationBuilder.AlterColumn<decimal>(
                name: "Stars",
                table: "Ratings",
                type: "decimal(8,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(8, 2)");

            migrationBuilder.AlterColumn<int>(
                name: "ParkId",
                table: "ImageFileNames",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_ImageFileNames_Parks_ParkId",
                table: "ImageFileNames",
                column: "ParkId",
                principalTable: "Parks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
