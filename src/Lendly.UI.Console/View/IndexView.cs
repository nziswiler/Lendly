namespace Lendly.UI.CommandLine.View
{
    public static class IndexView
    {
        public static string GetMainMenuInput()
        {
            DisplayHeader();
            Console.WriteLine("    Hauptmenü:");
            Console.WriteLine("    ---------------------------------------------------------------------");
            Console.WriteLine("    1 Bücher");
            Console.WriteLine("    2 Leihen ");
            Console.WriteLine("    3 Kunden ");
            Console.WriteLine("    4 Kategorien \n");
            Console.Write("    Bitte wähle den gewünschten Menüpunkt aus (1-4): ");

            return Console.ReadLine() ?? string.Empty;
        }

        public static string GetTargetDirectory(int menuPoint)
        {
            DisplayHeader();
            Console.WriteLine("    Du hast den Menupunkt: " + menuPoint + " ausgewählt.");
            Console.WriteLine("    (Mit der Eingabe 'X' gelangst du zurück zum Hauptmenü.)");
            Console.WriteLine("    -----------------------------------------------------");
            Console.Write("    Bitte gib den gewünschten Speicherort an (Format: [Laufwerkbuchstabe]:/mein/pfad): ");

            return Console.ReadLine() ?? string.Empty;
        }

        public static void DisplaySearchScreen()
        {
            DisplayHeader();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("    Die Suche wurde nun gestartet.");
            Console.WriteLine("    Dieser Vorgang kann einige Zeit in Anspruch nehemen.");
            Console.WriteLine("    Vielen Dank für Deine Geduld!\n");
            Console.ResetColor();
        }

        public static void DisplayClosingScreen()
        {
            DisplayHeader();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("    Vielen Dank, dass Du Lendly verwendet hast!");
            Console.Write("    Hoffentlich bis bald. ");
            Console.ResetColor();
        }

        public static void DisplayErrorMessage(string errorMessage)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("    " + errorMessage + " ");

            Console.WriteLine("    Drücke eine beliebige Taste um fortzufahren.");
            Console.ReadKey();
            Console.ResetColor();
        }

        public static void DisplaySuccessMessage(string successMessage)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("    " + successMessage + " ");
            Console.ResetColor();
        }

        public static void DisplayInformation(string inforamtion)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("    " + inforamtion + " ");
            Console.ResetColor();
        }

        public static void DisplayHeader()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Clear();
            Console.WriteLine("    #################################");
            Console.WriteLine("    ############ Lendly #############");
            Console.WriteLine("    #################################\n");
            Console.ResetColor();
        }
    }
}
