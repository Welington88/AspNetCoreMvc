using Microsoft.EntityFrameworkCore.Migrations;

namespace ApsNet.Data.Migrations
{
    public partial class AlteracaoId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "Setor",
                newName: "IdSetor");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Cargo",
                newName: "IdCargo");

            migrationBuilder.CreateTable(
                name: "Colaborador",
                columns: table => new
                {
                    Matricula = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Gestor = table.Column<bool>(type: "INTEGER", nullable: false),
                    IdSetor = table.Column<int>(type: "INTEGER", nullable: false),
                    IdCargo = table.Column<int>(type: "INTEGER", nullable: false),
                    SetorIdSetor = table.Column<int>(type: "INTEGER", nullable: true),
                    CargoIdCargo = table.Column<int>(type: "INTEGER", nullable: true)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Colaborador");

            migrationBuilder.RenameColumn(
                name: "IdSetor",
                table: "Setor",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "IdCargo",
                table: "Cargo",
                newName: "Id");
        }
    }
}
