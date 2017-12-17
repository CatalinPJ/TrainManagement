using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Data.Persistance.Migrations
{
    public partial class _1st : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Routes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DestinationStationCode = table.Column<int>(nullable: false),
                    OriginStationCode = table.Column<int>(nullable: false),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Routes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stations",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    OfficialCode = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ArrivalTime = table.Column<DateTime>(nullable: false),
                    Bike = table.Column<int>(nullable: false),
                    Car = table.Column<int>(nullable: false),
                    DepartureTime = table.Column<DateTime>(nullable: false),
                    DestinationStationId = table.Column<Guid>(nullable: false),
                    Duration = table.Column<int>(nullable: false),
                    Km = table.Column<int>(nullable: false),
                    OriginStationId = table.Column<Guid>(nullable: false),
                    Pet = table.Column<int>(nullable: false),
                    Price = table.Column<int>(nullable: false),
                    Seat = table.Column<int>(nullable: false),
                    TrainId = table.Column<Guid>(nullable: false),
                    Type = table.Column<string>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Trains",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Category = table.Column<string>(nullable: true),
                    CumulatedKm = table.Column<int>(nullable: false),
                    Length = table.Column<int>(nullable: false),
                    OfficialNumber = table.Column<string>(nullable: true),
                    OperatorCode = table.Column<int>(nullable: false),
                    OwnerCode = table.Column<int>(nullable: false),
                    Rank = table.Column<int>(nullable: false),
                    Weight = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trains", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RouteNodes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ArrivalTime = table.Column<long>(nullable: false),
                    DepartureTime = table.Column<long>(nullable: false),
                    DestinationStationCode = table.Column<int>(nullable: false),
                    DestinationStationName = table.Column<string>(nullable: true),
                    Km = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    OfficialCode = table.Column<int>(nullable: false),
                    OriginStationCode = table.Column<int>(nullable: false),
                    OriginStationName = table.Column<string>(nullable: true),
                    RouteId = table.Column<Guid>(nullable: false),
                    Standing = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RouteNodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RouteNodes_Routes_RouteId",
                        column: x => x.RouteId,
                        principalTable: "Routes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RouteNodes_RouteId",
                table: "RouteNodes",
                column: "RouteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RouteNodes");

            migrationBuilder.DropTable(
                name: "Stations");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Trains");

            migrationBuilder.DropTable(
                name: "Routes");
        }
    }
}
