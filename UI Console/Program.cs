using Application;
using Domain.Model.Entities;
using Domain.Model.ValueObjects;
using Infrastracture;
using Infrastracture.Persistance.Repositories;
//public Cat(string name, string breed, bool ismale, DateOnly arrivalDate, DateOnly? departureDate, DateOnly? birthDate, string description
Cat cat = new Cat(
    name: "Whiskers",
    breed: "Siamese",
    ismale: true,
    arrivalDate: DateOnly.FromDateTime(DateTime.Now.AddDays(-10)),
    departureDate: null,
    birthDate: DateOnly.FromDateTime(DateTime.Now.AddYears(-2)),
    description: "A playful and affectionate cat.",
    id: "37496O2025FBB"
);
Console.WriteLine($"Cat Created: {cat.Name}, Breed: {cat.Breed}, Arrival Date: {cat.ArrivalDate}");
//public Adopter(string firstName, string lastName, Email address, PhoneNumber phone, FiscalCode fiscalCode, string city, Cap cityCap)
Adopter adopter = new Adopter(
    firstName: "John",
    lastName: "Doe",
    address: new Email("jondoe@gmail.com"),
    phone: new PhoneNumber("1234567890"),
    fiscalCode: new FiscalCode("DOEJHN80A01C573O"),
    city: "Cesena",
    cityCap: new Cap("47521")
);
Console.WriteLine($"Adopter Created: {adopter.FirstName} {adopter.LastName}, City: {adopter.City}");
Adoption adoption = new Adoption(
    cat: cat,
    adopter: adopter,
    adoptionDate: DateOnly.FromDateTime(DateTime.Now)
);
//ui
Console.WriteLine($"Adoption Created: Cat {adoption.AdoptedCat.Name} adopted by {adoption.AdopterData.FirstName} on {adoption.AdoptionDate}");
JsonAdoptionRepository repository = new JsonAdoptionRepository("C:\\Users\\giacomo.strambi\\Desktop\\Json\\adoption.json");
try
{
    repository.AddToRepository(adoption);
}
catch (Exception ex)
{
    Console.WriteLine($"Error adding adoption record: {ex.Message}");
}
Console.WriteLine("Adoption record added to repository.");
adopter = new Adopter(
    firstName: "John",
    lastName: "Bay",
    address: new Email("jondoe@gmail.com"),
    phone: new PhoneNumber("1234567890"),
    fiscalCode: new FiscalCode("DOEJHN80A01C573O"),
    city: "Cesena",
    cityCap: new Cap("47521")
);
Console.WriteLine($"Adopter Created: {adopter.FirstName} {adopter.LastName}, City: {adopter.City}");
adoption = new Adoption(
    cat: cat,
    adopter: adopter,
    adoptionDate: DateOnly.FromDateTime(DateTime.Now)
);
repository.UpdateInRepository(adoption);
