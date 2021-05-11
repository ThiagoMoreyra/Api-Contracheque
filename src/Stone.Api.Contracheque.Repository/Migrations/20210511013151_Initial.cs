using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Stone.Api.Contracheque.Repository.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbFuncionario",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    SobreNome = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    CPF = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    Setor = table.Column<string>(type: "varchar(50)", nullable: false),
                    SalarioBruto = table.Column<decimal>(type: "decimal", nullable: false),
                    DataDeAdmissao = table.Column<DateTime>(type: "datetime", nullable: false),
                    PossuiDescontoPlanoDeSaude = table.Column<bool>(type: "bit", nullable: false),
                    PossuiDescontoPlanoDental = table.Column<bool>(type: "bit", nullable: false),
                    PossuiDescontoValeTransporte = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbFuncionario", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbFuncionario");
        }
    }
}
