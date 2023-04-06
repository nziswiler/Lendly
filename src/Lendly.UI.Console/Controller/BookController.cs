using Lendly.Core.Domain.Model;
using Lendly.Infrastructure.DbAccess;
using Lendly.UI.CommandLine.View;

namespace Lendly.UI.CommandLine.Controller
{
    public static class BookController
    {
        public static void Menu()
        {
            var userInput = BookView.GetMenuInput();
            bool IsUserInputANumber = int.TryParse(userInput, out int menuPoint);

            if (!IsUserInputANumber && menuPoint > 5 && menuPoint < 0)
            {
                IndexController.ErrorMessage("Bitte gib eine Nummer von 1-5 an.");
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
                Edit();
            }
            else if (menuPoint == 4)
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
            var userInput = BookView.GetBookInput();
            var bookProperties = userInput.Split(';');

            if (bookProperties.Length != 4)
            {
                IndexController.ErrorMessage("Bitte geben Sie alle erforderlichen Angaben an!");
                Menu();

                return;
            }

            using (var unitOfWork = new UnitOfWork())
            {
                var category = unitOfWork.CategoryRepository.GetByNameOrDefault(bookProperties[3]);
                if (category == null)
                {
                    IndexController.ErrorMessage("Die von Ihnen angebene Kategorie existiert nicht. Bitte erfassen Sie zuerst die Kategorie. Der Vorgang wurde abgebrochen.");
                    Menu();

                    return;
                }

                var book = new Book()
                {
                    Title = bookProperties[0],
                    Author = bookProperties[1],
                    Publisher = bookProperties[2],
                    CategoryId = category.Id
                };

                unitOfWork.BookRepository.Add(book);
                unitOfWork.Commit();
                IndexController.SuccessMessage("Das Buch wurde erfolgreich erfasst.");
            }

            ReturnToMenu();
        }

        private static void ListAll()
        {
            IndexController.Information("Die Bücher werden geladen");
            using (var unitOfWork = new UnitOfWork())
            {
                var books = unitOfWork.BookRepository.GetAll();
                BookView.ListBooks(books);
            }

            ReturnToMenu();
        }

        private static void Edit()
        {
            var userInput = BookView.GetBookId();
            bool IsUserInputANumber = int.TryParse(userInput, out int visibleIdentifier);

            if (!IsUserInputANumber)
            {
                IndexController.ErrorMessage("Ungültige Eingabe!\n Der Vorgang wurde abgebrochen.");
                Menu();
                return;
            }

            IndexController.Information("Das Buch wird gesucht.");
            using (var unitOfWork = new UnitOfWork())
            {
                var book = unitOfWork.BookRepository.GetByVisibleIdentifierOrDefault(visibleIdentifier);
                if (book == null)
                {
                    IndexController.ErrorMessage("Dieser Kunde existiert nicht! Der Vorgang wurde abgebrochen.");
                    Menu();
                    return;
                }

                var editInput = BookView.GetEditInput(book);
                var bookProperties = editInput.Split(';');

                if (bookProperties.Length != 4)
                {
                    IndexController.ErrorMessage("Bitte geben Sie alle erforderlichen Angaben an! Der Vorgang wurde abgebrochen!");
                    Menu();
                    return;
                }

                var category = unitOfWork.CategoryRepository.GetByNameOrDefault(bookProperties[3]);
                if (category == null)
                {
                    IndexController.ErrorMessage("Die von Ihnen angebene Kategorie existiert nicht. Bitte erfassen Sie zuerst die Kategorie. Der Vorgang wurde abgebrochen.");
                    Menu();
                    return;
                }

                book.Title = bookProperties[0];
                book.Author = bookProperties[1];
                book.Publisher = bookProperties[2];
                book.CategoryId = category.Id;
                unitOfWork.Commit();

                IndexController.SuccessMessage("Das Buch wurde erfolgreich eangepasst");
            }

            ReturnToMenu();
        }

        private static void Remove()
        {
            var userInput = BookView.GetBookId();
            bool IsUserInputANumber = int.TryParse(userInput, out int visibleIdentifier);

            if (!IsUserInputANumber)
            {
                IndexController.ErrorMessage("Ungültige Eingabe!\n Der Vorgang wurde abgebrochen.");
                Menu();
                return;
            }

            IndexController.Information("Das Buch wird gesucht.");
            using (var unitOfWork = new UnitOfWork())
            {
                var book = unitOfWork.BookRepository.GetByVisibleIdentifierOrDefault(visibleIdentifier);
                if (book == null)
                {
                    IndexController.ErrorMessage("Dieses Buch existiert nicht!");
                    Menu();
                    return;
                }

                userInput = BookView.GetConfirmationAnswer(book.VisibleIdentifier);
                if (userInput.ToLower() == "ja")
                {
                    unitOfWork.BookRepository.Remove(book);
                    unitOfWork.Commit();
                    IndexController.SuccessMessage("Das Buch wurde erfolgreich gelöscht.");
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
