using Lendly.UI.CommandLine.View;

namespace Lendly.UI.CommandLine.Controller
{
    public static class BookController
    {
        public static void Menu()
        {
            var userInput = BookView.GetMenuInput();
        }
    }
}
