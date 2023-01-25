using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HakanBoardGames.Server.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BoardGames",
                columns: table => new
                {
                    BGBoardGameDBId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Releasd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tagline = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    SavedToDatabaseDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoardGames", x => x.BGBoardGameDBId);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    BGCategoryDBId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BoardGameDBId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BoardGameBGBoardGameDBId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.BGCategoryDBId);
                    table.ForeignKey(
                        name: "FK_Categories_BoardGames_BoardGameBGBoardGameDBId",
                        column: x => x.BoardGameBGBoardGameDBId,
                        principalTable: "BoardGames",
                        principalColumn: "BGBoardGameDBId");
                });

            migrationBuilder.CreateTable(
                name: "Creators",
                columns: table => new
                {
                    BGCreatorDBId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BoardGameDBId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BoardGameBGBoardGameDBId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Creators", x => x.BGCreatorDBId);
                    table.ForeignKey(
                        name: "FK_Creators_BoardGames_BoardGameBGBoardGameDBId",
                        column: x => x.BoardGameBGBoardGameDBId,
                        principalTable: "BoardGames",
                        principalColumn: "BGBoardGameDBId");
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    BGPlayerDBId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Min = table.Column<int>(type: "int", nullable: false),
                    Max = table.Column<int>(type: "int", nullable: false),
                    BoardGameDBId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BoardGameBGBoardGameDBId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.BGPlayerDBId);
                    table.ForeignKey(
                        name: "FK_Players_BoardGames_BoardGameBGBoardGameDBId",
                        column: x => x.BoardGameBGBoardGameDBId,
                        principalTable: "BoardGames",
                        principalColumn: "BGBoardGameDBId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_BoardGameBGBoardGameDBId",
                table: "Categories",
                column: "BoardGameBGBoardGameDBId");

            migrationBuilder.CreateIndex(
                name: "IX_Creators_BoardGameBGBoardGameDBId",
                table: "Creators",
                column: "BoardGameBGBoardGameDBId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_BoardGameBGBoardGameDBId",
                table: "Players",
                column: "BoardGameBGBoardGameDBId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Creators");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "BoardGames");
        }
    }
}
