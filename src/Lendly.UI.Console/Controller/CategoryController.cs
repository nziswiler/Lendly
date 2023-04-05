using Lendly.UI.CommandLine.View;

namespace Lendly.UI.CommandLine.Controller
{
    public static class CategoryController
    {
        public static void Menu()
        {
            var userInput = CategoryView.GetMenuInput();
        }
    }
}
