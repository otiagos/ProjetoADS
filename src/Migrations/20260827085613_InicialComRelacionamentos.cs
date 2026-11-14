using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gestao.Migrations
{
    /// <inheritdoc />
    public partial class InicialComRelacionamentos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Gato",
                table: "Gato");

            migrationBuilder.RenameTable(
                name: "Gato",
                newName: "Animal");

            migrationBuilder.AlterColumn<int>(
                name: "Idade",
                table: "Animal",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataNascimento",
                table: "Animal",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Animal",
                type: "TEXT",
                maxLength: 8,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "IdTutor",
                table: "Animal",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Animal",
                table: "Animal",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Tutor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CpfTutor = table.Column<string>(type: "TEXT", nullable: false),
                    Telefone = table.Column<string>(type: "TEXT", nullable: false),
                    Endereco = table.Column<string>(type: "TEXT", nullable: true),
                    DataNascimento = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Nome = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tutor", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Animal_IdTutor",
                table: "Animal",
                column: "IdTutor");

            migrationBuilder.AddForeignKey(
                name: "FK_Animal_Tutor_IdTutor",
                table: "Animal",
                column: "IdTutor",
                principalTable: "Tutor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animal_Tutor_IdTutor",
                table: "Animal");

            migrationBuilder.DropTable(
                name: "Tutor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Animal",
                table: "Animal");

            migrationBuilder.DropIndex(
                name: "IX_Animal_IdTutor",
                table: "Animal");

            migrationBuilder.DropColumn(
                name: "DataNascimento",
                table: "Animal");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Animal");

            migrationBuilder.DropColumn(
                name: "IdTutor",
                table: "Animal");

            migrationBuilder.RenameTable(
                name: "Animal",
                newName: "Gato");

            migrationBuilder.AlterColumn<int>(
                name: "Idade",
                table: "Gato",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Gato",
                table: "Gato",
                column: "Id");
        }
    }
}
