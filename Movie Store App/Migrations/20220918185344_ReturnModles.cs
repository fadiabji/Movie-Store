using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Movie_Store_App.Migrations
{
    public partial class ReturnModles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderRows_Movies_MovieId",
                table: "OrderRows");

            migrationBuilder.DropIndex(
                name: "IX_OrderRows_MovieId",
                table: "OrderRows");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "OrderRows");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "OrderRows");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "OrderRows",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<string>(
                name: "Lastname",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "OrderRows");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "OrderRows",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "OrderRows",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Lastname",
                table: "Customers",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_OrderRows_MovieId",
                table: "OrderRows",
                column: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderRows_Movies_MovieId",
                table: "OrderRows",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
