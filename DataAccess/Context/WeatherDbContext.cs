





using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Context
{
    public class WeatherDbContext : DbContext
    {
        // Anslutningssträng för databasen
        private const string ConnectionString = "Server=(localdb)\\MSSQLLocalDB;Database=VäderData;Trusted_Connection=True;";

        // Konfigurera databaskopplingen och ange SQL Server som databas
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }

        // DbSet för att lagra väderdata i databasen
        public DbSet<WeatherData> WeatherDatas { get; set; }
    }
}
