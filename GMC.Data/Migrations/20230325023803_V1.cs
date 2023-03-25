using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GMC.Data.Migrations
{
    /// <inheritdoc />
    public partial class V1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LigneProduction",
                columns: table => new
                {
                    IdLigneProduction = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodeLigneProduction = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Etat = table.Column<int>(type: "int", nullable: false),
                    Observation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RobotTraitement = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateMaj = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Boucle = table.Column<int>(type: "int", nullable: false),
                    Forced = table.Column<int>(type: "int", nullable: false),
                    ProduitForced = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LigneProduction", x => x.IdLigneProduction);
                });

            migrationBuilder.CreateTable(
                name: "Produit",
                columns: table => new
                {
                    IdProduit = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodeProduit = table.Column<int>(type: "int", nullable: false),
                    Seuil = table.Column<int>(type: "int", nullable: false),
                    Etat = table.Column<int>(type: "int", nullable: false),
                    DateCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateMaj = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Designation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreerPar = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produit", x => x.IdProduit);
                });

            migrationBuilder.CreateTable(
                name: "RemoteUS",
                columns: table => new
                {
                    IdRemoteUS = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumPickList = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MAPA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OT = table.Column<int>(type: "int", nullable: false),
                    EtatCreate = table.Column<int>(type: "int", nullable: false),
                    EtatConfirm = table.Column<int>(type: "int", nullable: false),
                    DateCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateMaj = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Quantite = table.Column<int>(type: "int", nullable: false),
                    ProduitCode = table.Column<int>(type: "int", nullable: false),
                    Source = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RemoteUS", x => x.IdRemoteUS);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    IdStatus = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.IdStatus);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    IdUser = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.IdUser);
                });

            migrationBuilder.CreateTable(
                name: "PickList",
                columns: table => new
                {
                    IdPickList = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumPickList = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Magasin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateMaj = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TypePickList = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodeProduit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateLivraison = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateServi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NbUSServi = table.Column<int>(type: "int", nullable: false),
                    NbUSRecept = table.Column<int>(type: "int", nullable: false),
                    Observation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdCauseServi = table.Column<int>(type: "int", nullable: false),
                    PrintedServi = table.Column<int>(type: "int", nullable: false),
                    DemandeAnnulation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DemandeSuppPar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApprobSuppPar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateDemandeSuppression = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateApprobSuppression = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NbUSReceptCond = table.Column<int>(type: "int", nullable: false),
                    SetEmp = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LigneProductionId = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PickList", x => x.IdPickList);
                    table.ForeignKey(
                        name: "FK_PickList_LigneProduction_LigneProductionId",
                        column: x => x.LigneProductionId,
                        principalTable: "LigneProduction",
                        principalColumn: "IdLigneProduction",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PickList_Status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "IdStatus",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DetailPickList",
                columns: table => new
                {
                    IdPickDetail = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PickListId = table.Column<int>(type: "int", nullable: false),
                    ProduitId = table.Column<int>(type: "int", nullable: false),
                    Emplacement = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuantiteDemande = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    NombreUS = table.Column<int>(type: "int", nullable: false),
                    Skipped = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailPickList", x => x.IdPickDetail);
                    table.ForeignKey(
                        name: "FK_DetailPickList_PickList_PickListId",
                        column: x => x.PickListId,
                        principalTable: "PickList",
                        principalColumn: "IdPickList",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetailPickList_Produit_ProduitId",
                        column: x => x.ProduitId,
                        principalTable: "Produit",
                        principalColumn: "IdProduit",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetailPickList_Status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "IdStatus",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "USPickList",
                columns: table => new
                {
                    NumUS = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PickListId = table.Column<int>(type: "int", nullable: false),
                    Quantite = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    CodeProduit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateMaj = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Source = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationPar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MajPar = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USPickList", x => x.NumUS);
                    table.ForeignKey(
                        name: "FK_USPickList_PickList_PickListId",
                        column: x => x.PickListId,
                        principalTable: "PickList",
                        principalColumn: "IdPickList",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_USPickList_Status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "IdStatus",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InformationUS",
                columns: table => new
                {
                    IdInformationUS = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumUs = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CodeProduit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantite = table.Column<int>(type: "int", nullable: false),
                    StockSpecial = table.Column<int>(type: "int", nullable: false),
                    Fournisseur = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SAPMag = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Emplacement = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RefLotFRS = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCodeSAG = table.Column<int>(type: "int", nullable: false),
                    AvisArrivage = table.Column<int>(type: "int", nullable: false),
                    Fabricant = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodePart = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RefFabricant = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodeCoutStock = table.Column<int>(type: "int", nullable: false),
                    NumPieceFab = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InformationUS", x => x.IdInformationUS);
                    table.ForeignKey(
                        name: "FK_InformationUS_USPickList_NumUs",
                        column: x => x.NumUs,
                        principalTable: "USPickList",
                        principalColumn: "NumUS",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RemoteUSUSPickList",
                columns: table => new
                {
                    RemoteUSsIdRemoteUS = table.Column<int>(type: "int", nullable: false),
                    USPickListsNumUS = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RemoteUSUSPickList", x => new { x.RemoteUSsIdRemoteUS, x.USPickListsNumUS });
                    table.ForeignKey(
                        name: "FK_RemoteUSUSPickList_RemoteUS_RemoteUSsIdRemoteUS",
                        column: x => x.RemoteUSsIdRemoteUS,
                        principalTable: "RemoteUS",
                        principalColumn: "IdRemoteUS",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RemoteUSUSPickList_USPickList_USPickListsNumUS",
                        column: x => x.USPickListsNumUS,
                        principalTable: "USPickList",
                        principalColumn: "NumUS",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetailPickList_PickListId",
                table: "DetailPickList",
                column: "PickListId");

            migrationBuilder.CreateIndex(
                name: "IX_DetailPickList_ProduitId",
                table: "DetailPickList",
                column: "ProduitId");

            migrationBuilder.CreateIndex(
                name: "IX_DetailPickList_StatusId",
                table: "DetailPickList",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_InformationUS_NumUs",
                table: "InformationUS",
                column: "NumUs",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PickList_LigneProductionId",
                table: "PickList",
                column: "LigneProductionId");

            migrationBuilder.CreateIndex(
                name: "IX_PickList_StatusId",
                table: "PickList",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_RemoteUSUSPickList_USPickListsNumUS",
                table: "RemoteUSUSPickList",
                column: "USPickListsNumUS");

            migrationBuilder.CreateIndex(
                name: "IX_USPickList_NumUS",
                table: "USPickList",
                column: "NumUS",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_USPickList_PickListId",
                table: "USPickList",
                column: "PickListId");

            migrationBuilder.CreateIndex(
                name: "IX_USPickList_StatusId",
                table: "USPickList",
                column: "StatusId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetailPickList");

            migrationBuilder.DropTable(
                name: "InformationUS");

            migrationBuilder.DropTable(
                name: "RemoteUSUSPickList");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Produit");

            migrationBuilder.DropTable(
                name: "RemoteUS");

            migrationBuilder.DropTable(
                name: "USPickList");

            migrationBuilder.DropTable(
                name: "PickList");

            migrationBuilder.DropTable(
                name: "LigneProduction");

            migrationBuilder.DropTable(
                name: "Status");
        }
    }
}
