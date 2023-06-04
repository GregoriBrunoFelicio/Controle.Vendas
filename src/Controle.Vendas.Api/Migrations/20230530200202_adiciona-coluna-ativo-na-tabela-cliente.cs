using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Controle.Vendas.Api.Migrations
{
    public partial class adicionacolunaativonatabelacliente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Ativo",
                table: "Cliente",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ativo",
                table: "Cliente");
        }
    }
}
