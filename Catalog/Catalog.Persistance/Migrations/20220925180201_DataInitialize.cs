using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Catalog.Persistance.Migrations
{
    public partial class DataInitialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Attributes",
                columns: new[] { "Id", "CreatedDate", "DisplayName", "ModifiedDate", "Name", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 9, 25, 21, 2, 0, 856, DateTimeKind.Local).AddTicks(2843), "Cinsiyet", new DateTime(2022, 9, 25, 21, 2, 0, 856, DateTimeKind.Local).AddTicks(2853), "Gender", 1 },
                    { 2, new DateTime(2022, 9, 25, 21, 2, 0, 856, DateTimeKind.Local).AddTicks(2854), "Boyut", new DateTime(2022, 9, 25, 21, 2, 0, 856, DateTimeKind.Local).AddTicks(2854), "Size", 1 },
                    { 3, new DateTime(2022, 9, 25, 21, 2, 0, 856, DateTimeKind.Local).AddTicks(2855), "Renk", new DateTime(2022, 9, 25, 21, 2, 0, 856, DateTimeKind.Local).AddTicks(2856), "Color", 1 },
                    { 4, new DateTime(2022, 9, 25, 21, 2, 0, 856, DateTimeKind.Local).AddTicks(2856), "Marka", new DateTime(2022, 9, 25, 21, 2, 0, 856, DateTimeKind.Local).AddTicks(2857), "Brand", 1 }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "ModifiedDate", "Name", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 9, 25, 21, 2, 0, 856, DateTimeKind.Local).AddTicks(6243), new DateTime(2022, 9, 25, 21, 2, 0, 856, DateTimeKind.Local).AddTicks(6247), "Smart Phone", 1 },
                    { 2, new DateTime(2022, 9, 25, 21, 2, 0, 856, DateTimeKind.Local).AddTicks(6248), new DateTime(2022, 9, 25, 21, 2, 0, 856, DateTimeKind.Local).AddTicks(6248), "Computer", 1 },
                    { 3, new DateTime(2022, 9, 25, 21, 2, 0, 856, DateTimeKind.Local).AddTicks(6249), new DateTime(2022, 9, 25, 21, 2, 0, 856, DateTimeKind.Local).AddTicks(6249), "Tablet", 1 },
                    { 4, new DateTime(2022, 9, 25, 21, 2, 0, 856, DateTimeKind.Local).AddTicks(6250), new DateTime(2022, 9, 25, 21, 2, 0, 856, DateTimeKind.Local).AddTicks(6250), "Boiler", 1 }
                });

            migrationBuilder.InsertData(
                table: "CategoryAttribute",
                columns: new[] { "AttributeId", "CategoryId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 2, 2 },
                    { 2, 3 },
                    { 3, 3 },
                    { 1, 4 },
                    { 2, 4 },
                    { 4, 4 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedDate", "ModifiedDate", "Name", "Price", "Status" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2022, 9, 25, 21, 2, 0, 857, DateTimeKind.Local).AddTicks(61), new DateTime(2022, 9, 25, 21, 2, 0, 857, DateTimeKind.Local).AddTicks(64), "Test Product_1", 50m, 1 },
                    { 2, 2, new DateTime(2022, 9, 25, 21, 2, 0, 857, DateTimeKind.Local).AddTicks(65), new DateTime(2022, 9, 25, 21, 2, 0, 857, DateTimeKind.Local).AddTicks(66), "Test Product_2", 100m, 1 },
                    { 3, 3, new DateTime(2022, 9, 25, 21, 2, 0, 857, DateTimeKind.Local).AddTicks(67), new DateTime(2022, 9, 25, 21, 2, 0, 857, DateTimeKind.Local).AddTicks(67), "Test Product_3", 150m, 1 },
                    { 4, 4, new DateTime(2022, 9, 25, 21, 2, 0, 857, DateTimeKind.Local).AddTicks(68), new DateTime(2022, 9, 25, 21, 2, 0, 857, DateTimeKind.Local).AddTicks(68), "Test Product_4", 200m, 1 }
                });

            migrationBuilder.InsertData(
                table: "ProductAttribute",
                columns: new[] { "AttributeId", "ProductId", "Value" },
                values: new object[,]
                {
                    { 1, 1, "Erkek" },
                    { 2, 1, "XXL" },
                    { 2, 2, "M" },
                    { 2, 3, "L" },
                    { 3, 3, "Mavi" },
                    { 1, 4, "Bayan" },
                    { 4, 4, "Test Brand" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CategoryAttribute",
                keyColumns: new[] { "AttributeId", "CategoryId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "CategoryAttribute",
                keyColumns: new[] { "AttributeId", "CategoryId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "CategoryAttribute",
                keyColumns: new[] { "AttributeId", "CategoryId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "CategoryAttribute",
                keyColumns: new[] { "AttributeId", "CategoryId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "CategoryAttribute",
                keyColumns: new[] { "AttributeId", "CategoryId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "CategoryAttribute",
                keyColumns: new[] { "AttributeId", "CategoryId" },
                keyValues: new object[] { 1, 4 });

            migrationBuilder.DeleteData(
                table: "CategoryAttribute",
                keyColumns: new[] { "AttributeId", "CategoryId" },
                keyValues: new object[] { 2, 4 });

            migrationBuilder.DeleteData(
                table: "CategoryAttribute",
                keyColumns: new[] { "AttributeId", "CategoryId" },
                keyValues: new object[] { 4, 4 });

            migrationBuilder.DeleteData(
                table: "ProductAttribute",
                keyColumns: new[] { "AttributeId", "ProductId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "ProductAttribute",
                keyColumns: new[] { "AttributeId", "ProductId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "ProductAttribute",
                keyColumns: new[] { "AttributeId", "ProductId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "ProductAttribute",
                keyColumns: new[] { "AttributeId", "ProductId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "ProductAttribute",
                keyColumns: new[] { "AttributeId", "ProductId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "ProductAttribute",
                keyColumns: new[] { "AttributeId", "ProductId" },
                keyValues: new object[] { 1, 4 });

            migrationBuilder.DeleteData(
                table: "ProductAttribute",
                keyColumns: new[] { "AttributeId", "ProductId" },
                keyValues: new object[] { 4, 4 });

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
