using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RateMovie.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AutoDateForCreatedAtAndBetterTypeForGenreToMovies : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Movies",
                type: "DATETIME",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "DATETIME");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Movies",
                type: "DATETIME",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldDefaultValueSql: "CURRENT_TIMESTAMP");
        }
    }
}
