using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Livros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    Autor = table.Column<string>(type: "text", nullable: true),
                    Sinopse = table.Column<string>(type: "text", nullable: true),
                    AnoPublicacao = table.Column<int>(type: "integer", nullable: true),
                    DataInicioLeitura = table.Column<DateOnly>(type: "date", nullable: true),
                    DataFimLeitura = table.Column<DateOnly>(type: "date", nullable: true),
                    NumeroPaginas = table.Column<int>(type: "integer", nullable: true),
                    Categoria = table.Column<int>(type: "integer", nullable: false),
                    Avaliacao = table.Column<decimal>(type: "numeric(2,1)", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    Review = table.Column<string>(type: "text", nullable: true),
                    TipoLivro = table.Column<int>(type: "integer", nullable: false),
                    TipoFisico = table.Column<int>(type: "integer", nullable: true),
                    TipoDigital = table.Column<int>(type: "integer", nullable: true),
                    TipoAudio = table.Column<int>(type: "integer", nullable: true),
                    Valor = table.Column<decimal>(type: "numeric", nullable: false),
                    PlataformaCompra = table.Column<string>(type: "text", nullable: true),
                    Link = table.Column<string>(type: "text", nullable: true),
                    Favorito = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Livros", x => x.Id);
                });

            // Supabase: bloqueia acesso à tabela pela Data API pública (chave anon).
            // A API .NET conecta como "postgres" e não é afetada.
            migrationBuilder.Sql("ALTER TABLE \"Livros\" ENABLE ROW LEVEL SECURITY;");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Livros");
        }
    }
}
