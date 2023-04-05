using Lendly.UI.CommandLine.View;

namespace Lendly.UI.CommandLine.Controller
{
    public static class CustomerController
    {
        public static void Menu()
        {
            var userInput = CustomerView.GetMenuInput();
        }
    }
}
