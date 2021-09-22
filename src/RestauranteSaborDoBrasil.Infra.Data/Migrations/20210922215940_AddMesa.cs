using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RestauranteSaborDoBrasil.Infra.Data.Migrations
{
    public partial class AddMesa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Mesa",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Numero = table.Column<string>(type: "varchar(2)", nullable: false),
                    QuantidadeMax = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mesa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HistoricoMesa",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MesaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuantidadeOcupantes = table.Column<int>(type: "int", nullable: false),
                    DataAbertura = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataFechamento = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoricoMesa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HistoricoMesa_Mesa_MesaId",
                        column: x => x.MesaId,
                        principalTable: "Mesa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Mesa",
                columns: new[] { "Id", "Numero", "QuantidadeMax" },
                values: new object[,]
                {
                    { new Guid("8f32249b-0819-4272-8704-594511e24596"), "01", 6 },
                    { new Guid("1adb73e8-0a2d-403d-88cb-7f561e864f64"), "18", 6 },
                    { new Guid("9d8530bd-a89b-4a9b-9de4-d0576debd947"), "17", 6 },
                    { new Guid("8e668119-ef0f-46f7-bc1b-d428d30c1904"), "16", 6 },
                    { new Guid("d4cae3c4-2178-4f90-a2ac-623b3a322ebd"), "15", 6 },
                    { new Guid("e91a45d8-7224-48c3-a29b-84d46fdafb67"), "14", 6 },
                    { new Guid("9220a944-194d-4fab-a372-643bc01fb2a4"), "13", 6 },
                    { new Guid("7413ed05-521c-497e-8eba-7d8c83c7bfb7"), "12", 6 },
                    { new Guid("c169b985-cc94-4a56-81e7-25a57b74cdc2"), "11", 6 },
                    { new Guid("5edd16a3-3f19-4214-8986-a867fd76e5ff"), "10", 6 },
                    { new Guid("0ae6aa2e-064f-4b5e-bc1e-5468bfdcd5ed"), "09", 6 },
                    { new Guid("fe9ff411-2bf0-4424-9e3a-868732ad2140"), "08", 6 },
                    { new Guid("c316ae0e-2afc-44e2-8c16-86637a0e7bfc"), "07", 6 },
                    { new Guid("82f0a7b0-5d36-4f93-b558-210012960ecf"), "06", 6 },
                    { new Guid("4daa1d7b-2d3b-48e9-80fe-51ef7fdf6dcb"), "05", 6 },
                    { new Guid("2cdab575-5995-4bb8-a8ff-1fbf28c8247b"), "04", 6 },
                    { new Guid("a7a8f253-1fd0-441c-97a5-f9ad6aafd7ac"), "03", 6 },
                    { new Guid("19e3e924-771e-4a85-852c-b8d0eb787284"), "02", 6 },
                    { new Guid("9fb5adab-b100-49b3-8ab3-5b9d5656c21a"), "19", 6 },
                    { new Guid("b6b1ef31-dd14-4f53-b114-bbc08a75f648"), "20", 6 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_HistoricoMesa_MesaId",
                table: "HistoricoMesa",
                column: "MesaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HistoricoMesa");

            migrationBuilder.DropTable(
                name: "Mesa");
        }
    }
}
