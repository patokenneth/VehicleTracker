using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VehicleTracker.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleID = table.Column<int>(type: "int", nullable: false),
                    Latitude = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Longitude = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                values: new object[] { 1, true, new byte[] { 147, 158, 202, 240, 241, 6, 46, 152, 54, 136, 206, 234, 225, 46, 123, 171, 151, 73, 22, 251, 255, 47, 81, 99, 51, 124, 240, 225, 203, 18, 0, 130, 61, 59, 223, 244, 85, 78, 117, 226, 207, 99, 108, 10, 217, 230, 50, 191, 230, 40, 193, 225, 151, 71, 148, 170, 159, 133, 205, 175, 103, 57, 132, 193, 240, 196, 173, 137, 54, 95, 239, 142, 177, 160, 249, 212, 212, 50, 166, 101, 47, 39, 74, 100, 94, 255, 190, 138, 222, 222, 237, 78, 210, 14, 166, 248, 226, 196, 189, 66, 23, 229, 54, 234, 209, 76, 130, 242, 146, 231, 146, 185, 195, 16, 44, 41, 90, 253, 12, 172, 86, 84, 223, 147, 110, 106, 73, 79 }, "Seven", new byte[] { 79, 197, 206, 245, 148, 33, 232, 86, 94, 73, 93, 208, 89, 244, 53, 140, 92, 226, 228, 35, 159, 9, 180, 166, 94, 251, 103, 193, 140, 95, 95, 234, 21, 168, 94, 207, 27, 111, 105, 121, 126, 9, 230, 12, 191, 180, 149, 229, 128, 232, 51, 229, 66, 143, 74, 29, 73, 17, 28, 251, 17, 109, 79, 75 } });

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
