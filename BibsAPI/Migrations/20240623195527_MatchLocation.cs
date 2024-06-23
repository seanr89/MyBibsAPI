using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BibsAPI.Migrations
{
    /// <inheritdoc />
    public partial class MatchLocation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Matches",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Matches",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Clubs",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.CreateTable(
                name: "Player",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Rating = table.Column<double>(type: "double precision", nullable: false),
                    MemberId = table.Column<Guid>(type: "uuid", nullable: false),
                    Team = table.Column<string>(type: "text", nullable: false),
                    MatchId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Player", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Player_Matches_MatchId",
                        column: x => x.MatchId,
                        principalTable: "Matches",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Player_MatchId",
                table: "Player",
                column: "MatchId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Player");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Matches");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Matches",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Clubs",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");
        }
    }
}
