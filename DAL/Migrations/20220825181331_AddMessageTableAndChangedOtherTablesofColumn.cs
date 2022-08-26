using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class AddMessageTableAndChangedOtherTablesofColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VehicleNo",
                table: "Users");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "UtilityBillTypes",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UtilityBillNo",
                table: "UtilityBills",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LicensePlate",
                table: "Users",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UtilityBillTypes_Name",
                table: "UtilityBillTypes",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UtilityBills_UtilityBillNo",
                table: "UtilityBills",
                column: "UtilityBillNo",
                unique: true,
                filter: "[UtilityBillNo] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Users_LicensePlate",
                table: "Users",
                column: "LicensePlate",
                unique: true,
                filter: "[LicensePlate] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Flats_No",
                table: "Flats",
                column: "No",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UtilityBillTypes_Name",
                table: "UtilityBillTypes");

            migrationBuilder.DropIndex(
                name: "IX_UtilityBills_UtilityBillNo",
                table: "UtilityBills");

            migrationBuilder.DropIndex(
                name: "IX_Users_Email",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_LicensePlate",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Flats_No",
                table: "Flats");

            migrationBuilder.DropColumn(
                name: "UtilityBillNo",
                table: "UtilityBills");

            migrationBuilder.DropColumn(
                name: "LicensePlate",
                table: "Users");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "UtilityBillTypes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VehicleNo",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
