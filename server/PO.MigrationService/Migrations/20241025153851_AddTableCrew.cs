using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PO.MigrationService.Migrations
{
    /// <inheritdoc />
    public partial class AddTableCrew : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Crew",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Crew", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CrewMember",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CrewId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ShipId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CrewMember", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CrewMember_Crew_CrewId",
                        column: x => x.CrewId,
                        principalTable: "Crew",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_CrewMember_Ship_ShipId",
                        column: x => x.ShipId,
                        principalTable: "Ship",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CrewMember_CrewId",
                table: "CrewMember",
                column: "CrewId");

            migrationBuilder.CreateIndex(
                name: "IX_CrewMember_ShipId",
                table: "CrewMember",
                column: "ShipId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CrewMember");

            migrationBuilder.DropTable(
                name: "Crew");
        }
    }
}
