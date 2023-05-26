using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GMC.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddCreerParToPickList : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreerPar",
                table: "PickList",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreerPar",
                table: "PickList");
        }
    }
}
