using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TodoApi.Migrations
{
    /// <inheritdoc />
    public partial class LinkController2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Links",
                schema: "public",
                table: "Projects");

            migrationBuilder.AddColumn<long>(
                name: "LinksId",
                schema: "public",
                table: "Projects",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Link",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Url = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Link", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Projects_LinksId",
                schema: "public",
                table: "Projects",
                column: "LinksId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Link_LinksId",
                schema: "public",
                table: "Projects",
                column: "LinksId",
                principalSchema: "public",
                principalTable: "Link",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Link_LinksId",
                schema: "public",
                table: "Projects");

            migrationBuilder.DropTable(
                name: "Link",
                schema: "public");

            migrationBuilder.DropIndex(
                name: "IX_Projects_LinksId",
                schema: "public",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "LinksId",
                schema: "public",
                table: "Projects");

            migrationBuilder.AddColumn<string>(
                name: "Links",
                schema: "public",
                table: "Projects",
                type: "text",
                nullable: true);
        }
    }
}
