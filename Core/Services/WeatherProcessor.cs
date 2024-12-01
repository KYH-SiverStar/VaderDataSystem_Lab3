




using Core.Models;
using System.Globalization;

namespace Core.Services
{
    public class WeatherProcessor
    {
        // Läs CSV-fil och konvertera data till en lista med WeatherData
        public static List<WeatherData> ReadCsv(string filePath)
        {
            var data = new List<WeatherData>();
            var lines = File.ReadAllLines(filePath);

            // Kontrollera om CSV-filen har tillräckligt många rader
            if (lines.Length < 2)
                throw new Exception("CSV-filen är tom eller saknar data.");

            foreach (var line in lines.Skip(1)) // Hoppa över header-raden
            {
                var fields = line.Split(',');

                // Kontrollera om antalet fält är förväntat
                if (fields.Length != 4)
                {
                    Console.WriteLine($"Ogiltig rad ignorerad: {line}");
                    continue;
                }

                // Försök att konvertera datum
                if (!DateTime.TryParse(fields[0], out var date))
                {
                    Console.WriteLine($"Konvertering av datum: {fields[0]}");
                    continue;
                }

                // Försök att konvertera temperatur
                if (!float.TryParse(fields[1], NumberStyles.Float, CultureInfo.InvariantCulture, out var temperature))
                {
                    Console.WriteLine($"Konvertering av temperatur: {fields[1]}");
                    continue;
                }

                // Försök att konvertera luftfuktighet
                if (!float.TryParse(fields[2], NumberStyles.Float, CultureInfo.InvariantCulture, out var humidity))
                {
                    Console.WriteLine($"Konvertering av luftfuktighet: {fields[2]}");
                    continue;
                }

                var location = fields[3]; // 'Ute' eller 'Inne'

                // Lägg till den bearbetade väderdatan i listan
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

        // Gruppera väderdata efter plats (t.ex. 'Ute' eller 'Inne')
        public static IEnumerable<IGrouping<string, WeatherData>> GroupByLocation(IEnumerable<WeatherData> weatherData)
        {
            return weatherData.GroupBy(w => w.Location);
        }
    }
}
