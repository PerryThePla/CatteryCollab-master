using Domain.Model.Entities;
using Domain.Model.ValueObjects;
namespace TestDomain;

[TestClass]
public class AdopterTests
{
    [TestMethod]
    public void AdopterCostructor_FirstName_WorksCorrectly()
    {
        Email email = new Email("johndoe@gmai.com");
        PhoneNumber phone = new PhoneNumber("1234567890");
        FiscalCode fiscalCode = new FiscalCode("ABCDEF12G34H567I");
        Cap cap = new Cap("47042");
        Adopter adopter = new Adopter("John", "Doe", email, phone, fiscalCode, "New York", cap);
        Assert.AreEqual("John", adopter.FirstName);
    }
    [TestMethod]
    public void AdopterCostructor_LastName_WorksCorrectly()
    {
        Email email = new Email("johndoe@gmai.com");
        PhoneNumber phone = new PhoneNumber("1234567890");
        FiscalCode fiscalCode = new FiscalCode("ABCDEF12G34H567I");
        Cap cap = new Cap("47042");
        Adopter adopter = new Adopter("John", "Doe", email, phone, fiscalCode, "New York", cap);
        Assert.AreEqual("Doe", adopter.LastName);
    }
    [TestMethod]
    public void AdopterCostructor_City_WorksCorrectly()
    {
        Email email = new Email("johndoe@gmai.com");
        PhoneNumber phone = new PhoneNumber("1234567890");
        FiscalCode fiscalCode = new FiscalCode("ABCDEF12G34H567I");
        Cap cap = new Cap("47042");
        Adopter adopter = new Adopter("John", "Doe", email, phone, fiscalCode, "New York", cap);
        Assert.AreEqual("New York", adopter.City);
    }
    [TestMethod]
    public void AdopterCostructor_Address_WorksCorrectly()
    {
        Email email = new Email("johndoe@gmai.com");
        PhoneNumber phone = new PhoneNumber("1234567890");
        FiscalCode fiscalCode = new FiscalCode("ABCDEF12G34H567I");
        Cap cap = new Cap("47042");
        Adopter adopter = new Adopter("John", "Doe", email, phone, fiscalCode, "New York", cap);
        Assert.AreEqual(email, adopter.Address);
    }
    [TestMethod]
    public void AdopterCostructor_Cap_WorksCorrectly()
    {
        Email email = new Email("johndoe@gmai.com");
        PhoneNumber phone = new PhoneNumber("1234567890");
        FiscalCode fiscalCode = new FiscalCode("ABCDEF12G34H567I");
        Cap cap = new Cap("47042");
        Adopter adopter = new Adopter("John", "Doe", email, phone, fiscalCode, "New York", cap);
        Assert.AreEqual(cap, adopter.CityCap);
    }
    [TestMethod]
    public void AdopterCostructor_Phone_WorksCorrectly()
    {
        Email email = new Email("johndoe@gmai.com");
        PhoneNumber phone = new PhoneNumber("1234567890");
        FiscalCode fiscalCode = new FiscalCode("ABCDEF12G34H567I");
        Cap cap = new Cap("47042");
        Adopter adopter = new Adopter("John", "Doe", email, phone, fiscalCode, "New York", cap);
        Assert.AreEqual(phone, adopter.Phone);
    }
    [TestMethod]
    public void AdopterCostructor_FiscalCode_WorksCorrectly()
    {
        Email email = new Email("johndoe@gmai.com");
        PhoneNumber phone = new PhoneNumber("1234567890");
        FiscalCode fiscalCode = new FiscalCode("ABCDEF12G34H567I");
        Cap cap = new Cap("47042");
        Adopter adopter = new Adopter("John", "Doe", email, phone, fiscalCode, "New York", cap);
        Assert.AreEqual(phone, adopter.Phone);
    }
    [TestMethod]
    public void AdopterCostructor_NullOrEmptyFirstName_ThrowsArgumentNullException()
    {
        Email email = new Email("johndoe@gmai.com");
        PhoneNumber phone = new PhoneNumber("1234567890");
        FiscalCode fiscalCode = new FiscalCode("ABCDEF12G34H567I");
        Cap cap = new Cap("47042");
        Assert.ThrowsException<ArgumentNullException>(() => new Adopter("", "Doe", email, phone, fiscalCode, "New York", cap));
    }
    [TestMethod]
    public void AdopterCostructor_NullOrEmptyLastName_ThrowsArgumentNullException()
    {
        Email email = new Email("johndoe@gmai.com");
        PhoneNumber phone = new PhoneNumber("1234567890");
        FiscalCode fiscalCode = new FiscalCode("ABCDEF12G34H567I");
        Cap cap = new Cap("47042");
        Assert.ThrowsException<ArgumentNullException>(() => new Adopter("John", "", email, phone, fiscalCode, "New York", cap));
    }
    [TestMethod]
    public void AdopterCostructor_NullOrEmptyCity_ThrowsArgumentNullException()
    {
        Email email = new Email("johndoe@gmai.com");
        PhoneNumber phone = new PhoneNumber("1234567890");
        FiscalCode fiscalCode = new FiscalCode("ABCDEF12G34H567I");
        Cap cap = new Cap("47042");
        Assert.ThrowsException<ArgumentNullException>(() => new Adopter("John", "Doe", email, phone, fiscalCode, "", cap));
    }
    [TestMethod]
    public void AdopterCostructor_InvalidPhone_ThrowsArgumentNullException()
    {
        Email email = new Email("johndoe@gmai.com");
        PhoneNumber phone = new PhoneNumber("");
        FiscalCode fiscalCode = new FiscalCode("ABCDEF12G34H567I");
        Cap cap = new Cap("47042");
        Assert.ThrowsException<ArgumentNullException>(() => new Adopter("John", "Doe", email, phone, fiscalCode, "New York", cap));
    }
    [TestMethod]
    public void AdopterCostructor_InvalidEmail_ThrowsArgumentNullException()
    {
        Email email = new Email("");
        PhoneNumber phone = new PhoneNumber("1234567890");
        FiscalCode fiscalCode = new FiscalCode("ABCDEF12G34H567I");
        Cap cap = new Cap("47042");
        Assert.ThrowsException<ArgumentNullException>(() => new Adopter("John", "Doe", email, phone, fiscalCode, "New York", cap));
    }
    [TestMethod]
    public void AdopterCostructor_InvalidFiscalCode_ThrowsArgumentNullException()
    {
        Email email = new Email("johndoe@gmai.com");
        PhoneNumber phone = new PhoneNumber("1234567890");
        FiscalCode fiscalCode = new FiscalCode("");
        Cap cap = new Cap("47042");
        Assert.ThrowsException<ArgumentNullException>(() => new Adopter("John", "Doe", email, phone, fiscalCode, "New York", cap));
    }
    [TestMethod]
    public void AdopterCostructor_InvalidCap_ThrowsArgumentNullException()
    {
        Email email = new Email("johndoe@gmai.com");
        PhoneNumber phone = new PhoneNumber("1234567890");
        FiscalCode fiscalCode = new FiscalCode("ABCDEF12G34H567I");
        Cap cap = new Cap("2323232");
        Assert.ThrowsException<ArgumentException>(() => new Adopter("John", "Doe", email, phone, fiscalCode, "New York", cap));
    }
}