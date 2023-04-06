using Lendly.Core.Domain.Model;

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


        public static string GetCategoryNameInput(string title)
        {
            IndexView.DisplayHeader();
            Console.WriteLine($"   {title}\n");
            Console.WriteLine("    ---------------------------------------------------------------------");

            return Console.ReadLine() ?? string.Empty;

        }

        public static void ListCategories(IEnumerable<Category> categories)
        {
            IndexView.DisplayHeader();
            IndexView.DisplayInformation("Drücke eine beliebige Taste um zum Menu zurück zu kehren.\n");

            if (!categories.Any())
            {
                Console.WriteLine("    ---------------------------------------------------------------------");
                IndexView.DisplaySuccessMessage("Keine Ergebnisse.");
                return;
            }

            IndexView.DisplayInformation($"Anzahl Kategorien: {categories.Count()}");
            Console.WriteLine("    Kategorien:");
            Console.WriteLine("    ---------------------------------------------------------------------");

            foreach (var category in categories)
            {
                Console.WriteLine($"    {category.Name}");
            }
        }

        public static string GetKeywords()
        {
            IndexView.DisplayHeader();
            Console.WriteLine("    Geben Sie den gewünschten Suchbegriff an:\n");
            Console.WriteLine("    ---------------------------------------------------------------------");

            return Console.ReadLine() ?? string.Empty;
        }

        public static string GetConfirmationAnswer(string name)
        {
            IndexView.DisplayHeader();
            Console.WriteLine($"    Wollen Sie die Kategorie '{name}' wirklich löschen?");
            Console.WriteLine("    'Ja' für löschen. 'Nein' um den Vorgang abzubrechen:\n");
            Console.WriteLine("    ---------------------------------------------------------------------");

            return Console.ReadLine() ?? string.Empty;
        }
    }
}
