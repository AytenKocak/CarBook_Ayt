using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarBook_Ayt_Persistance.Migrations
{
    /// <inheritdoc />
    public partial class FixEmail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Emial",
                table: "FooterAddresses",
                newName: "Email");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Email",
                table: "FooterAddresses",
                newName: "Emial");
        }
    }
}
