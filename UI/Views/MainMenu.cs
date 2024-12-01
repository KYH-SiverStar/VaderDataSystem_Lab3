




using Spectre.Console;

namespace UI.Views
{
    public static class MainMenu
    {
        // Visar huvudmenyn och låter användaren välja ett alternativ
        public static string Show()
        {
            return AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("[bold yellow]Välj ett alternativ:[/]")  // Titel för prompten
                    .AddChoices("Visa data", "Avsluta"));  // Alternativ som användaren kan välja
        }
    }
}
