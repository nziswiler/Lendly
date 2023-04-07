using Lendly.Core.Domain.Model;
using Lendly.Infrastructure.DbAccess;
using Lendly.UI.CommandLine.View;

namespace Lendly.UI.CommandLine.Controller
{
    public static class LoanController
    {
        public static void Menu()
        {
            var userInput = LoanView.GetMenuInput();
            bool isUserInputANumber = int.TryParse(userInput, out int menuPoint);

            if (!isUserInputANumber && menuPoint > 6 && menuPoint < 1)
            {
                IndexController.ErrorMessage("Bitte gib eine Nummer von 1-6 an.");
                Menu();
                return;
            }

            if (menuPoint == 1)
            {
                Add();
            }
            else if (menuPoint == 2)
            {
                ListAllPending();
            }
            else if (menuPoint == 3)
            {
                EndLoan();
            }
            else if (menuPoint == 4)
            {
                ListByBookNumber();
            }
            else if (menuPoint == 5)
            {
                ListByCustomerNumber();
            }
            else
            {
                IndexController.Menu();
            }
        }

        private static void Add()
        {
            var userInput = LoanView.GetLoanInput();
            var loanProperties = userInput.Split(';');

            if (loanProperties.Length != 2)
            {
                IndexController.ErrorMessage("Bitte geben Sie alle erforderlichen Angaben an!");
                Menu();

                return;
            }

            bool isBookANumber = int.TryParse(loanProperties[0], out int bookNumber);
            bool isCustomerANumber = int.TryParse(loanProperties[1], out int customerNumber);
            if (!isBookANumber || !isCustomerANumber)
            {
                IndexController.ErrorMessage("Bitte geben Sie Zahlen an. Der Vorgang wurde abgebrochen");
                Menu();
                return;
            }

            using (var unitOfWork = new UnitOfWork())
            {
                var book = unitOfWork.BookRepository.GetByVisibleIdentifierOrDefault(bookNumber);
                if (book == null)
                {
                    IndexController.ErrorMessage("Das von Ihnen angebene Buch existiert nicht. Der Vorgang wurde abgebrochen.");
                    Menu();

                    return;
                }
                var pendingLoan = unitOfWork.LoanRepository.GetPendingOrDefaultByBookId(bookNumber);
                if (pendingLoan != null)
                {
                    IndexController.ErrorMessage("Das von Ihnen angebene Buch wird bereits ausgeliehen. Der Vorgang wurde abgebrochen.");
                    Menu();

                    return;
                }
                var customer = unitOfWork.CustomerRepository.GetByVisibleIdentifierOrDefault(customerNumber);
                if (customer == null)
                {
                    IndexController.ErrorMessage("Der von Ihnen ausgewählte Benutzer existiert nicht. Der Vorgang wurde abgebrochen.");
                    Menu();

                    return;
                }

                var loan = new Loan()
                {
                    BookId = book.Id,
                    CustomerId = customer.Id,
                    StartOfLoan = DateTime.Now
                };

                unitOfWork.LoanRepository.Add(loan);
                unitOfWork.Commit();
                IndexController.SuccessMessage("Die Leihe wurde erfolgreich erfasst.");
            }

            ReturnToMenu();
        }

        private static void ListAllPending()
        {
            IndexController.Information("Die Leihen werden geladen");
            using (var unitOfWork = new UnitOfWork())
            {
                var loans = unitOfWork.LoanRepository.GetAllPending();
                LoanView.ListLoans(loans);
            }

            ReturnToMenu();
        }

        private static void EndLoan()
        {
            var userInput = LoanView.GetLoanByBookId();
            bool isBookANumber = int.TryParse(userInput, out int bookNumber);
            if (!isBookANumber)
            {
                IndexController.ErrorMessage("Bitte geben Sie Zahlen an. Der Vorgang wurde abgebrochen");
                Menu();
                return;
            }

            IndexController.Information("Die Leihe wird beendet.");
            using (var unitOfWork = new UnitOfWork())
            {
                var loan = unitOfWork.LoanRepository.GetPendingOrDefaultByBookId(bookNumber);
                if (loan == null)
                {
                    IndexController.ErrorMessage("Es existiert keine Leihe für dieses Buch.");
                    Menu();
                    return;
                }

                loan.EndOfLoan = DateTime.Now;
                unitOfWork.Commit();
            }

            IndexController.SuccessMessage("Die Leihe wurde erfolgreich beendet.");
            ReturnToMenu();
        }

        private static void ListByBookNumber()
        {
            var userInput = LoanView.GetLoanByBookId();
            bool isBookANumber = int.TryParse(userInput, out int bookNumber);
            if (!isBookANumber)
            {
                IndexController.ErrorMessage("Bitte geben Sie Zahlen an. Der Vorgang wurde abgebrochen");
                Menu();
                return;
            }

            IndexController.Information("Die Leihen werden geladen");
            using (var unitOfWork = new UnitOfWork())
            {
                var book = unitOfWork.BookRepository.GetByVisibleIdentifierOrDefault(bookNumber);
                if (book == null)
                {
                    IndexController.ErrorMessage("Das von Ihnen angebene Buch existiert nicht. Der Vorgang wurde abgebrochen.");
                    Menu();

                    return;
                }

                var loans = unitOfWork.LoanRepository.GetByBookId(bookNumber);
                LoanView.ListLoans(loans);
            }

            ReturnToMenu();
        }

        private static void ListByCustomerNumber()
        {
            var userInput = LoanView.GetLoanByCustomerId();
            bool isCustomerANumber = int.TryParse(userInput, out int customerNumber);
            if (!isCustomerANumber)
            {
                IndexController.ErrorMessage("Bitte geben Sie Zahlen an. Der Vorgang wurde abgebrochen");
                Menu();
                return;
            }

            IndexController.Information("Die Leihen werden geladen");
            using (var unitOfWork = new UnitOfWork())
            {
                var book = unitOfWork.CustomerRepository.GetByVisibleIdentifierOrDefault(customerNumber);
                if (book == null)
                {
                    IndexController.ErrorMessage("Der von Ihnen angebene Kunde existiert nicht. Der Vorgang wurde abgebrochen.");
                    Menu();

                    return;
                }

                var loans = unitOfWork.LoanRepository.GetByCustomerId(customerNumber);
                LoanView.ListLoans(loans);
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
