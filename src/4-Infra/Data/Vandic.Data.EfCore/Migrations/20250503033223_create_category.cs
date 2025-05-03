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
            migrationBuilder.CreateTable(
                name: "category",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Chave primária"),
                    name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    name_menu = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    category_root_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    alternative_id = table.Column<int>(type: "int", nullable: false, comment: "Auto Incremento")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false, comment: "Nome do Usuario que criou o registro"),
                    modified_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true, comment: "Nome do ultimo usuário que modificou registro"),
                    deleted_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true, comment: "nome do usuário que excluiu o registro"),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: false, comment: "data de criação do registro (criado em)"),
                    modified_at = table.Column<DateTime>(type: "datetime", nullable: true, comment: "data da modificação"),
                    deleted_at = table.Column<DateTime>(type: "datetime", nullable: true, comment: "data da exclusao")
                },
                constraints: table =>
                {
                    table.PrimaryKey("category_id_pk", x => x.id);
                    table.ForeignKey(
                        name: "category_category_fk",
                        column: x => x.category_root_id,
                        principalTable: "category",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "category_category_root_id_idx",
                table: "category",
                column: "category_root_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "category");
        }
    }
}
