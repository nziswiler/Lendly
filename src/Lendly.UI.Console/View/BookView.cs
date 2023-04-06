using Lendly.Core.Domain.Model;

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
            Console.WriteLine("    3 Buch bearbeiten");
            Console.WriteLine("    4 Buch löschen");
            Console.WriteLine("    5 Hauptmenü\n");
            Console.Write("    Bitte wähle den gewünschten Menüpunkt aus (1-5): ");

            return Console.ReadLine() ?? string.Empty;
        }

        public static string GetBookInput()
        {
            IndexView.DisplayHeader();
            Console.WriteLine($"   Neues Buch erfassen\n");
            Console.WriteLine($"   Gewünschtes Format (Getrennt durch Semikolon ';' ): Titel;Autor;Verlag;Kategorie");
            Console.WriteLine("    ---------------------------------------------------------------------");

            return Console.ReadLine() ?? string.Empty;

        }

        public static void ListBooks(IEnumerable<Book> books)
        {
            IndexView.DisplayHeader();
            IndexView.DisplayInformation("Drücke eine beliebige Taste um zum Menu zurück zu kehren.\n");

            if (!books.Any())
            {
                Console.WriteLine("    ---------------------------------------------------------------------");
                IndexView.DisplaySuccessMessage("Keine Ergebnisse.");
                return;
            }

            IndexView.DisplayInformation($"Anzahl Bücher: {books.Count()}");
            Console.WriteLine("    Kunden:");
            Console.WriteLine($"   Format: Buch-Nr.; Titel; Autor; Verlag; Kategorie");
            Console.WriteLine("    ---------------------------------------------------------------------");

            foreach (var book in books)
            {
                Console.WriteLine($"    {book.VisibleIdentifier}; {book.Title}; {book.Author}; {book.Publisher}; {book.Category.Name}");
            }
        }

        public static string GetEditInput(Book book)
        {
            IndexView.DisplayHeader();
            Console.WriteLine($"   Buch bearbeiten:\n");
            Console.WriteLine($"   Bitte geben Sie alle Angaben erneut an. (Auch die, die sie nicht abändern wollen)");
            Console.WriteLine($"   Gewünschtes Eingabeformat (Getrennt durch Semikolon ';' ): Titel;Autor;Verlag;Kategorie\n");
            Console.WriteLine($"   Aktuelle Angaben: {book.Title}; {book.Author}; {book.Publisher}; {book.Category.Name}");
            Console.WriteLine("    ---------------------------------------------------------------------");

            return Console.ReadLine() ?? string.Empty;
        }

        public static string GetBookId()
        {
            IndexView.DisplayHeader();
            Console.WriteLine("    Geben Sie die Buch-Nr. des gewünschten Buchs an:\n");
            Console.WriteLine("    ---------------------------------------------------------------------");

            return Console.ReadLine() ?? string.Empty;
        }

        public static string GetConfirmationAnswer(int bookId)
        {
            IndexView.DisplayHeader();
            Console.WriteLine($"    Wollen Sie das Buch mit der Buch-Nr. '{bookId}' wirklich löschen?");
            Console.WriteLine("    'Ja' für löschen. 'Nein' um den Vorgang abzubrechen:\n");
            Console.WriteLine("    ---------------------------------------------------------------------");

            return Console.ReadLine() ?? string.Empty;
        }
    }
}
