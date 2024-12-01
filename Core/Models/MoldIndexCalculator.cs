


/* 
Motivering för val av algoritm:

Matris som datastruktur:
2D-array är ett snabbt sätt att slå upp kombinationer av temperatur och luftfuktighet. 
Alternativ som en hashtabell eller lista skulle ha introducerat mer komplexitet.

Avrundning:
Temperatur och luftfuktighet avrundas för att garantera att värden passar matrisens format.

*/




public class MoldIndexCalculator
{
    // Beräknar mögelrisken baserat på temperatur och luftfuktighet
    // En matris (mtab) används för att definiera möjliga risknivåer beroende på dessa två parametrar.

    public static int CalculateMoldRisk(float temperature, float humidity)
    {
        // Rundar temperaturen och fuktigheten till närmaste heltal
        int rtemp = (int)Math.Round(temperature);
        int rhum = (int)Math.Round(humidity);

        // Initialiserar tabellen mtab med 51 rader och 4 kolumner
        int[,] mtab = new int[51, 4];

        // Fyller tabellen med fördefinierade värden för olika temperatur- och fuktighetsnivåer
        mtab[1, 1] = 97; mtab[1, 2] = 98; mtab[1, 3] = 100;
        mtab[2, 1] = 95; mtab[2, 2] = 97; mtab[2, 3] = 100;
        mtab[3, 1] = 93; mtab[3, 2] = 95; mtab[3, 3] = 100;
        mtab[4, 1] = 91; mtab[4, 2] = 93; mtab[4, 3] = 98;
        mtab[5, 1] = 88; mtab[5, 2] = 92; mtab[5, 3] = 97;
        mtab[6, 1] = 87; mtab[6, 2] = 91; mtab[6, 3] = 96;
        mtab[7, 1] = 86; mtab[7, 2] = 91; mtab[7, 3] = 95;
        mtab[8, 1] = 84; mtab[8, 2] = 90; mtab[8, 3] = 95;
        mtab[9, 1] = 83; mtab[9, 2] = 89; mtab[9, 3] = 94;
        mtab[10, 1] = 82; mtab[10, 2] = 88; mtab[10, 3] = 93;
        mtab[11, 1] = 81; mtab[11, 2] = 88; mtab[11, 3] = 93;
        mtab[12, 1] = 81; mtab[12, 2] = 88; mtab[12, 3] = 92;
        mtab[13, 1] = 80; mtab[13, 2] = 87; mtab[13, 3] = 92;
        mtab[14, 1] = 79; mtab[14, 2] = 87; mtab[14, 3] = 92;
        mtab[15, 1] = 79; mtab[15, 2] = 87; mtab[15, 3] = 91;
        mtab[16, 1] = 79; mtab[16, 2] = 86; mtab[16, 3] = 91;
        mtab[17, 1] = 79; mtab[17, 2] = 86; mtab[17, 3] = 91;
        mtab[18, 1] = 79; mtab[18, 2] = 86; mtab[18, 3] = 90;
        mtab[19, 1] = 79; mtab[19, 2] = 85; mtab[19, 3] = 90;
        mtab[20, 1] = 79; mtab[20, 2] = 85; mtab[20, 3] = 90;
        mtab[21, 1] = 79; mtab[21, 2] = 85; mtab[21, 3] = 90;
        mtab[22, 1] = 79; mtab[22, 2] = 85; mtab[22, 3] = 89;
        mtab[23, 1] = 79; mtab[23, 2] = 84; mtab[23, 3] = 89;
        mtab[24, 1] = 79; mtab[24, 2] = 84; mtab[24, 3] = 89;
        mtab[25, 1] = 79; mtab[25, 2] = 84; mtab[25, 3] = 89;
        mtab[26, 1] = 79; mtab[26, 2] = 84; mtab[26, 3] = 89;
        mtab[27, 1] = 79; mtab[27, 2] = 83; mtab[27, 3] = 88;
        mtab[28, 1] = 79; mtab[28, 2] = 83; mtab[28, 3] = 88;
        mtab[29, 1] = 79; mtab[29, 2] = 83; mtab[29, 3] = 88;
        mtab[30, 1] = 79; mtab[30, 2] = 83; mtab[30, 3] = 88;
        mtab[31, 1] = 79; mtab[31, 2] = 83; mtab[31, 3] = 88;
        mtab[32, 1] = 79; mtab[32, 2] = 82; mtab[32, 3] = 88;
        mtab[33, 1] = 79; mtab[33, 2] = 82; mtab[33, 3] = 87;
        mtab[34, 1] = 79; mtab[34, 2] = 82; mtab[34, 3] = 87;
        mtab[35, 1] = 79; mtab[35, 2] = 82; mtab[35, 3] = 87;
        mtab[36, 1] = 79; mtab[36, 2] = 82; mtab[36, 3] = 87;
        mtab[37, 1] = 79; mtab[37, 2] = 82; mtab[37, 3] = 87;
        mtab[38, 1] = 79; mtab[38, 2] = 82; mtab[38, 3] = 87;
        mtab[39, 1] = 79; mtab[39, 2] = 82; mtab[39, 3] = 87;
        mtab[40, 1] = 79; mtab[40, 2] = 81; mtab[40, 3] = 87;
        mtab[41, 1] = 79; mtab[41, 2] = 81; mtab[41, 3] = 87;
        mtab[42, 1] = 79; mtab[42, 2] = 81; mtab[42, 3] = 87;
        mtab[43, 1] = 79; mtab[43, 2] = 81; mtab[43, 3] = 87;
        mtab[44, 1] = 79; mtab[44, 2] = 81; mtab[44, 3] = 86;
        mtab[45, 1] = 79; mtab[45, 2] = 81; mtab[45, 3] = 86;
        mtab[46, 1] = 79; mtab[46, 2] = 81; mtab[46, 3] = 86;
        mtab[47, 1] = 79; mtab[47, 2] = 80; mtab[47, 3] = 86;
        mtab[48, 1] = 79; mtab[48, 2] = 80; mtab[48, 3] = 86;
        mtab[49, 1] = 79; mtab[49, 2] = 80; mtab[49, 3] = 86;
        mtab[50, 1] = 79; mtab[50, 2] = 80; mtab[50, 3] = 86;

        // Om temperaturen är utanför det tillåtna intervallet (0-50), returneras 0
        if (rtemp <= 0 || rtemp > 50)
            return 0;

        // Kontrollera luftfuktigheten och returnera motsvarande risknivå
        for (int i = 1; i <= 3; i++)
        {
            if (rhum < mtab[rtemp, i])
                return i - 1;
        }

        // Om ingen av de tidigare villkoren uppfylls, returnera den högsta risken (3)
        return 3;
    }
}
