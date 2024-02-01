using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StrayHome.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class add_ShelterAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shelters_Users_AdministratorID",
                table: "Shelters");

            migrationBuilder.DropIndex(
                name: "IX_Shelters_AdministratorID",
                table: "Shelters");

            migrationBuilder.DropColumn(
                name: "AdministratorID",
                table: "Shelters");

            migrationBuilder.CreateTable(
                name: "ShelterAdmins",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    AdministratorID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ShelterID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShelterAdmins", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ShelterAdmins_Shelters_ShelterID",
                        column: x => x.ShelterID,
                        principalTable: "Shelters",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShelterAdmins_Users_AdministratorID",
                        column: x => x.AdministratorID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ShelterAdmins_AdministratorID",
                table: "ShelterAdmins",
                column: "AdministratorID");

            migrationBuilder.CreateIndex(
                name: "IX_ShelterAdmins_ShelterID",
                table: "ShelterAdmins",
                column: "ShelterID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShelterAdmins");

            migrationBuilder.AddColumn<Guid>(
                name: "AdministratorID",
                table: "Shelters",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_Shelters_AdministratorID",
                table: "Shelters",
                column: "AdministratorID");

            migrationBuilder.AddForeignKey(
                name: "FK_Shelters_Users_AdministratorID",
                table: "Shelters",
                column: "AdministratorID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
