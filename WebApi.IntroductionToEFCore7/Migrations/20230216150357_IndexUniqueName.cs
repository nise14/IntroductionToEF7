using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.IntroductionToEFCore7.Migrations
{
    /// <inheritdoc />
    public partial class IndexUniqueName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Genders_Name",
                table: "Genders",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Genders_Name",
                table: "Genders");
        }
    }
}
