using Lendly.Core.Domain.Model;
using Lendly.Infrastructure.DbAccess;
using Lendly.UI.CommandLine.View;

namespace Lendly.UI.CommandLine.Controller
{
    public static class CategoryController
    {
        public static void Menu()
        {
            var userInput = CategoryView.GetMenuInput();
            bool IsUserInputANumber = int.TryParse(userInput, out int menuPoint);

            if (!IsUserInputANumber && menuPoint > 4 && menuPoint < 0)
            {
                IndexController.ErrorMessage("Bitte gib eine Nummer von 1-4 an.");
                Menu();
                return;
            }

            if (menuPoint == 1)
            {
                Add();
            }
            else if (menuPoint == 2)
            {
                ListAll();
            }
            else if (menuPoint == 3)
            {
                Search();
            }
            else if (menuPoint == 4)
            {
                Edit();
            }
            else if (menuPoint == 5)
            {
                Remove();
            }
            else
            {
                IndexController.Menu();
            }
        }


        private static void Add()
        {
            var userInput = CategoryView.GetCategoryNameInput("Neue Kategorie erfassen.\n     Geben Sie den Namen der Kategorie an");

            using(var unitOfWork = new UnitOfWork())
            {
                var category = unitOfWork.CategoryRepository.GetByNameOrDefault(userInput);
                if (category == null)
                {
                    category = new Category
                    {
                        Name = userInput
                    };

                    unitOfWork.CategoryRepository.Add(category);
                    unitOfWork.Commit();
                    IndexController.SuccessMessage("Die Kategorie wurde erfolgreich erfasst.");
                }
                else
                {
                    IndexController.ErrorMessage("Diese Kategorie existiert bereits.");
                }
            }

            ReturnToMenu();
        }

        private static void ListAll()
        {
            IndexController.Information("Die Kategorien werden geladen");
            using (var unitOfWork = new UnitOfWork())
            {
                var categories = unitOfWork.CategoryRepository.Get();
                CategoryView.ListCategories(categories);
            }

            ReturnToMenu();
        }

        private static void Search()
        {
            var userInput = CategoryView.GetKeywords();
            IndexController.Information("Die Suche wurde gestartet");

            using(var unitOfWork = new UnitOfWork())
            {
                var categories = unitOfWork.CategoryRepository.GetByKeyword(userInput);
                CategoryView.ListCategories(categories);
            }

            ReturnToMenu();
        }

        private static void Edit()
        {
            var userInput = CategoryView.GetCategoryNameInput("Bitte geben Sie den Namen der gewünschten Kategorie an:");
            IndexController.Information("Die Kategorie wird gesucht.");

            using(var unitOfWork = new UnitOfWork())
            {
                var category = unitOfWork.CategoryRepository.GetByNameOrDefault(userInput);
                if (category == null)
                {
                    IndexController.ErrorMessage("Diese Kategorie existiert nicht! Der Vorgang wurde abgebrochen.");
                    Edit();
                    return;
                }

                var categoryName = CategoryView.GetCategoryNameInput($"Kategorie '{category.Name}' bearbeiten:");
                var alreadyExisting = unitOfWork.CategoryRepository.GetByNameOrDefault(categoryName);
                if (alreadyExisting == null)
                {
                    category.Name = categoryName;
                    unitOfWork.Commit();
                    IndexController.SuccessMessage("Die Kategorie wurde erfolgreich eangepasst");
                }
                else
                {
                    IndexController.ErrorMessage("Es existiert bereits eine Kategorie mit diesem Namen. Der Vorgang wurde abgebrochen!");
                }
            }

            ReturnToMenu();
        }

        private static void Remove()
        {
            var userInput = CategoryView.GetCategoryNameInput("Bitte geben Sie den Namen der zu löschenden Kategorie an:");
            IndexController.Information("Die Kategorie wird gesucht.");

            using (var unitOfWork = new UnitOfWork())
            {
                var category = unitOfWork.CategoryRepository.GetByNameOrDefault(userInput);
                if (category == null)
                {
                    IndexController.ErrorMessage("Diese Kategorie existiert nicht!");
                    Remove();
                    return;
                }

                userInput = CategoryView.GetConfirmationAnswer(category.Name);
                if(userInput.ToLower() == "ja")
                {
                    unitOfWork.CategoryRepository.Remove(category);
                    unitOfWork.Commit();
                    IndexController.SuccessMessage("Die Kategorie wurde erfolgreich gelöscht.");
                }
                else
                {
                    IndexController.Information("Der Vorgang wurde abgebrochen.");
                }
            }

            ReturnToMenu();
        }


        private static void ReturnToMenu()
        {
            IndexController.Information("Drücke eine belibige Taste um zum Menu zurück zu kehren.");
            Console.ReadKey();
            Menu();
        }
    }
}
