using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.Entities
{
    public class Cat
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    _name = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("The name can't be null or whit white space");
                }
            }
        }

        private string _breed;
        public string Breed
        {
            get { return _breed; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    _breed = value;
                }
                else 
                {
                    throw new ArgumentOutOfRangeException("breed can't be null or with white space");
                }
            }
        }

        public bool IsMale = true;

        public DateOnly ArrivalDate { get; set; }
        public DateOnly? DepartureDate { get; set; }
        public DateOnly? BirthDate { get; set; }
        public string Description { get; set; }
        public string ID { get; set; }

        private string[] months = { "January", "February", "March", "April", "May", "June",
            "July", "August", "September", "October", "November", "December"
        };


        public Cat(string name, string breed, bool ismale, DateOnly arrivalDate, DateOnly? departureDate, DateOnly? birthDate, string description)
        {
            Name = name;
            Breed = breed;
            IsMale = ismale;
            ArrivalDate = arrivalDate;
            DepartureDate = departureDate;
            BirthDate = birthDate;
            Description = description;
            ID = GenerateID();
        }

        private string GenerateID()
        {
            string ID = "";
            for (int i = 0; i < 5; i++) ID += new Random().Next(0, 10);
            ID += months[ArrivalDate.Month - 1][0];
            ID += ArrivalDate.Year.ToString();
            for (int i = 0; i < 3; i++) ID += (char)('A' + new Random().Next(0, 26));
            return ID;
        }

        public void UpdateDepartureDate(DateOnly? departureDate)
        {
            DepartureDate = departureDate;
        }

        public override string ToString()
        {
            return Name;
        }
        public override bool Equals(object? obj)
        {
            if (obj is not null)
            {
                if (obj is Cat cat)
                {
                    return ID == cat.ID;
                }
                return false;
            }
            else
            {
                return false;
            }
        }
    }
}
