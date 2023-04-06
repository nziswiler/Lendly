using Lendly.Core.Domain.Model;

namespace Lendly.UI.CommandLine.View
{
    public static class CustomerView
    {
        public static string GetMenuInput()
        {
            IndexView.DisplayHeader();
            Console.WriteLine("    Kunden Menü:");
            Console.WriteLine("    ---------------------------------------------------------------------");
            Console.WriteLine("    1 Kunde erfassen");
            Console.WriteLine("    2 Alle Kunden anzeigen");
            Console.WriteLine("    3 Kunde bearbeiten");
            Console.WriteLine("    4 Kunde löschen");
            Console.WriteLine("    5 Hauptmenü\n");
            Console.Write("    Bitte wähle den gewünschten Menüpunkt aus (1-5): ");

            return Console.ReadLine() ?? string.Empty;
        }

        public static string GetCustomerInput()
        {
            IndexView.DisplayHeader();
            Console.WriteLine($"   Neuer Kunde erfassen\n");
            Console.WriteLine($"   Gewünschtes Format (Getrennt durch Semikolon ';' ): Vorname;Nachname;Adresse;Email;Telefon");
            Console.WriteLine("    ---------------------------------------------------------------------");

            return Console.ReadLine() ?? string.Empty;

        }

        public static void ListCustomers(IEnumerable<Customer> customers)
        {
            IndexView.DisplayHeader();
            IndexView.DisplayInformation("Drücke eine beliebige Taste um zum Menu zurück zu kehren.\n");

            if (!customers.Any())
            {
                Console.WriteLine("    ---------------------------------------------------------------------");
                IndexView.DisplaySuccessMessage("Keine Ergebnisse.");
                return;
            }

            IndexView.DisplayInformation($"Anzahl Kunden: {customers.Count()}");
            Console.WriteLine("    Kunden:");
            Console.WriteLine($"   Format: Kunden-Nr.;Vorname; Nachname; Adresse; Email; Telefon");
            Console.WriteLine("    ---------------------------------------------------------------------");

            foreach (var customer in customers)
            {
                Console.WriteLine($"    {customer.VisibleIdentifier}; {customer.FirstName}; {customer.LastName}; {customer.Address}; {customer.Email}; {customer.PhoneNumber}");
            }
        }

        public static string GetEditInput(Customer customer)
        {
            IndexView.DisplayHeader();
            Console.WriteLine($"   Kunde bearbeiten:\n");
            Console.WriteLine($"   Bitte geben Sie alle Angaben erneut an. (Auch die, die sie nicht abändern wollen)");
            Console.WriteLine($"   Gewünschtes Eingabeformat (Getrennt durch Semikolon ';' ): Vorname;Nachname;Adresse;Email;Telefon\n");
            Console.WriteLine($"   Aktuelle Angaben: {customer.FirstName}; {customer.LastName}; {customer.Address}; {customer.Email};{customer.PhoneNumber}");
            Console.WriteLine("    ---------------------------------------------------------------------");

            return Console.ReadLine() ?? string.Empty;
        }

        public static string GetCustomerId()
        {
            IndexView.DisplayHeader();
            Console.WriteLine("    Geben Sie die Kundennummer des gewünschten Kunden an:\n");
            Console.WriteLine("    ---------------------------------------------------------------------");

            return Console.ReadLine() ?? string.Empty;
        }

        public static string GetConfirmationAnswer(int customerId)
        {
            IndexView.DisplayHeader();
            Console.WriteLine($"    Wollen Sie den Kunden mit der Kundenummer '{customerId}' wirklich löschen?");
            Console.WriteLine("    'Ja' für löschen. 'Nein' um den Vorgang abzubrechen:\n");
            Console.WriteLine("    ---------------------------------------------------------------------");

            return Console.ReadLine() ?? string.Empty;
        }
    }
}
