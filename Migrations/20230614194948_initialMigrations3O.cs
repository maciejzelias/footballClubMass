using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace footballClubMass.Migrations
{
    /// <inheritdoc />
    public partial class initialMigrations3O : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Clause",
                table: "Contract",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "coachId",
                table: "Contract",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Coach",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    baseSalary = table.Column<double>(type: "REAL", nullable: false),
                    Discriminator = table.Column<string>(type: "TEXT", nullable: false),
                    degreeEducationType = table.Column<int>(type: "INTEGER", nullable: true),
                    CanTeachPositioning = table.Column<bool>(type: "INTEGER", nullable: true),
                    CanTeachPanemka = table.Column<bool>(type: "INTEGER", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Surname = table.Column<string>(type: "TEXT", nullable: false),
                    BirthdayYear = table.Column<int>(type: "INTEGER", nullable: false),
                    PESEL = table.Column<string>(type: "TEXT", maxLength: 11, nullable: false),
                    CountOfTitles = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coach", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SetPieceCoachTypeDb",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    type = table.Column<int>(type: "INTEGER", nullable: false),
                    setPieceCoachId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SetPieceCoachTypeDb", x => x.id);
                    table.ForeignKey(
                        name: "FK_SetPieceCoachTypeDb_Coach_setPieceCoachId",
                        column: x => x.setPieceCoachId,
                        principalTable: "Coach",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contract_coachId",
                table: "Contract",
                column: "coachId");

            migrationBuilder.CreateIndex(
                name: "IX_SetPieceCoachTypeDb_setPieceCoachId",
                table: "SetPieceCoachTypeDb",
                column: "setPieceCoachId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contract_Coach_coachId",
                table: "Contract",
                column: "coachId",
                principalTable: "Coach",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contract_Coach_coachId",
                table: "Contract");

            migrationBuilder.DropTable(
                name: "SetPieceCoachTypeDb");

            migrationBuilder.DropTable(
                name: "Coach");

            migrationBuilder.DropIndex(
                name: "IX_Contract_coachId",
                table: "Contract");

            migrationBuilder.DropColumn(
                name: "Clause",
                table: "Contract");

            migrationBuilder.DropColumn(
                name: "coachId",
                table: "Contract");
        }
    }
}
