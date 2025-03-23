using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IndieFusionFinal.Migrations
{
    /// <inheritdoc />
    public partial class Game : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
    INSERT INTO Game (Title, Producer, price, Url, Classification_Id, Genre_Id, UserId)
VALUES 
('Mortal Kombat 11', 'NetherRealm Studios', 199.99, '~/img/mortal-kombat-11.jpg', 3, 1, 3), 
('Super Mario Odyssey', 'Nintendo', 299.99, '~/img/super-mario-odyssey.jpg', 1, 2, 5), 
('Forza Horizon 5', 'Playground Games', 249.99, '~/img/forza-horizon-5.jpg', 1, 3, 3),
('Resident Evil 2', 'Capcom', 159.99, '~/img/resident-evil-2.jpg', 3, 4, 3),
('Call of Duty: Modern Warfare II', 'Infinity Ward', 279.99, '~/img/call-of-duty-mw2.jpg', 3, 5, 5),
('The Legend of Zelda: Breath of the Wild', 'Nintendo', 349.99, '~/img/zelda-breath-of-the-wild.jpg', 1, 6, 3),
('Grand Theft Auto V', 'Rockstar Games', 99.99, '~/img/gta-v.jpg', 3, 7, 3),
('Elden Ring', 'FromSoftware', 299.99, '~/img/elden-ring.jpg', 3, 8, 5);

");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
