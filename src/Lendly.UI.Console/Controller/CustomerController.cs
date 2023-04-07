using Lendly.Core.Domain.Model;
using Lendly.Infrastructure.DbAccess;
using Lendly.UI.CommandLine.View;

namespace Lendly.UI.CommandLine.Controller
{
    public static class CustomerController
    {
        public static void Menu()
        {
            var userInput = CustomerView.GetMenuInput();
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
            var userInput = CustomerView.GetCustomerInput();
            var customerProperties = userInput.Split(';');

            if (customerProperties.Length != 5)
            {
                IndexController.ErrorMessage("Bitte geben Sie alle erforderlichen Angaben an!");
                Menu();

                return;
            }

            using (var unitOfWork = new UnitOfWork())
            {
                var customer = new Customer()
                {
                    FirstName = customerProperties[0],
                    LastName = customerProperties[1],
                    Address = customerProperties[2],
                    Email = customerProperties[3],
                    PhoneNumber = customerProperties[4],
                };

                unitOfWork.CustomerRepository.Add(customer);
                unitOfWork.Commit();
                IndexController.SuccessMessage("Der Kunde wurde erfolgreich erfasst.");
            }

            ReturnToMenu();
        }

        private static void ListAll()
        {
            IndexController.Information("Die Kunden werden geladen");
            using (var unitOfWork = new UnitOfWork())
            {
                var customers = unitOfWork.CustomerRepository.GetAll();
                CustomerView.ListCustomers(customers);
            }

            ReturnToMenu();
        }

        private static void Edit()
        {
            var userInput = CustomerView.GetCustomerId();
            bool IsUserInputANumber = int.TryParse(userInput, out int visibleIdentifier);

            if (!IsUserInputANumber)
            {
                IndexController.ErrorMessage("Ungültige Eingabe!\n Der Vorgang wurde abgebrochen.");
                Menu();
                return;
            }

            IndexController.Information("Der Kunde wird gesucht.");
            using (var unitOfWork = new UnitOfWork())
            {
                var customer = unitOfWork.CustomerRepository.GetByVisibleIdentifierOrDefault(visibleIdentifier);
                if (customer == null)
                {
                    IndexController.ErrorMessage("Dieser Kunde existiert nicht! Der Vorgang wurde abgebrochen.");
                    Menu();
                    return;
                }

                var editInput = CustomerView.GetEditInput(customer);
                var customerProperties = editInput.Split(';');

                if (customerProperties.Length != 5)
                {
                    IndexController.ErrorMessage("Bitte geben Sie alle erforderlichen Angaben an! Der Vorgang wurde abgebrochen!");
                    Menu();
                    return;
                }

                customer.FirstName = customerProperties[0];
                customer.LastName = customerProperties[1];
                customer.Address = customerProperties[2];
                customer.Email = customerProperties[3];
                customer.PhoneNumber = customerProperties[4];
                unitOfWork.Commit();

                IndexController.SuccessMessage("Die Kategorie wurde erfolgreich eangepasst");
            }

            ReturnToMenu();
        }

        private static void Remove()
        {
            var userInput = CustomerView.GetCustomerId();
            bool IsUserInputANumber = int.TryParse(userInput, out int visibleIdentifier);

            if (!IsUserInputANumber)
            {
                IndexController.ErrorMessage("Ungültige Eingabe!\n Der Vorgang wurde abgebrochen.");
                Menu();
                return;
            }

            IndexController.Information("Der Kunde wird gesucht.");
            using (var unitOfWork = new UnitOfWork())
            {
                var customer = unitOfWork.CustomerRepository.GetByVisibleIdentifierOrDefault(visibleIdentifier);
                if (customer == null)
                {
                    IndexController.ErrorMessage("Dieser Kunde existiert nicht!");
                    Menu();
                    return;
                }

                var loans = unitOfWork.LoanRepository.GetByCustomerId(visibleIdentifier);
                if (loans.Any())
                {
                    IndexController.ErrorMessage("Dieser Kunde hat bereits ausleihen getätigt und kann nicht geläscht werden. Der Vorgang wurde abgebrochen.");
                    Menu();
                    return;
                }

                userInput = CustomerView.GetConfirmationAnswer(customer.VisibleIdentifier);
                if (userInput.ToLower() == "ja")
                {
                    unitOfWork.CustomerRepository.Remove(customer);
                    unitOfWork.Commit();
                    IndexController.SuccessMessage("Der Kunde wurde erfolgreich gelöscht.");
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
