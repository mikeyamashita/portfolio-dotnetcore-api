using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoApi.Migrations
{
    /// <inheritdoc />
    public partial class LinkController5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Link_LinksId",
                schema: "public",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Projects_LinksId",
                schema: "public",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "LinksId",
                schema: "public",
                table: "Projects");

            migrationBuilder.AddColumn<int>(
                name: "LinkId",
                schema: "public",
                table: "Link",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "ProjectId",
                schema: "public",
                table: "Link",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Link_ProjectId",
                schema: "public",
                table: "Link",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Link_Projects_ProjectId",
                schema: "public",
                table: "Link",
                column: "ProjectId",
                principalSchema: "public",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Link_Projects_ProjectId",
                schema: "public",
                table: "Link");

            migrationBuilder.DropIndex(
                name: "IX_Link_ProjectId",
                schema: "public",
                table: "Link");

            migrationBuilder.DropColumn(
                name: "LinkId",
                schema: "public",
                table: "Link");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                schema: "public",
                table: "Link");

            migrationBuilder.AddColumn<long>(
                name: "LinksId",
                schema: "public",
                table: "Projects",
                type: "bigint",
                nullable: true);

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
    }
}
