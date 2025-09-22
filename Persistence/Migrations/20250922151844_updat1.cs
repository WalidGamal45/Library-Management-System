using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class updat1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BorrowedAt",
                table: "BorrowTransactions");

            migrationBuilder.DropColumn(
                name: "DueAt",
                table: "BorrowTransactions");

            migrationBuilder.AlterColumn<string>(
                name: "ProcessedByUserId",
                table: "BorrowTransactions",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedByUserId",
                table: "BorrowTransactions",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_BorrowTransactions_CreatedByUserId",
                table: "BorrowTransactions",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BorrowTransactions_ProcessedByUserId",
                table: "BorrowTransactions",
                column: "ProcessedByUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BorrowTransactions_AspNetUsers_CreatedByUserId",
                table: "BorrowTransactions",
                column: "CreatedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_BorrowTransactions_AspNetUsers_ProcessedByUserId",
                table: "BorrowTransactions",
                column: "ProcessedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BorrowTransactions_AspNetUsers_CreatedByUserId",
                table: "BorrowTransactions");

            migrationBuilder.DropForeignKey(
                name: "FK_BorrowTransactions_AspNetUsers_ProcessedByUserId",
                table: "BorrowTransactions");

            migrationBuilder.DropIndex(
                name: "IX_BorrowTransactions_CreatedByUserId",
                table: "BorrowTransactions");

            migrationBuilder.DropIndex(
                name: "IX_BorrowTransactions_ProcessedByUserId",
                table: "BorrowTransactions");

            migrationBuilder.AlterColumn<int>(
                name: "ProcessedByUserId",
                table: "BorrowTransactions",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedByUserId",
                table: "BorrowTransactions",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<DateTime>(
                name: "BorrowedAt",
                table: "BorrowTransactions",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DueAt",
                table: "BorrowTransactions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
