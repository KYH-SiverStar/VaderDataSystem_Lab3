




namespace Core.Models
{
    public class WeatherData
    {
        // Unikt ID för väderdata
        public int Id { get; set; }

        // Datumet för väderdata
        public DateTime Date { get; set; }

        // Temperaturvärde i grader
        public float Temperature { get; set; }

        // Luftfuktighet i procent
        public float Humidity { get; set; }

        // Plats för väderdata, t.ex. Ute (Exterior) eller Inne (Interior)
        public string Location { get; set; }
    }
}
