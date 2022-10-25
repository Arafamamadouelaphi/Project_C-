using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BowlingEF.Migrations
{
    public partial class myMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Equipes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nom = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Joueurs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Pseudo = table.Column<string>(type: "TEXT", nullable: false),
                    EquipeEntityId = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Joueurs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Joueurs_Equipes_EquipeEntityId",
                        column: x => x.EquipeEntityId,
                        principalTable: "Equipes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Parties",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    JoueurForeignKey = table.Column<long>(type: "INTEGER", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Score = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Parties_Joueurs_JoueurForeignKey",
                        column: x => x.JoueurForeignKey,
                        principalTable: "Joueurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Frames",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Numero = table.Column<int>(type: "INTEGER", nullable: false),
                    Lancer1 = table.Column<int>(type: "INTEGER", nullable: false),
                    Lancer2 = table.Column<int>(type: "INTEGER", nullable: false),
                    Lancer3 = table.Column<int>(type: "INTEGER", nullable: false),
                    PartieId = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Frames", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Frames_Parties_PartieId",
                        column: x => x.PartieId,
                        principalTable: "Parties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Frames_PartieId",
                table: "Frames",
                column: "PartieId");

            migrationBuilder.CreateIndex(
                name: "IX_Joueurs_EquipeEntityId",
                table: "Joueurs",
                column: "EquipeEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Parties_JoueurForeignKey",
                table: "Parties",
                column: "JoueurForeignKey");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Frames");

            migrationBuilder.DropTable(
                name: "Parties");

            migrationBuilder.DropTable(
                name: "Joueurs");

            migrationBuilder.DropTable(
                name: "Equipes");
        }
    }
}
