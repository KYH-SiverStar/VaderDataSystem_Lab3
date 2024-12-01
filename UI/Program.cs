


using Spectre.Console;
using Core.Models;
using Core.Services;
using UI.Views;
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        AnsiConsole.Markup("[bold yellow]Välkommen till VäderData-systemet![/]");

        // Ladda väderdata från CSV-filen
        var weatherData = WeatherProcessor.ReadCsv("TempFuktData.csv");

        while (true)
        {
            var option = MainMenu.Show(); // Visar huvudmenyn

            switch (option)
            {
                case "Visa Data":
                    ShowWeatherData(weatherData); // Visar väderdata
                    break;
                case "Beräkna Meteorologiska Säsonger":
                    CalculateSeasons(); // Beräknar meteorologiska säsonger
                    break;
                case "Beräkna Mödrisk":
                    CalculateMoldRisk(); // Beräknar mögelrisken
                    break;
                case "Beräkna Genomsnittstemperatur":
                    CalculateAverageTemperature(weatherData); // Beräknar genomsnittstemperatur
                    break;
                case "Sortera Data efter Temperatur":
                    ShowSortedData(WeatherProcessor.SortByTemperature(weatherData), "Temperatur"); // Sortera efter temperatur
                    break;
                case "Sortera Data efter Luftfuktighet":
                    ShowSortedData(WeatherProcessor.SortByHumidity(weatherData), "Luftfuktighet"); // Sortera efter luftfuktighet
                    break;
                case "Sortera Data efter Mödrisk":
                    ShowSortedData(WeatherProcessor.SortByMoldRisk(weatherData), "Mödrisk"); // Sortera efter mögelrisk
                    break;
                case "Avsluta":
                    return; // Stänger programmet
            }
        }
    }

    // Visa väderdata (temperatur, luftfuktighet och plats)
    static void ShowWeatherData(List<WeatherData> weatherData)
    {
        foreach (var data in weatherData)
        {
            AnsiConsole.Markup($"Data: {data.Date.ToString("d")}, Temp: {data.Temperature}°C, Luftfuktighet: {data.Humidity}%, Plats: {data.Location}\n");
        }
    }

    // Beräkna genomsnittlig temperatur och luftfuktighet för ett specifikt datum
    static void CalculateAverageTemperature(List<WeatherData> weatherData)
    {
        DateTime targetDate = DateTime.Now;  // Exempel: Dagens datum
        var averages = WeatherProcessor.CalculateDailyAverages(weatherData, targetDate);
        AnsiConsole.Markup($"Genomsnittlig Temperatur: {averages.avgTemp}°C, Genomsnittlig Luftfuktighet: {averages.avgHumidity}%\n");
    }

    // Visa de sorterade väderdata (temperatur, luftfuktighet eller mögelrisk)
    static void ShowSortedData(List<WeatherData> sortedData, string sortType)
    {
        // Dynamisk färginställning baserat på sorterings typ
        string color = sortType.ToLower() switch
        {
            "temperatur" => "yellow",  // För "Temperatur", använd gul
            "luftfuktighet" => "cyan", // För "Luftfuktighet", använd cyan
            "mödrisk" => "red",        // För "Mödrisk", använd röd
            _ => "white"                // För alla andra fall, använd vit
        };

        // Visa rubrik med rätt färg
        AnsiConsole.Markup($"[bold {color}]Data sorterade efter {sortType}:[/]\n");

        // Visa de sorterade data
        foreach (var data in sortedData)
        {
            AnsiConsole.Markup($"Data: {data.Date.ToString("d")}, Temp: {data.Temperature}°C, Luftfuktighet: {data.Humidity}%\n");
        }
    }

    // Beräkna meteorologiska säsonger baserat på temperatur
    static void CalculateSeasons()
    {
        DateTime today = DateTime.Now;
        float avgTemperature = 8.0f; // Exempel på genomsnittstemperatur
        float previousTemperature = 9.0f; // Exempel på temperatur från föregående dag

        if (MeteorologicalSeason.IsWinter(today, avgTemperature))
        {
            AnsiConsole.Markup("[bold red]Vinter![/]"); // Om det är vinter, visa röd
        }
        else if (MeteorologicalSeason.IsFall(today, avgTemperature, previousTemperature))
        {
            AnsiConsole.Markup("[bold yellow]Höst![/]"); // Om det är höst, visa gul
        }
        else
        {
            AnsiConsole.Markup("[bold green]Det är varken höst eller vinter![/]"); // Om det inte är höst eller vinter, visa grön
        }
    }

    // Beräkna mögelrisken baserat på temperatur och luftfuktighet
    static void CalculateMoldRisk()
    {
        float temperature = 7.0f;  // Exempel på temperatur
        float humidity = 80.0f;    // Exempel på luftfuktighet

        int risk = MoldIndexCalculator.CalculateMoldRisk(temperature, humidity);
        AnsiConsole.Markup($"[bold green]Mögelrisk: {risk}[/]");  // Visa mögelrisken med grön färg
    }
}
