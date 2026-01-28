using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarBook_Ayt_Persistance.Migrations
{
    /// <inheritdoc />
    public partial class mig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CarId",
                table: "Cars",
                newName: "CarID");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Pricings",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CarID",
                table: "Cars",
                newName: "CarId");

            migrationBuilder.AlterColumn<int>(
                name: "Name",
                table: "Pricings",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
