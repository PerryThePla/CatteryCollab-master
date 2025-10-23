using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.Entities
{
    public class Cattery
    {
        public List<Cat> Cats { get; set; } = new List<Cat>();
        public List<Adoption> Adoptions { get; set; } = new List<Adoption>();

        public void AddCat(Cat cat)
        {
            if (Cats.Any(c => c.ID == cat.ID)) throw new InvalidOperationException("A cat with the same ID already exists.");
            Cats.Add(cat);
        }

        public void AddAdoption(Adoption adoption)
        {
            if (adoption.AdoptedCat.DepartureDate.HasValue) throw new Exception("The cat has already been adopted.");
            if (adoption.AdoptionDate < adoption.AdoptedCat.ArrivalDate) throw new ArgumentException("The adoption date cannot be earlier than the cat's arrival date.");
            adoption.AdoptedCat.UpdateDepartureDate(adoption.AdoptionDate);
            Adoptions.Add(adoption);
        }
    }
}
