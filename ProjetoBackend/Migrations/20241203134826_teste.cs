using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoBackend.Migrations
{
    /// <inheritdoc />
    public partial class teste : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Compras_Fornecedores_FornecedorId1",
                table: "Compras");

            migrationBuilder.DropTable(
                name: "ServicosVendas");

            migrationBuilder.DropTable(
                name: "Servicos");

            migrationBuilder.DropIndex(
                name: "IX_Compras_FornecedorId1",
                table: "Compras");

            migrationBuilder.DropColumn(
                name: "FornecedorId1",
                table: "Compras");

            migrationBuilder.AlterColumn<int>(
                name: "FornecedorId",
                table: "Compras",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_Compras_FornecedorId",
                table: "Compras",
                column: "FornecedorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Compras_Fornecedores_FornecedorId",
                table: "Compras",
                column: "FornecedorId",
                principalTable: "Fornecedores",
                principalColumn: "FornecedorId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Compras_Fornecedores_FornecedorId",
                table: "Compras");

            migrationBuilder.DropIndex(
                name: "IX_Compras_FornecedorId",
                table: "Compras");

            migrationBuilder.AlterColumn<Guid>(
                name: "FornecedorId",
                table: "Compras",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "FornecedorId1",
                table: "Compras",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Servicos",
                columns: table => new
                {
                    ServicoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ValorServico = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicos", x => x.ServicoId);
                });

            migrationBuilder.CreateTable(
                name: "ServicosVendas",
                columns: table => new
                {
                    ServicoVendaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServicoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VendaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicosVendas", x => x.ServicoVendaId);
                    table.ForeignKey(
                        name: "FK_ServicosVendas_Servicos_ServicoId",
                        column: x => x.ServicoId,
                        principalTable: "Servicos",
                        principalColumn: "ServicoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServicosVendas_Vendas_VendaId",
                        column: x => x.VendaId,
                        principalTable: "Vendas",
                        principalColumn: "VendaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Compras_FornecedorId1",
                table: "Compras",
                column: "FornecedorId1");

            migrationBuilder.CreateIndex(
                name: "IX_ServicosVendas_ServicoId",
                table: "ServicosVendas",
                column: "ServicoId");

            migrationBuilder.CreateIndex(
                name: "IX_ServicosVendas_VendaId",
                table: "ServicosVendas",
                column: "VendaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Compras_Fornecedores_FornecedorId1",
                table: "Compras",
                column: "FornecedorId1",
                principalTable: "Fornecedores",
                principalColumn: "FornecedorId");
        }
    }
}
