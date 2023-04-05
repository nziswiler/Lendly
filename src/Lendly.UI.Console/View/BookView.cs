namespace Lendly.UI.CommandLine.View
{
    public static class BookView
    {
        public static string GetMenuInput()
        {
            IndexView.DisplayHeader();
            Console.WriteLine("    Bücher Menü:");
            Console.WriteLine("    ---------------------------------------------------------------------");
            Console.WriteLine("    1 Buch erfassen");
            Console.WriteLine("    2 Alle Bücher anzeigen");
            Console.WriteLine("    3 Buch suchen");
            Console.WriteLine("    4 Buch bearbeiten");
            Console.WriteLine("    5 Buch löschen");
            Console.WriteLine("    6 Hauptmenü\n");
            Console.Write("    Bitte wähle den gewünschten Menüpunkt aus (1-6): ");

            return Console.ReadLine() ?? string.Empty;
        }

        //public static string GetCrawlingUrl(int menuPoint)
        //{
        //    IndexView.DisplayHeader();
        //    Console.WriteLine("    Du hast den Menupunkt: " + menuPoint + " ausgewählt.");
        //    Console.WriteLine("    (Mit der Eingabe 'X' gelangen Sie zurück zum Hauptmenü.)");
        //    Console.WriteLine("    -----------------------------------------------------");
        //    Console.Write("    Bitte gib die gewünschte URL an (Format: https://domain.ch): ");

        //    return Console.ReadLine() ?? string.Empty;

        //}
    }
}
