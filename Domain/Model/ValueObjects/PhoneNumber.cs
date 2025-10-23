using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.ValueObjects
{
    public record PhoneNumber
    {
        public string Value { get; private set; }
        public PhoneNumber(string value)
        {
            if (string.IsNullOrEmpty(value)) throw new ArgumentNullException("value");
            if (value.Length < 9 || value.Length > 12) throw new ArgumentException("Phone number must be between 10 and 15 digits.");
            if (!value.All(char.IsDigit)) throw new ArgumentException("Phone number must contain only digits.");
            Value = value;
        }   
    }
}
