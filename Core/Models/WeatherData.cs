




namespace Core.Models
{
    public class WeatherData
    {
        public int Id { get; set; } // Unik identifierare för väderdata
        public DateTime Date { get; set; } // Datum för väderrapporten
        public float Temperature { get; set; } // Temperatur i grader
        public float Humidity { get; set; } // Luftfuktighet i procent
        public string Location { get; set; } = string.Empty; // Plats, initialiserad med ett tomt värde (om nödvändigt)

        // För att säkerställa att Location är obligatorisk, kan vi använda modifieraren 'required' i C# 9.0 eller högre
        // public required string Location { get; set; } 
    }
}
