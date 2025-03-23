using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IndieFusionFinal.Migrations
{
    /// <inheritdoc />
    public partial class Classification : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Classification (Description) VALUES ('Free'),('+12'),('+18')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
