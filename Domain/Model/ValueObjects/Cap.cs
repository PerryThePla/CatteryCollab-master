using System;
using System.Linq;

namespace Domain.Model.ValueObjects
{
    public record Cap
    {
        public string Value { get; private set; }

        public Cap(string value)
        {
            if (value is null) throw new ArgumentNullException("Valore nullo");

            value = value.Trim();

            if (value.Length != 5)
                throw new ArgumentException("CAP must be exactly 5 digits long.");

            if (!value.All(char.IsDigit))
                throw new ArgumentException("CAP must contain only digits.");

            Value = value;
        }
    }
}
