using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VehicleTracker.Migrations
{
    public partial class first : Migration
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
                    Longitude = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                values: new object[] { 1, true, new byte[] { 142, 95, 51, 68, 135, 40, 208, 87, 149, 213, 182, 148, 179, 209, 68, 24, 190, 142, 104, 212, 203, 192, 103, 121, 142, 94, 207, 31, 176, 124, 63, 94, 70, 199, 75, 16, 221, 157, 36, 66, 90, 232, 230, 120, 113, 56, 83, 46, 158, 32, 113, 193, 87, 166, 131, 118, 101, 148, 7, 30, 122, 191, 164, 14, 47, 240, 209, 90, 67, 94, 102, 176, 124, 239, 247, 148, 7, 166, 181, 4, 171, 183, 56, 57, 167, 58, 69, 205, 131, 219, 75, 242, 112, 171, 72, 39, 189, 55, 50, 80, 194, 90, 157, 228, 99, 75, 216, 122, 155, 254, 123, 245, 99, 172, 4, 67, 212, 126, 38, 227, 215, 254, 65, 73, 96, 1, 154, 117 }, "Seven", new byte[] { 254, 184, 221, 203, 53, 211, 117, 28, 129, 90, 244, 204, 25, 2, 183, 68, 55, 166, 16, 174, 57, 41, 150, 188, 135, 161, 230, 220, 103, 106, 251, 254, 116, 128, 20, 15, 52, 159, 194, 143, 102, 121, 238, 177, 211, 63, 217, 163, 33, 92, 154, 31, 71, 182, 203, 100, 204, 190, 154, 215, 11, 122, 77, 52 } });

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
