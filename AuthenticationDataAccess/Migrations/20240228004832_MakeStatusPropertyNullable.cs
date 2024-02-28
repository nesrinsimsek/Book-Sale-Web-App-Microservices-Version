using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthenticationDataAccess.Migrations
{
    /// <inheritdoc />
    public partial class MakeStatusPropertyNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "Onay Bekliyor",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValue: "Onay Bekliyor");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "Onay Bekliyor",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValue: "Onay Bekliyor");
        }
    }
}
