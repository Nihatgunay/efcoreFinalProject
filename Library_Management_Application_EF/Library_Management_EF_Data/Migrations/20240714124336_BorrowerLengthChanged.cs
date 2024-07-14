using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library_Management_EF_Data.Migrations
{
    /// <inheritdoc />
    public partial class BorrowerLengthChanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Borrowers",
                type: "NVARCHAR(40)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Borrowers",
                type: "NVARCHAR(40)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Borrowers",
                type: "NVARCHAR",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(40)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Borrowers",
                type: "NVARCHAR",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(40)");
        }
    }
}
