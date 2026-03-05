using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eVote360.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddPartidoCandidatoEleccion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Candidatos_Puestos_PuestoId",
                table: "Candidatos");

            migrationBuilder.DropColumn(
                name: "FechaFin",
                table: "Elecciones");

            migrationBuilder.DropColumn(
                name: "Titulo",
                table: "Elecciones");

            migrationBuilder.RenameColumn(
                name: "FechaInicio",
                table: "Elecciones",
                newName: "Fecha");

            migrationBuilder.AlterColumn<string>(
                name: "Siglas",
                table: "Partidos",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Partidos",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "LogoUrl",
                table: "Partidos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                table: "Elecciones",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "Elecciones",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<Guid>(
                name: "PuestoId",
                table: "Candidatos",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "NombreCompleto",
                table: "Candidatos",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Cargo",
                table: "Candidatos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Candidatos_Puestos_PuestoId",
                table: "Candidatos",
                column: "PuestoId",
                principalTable: "Puestos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Candidatos_Puestos_PuestoId",
                table: "Candidatos");

            migrationBuilder.DropColumn(
                name: "Descripcion",
                table: "Elecciones");

            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "Elecciones");

            migrationBuilder.DropColumn(
                name: "Cargo",
                table: "Candidatos");

            migrationBuilder.RenameColumn(
                name: "Fecha",
                table: "Elecciones",
                newName: "FechaInicio");

            migrationBuilder.AlterColumn<string>(
                name: "Siglas",
                table: "Partidos",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Partidos",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "LogoUrl",
                table: "Partidos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaFin",
                table: "Elecciones",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Titulo",
                table: "Elecciones",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<Guid>(
                name: "PuestoId",
                table: "Candidatos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NombreCompleto",
                table: "Candidatos",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddForeignKey(
                name: "FK_Candidatos_Puestos_PuestoId",
                table: "Candidatos",
                column: "PuestoId",
                principalTable: "Puestos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
