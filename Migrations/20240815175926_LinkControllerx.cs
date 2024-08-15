using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoApi.Migrations
{
    /// <inheritdoc />
    public partial class LinkControllerx : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Link_Projects_ProjectId1",
                schema: "public",
                table: "Link");

            migrationBuilder.DropIndex(
                name: "IX_Link_ProjectId1",
                schema: "public",
                table: "Link");

            migrationBuilder.DropColumn(
                name: "ProjectId1",
                schema: "public",
                table: "Link");

            migrationBuilder.RenameColumn(
                name: "ProjectId",
                schema: "public",
                table: "Projects",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "LinkId",
                schema: "public",
                table: "Link",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "public",
                table: "Projects",
                newName: "ProjectId");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "public",
                table: "Link",
                newName: "LinkId");

            migrationBuilder.AddColumn<long>(
                name: "ProjectId1",
                schema: "public",
                table: "Link",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Link_ProjectId1",
                schema: "public",
                table: "Link",
                column: "ProjectId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Link_Projects_ProjectId1",
                schema: "public",
                table: "Link",
                column: "ProjectId1",
                principalSchema: "public",
                principalTable: "Projects",
                principalColumn: "ProjectId");
        }
    }
}
