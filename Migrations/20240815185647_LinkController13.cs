using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoApi.Migrations
{
    /// <inheritdoc />
    public partial class LinkController13 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Link_Projects_ProjectId1",
                schema: "public",
                table: "Link");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Link",
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

            migrationBuilder.RenameTable(
                name: "Link",
                schema: "public",
                newName: "Links",
                newSchema: "public");

            migrationBuilder.AlterColumn<long>(
                name: "ProjectId",
                schema: "public",
                table: "Links",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Links",
                schema: "public",
                table: "Links",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Links_ProjectId",
                schema: "public",
                table: "Links",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Links_Projects_ProjectId",
                schema: "public",
                table: "Links",
                column: "ProjectId",
                principalSchema: "public",
                principalTable: "Projects",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Links_Projects_ProjectId",
                schema: "public",
                table: "Links");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Links",
                schema: "public",
                table: "Links");

            migrationBuilder.DropIndex(
                name: "IX_Links_ProjectId",
                schema: "public",
                table: "Links");

            migrationBuilder.RenameTable(
                name: "Links",
                schema: "public",
                newName: "Link",
                newSchema: "public");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectId",
                schema: "public",
                table: "Link",
                type: "integer",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ProjectId1",
                schema: "public",
                table: "Link",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Link",
                schema: "public",
                table: "Link",
                column: "Id");

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
                principalColumn: "Id");
        }
    }
}
