using Microsoft.EntityFrameworkCore.Migrations;

namespace ApsNet.Data.Migrations
{
    public partial class AjusteModelo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Colaborador");

            migrationBuilder.CreateTable(
                name: "Funcionario",
                columns: table => new
                {
                    Matricula = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Gestor = table.Column<bool>(type: "INTEGER", nullable: false),
                    IdSetor = table.Column<int>(type: "INTEGER", nullable: false),
                    IdCargo = table.Column<int>(type: "INTEGER", nullable: false),
                    CargoRefId = table.Column<int>(type: "INTEGER", nullable: true),
                    SetorRefId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionario", x => x.Matricula);
                    table.ForeignKey(
                        name: "FK_Funcionario_Cargo_CargoRefId",
                        column: x => x.CargoRefId,
                        principalTable: "Cargo",
                        principalColumn: "IdCargo",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Funcionario_Cargo_IdCargo",
                        column: x => x.IdCargo,
                        principalTable: "Cargo",
                        principalColumn: "IdCargo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Funcionario_Setor_IdSetor",
                        column: x => x.IdSetor,
                        principalTable: "Setor",
                        principalColumn: "IdSetor",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Funcionario_Setor_SetorRefId",
                        column: x => x.SetorRefId,
                        principalTable: "Setor",
                        principalColumn: "IdSetor",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Funcionario_CargoRefId",
                table: "Funcionario",
                column: "CargoRefId");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionario_IdCargo",
                table: "Funcionario",
                column: "IdCargo");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionario_IdSetor",
                table: "Funcionario",
                column: "IdSetor");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionario_SetorRefId",
                table: "Funcionario",
                column: "SetorRefId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Funcionario");

            migrationBuilder.CreateTable(
                name: "Colaborador",
                columns: table => new
                {
                    Matricula = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CargoIdCargo = table.Column<int>(type: "INTEGER", nullable: true),
                    Gestor = table.Column<bool>(type: "INTEGER", nullable: false),
                    IdCargo = table.Column<int>(type: "INTEGER", nullable: false),
                    IdSetor = table.Column<int>(type: "INTEGER", nullable: false),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    SetorIdSetor = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colaborador", x => x.Matricula);
                    table.ForeignKey(
                        name: "FK_Colaborador_Cargo_CargoIdCargo",
                        column: x => x.CargoIdCargo,
                        principalTable: "Cargo",
                        principalColumn: "IdCargo",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Colaborador_Setor_SetorIdSetor",
                        column: x => x.SetorIdSetor,
                        principalTable: "Setor",
                        principalColumn: "IdSetor",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Colaborador_CargoIdCargo",
                table: "Colaborador",
                column: "CargoIdCargo");

            migrationBuilder.CreateIndex(
                name: "IX_Colaborador_SetorIdSetor",
                table: "Colaborador",
                column: "SetorIdSetor");
        }
    }
}
