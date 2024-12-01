



using Core.Models;
using DataAccess.Context;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class WeatherRepository
    {
        // DbContext för att interagera med databasen
        private readonly WeatherDbContext _context;

        // Konstruktor som tar emot en WeatherDbContext
        public WeatherRepository(WeatherDbContext context)
        {
            _context = context;
        }

        // Asynkron metod för att lägga till väderdata i databasen
        public async Task AddWeatherDataAsync(IEnumerable<WeatherData> weatherData)
        {
            await _context.WeatherDatas.AddRangeAsync(weatherData);
            await _context.SaveChangesAsync();
        }

        // Asynkron metod för att hämta alla väderdata från databasen
        public async Task<List<WeatherData>> GetAllWeatherDataAsync()
        {
            return await _context.WeatherDatas.ToListAsync();
        }

        // Asynkron metod för att rensa alla väderdata från databasen
        public async Task ClearWeatherDataAsync()
        {
            _context.WeatherDatas.RemoveRange(_context.WeatherDatas);
            await _context.SaveChangesAsync();
        }
    }
}
