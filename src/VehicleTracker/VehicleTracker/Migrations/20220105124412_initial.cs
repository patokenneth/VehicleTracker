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
                values: new object[] { 1, true, new byte[] { 101, 82, 128, 52, 222, 60, 37, 178, 138, 78, 90, 254, 195, 19, 202, 173, 24, 9, 23, 16, 163, 78, 109, 188, 216, 41, 62, 31, 186, 197, 129, 76, 145, 12, 37, 80, 121, 101, 104, 247, 92, 55, 212, 4, 121, 176, 14, 167, 71, 131, 121, 145, 198, 12, 173, 152, 113, 187, 223, 168, 226, 166, 122, 191, 32, 53, 57, 154, 93, 217, 177, 88, 139, 71, 52, 77, 158, 142, 15, 224, 62, 83, 116, 79, 78, 188, 84, 241, 211, 90, 8, 58, 164, 14, 196, 250, 76, 105, 145, 118, 67, 201, 167, 39, 101, 176, 199, 109, 61, 237, 195, 65, 253, 233, 48, 3, 71, 153, 200, 242, 154, 149, 85, 51, 210, 178, 154, 135 }, "Seven", new byte[] { 212, 187, 36, 95, 47, 143, 192, 217, 83, 84, 131, 16, 43, 86, 130, 233, 28, 209, 228, 103, 203, 244, 66, 152, 6, 75, 155, 70, 220, 30, 127, 66, 134, 3, 36, 96, 164, 59, 142, 249, 123, 68, 202, 207, 5, 90, 32, 151, 220, 242, 51, 236, 215, 205, 92, 203, 202, 215, 176, 179, 238, 225, 37, 158 } });

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
