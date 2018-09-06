using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Integration.Migrations
{
    public partial class initialmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Number = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: false),
                    CarId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Travels",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Origin = table.Column<string>(nullable: true),
                    Destination = table.Column<string>(nullable: true),
                    DepartureTime = table.Column<DateTimeOffset>(nullable: false),
                    DriverUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Travels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Travels_Users_DriverUserId",
                        column: x => x.DriverUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Passangers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    PassengerUserId = table.Column<string>(nullable: true),
                    TravelId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passangers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Passangers_Users_PassengerUserId",
                        column: x => x.PassengerUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Passangers_Travels_TravelId",
                        column: x => x.TravelId,
                        principalTable: "Travels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Number" },
                values: new object[] { "CarVeryUniqueGuid", "YAU123" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CarId", "Name", "PhoneNumber" },
                values: new object[] { "UserVeryUniqueGuid2", null, "Alisa Selezniova", "864001010" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CarId", "Name", "PhoneNumber" },
                values: new object[] { "UserVeryUniqueGuid1", "CarVeryUniqueGuid", "Domas Sostronk", "86656911" });

            migrationBuilder.InsertData(
                table: "Travels",
                columns: new[] { "Id", "DepartureTime", "Destination", "DriverUserId", "Origin" },
                values: new object[] { "TravelVeryUniqueGuid", new DateTimeOffset(new DateTime(2018, 9, 28, 9, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), "54.700690, 25.261981", "UserVeryUniqueGuid1", "54.670396, 25.284133" });

            migrationBuilder.InsertData(
                table: "Passangers",
                columns: new[] { "Id", "PassengerUserId", "TravelId" },
                values: new object[] { "PassengerVeryUniqueGuid", "UserVeryUniqueGuid2", "TravelVeryUniqueGuid" });

            migrationBuilder.CreateIndex(
                name: "IX_Passangers_PassengerUserId",
                table: "Passangers",
                column: "PassengerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Passangers_TravelId",
                table: "Passangers",
                column: "TravelId");

            migrationBuilder.CreateIndex(
                name: "IX_Travels_DriverUserId",
                table: "Travels",
                column: "DriverUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CarId",
                table: "Users",
                column: "CarId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Passangers");

            migrationBuilder.DropTable(
                name: "Travels");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Cars");
        }
    }
}
