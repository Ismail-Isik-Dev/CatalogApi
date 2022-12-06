using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Catalog.Persistance.Migrations
{
    public partial class UpdateOne : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryAttribute_Attributes_CategoryId",
                table: "CategoryAttribute");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryAttribute_AttributeId",
                table: "CategoryAttribute",
                column: "AttributeId");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryAttribute_Attributes_AttributeId",
                table: "CategoryAttribute",
                column: "AttributeId",
                principalTable: "Attributes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryAttribute_Attributes_AttributeId",
                table: "CategoryAttribute");

            migrationBuilder.DropIndex(
                name: "IX_CategoryAttribute_AttributeId",
                table: "CategoryAttribute");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryAttribute_Attributes_CategoryId",
                table: "CategoryAttribute",
                column: "CategoryId",
                principalTable: "Attributes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
