using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IndieFusionFinal.Migrations
{
    /// <inheritdoc />
    public partial class Genre : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Genre (Description) VALUES ('Luta'), ('Plataforma'), ('Corrida'), ('Terror'), ('FPS'), ('Aventura'), ('Ação'), ('RPG')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
