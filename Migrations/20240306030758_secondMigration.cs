using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TunaPiano.Migrations
{
    public partial class secondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Songs_ArtistID",
                table: "Songs",
                column: "ArtistID");

            migrationBuilder.CreateIndex(
                name: "IX_SongGenres_GenreID",
                table: "SongGenres",
                column: "GenreID");

            migrationBuilder.CreateIndex(
                name: "IX_SongGenres_SongID",
                table: "SongGenres",
                column: "SongID");

            migrationBuilder.AddForeignKey(
                name: "FK_SongGenres_Genres_GenreID",
                table: "SongGenres",
                column: "GenreID",
                principalTable: "Genres",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SongGenres_Songs_SongID",
                table: "SongGenres",
                column: "SongID",
                principalTable: "Songs",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Songs_Artists_ArtistID",
                table: "Songs",
                column: "ArtistID",
                principalTable: "Artists",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SongGenres_Genres_GenreID",
                table: "SongGenres");

            migrationBuilder.DropForeignKey(
                name: "FK_SongGenres_Songs_SongID",
                table: "SongGenres");

            migrationBuilder.DropForeignKey(
                name: "FK_Songs_Artists_ArtistID",
                table: "Songs");

            migrationBuilder.DropIndex(
                name: "IX_Songs_ArtistID",
                table: "Songs");

            migrationBuilder.DropIndex(
                name: "IX_SongGenres_GenreID",
                table: "SongGenres");

            migrationBuilder.DropIndex(
                name: "IX_SongGenres_SongID",
                table: "SongGenres");
        }
    }
}
