using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library_Management_EF_Data.Migrations
{
    /// <inheritdoc />
    public partial class configurationAuthorBook : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuthorsBooks_Authors_BookId",
                table: "AuthorsBooks");

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorsBooks_Authors_AuthorId",
                table: "AuthorsBooks",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuthorsBooks_Authors_AuthorId",
                table: "AuthorsBooks");

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorsBooks_Authors_BookId",
                table: "AuthorsBooks",
                column: "BookId",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
