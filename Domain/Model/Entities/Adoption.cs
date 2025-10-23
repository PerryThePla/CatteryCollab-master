using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows; // Required for MessageBox

namespace Domain.Model.Entities
{
    public class Adoption
    {
        public Cat AdoptedCat { get; set; }
        public DateOnly AdoptionDate { get; set; }
        public Adopter AdopterData { get; set; }

        public enum AdoptionStatus
        {
            Completed,
            Cancelled
        }

        public AdoptionStatus Status { get; set; } = AdoptionStatus.Completed;

        public Adoption(Cat cat, DateOnly adoptionDate, Adopter adopter)
        {
            if (cat.ArrivalDate > adoptionDate)
            {
                throw new ArgumentException("The adoption date cannot be earlier than the cat's arrival date.", nameof(adoptionDate));
            }
            AdoptedCat = cat;
            AdoptionDate = adoptionDate;
            AdopterData = adopter;
        }

        public void CancelAdoption()
        {
            if (Status == AdoptionStatus.Cancelled)
            {
                throw new InvalidOperationException("The adoption is already cancelled.");
                return;
            }
            Status = AdoptionStatus.Cancelled;
        }

    }
}
