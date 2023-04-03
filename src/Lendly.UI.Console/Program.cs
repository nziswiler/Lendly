// See https://aka.ms/new-console-template for more information
using Lendly.Core.Domain.Model;
using Lendly.Infrastructure.DbAccess;

Console.WriteLine("Hello, World!");

var maxMuster = new Customer()
{
    FirstName = "Max",
    LastName = "Muster",
    Address = "Musterstrasse 10, 3612 Muster",
    Email = "max.muster@gmail.com",
    PhoneNumber = "090909090"
};

using (var unitOfWork = new UnitOfWork())
{
    unitOfWork.CustomerRepository.Add(maxMuster);
    unitOfWork.Commit();


    var customers = unitOfWork.CustomerRepository.Get();
    foreach (var customer in customers)
    {
        Console.WriteLine(customer.FirstName);
    }
}
