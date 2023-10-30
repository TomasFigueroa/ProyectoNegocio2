using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Negocio.Bdata.Migrations
{
    /// <inheritdoc />
    public partial class inicalq1q29 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "dnipersona",
                table: "cuotas",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "dnipersona",
                table: "cuotas");
        }
    }
}
