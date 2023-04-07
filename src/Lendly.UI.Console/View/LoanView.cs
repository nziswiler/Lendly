using Lendly.Core.Domain.Model;

namespace Lendly.UI.CommandLine.View
{
    public static class LoanView
    {
        public static string GetMenuInput()
        {
            IndexView.DisplayHeader();
            Console.WriteLine("    Leihen Menü:");
            Console.WriteLine("    ----------------------------------------------------------------------");
            Console.WriteLine("    1 Leihe erfassen");
            Console.WriteLine("    2 Laufende Leihen anzeigen");
            Console.WriteLine("    3 Leihe beenden");
            Console.WriteLine("    4 Leihhistorie von einem Buch anzeigen");
            Console.WriteLine("    5 Leihhistorie von einem Kunden anzeigen");
            Console.WriteLine("    6 Hauptmenü\n");
            Console.Write("    Bitte wähle den gewünschten Menüpunkt aus (1-6): ");

            return Console.ReadLine() ?? string.Empty;
        }


        public static string GetLoanInput()
        {
            IndexView.DisplayHeader();
            Console.WriteLine($"   Neue Leihe erfassen\n");
            Console.WriteLine($"   Gewünschtes Format (Getrennt durch Semikolon ';' ): Buch-Nr;Kunden-Nr.");
            Console.WriteLine("    ---------------------------------------------------------------------");

            return Console.ReadLine() ?? string.Empty;

        }

        public static void ListLoans(IEnumerable<Loan> loans)
        {
            IndexView.DisplayHeader();
            IndexView.DisplayInformation("Drücke eine beliebige Taste um zum Menu zurück zu kehren.\n");

            if (!loans.Any())
            {
                Console.WriteLine("    ---------------------------------------------------------------------");
                IndexView.DisplaySuccessMessage("Keine Ergebnisse.");
                return;
            }

            IndexView.DisplayInformation($"Anzahl Bücher: {loans.Count()}");
            Console.WriteLine("    Kunden:");
            Console.WriteLine($"    Format: Loan-Nr.; Ausgeliehen am; Buch-Nr; Buch; Kunden-Nr.; Kunde");
            Console.WriteLine("    ---------------------------------------------------------------------");

            foreach (var loan in loans)
            {
                Console.WriteLine($"    {loan.VisibleIdentifier}; {loan.StartOfLoan}; {loan.Book.VisibleIdentifier}; {loan.Book.Title}; {loan.Customer.VisibleIdentifier}; {loan.Customer.FirstName} {loan.Customer.LastName}");
            }
        }

        public static string GetLoanByBookId()
        {
            IndexView.DisplayHeader();
            Console.WriteLine("    Geben Sie die Buch-Nr. des gewünschten Buchs an:\n");
            Console.WriteLine("    ---------------------------------------------------------------------");

            return Console.ReadLine() ?? string.Empty;
        }

        public static string GetLoanByCustomerId()
        {
            IndexView.DisplayHeader();
            Console.WriteLine("    Geben Sie die Kunden-Nr. des gewünschten Kunden an:\n");
            Console.WriteLine("    ---------------------------------------------------------------------");

            return Console.ReadLine() ?? string.Empty;
        }
    }
}
