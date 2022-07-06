using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PackIT.Infrastructure.EF.Migrations
{
    public partial class Init_Read : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "packing");

            migrationBuilder.CreateTable(
                name: "packing_lists",
                schema: "packing",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Version = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Localization = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_packing_lists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "packing_items",
                schema: "packing",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Qty = table.Column<long>(type: "bigint", nullable: false),
                    IsPacked = table.Column<bool>(type: "boolean", nullable: false),
                    PackingListId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_packing_items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_packing_items_packing_lists_PackingListId",
                        column: x => x.PackingListId,
                        principalSchema: "packing",
                        principalTable: "packing_lists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_packing_items_PackingListId",
                schema: "packing",
                table: "packing_items",
                column: "PackingListId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "packing_items",
                schema: "packing");

            migrationBuilder.DropTable(
                name: "packing_lists",
                schema: "packing");
        }
    }
}
