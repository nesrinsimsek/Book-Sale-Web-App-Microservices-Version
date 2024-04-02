using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookSale.MVC.Migrations
{
    /// <inheritdoc />
    public partial class ChangeNameOfDatePropertyInHttpMessageLogTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Responses",
                newName: "ResponseDate");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Requests",
                newName: "RequestDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ResponseDate",
                table: "Responses",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "RequestDate",
                table: "Requests",
                newName: "Date");
        }
    }
}
