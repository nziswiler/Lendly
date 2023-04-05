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
            Console.WriteLine("    3 Leihen beenden");
            Console.WriteLine("    4 Leihhistorie von einem Buch anzeigen");
            Console.WriteLine("    5 Leihhistorie von einem Kunden anzeigen");
            Console.WriteLine("    6 Hauptmenü\n");
            Console.Write("    Bitte wähle den gewünschten Menüpunkt aus (1-6): ");

            return Console.ReadLine() ?? string.Empty;
        }
    }
}
