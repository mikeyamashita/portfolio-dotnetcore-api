using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoApi.Migrations
{
    /// <inheritdoc />
    public partial class LinkController9 : Migration
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
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

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
                principalColumn: "Id");
        }
    }
}
