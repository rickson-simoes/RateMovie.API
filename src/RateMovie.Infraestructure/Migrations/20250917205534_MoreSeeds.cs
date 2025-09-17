using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RateMovie.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class MoreSeeds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Comment", "Name", "Stars" },
                values: new object[,]
                {
                    { 4, "Revolutionary sci-fi with a unique take on reality. Groundbreaking for its time.", "The Matrix", (sbyte)5 },
                    { 5, "Classic mafia story, slow pacing but unmatched storytelling.", "The Godfather", (sbyte)4 },
                    { 6, "So bad it became a cult classic. Unintentionally hilarious.", "The Room", (sbyte)1 },
                    { 7, "Epic conclusion to a decade of Marvel movies, lots of fan service.", "Avengers: Endgame", (sbyte)4 },
                    { 8, "Emotional love story with spectacular visuals, though a bit too long.", "Titanic", (sbyte)3 },
                    { 9, "Disturbing but brilliant character study, Joaquin Phoenix delivers a masterpiece.", "Joker", (sbyte)5 },
                    { 10, "Funny, clever, and full of references. Works for both kids and adults.", "Shrek", (sbyte)4 },
                    { 11, "Visually impressive but shallow story, feels repetitive.", "Transformers", (sbyte)2 },
                    { 12, "Beautiful musical, strong performances, bittersweet ending.", "La La Land", (sbyte)4 },
                    { 13, "Uncanny visuals and lack of coherent plot. Painful to watch.", "Cats", (sbyte)1 },
                    { 14, "Chaotic story, weak villain, but some fun moments.", "Suicide Squad", (sbyte)2 },
                    { 15, "Disjointed narrative, inconsistent tone, feels rushed.", "Justice League (2017)", (sbyte)2 },
                    { 16, "Poor acting, terrible CGI. Fans deserved better.", "Mortal Kombat: Annihilation", (sbyte)1 },
                    { 17, "Total disrespect to the source material, universally hated.", "Dragonball Evolution", (sbyte)1 },
                    { 18, "Decent action, but uneven tone. Carried by Tom Hardy.", "Venom", (sbyte)3 },
                    { 19, "Some good visuals, but overcrowded plot and wasted villains.", "The Amazing Spider-Man 2", (sbyte)3 },
                    { 20, "Charming moments, but franchise fatigue shows.", "Pirates of the Caribbean: On Stranger Tides", (sbyte)3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 20);
        }
    }
}
