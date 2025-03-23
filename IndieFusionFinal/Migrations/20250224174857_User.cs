using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IndieFusionFinal.Migrations
{
    /// <inheritdoc />
    public partial class User : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"INSERT INTO [User] (Name, NickName, Email, Password, BirthDate, UserTp) VALUES 
 ('Juia', 'Juju', 'juia@email.com', 'jui123', '2006-10-03', 1),
 ('Momo', 'Mo', 'momo@email.com', 'mom123', '2001-09-11', 3),
 ('Geovana', 'Geo', 'geovana@email.com', 'geo123', '2006-10-15', 2),
 ('Atlas', 'Atl', 'atlas@email.com', 'atl123', '2001-07-28', 1),
 ('Minzon', 'Minz', 'minzon@email.com', 'min123', '2006-08-10', 3)");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
