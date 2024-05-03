using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StrayHome.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addImageLinkForMissingAnimal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageLink",
                table: "MissingAnimals",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageLink",
                table: "MissingAnimals");
        }
    }
}
