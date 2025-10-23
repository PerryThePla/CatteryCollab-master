using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.ValueObjects
{
    public record FiscalCode
    {
        public string Value { get; private set; }

        public FiscalCode(string value)
        {
            value = value.Trim();
            if(!value.Substring(0,6).Any(char.IsLetter)) throw new ArgumentException("The first 6 characters must be letters.");
            if(!value.Substring(6,2).Any(char.IsDigit)) throw new ArgumentException("The first 2 characters must be numbers.");
            if(value.Length != 16) throw new ArgumentException("Fiscal code must be exactly 16 characters long.");
            Value = value;
        }
    }
}
