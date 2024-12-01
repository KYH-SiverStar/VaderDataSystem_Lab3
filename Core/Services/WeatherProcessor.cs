




using Core.Models;
using System.Globalization;

namespace Core.Services
{
    public class WeatherProcessor
    {
        // Metod för att läsa data från en CSV-fil och konvertera den till en lista av WeatherData-objekt
        public static List<WeatherData> ReadCsv(string filePath)
        {
            var data = new List<WeatherData>();
            var lines = File.ReadAllLines(filePath);

            if (lines.Length < 2)
                throw new Exception("CSV-filen är tom eller saknar data.");

            foreach (var line in lines.Skip(1)) // Hoppa över rubriken
            {
                var fields = line.Split(',');

                if (fields.Length != 4)
                {
                    Console.WriteLine($"Ogiltig rad ignorerad: {line}");
                    continue;
                }

                if (!DateTime.TryParse(fields[0], out var date))
                {
                    Console.WriteLine($"Konvertering av datum: {fields[0]}");
                    continue;
                }

                if (!float.TryParse(fields[1], NumberStyles.Float, CultureInfo.InvariantCulture, out var temperature))
                {
                    Console.WriteLine($"Konvertering av temperatur: {fields[1]}");
                    continue;
                }

                if (!float.TryParse(fields[2], NumberStyles.Float, CultureInfo.InvariantCulture, out var humidity))
                {
                    Console.WriteLine($"Konvertering av luftfuktighet: {fields[2]}");
                    continue;
                }

                var location = fields[3];

                data.Add(new WeatherData
                {
                    Date = date,
                    Temperature = temperature,
                    Humidity = humidity,
                    Location = location
                });
            }

            return data;
        }

        // Aggregering av data för att beräkna medeltemperatur och medelhygien för ett specifikt datum
        public static (float avgTemp, float avgHumidity) CalculateDailyAverages(List<WeatherData> weatherData, DateTime targetDate)
        {
            var dailyData = weatherData.Where(w => w.Date.Date == targetDate.Date).ToList();

            // Kontrollera om det finns data för det valda datumet
            if (!dailyData.Any())
            {
                Console.WriteLine("Inga data hittades för det valda datumet.");
                return (0f, 0f); // Eller kasta ett anpassat undantag om det behövs
            }

            var avgTemp = dailyData.Average(w => w.Temperature);
            var avgHumidity = dailyData.Average(w => w.Humidity);

            return (avgTemp, avgHumidity);
        }

        // Sortering av väderdata efter temperatur (från varmaste till kallaste)
        public static List<WeatherData> SortByTemperature(List<WeatherData> weatherData)
        {
            return weatherData.OrderByDescending(w => w.Temperature).ToList();
        }

        // Sortering av väderdata efter luftfuktighet (från torraste till fuktigaste)
        public static List<WeatherData> SortByHumidity(List<WeatherData> weatherData)
        {
            return weatherData.OrderByDescending(w => w.Humidity).ToList();
        }

        // Sortering av väderdata efter mögelrisksnivå (från lägre till högre risk)
        public static List<WeatherData> SortByMoldRisk(List<WeatherData> weatherData)
        {
            return weatherData.OrderBy(w => MoldIndexCalculator.CalculateMoldRisk(w.Temperature, w.Humidity)).ToList();
        }
    }
}
