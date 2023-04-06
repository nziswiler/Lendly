using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lendly.Infrastructure.DbAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddVisibleIdentifier : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ISBN",
                table: "Book");

            migrationBuilder.AddColumn<int>(
                name: "VisibleIdentifier",
                table: "Loan",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "VisibleIdentifier",
                table: "Customer",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "VisibleIdentifier",
                table: "Book",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VisibleIdentifier",
                table: "Loan");

            migrationBuilder.DropColumn(
                name: "VisibleIdentifier",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "VisibleIdentifier",
                table: "Book");

            migrationBuilder.AddColumn<string>(
                name: "ISBN",
                table: "Book",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
