using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Migrators.Sqlite.Migrations
{
    /// <inheritdoc />
    public partial class AddPermission : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Permission",
                schema: "Master",
                columns: table => new
                {
                    Name = table.Column<string>(type: "VarChar(128)", nullable: false),
                    Type = table.Column<string>(type: "VarChar(6)", nullable: false),
                    RelatedAggregateRoot = table.Column<string>(type: "VarChar(128)", nullable: true),
                    RelatedEntity = table.Column<string>(type: "VarChar(128)", nullable: true),
                    Properties = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permission", x => x.Name);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Permission",
                schema: "Master");
        }
    }
}
