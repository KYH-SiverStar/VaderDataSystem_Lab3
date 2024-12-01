




public class MeteorologicalSeason
{
    // Funktion för att kontrollera om datumet motsvarar vinter (genomsnittstemperatur <= 0°C)
    public static bool IsWinter(DateTime date, float dailyAverageTemperature)
    {
        // Om den genomsnittliga dagstemperaturen är 0°C eller lägre, är det vinter.
        return dailyAverageTemperature <= 0.0f;
    }

    // Funktion för att kontrollera om datumet motsvarar höst (genomsnittstemperatur mellan 0°C och 10°C, och temperatur minskar)
    public static bool IsFall(DateTime date, float dailyAverageTemperature, float previousDayTemperature)
    {
        // Om den genomsnittliga dagstemperaturen är mellan 0°C och 10°C och sjunker, är det höst.
        return dailyAverageTemperature < 10.0f && dailyAverageTemperature > 0.0f && previousDayTemperature > dailyAverageTemperature;
    }
}
