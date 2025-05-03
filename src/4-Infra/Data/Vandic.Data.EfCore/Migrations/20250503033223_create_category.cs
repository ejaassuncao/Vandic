using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vandic.Data.EfCore.Migrations
{
    /// <inheritdoc />
    public partial class create_category : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // QUANDO FOR VIA SCAFFOLDING,  LIMPAR OS ITENS NÃO NÃO RECRIAR A TABELA
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "category");
        }
    }
}
