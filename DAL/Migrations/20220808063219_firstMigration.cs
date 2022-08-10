using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class firstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UtilityBillTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UtilityBillTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FlatId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    No = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VehicleNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Flats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    No = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HirerOrHostId = table.Column<int>(type: "int", nullable: false),
                    FloorNo = table.Column<byte>(type: "tinyint", nullable: false),
                    Block = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Flats_Users_HirerOrHostId",
                        column: x => x.HirerOrHostId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsersPassswords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersPassswords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsersPassswords_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UtilityBills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BillNameId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FlatId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UtilityBills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UtilityBills_Flats_FlatId",
                        column: x => x.FlatId,
                        principalTable: "Flats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UtilityBills_UtilityBillTypes_BillNameId",
                        column: x => x.BillNameId,
                        principalTable: "UtilityBillTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Flats_HirerOrHostId",
                table: "Flats",
                column: "HirerOrHostId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_FlatId",
                table: "Users",
                column: "FlatId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersPassswords_UserId",
                table: "UsersPassswords",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UtilityBills_BillNameId",
                table: "UtilityBills",
                column: "BillNameId");

            migrationBuilder.CreateIndex(
                name: "IX_UtilityBills_FlatId",
                table: "UtilityBills",
                column: "FlatId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Flats_FlatId",
                table: "Users",
                column: "FlatId",
                principalTable: "Flats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flats_Users_HirerOrHostId",
                table: "Flats");

            migrationBuilder.DropTable(
                name: "UsersPassswords");

            migrationBuilder.DropTable(
                name: "UtilityBills");

            migrationBuilder.DropTable(
                name: "UtilityBillTypes");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Flats");
        }
    }
}
