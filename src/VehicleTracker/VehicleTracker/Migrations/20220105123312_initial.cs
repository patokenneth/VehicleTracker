using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VehicleTracker.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Passwordsalt = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    password = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleID = table.Column<int>(type: "int", nullable: false),
                    Latitude = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Longitude = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Location_Vehicles_VehicleID",
                        column: x => x.VehicleID,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "IsAdmin", "Passwordsalt", "Username", "password" },
                values: new object[] { 1, true, new byte[] { 181, 212, 27, 206, 250, 53, 225, 154, 22, 75, 225, 136, 179, 148, 244, 2, 148, 38, 61, 245, 62, 157, 251, 46, 245, 241, 251, 158, 240, 99, 192, 214, 239, 164, 86, 188, 194, 5, 130, 64, 86, 131, 218, 39, 101, 185, 57, 148, 42, 226, 217, 196, 85, 86, 97, 120, 150, 81, 93, 0, 201, 251, 38, 96, 68, 69, 229, 122, 175, 185, 194, 177, 152, 224, 221, 233, 180, 192, 70, 163, 14, 206, 184, 94, 94, 97, 8, 48, 52, 173, 4, 33, 141, 139, 173, 63, 88, 212, 136, 145, 219, 239, 120, 64, 210, 119, 17, 120, 61, 85, 232, 218, 83, 69, 92, 155, 252, 99, 65, 175, 238, 114, 209, 72, 150, 184, 59, 110 }, "Seven", new byte[] { 221, 126, 64, 109, 69, 93, 154, 180, 5, 196, 159, 101, 97, 65, 214, 74, 3, 149, 144, 97, 155, 24, 171, 113, 208, 75, 36, 154, 74, 90, 197, 184, 97, 177, 173, 106, 208, 44, 146, 71, 117, 157, 98, 8, 78, 31, 226, 216, 102, 46, 212, 74, 141, 165, 226, 3, 109, 110, 143, 58, 232, 224, 7, 17 } });

            migrationBuilder.CreateIndex(
                name: "IX_Location_VehicleID",
                table: "Location",
                column: "VehicleID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Vehicles");
        }
    }
}
