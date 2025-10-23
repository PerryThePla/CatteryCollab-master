using Domain.Model.Entities;
using Domain.Model.ValueObjects;
namespace TestDomain;

[TestClass]
public class CatTests
{
    [TestMethod]
    public void Cat_NameIsEmpty_ThrowsException()
    {
        Cat cat;
        Assert.ThrowsException<ArgumentNullException>(() => cat = new Cat("", "Siamese", true, new DateOnly(2025, 08, 19), new DateOnly(2025, 10, 15), new DateOnly(2025, 08, 10), "gatto colore arancione"));
    }
    [TestMethod]
    public void Cat_BreedIsEmpty_ThrowsException()
    {
        Cat cat = new Cat("Romeo", "", false, new DateOnly(2025, 08, 19), new DateOnly(2025, 10, 15), new DateOnly(2025, 08, 10), "gatto colore arancione");
        Assert.ThrowsException<ArgumentNullException>(() => cat.Breed);
    }

    [TestMethod]
    public void Cat_GenerateID_WorksCorrectly()
    {
        Cat cat = new Cat("Romeo", "Siamese", true, new DateOnly(2025, 08, 19), new DateOnly(2025, 10, 15), new DateOnly(2025, 08, 10), "gatto colore arancione");
        Assert.Equals(13, cat.ID.Length);
    }
    [TestMethod]
    public void Cat_UpdateDepartureDate_WorksCorrectly()
    {
        Cat cat = new Cat("Romeo", "Siamese", true, new DateOnly(2025, 08, 19), null, new DateOnly(2025, 08, 10), "gatto colore arancione");
        cat.UpdateDepartureDate(new DateOnly(2025, 10, 15));
        Assert.Equals((2025, 10, 15), cat.DepartureDate);
    }

}