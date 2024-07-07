using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OneToOne_02_PrimaryKeyToPrimaryKey.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Blogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BlogHeaders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogHeaders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BlogHeaders_Blogs_Id",
                        column: x => x.Id,
                        principalTable: "Blogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlogHeaders");

            migrationBuilder.DropTable(
                name: "Blogs");
        }
    }
}
