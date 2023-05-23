using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AspNetMvcRoles.Data.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cargo",
                columns: table => new
                {
                    IdCargo = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descricao = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cargo", x => x.IdCargo);
                });

            migrationBuilder.CreateTable(
                name: "Sedes_Empresa",
                columns: table => new
                {
                    IdSede = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descr_Sede = table.Column<string>(type: "varchar(50)", nullable: false),
                    Aluguel = table.Column<bool>(type: "INTEGER", nullable: false),
                    DataAbertura = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ValorDaSede = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sedes_Empresa", x => x.IdSede);
                });

            migrationBuilder.CreateTable(
                name: "Setores",
                columns: table => new
                {
                    IdSetor = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descricao = table.Column<string>(type: "TEXT", nullable: true),
                    IdSede = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Setores", x => x.IdSetor);
                    table.ForeignKey(
                        name: "FK_Setores_Sedes_Empresa_IdSede",
                        column: x => x.IdSede,
                        principalTable: "Sedes_Empresa",
                        principalColumn: "IdSede",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Funcionario",
                columns: table => new
                {
                    Matricula = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Endereco = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Telefone = table.Column<string>(type: "TEXT", nullable: false),
                    Admissao = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Salario = table.Column<float>(type: "REAL", nullable: false),
                    Gestor = table.Column<bool>(type: "INTEGER", nullable: false),
                    IdSetor = table.Column<int>(type: "INTEGER", nullable: false),
                    IdCargo = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionario", x => x.Matricula);
                    table.ForeignKey(
                        name: "FK_Funcionario_Cargo_IdCargo",
                        column: x => x.IdCargo,
                        principalTable: "Cargo",
                        principalColumn: "IdCargo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Funcionario_Setores_IdSetor",
                        column: x => x.IdSetor,
                        principalTable: "Setores",
                        principalColumn: "IdSetor",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Funcionario_IdCargo",
                table: "Funcionario",
                column: "IdCargo");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionario_IdSetor",
                table: "Funcionario",
                column: "IdSetor");

            migrationBuilder.CreateIndex(
                name: "IX_Setores_IdSede",
                table: "Setores",
                column: "IdSede");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Funcionario");

            migrationBuilder.DropTable(
                name: "Cargo");

            migrationBuilder.DropTable(
                name: "Setores");

            migrationBuilder.DropTable(
                name: "Sedes_Empresa");
        }
    }
}
