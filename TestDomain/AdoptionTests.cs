using Domain.Model.Entities;
using Domain.Model.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDomain
{
    [TestClass]
    public class AdoptionTests
    {
        [TestMethod]
        public void Adoption_CreateAdoption_Success()
        {
            Cat cat = new Cat("Romeo", "Siamese", true, new DateOnly(2025, 08, 19), new DateOnly(2025, 10, 20), new DateOnly(2025, 07, 2), "gatto colore arancione");
            Email email = new Email("jhon.doe@gmail.com");
            PhoneNumber phoneNumber = new PhoneNumber("1234567890");
            FiscalCode fiscalCode = new FiscalCode("JHNDOE80A01H501U");
            Adopter adopter = new Adopter("John", "Doe", email, phoneNumber, fiscalCode, "New York", new Cap("10001"));
            Adoption adoption = new Adoption(cat, new DateOnly(2025, 10, 20), adopter);
            Assert.AreEqual(cat, adoption.AdoptedCat);
            Assert.AreEqual(new DateOnly(2025, 10, 20), adoption.AdoptionDate);
            Assert.AreEqual(adopter, adoption.AdopterData);
            Assert.AreEqual(Adoption.AdoptionStatus.Completed, adoption.Status);
        }
        [TestMethod]
        public void Adoption_CancelAdoption_Success()
        {
            Cat cat = new Cat("Romeo", "Siamese", true, new DateOnly(2025, 08, 19), new DateOnly(2025, 10, 20), new DateOnly(2025, 07, 2), "gatto colore arancione");
            Email email = new Email("jhon.doe@gmail.com");
            PhoneNumber phoneNumber = new PhoneNumber("1234567890");
            FiscalCode fiscalCode = new FiscalCode("JHNDOE80A01H501U");
            Adopter adopter = new Adopter("John", "Doe", email, phoneNumber, fiscalCode, "New York", new Cap("10001"));
            Adoption adoption = new Adoption(cat, new DateOnly(2025, 10, 20), adopter); 
            adoption.CancelAdoption();
            Assert.AreEqual(Adoption.AdoptionStatus.Cancelled, adoption.Status);
        }
        [TestMethod]
        public void Adoption_CancelAdoption_AlreadyCancelled_ThrowsException()
        {
            Cat cat = new Cat("Romeo", "Siamese", true, new DateOnly(2025, 08, 19), new DateOnly(2025, 10, 20), new DateOnly(2025, 07, 2), "gatto colore arancione");
            Email email = new Email("jhon.doe@gmail.com");
            PhoneNumber phoneNumber = new PhoneNumber("1234567890");
            FiscalCode fiscalCode = new FiscalCode("JHNDOE80A01H501U");
            Adopter adopter = new Adopter("John", "Doe", email, phoneNumber, fiscalCode, "New York", new Cap("10001"));
            Adoption adoption = new Adoption(cat, new DateOnly(2025, 10, 20), adopter);
            adoption.CancelAdoption();
            Assert.ThrowsException<InvalidOperationException>(() => adoption.CancelAdoption());
        }
        [TestMethod]
        public void Adoption_AdoptionDateBeforeArrivalDate_ThrowsException()
        {
            Cat cat = new Cat("Romeo", "Siamese", true, new DateOnly(2025, 11, 19), new DateOnly(2025, 10, 20), new DateOnly(2025, 07, 2), "gatto colore arancione");
            Email email = new Email("jhon.doe@gmail.com");
            Adopter adopter = new Adopter("John","Doe",
        }
    }
