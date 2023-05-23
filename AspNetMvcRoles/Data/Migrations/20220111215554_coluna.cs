using Microsoft.EntityFrameworkCore.Migrations;

namespace AspNetMvcRoles.Data.Migrations
{
    public partial class coluna : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdSetor",
                table: "Cargo",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cargo_Setores_SetoresIdSetor",
                table: "Cargo");

            migrationBuilder.DropIndex(
                name: "IX_Cargo_SetoresIdSetor",
                table: "Cargo");

            migrationBuilder.DropColumn(
                name: "IdSetor",
                table: "Cargo");

            migrationBuilder.DropColumn(
                name: "SetoresIdSetor",
                table: "Cargo");
        }
    }
}
