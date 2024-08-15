using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoApi.Migrations
{
    /// <inheritdoc />
    public partial class LinkController6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<int>(
                name: "ProjectId",
                schema: "public",
                table: "Link",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<long>(
                name: "ProjectId1",
                schema: "public",
                table: "Link",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

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
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<long>(
                name: "ProjectId",
                schema: "public",
                table: "Link",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "LinkId",
                schema: "public",
                table: "Link",
                type: "integer",
                nullable: false,
                defaultValue: 0);

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
    }
}
