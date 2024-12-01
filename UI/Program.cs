




using Spectre.Console;
using Core.Services;
using DataAccess.Context;
using DataAccess.Repositories;

class Program
{
    static async Task Main()
    {
        var context = new WeatherDbContext();
        var repository = new WeatherRepository(context);

        // Välkomstmeddelande
        AnsiConsole.Markup("[bold yellow]Välkommen till VäderData Systemet![/]");
        var filePath = "TempFuktData.csv"; // Byt ut med sökvägen till din CSV-fil.

        // Läs och sätt in väderdata
        var weatherData = WeatherProcessor.ReadCsv(filePath);
        await repository.ClearWeatherDataAsync(); // Rensa gamla data
        await repository.AddWeatherDataAsync(weatherData); // Lägg till nya data

        // Visa data grupperade efter plats
        var allData = await repository.GetAllWeatherDataAsync();
        var groupedData = WeatherProcessor.GroupByLocation(allData);

        // Visa väderdata för varje grupp (t.ex. Ute eller Inne)
        foreach (var group in groupedData)
        {
            AnsiConsole.Markup($"[green]{group.Key}:[/]\n");
            foreach (var data in group)
            {
                AnsiConsole.Markup($"- [blue]{data.Date}[/]: {data.Temperature}°C, {data.Humidity}%\n");
            }
        }

        // Vänta på användarens input innan programmet stängs
        Console.ReadLine();
    }
}
