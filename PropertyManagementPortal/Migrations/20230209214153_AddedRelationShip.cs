using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PropertyManagementPortal.Migrations
{
    /// <inheritdoc />
    public partial class AddedRelationShip : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BuildingId",
                table: "Apartment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Apartment_BuildingId",
                table: "Apartment",
                column: "BuildingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Apartment_Building_BuildingId",
                table: "Apartment",
                column: "BuildingId",
                principalTable: "Building",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apartment_Building_BuildingId",
                table: "Apartment");

            migrationBuilder.DropIndex(
                name: "IX_Apartment_BuildingId",
                table: "Apartment");

            migrationBuilder.DropColumn(
                name: "BuildingId",
                table: "Apartment");
        }
    }
}
