using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Negocio.Bdata.Migrations
{
    /// <inheritdoc />
    public partial class inicalq1q : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "personas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DNI = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_personas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ventas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Saldo_Total = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Idpersona = table.Column<int>(type: "int", nullable: false),
                    PersonasId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ventas", x => x.id);
                    table.ForeignKey(
                        name: "FK_ventas_personas_PersonasId",
                        column: x => x.PersonasId,
                        principalTable: "personas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "cuotas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    total = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Numero_cuotas = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    Idventa = table.Column<int>(type: "int", nullable: false),
                    Ventaid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cuotas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_cuotas_ventas_Ventaid",
                        column: x => x.Ventaid,
                        principalTable: "ventas",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_cuotas_Ventaid",
                table: "cuotas",
                column: "Ventaid");

            migrationBuilder.CreateIndex(
                name: "Persona_DNI_UQ",
                table: "personas",
                column: "DNI",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ventas_PersonasId",
                table: "ventas",
                column: "PersonasId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cuotas");

            migrationBuilder.DropTable(
                name: "ventas");

            migrationBuilder.DropTable(
                name: "personas");
        }
    }
}
