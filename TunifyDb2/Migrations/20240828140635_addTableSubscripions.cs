using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TunifyDb2.Migrations
{
    /// <inheritdoc />
    public partial class addTableSubscripions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "subscripions",
                columns: table => new
                {
                    SubscripionsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubscripionsType = table.Column<string>(name: "Subscripions_Type", type: "nvarchar(max)", nullable: false),
                    Price = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subscripions", x => x.SubscripionsId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "subscripions");
        }
    }
}
