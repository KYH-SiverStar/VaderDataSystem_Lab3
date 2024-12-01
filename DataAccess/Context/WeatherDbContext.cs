




using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Context
{
    public class WeatherDbContext : DbContext
    {
        private const string ConnectionString = "Server=(localdb)\\MSSQLLocalDB;Database=VäderData;Trusted_Connection=True;";

        public DbSet<WeatherData> WeatherDatas { get; set; } = null!; // Lägger till standardinitialisering

        // Konfigurerar databasanslutningen och anger SQL Server som databas
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }

        // Här kan du lägga till extra konfigurationer, som tabellnamn eller relationer
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Här kan du lägga till anpassade konfigurationer för modellerna
        }
    }
}
