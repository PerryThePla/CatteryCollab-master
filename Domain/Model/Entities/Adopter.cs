using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model.ValueObjects;

namespace Domain.Model.Entities
{
    public class Adopter
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public Email Address { get; private set; }
        public PhoneNumber Phone { get; private set; }
        public FiscalCode FiscalCode { get; private set; }
        public string City { get; private set; }

        public Cap CityCap { get; private set; }
        public Adopter(string firstName, string lastName, Email address, PhoneNumber phone, FiscalCode fiscalCode, string city, Cap cityCap)
        {
            if (string.IsNullOrWhiteSpace(firstName)) throw new ArgumentNullException(nameof(firstName), "First name cannot be null or empty.");
            if (string.IsNullOrWhiteSpace(lastName)) throw new ArgumentNullException(nameof(lastName), "Last name cannot be null or empty.");
            if (string.IsNullOrWhiteSpace(city)) throw new ArgumentNullException(nameof(city), "City cannot be null or empty.");
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            Phone = phone;
            FiscalCode = fiscalCode;
            City = city;
            CityCap = cityCap;
        }
        public override bool Equals(object? obj)
        {
            if(obj is not null)
            {
                if (obj is Adopter adopter)
                {
                    return FirstName == adopter.FirstName &&
                           LastName == adopter.LastName;
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
