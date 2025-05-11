using Microsoft.EntityFrameworkCore;

namespace WebApi.Database
{
    public class GameDBContext(DbContextOptions<GameDBContext> options) : DbContext(options)
    {
        public DbSet<Game> Games => Set<Game>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Game>().HasData(
                new Game
                {
                    Id = 1,
                    Title = "Spider-Man",
                    Platform = "PS5",
                    Developer = "Insomniac Games",
                    Publisher = "Sony Interactive"
                },
                new Game
                {
                    Id = 2,
                    Title = "The Legen of Zelda",
                    Platform = "Nintenao Switch",
                    Developer = "Nintenao Games",
                    Publisher = "Nintenao"
                },
                new Game
                {
                    Id = 3,
                    Title = "Cyberpunk",
                    Platform = "PS5",
                    Developer = "CD Project Games",
                    Publisher = "CD Project"
                }
             );

        }
    }


}
