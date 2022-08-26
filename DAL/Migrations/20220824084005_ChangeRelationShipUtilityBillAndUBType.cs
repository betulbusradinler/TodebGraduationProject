using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class ChangeRelationShipUtilityBillAndUBType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UtilityBillTypes_UtilityBills_UtilityBillId",
                table: "UtilityBillTypes");

            migrationBuilder.DropIndex(
                name: "IX_UtilityBillTypes_UtilityBillId",
                table: "UtilityBillTypes");

            migrationBuilder.DropColumn(
                name: "UtilityBillId",
                table: "UtilityBillTypes");

            migrationBuilder.AddColumn<int>(
                name: "BillNameId",
                table: "UtilityBills",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UtilityBills_BillNameId",
                table: "UtilityBills",
                column: "BillNameId");

            migrationBuilder.AddForeignKey(
                name: "FK_UtilityBills_UtilityBillTypes_BillNameId",
                table: "UtilityBills",
                column: "BillNameId",
                principalTable: "UtilityBillTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UtilityBills_UtilityBillTypes_BillNameId",
                table: "UtilityBills");

            migrationBuilder.DropIndex(
                name: "IX_UtilityBills_BillNameId",
                table: "UtilityBills");

            migrationBuilder.DropColumn(
                name: "BillNameId",
                table: "UtilityBills");

            migrationBuilder.AddColumn<int>(
                name: "UtilityBillId",
                table: "UtilityBillTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UtilityBillTypes_UtilityBillId",
                table: "UtilityBillTypes",
                column: "UtilityBillId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UtilityBillTypes_UtilityBills_UtilityBillId",
                table: "UtilityBillTypes",
                column: "UtilityBillId",
                principalTable: "UtilityBills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
