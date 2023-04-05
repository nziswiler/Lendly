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
            ShowSpinner();
            Console.ResetColor();
        }

        public static void DisplayErrorMessage(string errorMessage)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("    Es ist ein Fehler aufgetreten!");
            Console.Write("    " + errorMessage + " ");
            ShowSpinner();
            Console.ResetColor();
        }

        public static void DisplaySuccessMessage(string successMessage)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("    Der Vorgang war Erfolgreich!");
            Console.Write("    " + successMessage + " ");
            Console.ResetColor();
            Console.ReadLine();
        }

        public static void DisplayHeader()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Clear();
            Console.WriteLine("    #################################");
            Console.WriteLine("    ############ Lendly #############");
            Console.WriteLine("    #################################\n");
            Console.ResetColor();
        }

        public static void ShowSpinner()
        {
            var counter = 0;
            for (int i = 0; i < 30; i++)
            {
                switch (counter % 4)
                {
                    case 0: Console.Write("/"); break;
                    case 1: Console.Write("-"); break;
                    case 2: Console.Write("\\"); break;
                    case 3: Console.Write("|"); break;
                }
                Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                counter++;
                Thread.Sleep(100);
            }
        }
    }
}
