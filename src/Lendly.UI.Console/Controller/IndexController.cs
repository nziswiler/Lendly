using Lendly.UI.CommandLine.View;

namespace Lendly.UI.CommandLine.Controller
{
    public class IndexController
    {
        public IndexController()
        {
            this.Menu();
        }

        private void Menu()
        {
            var userInput = IndexView.GetMainMenuInput();
            bool IsUserInputANumber = int.TryParse(userInput, out int menuPoint);
            if (IsUserInputANumber && menuPoint == 1)
            {
                BookController.Menu();
            }
            else if (IsUserInputANumber && menuPoint == 2)
            {
                LoanController.Menu();
            }
            else if (IsUserInputANumber && menuPoint == 3)
            {
                CustomerController.Menu();
            }
            else if (IsUserInputANumber && menuPoint == 4)
            {
                CategoryController.Menu();
            }
            else
            {
                ErrorMessage("Bitte gib eine Nummer von 1-4 an.");
                Menu();
            }
        }

        private static void ErrorMessage(string message)
        {
            IndexView.DisplayErrorMessage(message);
        }

        private static void DisplaySuccessMessage(string message)
        {
            IndexView.DisplaySuccessMessage(message);
        }

        private static void CloseLendly()
        {
            IndexView.DisplayClosingScreen();
            Environment.Exit(0);
        }
    }
}
