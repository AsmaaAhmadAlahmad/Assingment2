using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assingment2_Data.Migrations
{
    /// <inheritdoc />
    public partial class AddSalesCarRelationship_One2One : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CarId",
                table: "Sales",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Sales_CarId",
                table: "Sales",
                column: "CarId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_Cars_CarId",
                table: "Sales",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sales_Cars_CarId",
                table: "Sales");

            migrationBuilder.DropIndex(
                name: "IX_Sales_CarId",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "CarId",
                table: "Sales");
        }
    }
}
