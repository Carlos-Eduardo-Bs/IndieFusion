using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IndieFusionFinal.Migrations
{
    /// <inheritdoc />
    public partial class UserType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO UserType (Description) VALUES ('Administrador'), ('Game Maker'), ('Usuario')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
