using Lendly.UI.CommandLine.View;

namespace Lendly.UI.CommandLine.Controller
{
    public static class LoanController
    {
        public static void Menu()
        {
            var userInput = LoanView.GetMenuInput();
        }
    }
}
