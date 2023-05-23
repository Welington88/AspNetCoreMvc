using Microsoft.EntityFrameworkCore.Migrations;

namespace AspNetMvcRoles.Data.Migrations
{
    public partial class validacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cargo_Setores_SetoresIdSetor",
                table: "Cargo");

            migrationBuilder.DropIndex(
                name: "IX_Cargo_SetoresIdSetor",
                table: "Cargo");

            migrationBuilder.DropColumn(
                name: "SetoresIdSetor",
                table: "Cargo");

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Setores",
                type: "TEXT",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Salario",
                table: "Funcionario",
                type: "decimal(18, 2)",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "REAL");

            migrationBuilder.CreateIndex(
                name: "IX_Cargo_IdSetor",
                table: "Cargo",
                column: "IdSetor");

            migrationBuilder.AddForeignKey(
                name: "FK_Cargo_Setores_IdSetor",
                table: "Cargo",
                column: "IdSetor",
                principalTable: "Setores",
                principalColumn: "IdSetor",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cargo_Setores_IdSetor",
                table: "Cargo");

            migrationBuilder.DropIndex(
                name: "IX_Cargo_IdSetor",
                table: "Cargo");

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Setores",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<float>(
                name: "Salario",
                table: "Funcionario",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 2)");

            migrationBuilder.AddColumn<int>(
                name: "SetoresIdSetor",
                table: "Cargo",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cargo_SetoresIdSetor",
                table: "Cargo",
                column: "SetoresIdSetor");

            migrationBuilder.AddForeignKey(
                name: "FK_Cargo_Setores_SetoresIdSetor",
                table: "Cargo",
                column: "SetoresIdSetor",
                principalTable: "Setores",
                principalColumn: "IdSetor",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
