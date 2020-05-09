using Microsoft.EntityFrameworkCore.Migrations;

namespace DVDMovie.Migrations
{
    public partial class initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movie_Studio_StudioId",
                table: "Movie");

            migrationBuilder.DropForeignKey(
                name: "FK_Rating_Movie_MovieId",
                table: "Rating");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Studio",
                table: "Studio");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rating",
                table: "Rating");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Movie",
                table: "Movie");

            migrationBuilder.RenameTable(
                name: "Studio",
                newName: "Studios");

            migrationBuilder.RenameTable(
                name: "Rating",
                newName: "Ratings");

            migrationBuilder.RenameTable(
                name: "Movie",
                newName: "Movies");

            migrationBuilder.RenameIndex(
                name: "IX_Rating_MovieId",
                table: "Ratings",
                newName: "IX_Ratings_MovieId");

            migrationBuilder.RenameIndex(
                name: "IX_Movie_StudioId",
                table: "Movies",
                newName: "IX_Movies_StudioId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Studios",
                table: "Studios",
                column: "StudioId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ratings",
                table: "Ratings",
                column: "RatingId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Movies",
                table: "Movies",
                column: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Studios_StudioId",
                table: "Movies",
                column: "StudioId",
                principalTable: "Studios",
                principalColumn: "StudioId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Movies_MovieId",
                table: "Ratings",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "MovieId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Studios_StudioId",
                table: "Movies");

            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Movies_MovieId",
                table: "Ratings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Studios",
                table: "Studios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ratings",
                table: "Ratings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Movies",
                table: "Movies");

            migrationBuilder.RenameTable(
                name: "Studios",
                newName: "Studio");

            migrationBuilder.RenameTable(
                name: "Ratings",
                newName: "Rating");

            migrationBuilder.RenameTable(
                name: "Movies",
                newName: "Movie");

            migrationBuilder.RenameIndex(
                name: "IX_Ratings_MovieId",
                table: "Rating",
                newName: "IX_Rating_MovieId");

            migrationBuilder.RenameIndex(
                name: "IX_Movies_StudioId",
                table: "Movie",
                newName: "IX_Movie_StudioId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Studio",
                table: "Studio",
                column: "StudioId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rating",
                table: "Rating",
                column: "RatingId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Movie",
                table: "Movie",
                column: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movie_Studio_StudioId",
                table: "Movie",
                column: "StudioId",
                principalTable: "Studio",
                principalColumn: "StudioId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Rating_Movie_MovieId",
                table: "Rating",
                column: "MovieId",
                principalTable: "Movie",
                principalColumn: "MovieId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
