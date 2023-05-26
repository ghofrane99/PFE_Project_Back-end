using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GMC.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddTableUS : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "US",
                columns: table => new
                {
                    NumUS = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CodeProduit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantite = table.Column<int>(type: "int", nullable: false),
                    RefLotFRS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCodeSAG = table.Column<int>(type: "int", nullable: false),
                    StockSpecial = table.Column<int>(type: "int", nullable: false),
                    SAPMag = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_US", x => x.NumUS);
                });

            migrationBuilder.CreateIndex(
                name: "IX_US_NumUS",
                table: "US",
                column: "NumUS",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "US");
        }
    }
}
