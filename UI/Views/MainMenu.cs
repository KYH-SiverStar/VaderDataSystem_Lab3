





using Spectre.Console;
using Core.Models;
using Core.Services;

namespace UI.Views
{
    public static class MainMenu
    {
        // Visar huvudmenyn och låter användaren välja ett alternativ
        public static string Show()
        {
            return AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("[bold yellow]Välj ett alternativ:[/]")  // Titel på menyn
                    .AddChoices(
                        "Visa Data",                         // Alternativ för att visa data
                        "Beräkna Meteorologiska Säsonger",    // Alternativ för att beräkna meteorologiska säsonger
                        "Beräkna Mödrisk",                   // Alternativ för att beräkna mögelrisk
                        "Beräkna Genomsnittstemperatur",      // Alternativ för att beräkna genomsnittstemperatur
                        "Sortera Data efter Temperatur",     // Alternativ för att sortera data efter temperatur
                        "Sortera Data efter Luftfuktighet",  // Alternativ för att sortera data efter luftfuktighet
                        "Sortera Data efter Mödrisk",       // Alternativ för att sortera data efter mögelrisk
                        "Avsluta"                            // Alternativ för att avsluta programmet
                    )
            );
        }
    }
}
