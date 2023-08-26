using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Negocio.Bdata.Migrations
{
    /// <inheritdoc />
    public partial class final : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Saldo",
                table: "cuentas",
                newName: "SaldoTotal");

            migrationBuilder.CreateTable(
                name: "saldos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Idsaldo = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    SaldoF = table.Column<int>(type: "int", maxLength: 20, nullable: false),
                    SaldoR = table.Column<int>(type: "int", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_saldos", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "Cuenta_Idcuenta_UQ",
                table: "saldos",
                column: "Idsaldo",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "saldos");

            migrationBuilder.RenameColumn(
                name: "SaldoTotal",
                table: "cuentas",
                newName: "Saldo");
        }
    }
}
