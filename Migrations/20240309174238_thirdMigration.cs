using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TunaPiano.Migrations
{
    public partial class thirdMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Songs_Artists_ArtistID",
                table: "Songs");

            migrationBuilder.AlterColumn<int>(
                name: "Length",
                table: "Songs",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "ArtistID",
                table: "Songs",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "GenreID",
                table: "Songs",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Songs_GenreID",
                table: "Songs",
                column: "GenreID");

            migrationBuilder.AddForeignKey(
                name: "FK_Songs_Artists_ArtistID",
                table: "Songs",
                column: "ArtistID",
                principalTable: "Artists",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Songs_Genres_GenreID",
                table: "Songs",
                column: "GenreID",
                principalTable: "Genres",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Songs_Artists_ArtistID",
                table: "Songs");

            migrationBuilder.DropForeignKey(
                name: "FK_Songs_Genres_GenreID",
                table: "Songs");

            migrationBuilder.DropIndex(
                name: "IX_Songs_GenreID",
                table: "Songs");

            migrationBuilder.DropColumn(
                name: "GenreID",
                table: "Songs");

            migrationBuilder.AlterColumn<int>(
                name: "Length",
                table: "Songs",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ArtistID",
                table: "Songs",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Songs_Artists_ArtistID",
                table: "Songs",
                column: "ArtistID",
                principalTable: "Artists",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
