using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.IntroductionToEFCore7.Migrations
{
    /// <inheritdoc />
    public partial class changenombretoname : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Genders",
                newName: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Genders",
                newName: "Nombre");
        }
    }
}
