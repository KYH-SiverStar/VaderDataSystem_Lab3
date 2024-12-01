




namespace Core.Models
{
    public static class MoldIndexCalculator
    {
        // Metod för att beräkna risken för mögel.
        // Tar temperaturen och luftfuktigheten som parametrar.
        public static float CalculateMoldRisk(float temperature, float humidity)
        {
            // Fiktiv formel för att beräkna risken för mögel.
            return (temperature + humidity) / 2;
        }
    }
}
