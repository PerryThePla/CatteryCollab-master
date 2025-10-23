using Domain.Model.Entities;
using Domain.Model.ValueObjects;
namespace TestDomain;

[TestClass]
public class CatteryTests
{
    [TestMethod]
    public void Cattery_AddCat_AddsACatCorrectly()
    {
        Cattery cattery = new Cattery();
        Cat cat = new Cat("Romeo", "Siamese", true, new DateOnly(2025, 08, 19), new DateOnly(2025, 10, 20), new DateOnly(2025, 08, 10), "gatto colore arancione");
        cattery.AddCat(cat);
        Assert.AreEqual(1, cattery.Cats.Count);
    }
    [TestMethod]
    public void Cattery_AddCat_AddACatEqualToAnotherCat()
    {
        Cattery cattery = new Cattery();
        Cat cat1 = new Cat("Romeo", "Siamese", true, new DateOnly(2025, 08, 19), new DateOnly(2025, 10, 20), new DateOnly(2025, 08, 10), "gatto colore arancione");
        Cat cat2 = new Cat("Romeo", "Siamese", true, new DateOnly(2025, 08, 19), new DateOnly(2025, 10, 20), new DateOnly(2025, 08, 10), "gatto colore arancione");
        cattery.AddCat(cat1);
        Assert.AreNotEqual(cat1, cat2);
    }
    [TestMethod]
    public void Cattery_AddAdoption_AdoptiondInsertedCorrectly()
    {
        Cattery cattery = new Cattery();
        Cat cat = new Cat("Romeo", "Siamese", true, new DateOnly(2025, 08, 19), null, new DateOnly(2025, 08, 20), "gatto colore arancione");
        Email email = new Email("johndoe@gmail.com");
        PhoneNumber phoneNumber = new PhoneNumber("3336767676");
        FiscalCode fiscalCode = new FiscalCode("RSSMRA85M01H501U");
        Adopter adopter = new Adopter("John", "Doe", email, phoneNumber, fiscalCode, "Rome", new Cap("00100"));
        Adoption adoption = new Adoption(cat, new DateOnly(2025, 10, 22), adopter);
        cattery.AddAdoption(adoption);
        Adoption adoption1 = cattery.Adoptions.FirstOrDefault();
        Assert.AreEqual(adoption, adoption1);
    }
}
