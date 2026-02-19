using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreateTabelaLivros : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Livros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Autor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sinopse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnoPublicacao = table.Column<int>(type: "int", nullable: true),
                    DataInicioLeitura = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataFimLeitura = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NumeroPaginas = table.Column<int>(type: "int", nullable: true),
                    Categoria = table.Column<int>(type: "int", nullable: false),
                    Avaliacao = table.Column<decimal>(type: "decimal(2,1)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Review = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoLivro = table.Column<int>(type: "int", nullable: false),
                    TipoFisico = table.Column<int>(type: "int", nullable: true),
                    TipoDigital = table.Column<int>(type: "int", nullable: true),
                    TipoAudio = table.Column<int>(type: "int", nullable: true),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PlataformaCompra = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Favorito = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Livros", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Livros");
        }
    }
}
