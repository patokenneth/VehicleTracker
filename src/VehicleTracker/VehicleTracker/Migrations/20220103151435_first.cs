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
                values: new object[] { 1, true, new byte[] { 230, 143, 136, 1, 21, 5, 9, 159, 248, 87, 16, 174, 247, 186, 65, 46, 238, 132, 223, 127, 215, 218, 14, 167, 27, 202, 44, 26, 37, 0, 161, 186, 16, 246, 166, 198, 202, 108, 47, 94, 151, 120, 237, 141, 223, 11, 103, 61, 51, 118, 186, 133, 132, 248, 61, 34, 140, 75, 84, 166, 234, 253, 172, 19, 160, 87, 228, 121, 217, 175, 72, 240, 123, 220, 37, 32, 69, 136, 207, 105, 249, 137, 107, 7, 246, 4, 166, 30, 209, 23, 129, 213, 24, 120, 17, 32, 40, 155, 228, 71, 50, 193, 200, 111, 172, 232, 171, 29, 252, 86, 186, 157, 65, 171, 81, 230, 151, 226, 32, 37, 126, 22, 56, 169, 137, 39, 36, 195 }, "Seven", new byte[] { 201, 5, 19, 17, 45, 222, 202, 229, 95, 107, 118, 64, 18, 46, 132, 204, 160, 3, 70, 30, 243, 57, 40, 1, 133, 32, 172, 236, 60, 174, 113, 132, 18, 93, 121, 74, 236, 237, 47, 41, 255, 180, 160, 116, 234, 249, 66, 215, 246, 131, 19, 244, 216, 97, 89, 20, 9, 87, 117, 237, 238, 140, 225, 213 } });

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
