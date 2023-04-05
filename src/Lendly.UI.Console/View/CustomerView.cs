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
            Console.WriteLine("    3 Kunde suchen");
            Console.WriteLine("    4 Kunde bearbeiten");
            Console.WriteLine("    5 Kunde löschen");
            Console.WriteLine("    6 Hauptmenü\n");
            Console.Write("    Bitte wähle den gewünschten Menüpunkt aus (1-6): ");

            return Console.ReadLine() ?? string.Empty;
        }
    }
}
