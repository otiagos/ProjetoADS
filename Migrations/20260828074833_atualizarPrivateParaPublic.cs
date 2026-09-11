using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gestao.Migrations
{
    /// <inheritdoc />
    public partial class atualizarPrivateParaPublic : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Raca",
                table: "Animal");

            migrationBuilder.AddColumn<int>(
                name: "IdRaca",
                table: "Animal",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RacaId",
                table: "Animal",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Raca",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DescricaoRaca = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Raca", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Animal_RacaId",
                table: "Animal",
                column: "RacaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Animal_Raca_RacaId",
                table: "Animal",
                column: "RacaId",
                principalTable: "Raca",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animal_Raca_RacaId",
                table: "Animal");

            migrationBuilder.DropTable(
                name: "Raca");

            migrationBuilder.DropIndex(
                name: "IX_Animal_RacaId",
                table: "Animal");

            migrationBuilder.DropColumn(
                name: "IdRaca",
                table: "Animal");

            migrationBuilder.DropColumn(
                name: "RacaId",
                table: "Animal");

            migrationBuilder.AddColumn<string>(
                name: "Raca",
                table: "Animal",
                type: "TEXT",
                nullable: true);
        }
    }
}
