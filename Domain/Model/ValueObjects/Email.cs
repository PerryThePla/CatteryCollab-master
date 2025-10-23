using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.ValueObjects
{
    public record Email
    {
        public string Value {  get; private set; }
        public Email(string value)
        {
            if(string.IsNullOrEmpty(value)) throw new ArgumentNullException("value");
            if (!value.Contains("@")) throw new ArgumentNullException("value");
            if (value.Split("@").Length-1!=1) throw new ArgumentNullException("value");
            string[] email=value.Split(".");
            if (email[0].Length < 3 && email[1].Length < 2)
            {
                throw new ArgumentException("non gasa");
            }
            Value = value;
        }
    }
}
