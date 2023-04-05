namespace Lendly.UI.CommandLine.View
{
    public static class CategoryView
    {
        public static string GetMenuInput()
        {
            IndexView.DisplayHeader();
            Console.WriteLine("    Kategorie Menü:");
            Console.WriteLine("    ---------------------------------------------------------------------");
            Console.WriteLine("    1 Kategorie erfassen");
            Console.WriteLine("    2 Alle Kategorien anzeigen");
            Console.WriteLine("    3 Kategorie suchen");
            Console.WriteLine("    4 Kategorie bearbeiten");
            Console.WriteLine("    5 Kategorie löschen");
            Console.WriteLine("    6 Hauptmenü\n");
            Console.Write("    Bitte wähle den gewünschten Menüpunkt aus (1-6): ");

            return Console.ReadLine() ?? string.Empty;
        }
    }
}
