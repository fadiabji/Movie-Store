using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Movie_Store_App.Migrations
{
    public partial class UpdateOrderRow : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Price",
                table: "OrderRows",
                newName: "Quantity");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "OrderRows",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "OrderRows",
                newName: "Price");
        }
    }
}
