using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace footballClubMass.Migrations
{
    /// <inheritdoc />
    public partial class initialMigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PlayerInfo",
                columns: table => new
                {
                    PlayerId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nickname = table.Column<string>(type: "TEXT", nullable: false),
                    betterFoot = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerInfo", x => x.PlayerId);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TshirtNumber = table.Column<int>(type: "INTEGER", nullable: true),
                    PlayerInfoId = table.Column<int>(type: "INTEGER", nullable: false),
                    playerType = table.Column<int>(type: "INTEGER", nullable: false),
                    Role = table.Column<string>(type: "TEXT", nullable: false),
                    InjuryDescription = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Surname = table.Column<string>(type: "TEXT", nullable: false),
                    BirthdayYear = table.Column<int>(type: "INTEGER", nullable: false),
                    PESEL = table.Column<string>(type: "TEXT", maxLength: 11, nullable: false),
                    CountOfTitles = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Players_PlayerInfo_PlayerInfoId",
                        column: x => x.PlayerInfoId,
                        principalTable: "PlayerInfo",
                        principalColumn: "PlayerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PreviousClub",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    clubName = table.Column<string>(type: "TEXT", nullable: false),
                    PlayerInfoId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreviousClub", x => x.id);
                    table.ForeignKey(
                        name: "FK_PreviousClub_PlayerInfo_PlayerInfoId",
                        column: x => x.PlayerInfoId,
                        principalTable: "PlayerInfo",
                        principalColumn: "PlayerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contract",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    endDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Discriminator = table.Column<string>(type: "TEXT", nullable: false),
                    Salary = table.Column<float>(type: "REAL", nullable: true),
                    playerId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contract", x => x.id);
                    table.ForeignKey(
                        name: "FK_Contract_Players_playerId",
                        column: x => x.playerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "pages",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Content = table.Column<string>(type: "TEXT", nullable: false),
                    pageNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    contractId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pages", x => x.id);
                    table.ForeignKey(
                        name: "FK_pages_Contract_contractId",
                        column: x => x.contractId,
                        principalTable: "Contract",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contract_playerId",
                table: "Contract",
                column: "playerId");

            migrationBuilder.CreateIndex(
                name: "IX_pages_contractId",
                table: "pages",
                column: "contractId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_PlayerInfoId",
                table: "Players",
                column: "PlayerInfoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PreviousClub_PlayerInfoId",
                table: "PreviousClub",
                column: "PlayerInfoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "pages");

            migrationBuilder.DropTable(
                name: "PreviousClub");

            migrationBuilder.DropTable(
                name: "Contract");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "PlayerInfo");
        }
    }
}
