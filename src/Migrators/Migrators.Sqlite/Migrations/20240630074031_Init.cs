using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Migrators.Sqlite.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Master");

            migrationBuilder.CreateTable(
                name: "Role",
                schema: "Master",
                columns: table => new
                {
                    Name = table.Column<string>(type: "VarChar(128)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "User",
                schema: "Master",
                columns: table => new
                {
                    Id = table.Column<string>(type: "Char(26)", nullable: false),
                    Username = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 40, nullable: false),
                    PasswordHash = table.Column<string>(type: "NChar(514)", nullable: false),
                    CreatedOn = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    UpdatedOn = table.Column<DateTimeOffset>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoleUser",
                schema: "Master",
                columns: table => new
                {
                    RoleName = table.Column<string>(type: "VarChar(128)", nullable: false),
                    UserId = table.Column<string>(type: "Char(26)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleUser", x => new { x.RoleName, x.UserId });
                    table.ForeignKey(
                        name: "FK_RoleUser_Role_RoleName",
                        column: x => x.RoleName,
                        principalSchema: "Master",
                        principalTable: "Role",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleUser_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "Master",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "Master",
                table: "Role",
                column: "Name",
                values: new object[]
                {
                    "Administrator",
                    "Customer",
                    "Employee",
                    "Manager"
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoleUser_UserId",
                schema: "Master",
                table: "RoleUser",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoleUser",
                schema: "Master");

            migrationBuilder.DropTable(
                name: "Role",
                schema: "Master");

            migrationBuilder.DropTable(
                name: "User",
                schema: "Master");
        }
    }
}
