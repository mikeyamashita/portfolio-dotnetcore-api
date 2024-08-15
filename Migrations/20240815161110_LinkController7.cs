using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoApi.Migrations
{
    /// <inheritdoc />
    public partial class LinkController7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Link_Projects_ProjectId1",
                schema: "public",
                table: "Link");

            migrationBuilder.AlterColumn<long>(
                name: "ProjectId1",
                schema: "public",
                table: "Link",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectId",
                schema: "public",
                table: "Link",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

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

            migrationBuilder.AlterColumn<long>(
                name: "ProjectId1",
                schema: "public",
                table: "Link",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProjectId",
                schema: "public",
                table: "Link",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

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
    }
}
