using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArchDdd.Adapters.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class refactor_IAuditable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                schema: "Master",
                table: "User");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                schema: "Master",
                table: "User");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                schema: "Master",
                table: "User",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                schema: "Master",
                table: "User",
                type: "TEXT",
                nullable: true);
        }
    }
}
