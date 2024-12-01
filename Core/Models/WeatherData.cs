



namespace Core.Models
{
    public class WeatherData
    {
        // Användning av int för ID:
        // En int används här som en unik identifierare för varje väderpost. Datatypen int är tillräcklig för att hantera ett stort antal poster 
        // (upp till cirka 2 miljarder i positivt område), vilket gör den idealisk för en primärnyckel i en databas.
        public int Id { get; set; } // Unik identifierare för väderdata

        // Användning av DateTime för Datum:
        // DateTime är den mest lämpliga typen för att representera datum och tid. Det stöder exakta beräkningar, jämförelser och konverteringar.
        // Detta gör det enkelt att hantera sortering, filtrering och andra tidsbaserade operationer.
        public DateTime Date { get; set; } // Datum för väderrapporten

        // Användning av float för Temperatur:
        // Float används för att representera decimalvärden som temperatur. Float är en lättviktsdatatyp och erbjuder tillräcklig precision
        // för att hantera temperaturvärden som vanligtvis sträcker sig mellan -50°C och 50°C.
        // Om högre precision krävs (som för vetenskapliga beräkningar), kan double övervägas.
        public float Temperature { get; set; } // Temperatur i grader

        // Användning av float för Luftfuktighet:
        // Luftfuktighet anges ofta som en procentsats (0–100 %), vilket gör float till ett passande val. Den låga precisionen är tillräcklig
        // för att hantera de flesta scenarion där luftfuktighet används som en del av väderdata.
        public float Humidity { get; set; } // Luftfuktighet i procent

        // Användning av string för Plats:
        // Platsdata (t.ex. "Ute" eller "Inne") representeras bäst som en string eftersom det är en textuell kategori. 
        // Defaultvärdet är en tom sträng för att undvika null-referensfel.
        public string Location { get; set; } = string.Empty; // Plats, initialiserad med ett tomt värde

        // Kommentar om obligatoriska fält:
        // I C# 9.0+ kan "required"-modifieraren användas för att göra det obligatoriskt att ange "Location".
        // Detta säkerställer att ingen instans av WeatherData skapas utan att platsen anges.
        // public required string Location { get; set; }
    }
}




/*
 
 
Motivering:

Valet av datatyper är optimerat för att balansera prestanda, minnesanvändning och funktionalitet. 

*/