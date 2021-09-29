using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RestauranteSaborDoBrasil.Infra.Data.Migrations
{
    public partial class AddControleEstoque : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ItemComandaId",
                table: "MovimentacaoEstoque",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ItemNotaId",
                table: "MovimentacaoEstoque",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataFechamento",
                table: "HistoricoMesa",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.CreateTable(
                name: "Comanda",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResponsavelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataEmissao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comanda", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fornecedor",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RazaoSocial = table.Column<string>(type: "varchar(200)", nullable: false),
                    NomeFantassia = table.Column<string>(type: "varchar(200)", nullable: false),
                    Cnpj = table.Column<string>(type: "varchar(14)", nullable: true),
                    InscricaoEstadual = table.Column<string>(type: "varchar(20)", nullable: true),
                    InscricaoMunicipal = table.Column<string>(type: "varchar(20)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fornecedor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ComandaMesa",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MesaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ComandaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComandaMesa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComandaMesa_Comanda_ComandaId",
                        column: x => x.ComandaId,
                        principalTable: "Comanda",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComandaMesa_Mesa_MesaId",
                        column: x => x.MesaId,
                        principalTable: "Mesa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemComanda",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ComandaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PratoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    Valor = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemComanda", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemComanda_Comanda_ComandaId",
                        column: x => x.ComandaId,
                        principalTable: "Comanda",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemComanda_Prato_PratoId",
                        column: x => x.PratoId,
                        principalTable: "Prato",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NotaEntrada",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FornecedorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Numero = table.Column<string>(type: "varchar(50)", nullable: false),
                    DataEmissao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataEntrada = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotaEntrada", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NotaEntrada_Fornecedor_FornecedorId",
                        column: x => x.FornecedorId,
                        principalTable: "Fornecedor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemNotaEntrada",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NotaEntradaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IngredienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantidade = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemNotaEntrada", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemNotaEntrada_Ingrediente_IngredienteId",
                        column: x => x.IngredienteId,
                        principalTable: "Ingrediente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemNotaEntrada_NotaEntrada_NotaEntradaId",
                        column: x => x.NotaEntradaId,
                        principalTable: "NotaEntrada",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovimentacaoEstoque_ItemComandaId",
                table: "MovimentacaoEstoque",
                column: "ItemComandaId",
                unique: true,
                filter: "[ItemComandaId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_MovimentacaoEstoque_ItemNotaId",
                table: "MovimentacaoEstoque",
                column: "ItemNotaId",
                unique: true,
                filter: "[ItemNotaId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ComandaMesa_ComandaId",
                table: "ComandaMesa",
                column: "ComandaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ComandaMesa_MesaId",
                table: "ComandaMesa",
                column: "MesaId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemComanda_ComandaId",
                table: "ItemComanda",
                column: "ComandaId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemComanda_PratoId",
                table: "ItemComanda",
                column: "PratoId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemNotaEntrada_IngredienteId",
                table: "ItemNotaEntrada",
                column: "IngredienteId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemNotaEntrada_NotaEntradaId",
                table: "ItemNotaEntrada",
                column: "NotaEntradaId");

            migrationBuilder.CreateIndex(
                name: "IX_NotaEntrada_FornecedorId",
                table: "NotaEntrada",
                column: "FornecedorId");

            migrationBuilder.AddForeignKey(
                name: "FK_MovimentacaoEstoque_ItemComanda_ItemComandaId",
                table: "MovimentacaoEstoque",
                column: "ItemComandaId",
                principalTable: "ItemComanda",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MovimentacaoEstoque_ItemNotaEntrada_ItemNotaId",
                table: "MovimentacaoEstoque",
                column: "ItemNotaId",
                principalTable: "ItemNotaEntrada",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovimentacaoEstoque_ItemComanda_ItemComandaId",
                table: "MovimentacaoEstoque");

            migrationBuilder.DropForeignKey(
                name: "FK_MovimentacaoEstoque_ItemNotaEntrada_ItemNotaId",
                table: "MovimentacaoEstoque");

            migrationBuilder.DropTable(
                name: "ComandaMesa");

            migrationBuilder.DropTable(
                name: "ItemComanda");

            migrationBuilder.DropTable(
                name: "ItemNotaEntrada");

            migrationBuilder.DropTable(
                name: "Comanda");

            migrationBuilder.DropTable(
                name: "NotaEntrada");

            migrationBuilder.DropTable(
                name: "Fornecedor");

            migrationBuilder.DropIndex(
                name: "IX_MovimentacaoEstoque_ItemComandaId",
                table: "MovimentacaoEstoque");

            migrationBuilder.DropIndex(
                name: "IX_MovimentacaoEstoque_ItemNotaId",
                table: "MovimentacaoEstoque");

            migrationBuilder.DropColumn(
                name: "ItemComandaId",
                table: "MovimentacaoEstoque");

            migrationBuilder.DropColumn(
                name: "ItemNotaId",
                table: "MovimentacaoEstoque");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataFechamento",
                table: "HistoricoMesa",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);
        }
    }
}
